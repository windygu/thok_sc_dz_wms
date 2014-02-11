using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOK.WES.Dal;
using THOK.WES;
using System.Collections;
using System.Threading;

namespace THOK.WES.View
{
    public partial class BaseTaskForm : THOK.AF.View.ToolbarForm
    {
        public delegate string TimerStateInMainThread();
        private ConfigUtil configUtil = new ConfigUtil();      
        private string url = @"http://59.61.87.212:8090/Task";
       
        /// <summary>
        /// 1：入库单；2：盘点单；3：移库单；4：出库单
        /// </summary>
        protected string BillTypes = "";
        protected string BillString = "";
        protected string ReturnString = "";
        private ReadRfid rRfid = new ReadRfid();
        //选择的主单；
        string billNo = string.Empty;
        
     
        /// <summary>
        /// 使用电子标签 = 0：不使用；1：使用；
        /// </summary>
        private string UseTag = "";

        /// <summary>
        /// 使用Rfid  = 0：不使用；1：手动使用；2：自动使用；
        /// </summary>
        private string UseRfid = "";

        /// <summary>
        /// 读取的托盘RFID号；
        /// </summary>
        private string RfidCode = "";

        /// <summary>
        /// 错误消息；
        /// </summary>
        private string errInfo;

        /// <summary>
        /// 串口；
        /// </summary>
        private string port;

       
        private WaveData wave = new WaveData();
        List<string> listBill = null;//读取订单号
        public BaseTaskForm()
        {
            InitializeComponent();
            pnlData.Visible = true;
            pnlData.Dock = DockStyle.Fill;

            pnlChart.Visible = false;
            pnlChart.Dock = DockStyle.Fill;
                 
            url = configUtil.GetConfig("URL")["URL"];          
            UseRfid = configUtil.GetConfig("RFID")["USEDRFID"];
            port = configUtil.GetConfig("RFID")["PORT"];
            if (configUtil.GetConfig("DeviceType")["Device"] == "0")
            {
                this.dgvMain.ColumnHeadersHeight = 40;
                this.dgvMain.RowTemplate.Height = 40;
                this.dgvMain.DefaultCellStyle.Font = new Font("宋体", 16);
                this.dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 13);
            
                UseTag = "0";
            }
            else if (configUtil.GetConfig("DeviceType")["Device"] == "1")
            {
                this.dgvMain.ColumnHeadersHeight = 40;
                this.dgvMain.RowTemplate.Height = 40;
                this.dgvMain.DefaultCellStyle.Font = new Font("宋体", 16);
                this.dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 13);
                //this.btnBatConfirm.Visible = false;
                UseTag = "1";
            }
            else
            {
                this.dgvMain.ColumnHeadersHeight = 22;
                this.dgvMain.RowTemplate.Height = 22;
                this.dgvMain.DefaultCellStyle.Font = new Font("宋体", 10);
                this.dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 10);
                UseTag = "1";
            } 
        }

        //查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                btnScanning_Click(null, null);
                ClosePlWailt();
                listBill = wave.ScanNewBill("ScanNewBill", BillTypes);
                switch (listBill.Count)
                {
                    case 0:
                        billNo = "";
                        break;
                    case 1:
                        billNo = listBill[0];
                        break;
                    default:
                        SelectDialog selectDialog = new SelectDialog(listBill);
                        if (selectDialog.ShowDialog() == DialogResult.OK)
                        {
                            billNo = selectDialog.SelectedBillID;
                        }
                        break;
                }
                DisplayPlWailt();
                RefreshData();
            }
            catch (Exception ex)
            {
                THOKUtil.ShowError("读取数据失败，原因：" + ex.Message);
                ClosePlWailt();
            }
        }

        //确认
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvMain.SelectedRows.Count != 0)
            {
                try
                {
                    DataSet ds = GenerateEmptyTables();
                    DisplayPlWailt();
                    foreach (DataGridViewRow row in dgvMain.SelectedRows)
                    {
                        DataRow detailRow = ds.Tables["DETAIL"].NewRow();
                        //主表信息

                        detailRow["bb_result_info"] = "0";
                        detailRow["bb_type"] = BillString;
                        detailRow["bb_order_id"] = row.Cells["bb_order_id"].Value.ToString();
                        detailRow["bb_pda_device_id"] = Environment.MachineName;
                        detailRow["bb_confirmor_name"] = Environment.MachineName;
                        detailRow["bb_confirm_date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        detailRow["bb_corporation_id"] = row.Cells["bb_corporation_id"].Value.ToString();
                        detailRow["bb_corporation_name"] = row.Cells["bb_corporation_name"].Value.ToString();

                        //细表信息
                        detailRow["bb_detail_id"] = row.Cells["bb_detail_id"].Value.ToString();
                        detailRow["bb_operate_type"] = row.Cells["bb_operate_type"].Value.ToString();
                        detailRow["bb_pallet_move_flg"] = row.Cells["bb_pallet_move_flg"].Value.ToString();
                        detailRow["bb_cargo_no"] = row.Cells["bb_cargo_no"].Value.ToString();
                        detailRow["bb_pallet_no"] = row.Cells["bb_pallet_no"].Value.ToString();
                        detailRow["bb_brand_id"] = row.Cells["bb_brand_id"].Value.ToString();
                        detailRow["bb_brand_name"] = row.Cells["bb_brand_name"].Value.ToString();
                        detailRow["bb_handle_num"] = Convert.ToDecimal(row.Cells["bb_handle_num"].Value.ToString());
                        detailRow["bb_inventory_num"] = Convert.ToDecimal(row.Cells["bb_inventory_num"].Value.ToString());
                        detailRow["bb_unit"] = row.Cells["bb_unit"].Value.ToString();
                        detailRow["bb_operator_name"] = Environment.UserName;
                        detailRow["bb_operate_date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        ConfirmDialog confirmForm = new ConfirmDialog(BillTypes, row.Cells["bb_cargo_no"].Value.ToString(), row.Cells["bb_cargo_no"].Value.ToString(), row.Cells["bb_operate_type"].Value.ToString(), row.Cells["bb_brand_name"].Value.ToString());
                        confirmForm.Piece = Convert.ToInt32(row.Cells["bb_handle_num"].Value.ToString());
                        confirmForm.Item = 0;
                        if (confirmForm.ShowDialog() == DialogResult.OK)
                        {
                            if (BillTypes == "2")
                            {
                                //detailRow["bb_handle_num"] = confirmForm.Piece;
                                detailRow["bb_inventory_num"] = confirmForm.Piece;
                            }
                        }
                        ds.Tables["DETAIL"].Rows.Add(detailRow);
                    }

                    THOKUtil.ShowInfo(wave.confirmData(ds.Tables["DETAIL"], ReturnString));
                    ClosePlWailt();
                }
                catch (Exception ex)
                {
                    THOKUtil.ShowError("执行失败，原因：" + ex.Message);
                }
            }
            else
                THOKUtil.ShowInfo("当前操作失败！原因：没有选择数据，请选择！");

            RefreshData();
        }

        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        //刷新数据
        private void RefreshData()
        {
            if (listBill == null)
            {
                dgvMain.DataSource = null;
                return;
            }
            sslBillID.Text = "单据号：" + billNo + "                              ";
            sslOperator.Text = "操作员：" + Environment.MachineName;

            DisplayPlWailt();
            DataTable billTable = wave.ImportData(BillString, billNo).Tables["DETAIL"];
            InTask = true;
            if (billTable != null && billTable.Rows.Count != 0)
            {
                dgvMain.DataSource = billTable;

                InTask = false;
            }
            else
            {
                dgvMain.DataSource = null;
            }
            ClosePlWailt();
        }

        //读取RFID
        private void getRfidCode()
        {
            List<string> listRfid = new List<string>();
            try
            {
                DisplayPlWailt();
                listRfid = rRfid.LoadTagList(port, 115200, out errInfo);
                Application.DoEvents();
                if(listRfid.Count>0)
                    RfidCode = listRfid[0].ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message + "," + RfidCode);
            }
        }

        private string getBrandInfo()
        {
            List<string> listRfid = new List<string>();
            DisplayPlWailt();
            string brandInfo = string.Empty;
            try
            {
                listRfid = rRfid.LoadTagList(port, 115200, out errInfo);
                brandInfo = listRfid[0].ToString();
                Application.DoEvents();
                QuantityDialog quantityForm = new QuantityDialog();
                if (quantityForm.ShowDialog() == DialogResult.OK)
                {
                    if (BillTypes == "1")
                    {
                        brandInfo = quantityForm.Piece + ";" + brandInfo;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("读取件烟码出错了！" + e.Message);
            }

            return brandInfo;
        }

        public void DisplayPlWailt()
        {
            this.plWailt.Visible = true;
            this.plWailt.Left = (this.dgvMain.Width - this.plWailt.Width) / 2;
            this.plWailt.Top = (this.dgvMain.Height - this.plWailt.Height) / 2;
        }

        public void ClosePlWailt()
        {
            this.plWailt.Visible = false;
        }

        private DataSet GenerateEmptyTables()
        {
            DataSet ds = new DataSet();
            DataTable detail = ds.Tables.Add("DETAIL");

            detail.Columns.Add("bb_result_info");
            detail.Columns.Add("bb_type");
            detail.Columns.Add("bb_order_id");
            detail.Columns.Add("bb_pda_device_id");
            detail.Columns.Add("bb_confirmor_name");
            detail.Columns.Add("bb_confirm_date");
            detail.Columns.Add("bb_corporation_id");
            detail.Columns.Add("bb_corporation_name");

            detail.Columns.Add("bb_detail_id");
            detail.Columns.Add("bb_operate_type");
            detail.Columns.Add("bb_pallet_move_flg");
            detail.Columns.Add("bb_cargo_no");
            detail.Columns.Add("bb_pallet_no");
            detail.Columns.Add("bb_brand_id");
            detail.Columns.Add("bb_brand_name");
            detail.Columns.Add("bb_handle_num");
            detail.Columns.Add("bb_inventory_num");
            detail.Columns.Add("bb_unit");
            detail.Columns.Add("bb_operator_name");
            detail.Columns.Add("bb_operate_date");

            return ds;
        }

        private void btnScanning_Click(object sender, EventArgs e)
        {
            try
            {
                if (BillTypes == "1")
                {
                    this.getRfidCode();
                    string brandInfo = "111";// getBrandInfo();//卷烟码段
                    if (brandInfo != "" && RfidCode != "")
                    {
                        wave.wmsPalletInfo(RfidCode, "", "读写天线编号", Environment.UserName);
                    }
                    else
                    {
                        THOKUtil.ShowError("扫描RFID读取失败！请从新扫描！");
                        ClosePlWailt();
                    }
                }
            }
            catch (Exception ex)
            {
                ClosePlWailt();
                THOKUtil.ShowError("扫描读取托盘信息出错，原因：" + ex.Message);
            }
        }

    }
}

