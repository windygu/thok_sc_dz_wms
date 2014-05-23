using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml;

namespace THOK.WES
{
    public class WaveData
    {
        private string url = null;

        #region XML
        /// <summary>
        /// 确认完成数据
        /// </summary>
        private const string returnMsg = @"<?xml version='1.0' encoding='GBK'?>
                                            <dataset>
	                                            <head>
	                                                <bb_result_info>{0}</bb_result_info>
		                                            <bb_type>{1}</bb_type>
		                                            <bb_order_id>{2}</bb_order_id>
		                                            <bb_pda_device_id>{3}</bb_pda_device_id >
		                                            <bb_confirmor_name>{4}</bb_confirmor_name>
		                                            <bb_confirm_date>{5}</bb_confirm_date>
		                                            <bb_corporation_id>{6}</bb_corporation_id >
		                                            <bb_corporation_name>{7}</bb_corporation_name >
	                                            </head>
                                                <datalist>
	                                                <data>
	                                                    <bb_detail_id>{8}</bb_detail_id>
		                                                <bb_operate_type>{9}</bb_operate_type>
		                                                <bb_cargo_no>{10}</bb_cargo_no>
		                                                <bb_pallet_no>{11}</bb_pallet_no>
		                                                <bb_pallet_move_flg>{12}</bb_pallet_move_flg>
		                                                <bb_brand_id>{13}</bb_brand_id>
                                                        <bb_brand_name>{14}</bb_brand_name>
		                                                <bb_handle_num>{15}</bb_handle_num>
		                                                <bb_inventory_num>{16}</bb_inventory_num>
                                                        <bb_unit>{17}</bb_unit>
		                                                <bb_operator_name>{18}</bb_operator_name>
                                                        <bb_operate_date>{19}</bb_operate_date>
	                                                </data>
                                                </datalist>
                                            </dataset>";

        /// <summary>散件烟组盘信息</summary>
        private const string wmsPalletInfoMsg = @"<?xml version='1.0' encoding='gb2312'?>
                                           <dataset>
                                              <head>
    	                                            <msg_id></msg_id>
   	                                                <state_code></state_code>
   	                                                <state_desc></state_desc>
    	                                            <ws_mark>WMSPalletInfo</ws_mark>
    	                                            <ws_method>PalletInfo</ws_method>
	                                                <ws_param>String</ws_param>
	                                                <client_ip>PCIP</client_ip>
    	                                            <curr_time>{0}</curr_time>
    	                                            <curr_user>{1}</curr_user>
                                              </head>
                                              <datalist>
                                                   <data>
                                                        <bb_type>I_PALLET_INFO_CREATE</bb_type>
                                                        <pallet_ID>{2}</pallet_ID>
                                                        <barcode_type>00</barcode_type>
                                                        <brand_info>{3}</brand_info>
                                                        <RFIDAntCode>{4}</RFIDAntCode>
                                                        <scan_time>{5}</scan_time>
                                                    </data>
                                              </datalist>
                                            </dataset>";


        /// <summary>货位与RFID绑定</summary>
        private const string cellRfidMsg = @"<?xml version='1.0' encoding='gb2312'?>
                                            <dataset>
	                                            <head>
	                                                <bb_cargo_no>{0}</bb_cargo_no>
		                                            <bb_rfid>{1}</bb_rfid>
	                                            </head>
                                            </dataset>";

        /// <summary>托盘与RFID绑定</summary>
        private const string palletRfidMsg = @"<?xml version='1.0' encoding='gb2312'?>
                                            <dataset>
	                                            <head>
	                                                <bb_pallet_no>{0}</bb_pallet_no>
		                                            <bb_rfid>{1}</bb_rfid>
	                                            </head>
                                            </dataset>";



        /// <summary>托盘RFID实时扫描</summary>
        private const string palletScanMsg = @"<?xml version='1.0' encoding='gb2312'?>
                                            <dataset>
	                                            <head>
	                                                <bb_pallet_no>{0}</bb_pallet_no>
		                                            <bb_operate_date>{1}</bb_operate_date>
	                                            </head>
                                            </dataset>";
        #endregion

        public List<string> ScanNewBill(string billString, string billType)
        {
            List<string> list = new List<string>();
            try
            {
                DzInspurWarehouseOperationService.WarehouseOperationServiceService ops = new DzInspurWarehouseOperationService.WarehouseOperationServiceService();
                string xml = ops.ScanNewBill();
                list = ParsDateBill(xml, billType, list);
            }
            catch (Exception e)
            {
                MessageBox.Show("从浪潮ScanNewBill下载数据出错，原因：" + e.Message);
            }
            return list;
        }

        public DataSet ImportData(string billString, string orderId)
        {
            DataSet ds = GenerateEmptyTables();
            try
            {
                DzInspurWarehouseOperationService.WarehouseOperationServiceService ops = new DzInspurWarehouseOperationService.WarehouseOperationServiceService();
                string xml = "";
                switch (billString)
                {
                    case "HITSHELF": //上架
                        xml = ops.HitShelf(orderId);
                        break;
                    case "STOCKTAKE": //盘点
                        xml = ops.StockTake(orderId);
                        break;
                    case "STOCKMOVE": //下架
                        xml = ops.StockOut(orderId);
                        break;
                    case "STOCKOUT": //移位
                        xml = ops.StockMove(orderId);
                        break;
                }
                ds = ParseData(xml, ds);
            }
            catch (Exception e)
            {
                MessageBox.Show("从浪潮下载数据出错，原因：" + e.Message);
            }
            return ds;
        }

        public void confirmData(DataTable dataTable, string billType)
        {
            string stateDesc = string.Empty;
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    DzInspurWarehouseOperationService.WarehouseOperationServiceService ops = new DzInspurWarehouseOperationService.WarehouseOperationServiceService();
                    url = string.Format(returnMsg,
                                        row["bb_result_info"],
                                        row["bb_type"],
                                        row["bb_order_id"],
                                        row["bb_pda_device_id"],
                                        row["bb_confirmor_name"],
                                        row["bb_confirm_date"],
                                        row["bb_corporation_id"],
                                        row["bb_corporation_name"],
                                        row["bb_detail_id"],
                                        row["bb_operate_type"],
                                        row["bb_cargo_no"],
                                        row["bb_pallet_no"],
                                        row["bb_pallet_move_flg"],
                                        row["bb_brand_id"],
                                        row["bb_brand_name"],
                                        row["bb_handle_num"],
                                        row["bb_inventory_num"],
                                        row["bb_unit"],
                                        row["bb_operator_name"],
                                        row["bb_operate_date"]);
                    string xml = "";
                    switch (billType)
                    {
                        case "1": //上架单确认
                            xml = ops.HitShelfConfirm(url);
                            break;
                        case "2": //盘点单确认
                            xml = ops.StockTakeConfirm(url);
                            break;
                        case "3": //移位单确认
                            xml = ops.StockMoveConfirm(url);
                            break;
                        case "5": //下架单确认
                            xml = ops.StockOutConfirm(url);
                            break;
                    }
                }
            }
        }

        private List<string> ParsDateBill(string xml, string billType, List<string> list)
        {
            XmlDocument doc = new XmlDocument();
            DataSet ds = GenerateEmptyTables();
            try
            {
                doc.LoadXml(xml);
                if (doc.GetElementsByTagName("bb_result_info")[0].InnerText == "1")
                {
                    foreach (XmlNode billdata in doc.GetElementsByTagName("data"))
                    {
                        if (billType == billdata.FirstChild.InnerText)
                        {
                            foreach (XmlNode orderlist in billdata.ChildNodes[1])
                            {
                                DataRow billTableRow = ds.Tables["BILLTABLE"].NewRow();
                                billTableRow["bb_order_id"] = orderlist.InnerText;
                                list.Add(orderlist.InnerText);
                                ds.Tables["BILLTABLE"].Rows.Add(billTableRow);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("从浪潮下载数据出错，原因：" + e.Message);
            }
            return list;
        }

        private DataSet ParseData(string xml, DataSet ds)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
                foreach (XmlNode billNode in doc.GetElementsByTagName("head"))
                {
                    foreach (XmlNode detailNode in doc.GetElementsByTagName("data"))
                    {
                        DataRow detailRow = ds.Tables["DETAIL"].NewRow();
                        //主表信息
                        detailRow["bb_type"] = billNode.SelectSingleNode("bb_type").InnerText;
                        detailRow["bb_order_id"] = billNode.SelectSingleNode("bb_order_id").InnerText;
                        detailRow["bb_corporation_id"] = billNode.SelectSingleNode("bb_corporation_id").InnerText;
                        detailRow["bb_corporation_name"] = billNode.SelectSingleNode("bb_corporation_name").InnerText;

                        //细表信息
                        detailRow["bb_detail_id"] = detailNode.SelectSingleNode("bb_detail_id").InnerText;
                        detailRow["bb_operate_type"] = detailNode.SelectSingleNode("bb_operate_type").InnerText == "A" ? "盘点" : detailNode.SelectSingleNode("bb_operate_type").InnerText == "B" ? "移出" : detailNode.SelectSingleNode("bb_operate_type").InnerText == "C" ? "移入" : "异常";
                        detailRow["bb_pallet_move_flg"] = detailNode.SelectSingleNode("bb_pallet_move_flg").InnerText;
                        detailRow["bb_cargo_no"] = detailNode.SelectSingleNode("bb_cargo_no").InnerText;
                        if (billNode.SelectSingleNode("bb_type").InnerText == "STOCKTAKE")
                            detailRow["bb_shelf_no"] = detailNode.SelectSingleNode("bb_shelf_no").InnerText;
                        detailRow["bb_pallet_no"] = detailNode.SelectSingleNode("bb_pallet_no").InnerText;
                        detailRow["bb_brand_id"] = detailNode.SelectSingleNode("bb_brand_id").InnerText;
                        detailRow["bb_brand_name"] = detailNode.SelectSingleNode("bb_brand_name").InnerText;
                        detailRow["bb_handle_num"] = Convert.ToDouble(detailNode.SelectSingleNode("bb_handle_num").InnerText);
                        detailRow["bb_inventory_num"] = Convert.ToDouble(detailNode.SelectSingleNode("bb_inventory_num").InnerText);
                        detailRow["bb_unit"] = detailNode.SelectSingleNode("bb_unit").InnerText;
                        detailRow["bb_cell_rfid"] = detailNode.SelectSingleNode("bb_cell_rfid").InnerText;
                        detailRow["bb_stock_rfid"] = detailNode.SelectSingleNode("bb_stock_rfid").InnerText;
                        detailRow["bb_unit_name"] = detailNode.SelectSingleNode("bb_unit_name").InnerText;
                        detailRow["bb_area_type"] = detailNode.SelectSingleNode("bb_area_type").InnerText;
                        detailRow["bb_data_time"] = DateTime.Now;

                        ds.Tables["DETAIL"].Rows.Add(detailRow);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("从浪潮下载数据出错，原因：" + e.Message);
            }
            return ds;
        }

        private string ParseMsg(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.GetElementsByTagName("state_desc")[0].InnerText;
        }

        private DataSet GenerateEmptyTables()
        {
            DataSet ds = new DataSet();

            DataTable billTable = ds.Tables.Add("BILLTABLE");
            billTable.Columns.Add("bb_billtype");
            billTable.Columns.Add("bb_order_id");

            DataTable detail = ds.Tables.Add("DETAIL");

            detail.Columns.Add("bb_type");
            detail.Columns.Add("bb_order_id");
            detail.Columns.Add("bb_corporation_id");
            detail.Columns.Add("bb_corporation_name");
            detail.Columns.Add("bb_detail_id");

            detail.Columns.Add("bb_operate_type");
            detail.Columns.Add("bb_pallet_move_flg");
            detail.Columns.Add("bb_cargo_no");
            detail.Columns.Add("bb_shelf_no");
            detail.Columns.Add("bb_pallet_no");
            
            detail.Columns.Add("bb_brand_id");
            detail.Columns.Add("bb_brand_name");
            detail.Columns.Add("bb_handle_num");
            detail.Columns.Add("bb_inventory_num");
            detail.Columns.Add("bb_unit");
            
            detail.Columns.Add("bb_cell_rfid");
            detail.Columns.Add("bb_stock_rfid");
            detail.Columns.Add("bb_unit_name");
            detail.Columns.Add("bb_area_type");
            detail.Columns.Add("bb_data_time");

            return ds;
        }
    }
}
