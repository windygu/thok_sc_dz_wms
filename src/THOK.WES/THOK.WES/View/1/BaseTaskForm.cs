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
        /// 1:上架清单,2:盘点清单,3:移位清单,4:并盘清单,5:下架清单
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

        /// <summary>
        /// Real: 实时出库；NoReal: 非实时出库；
        /// </summary>
        private string OperateType = "";

       
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
                //dgvMain.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvMain.Columns[0].Width = 150;
                dgvMain.Columns[1].Width = 150;
                dgvMain.Columns[2].Width = 60;
                dgvMain.Columns[3].Width = 120;
                dgvMain.Columns[4].Width = 100;
                dgvMain.Columns[5].Width = 200;
                dgvMain.Columns[6].Width = 60;
                dgvMain.Columns[7].Width = 60;
                this.dgvMain.ColumnHeadersHeight = 30;
                this.dgvMain.RowTemplate.Height = 40;
                this.dgvMain.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 10);
                this.dgvMain.DefaultCellStyle.Font = new Font("宋体", 14);                
                UseTag = "1";
            }
        }

        //查询
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.VisibleWailt(false);
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
                this.VisibleWailt(true);
                RefreshData();
            }
            catch (Exception ex)
            {
                THOKUtil.ShowError("读取数据失败，原因：" + ex.Message);
                this.VisibleWailt(false);
                return;
            }
        }

        //确认
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string getRFID = "";

            if (dgvMain.SelectedRows.Count != 0)
            {
                string bb_area_type = dgvMain.Rows[0].Cells["bb_area_type"].Value.ToString();

                if (bb_area_type == "0")                    //0:主储存区,1:零件烟区,2:零条烟区
                {
                    getRFID = ScanningRFID(bb_area_type);   //读取RFID

                    if (getRFID == null)
                    {
                        THOKUtil.ShowError("操作失败！");
                        this.VisibleWailt(false);
                        return;
                    }
                }
                else if (bb_area_type == "1")
                {
                    getRFID = "";
                }
                else
                {
                    THOKUtil.ShowError("该订单不是[主储区]或[零条烟区]");
                    this.VisibleWailt(false);
                    return;
                }
                try
                {
                    this.VisibleWailt(true);

                    DataSet ds = GenerateEmptyTables();
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
                        if (BillTypes == "1")
                        {
                            detailRow["bb_pallet_no"] = getRFID;//此标签改为RFID传入值
                        }
                        else
                        {
                            detailRow["bb_pallet_no"] = row.Cells["bb_pallet_no"].Value.ToString();
                        }
                        detailRow["bb_brand_id"] = row.Cells["bb_brand_id"].Value.ToString();
                        detailRow["bb_brand_name"] = row.Cells["bb_brand_name"].Value.ToString();
                        detailRow["bb_handle_num"] = Convert.ToDecimal(row.Cells["bb_handle_num"].Value.ToString());
                        detailRow["bb_inventory_num"] = Convert.ToDecimal(row.Cells["bb_inventory_num"].Value.ToString());
                        detailRow["bb_unit"] = row.Cells["bb_unit"].Value.ToString();
                        detailRow["bb_operator_name"] = Environment.UserName;
                        detailRow["bb_operate_date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        ConfirmDialog confirmForm = new ConfirmDialog(BillTypes, row.Cells["bb_cargo_no"].Value.ToString(), row.Cells["bb_cargo_no"].Value.ToString(), row.Cells["bb_operate_type"].Value.ToString(), row.Cells["bb_brand_name"].Value.ToString());
                        confirmForm.Piece = Convert.ToInt32(row.Cells["bb_handle_num"].Value.ToString());
                        confirmForm.Bar = 0;
                        if (confirmForm.ShowDialog() == DialogResult.OK)
                        {
                            if (BillTypes == "2")
                            {
                                detailRow["bb_inventory_num"] = confirmForm.Piece;
                            }

                            ds.Tables["DETAIL"].Rows.Add(detailRow);

                            try
                            {
                                if (BillTypes == "1")
                                {
                                    wave.confirmData(ds.Tables["DETAIL"], BillTypes);
                                }
                                else
                                {
                                    if (getRFID == detailRow["bb_pallet_no"].ToString() || detailRow["bb_pallet_no"].ToString() == "" || detailRow["bb_pallet_no"].ToString() == null)
                                    {
                                        try
                                        {
                                            wave.confirmData(ds.Tables["DETAIL"], BillTypes);
                                            THOKUtil.ShowInfo("操作完成");
                                            this.RefreshData();
                                        }
                                        catch (Exception ex)
                                        {
                                            THOKUtil.ShowError("操作失败！Catch：" + ex.Message);
                                            this.VisibleWailt(false);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        THOKUtil.ShowError("RFID不匹配！请选择正确的货位，重新出库！");
                                        this.VisibleWailt(false);
                                        return;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                THOKUtil.ShowError("执行浪潮confirmData失败！原因：" + ex.Message);
                                this.VisibleWailt(false);
                                return;
                            }
                        }
                        else
                        {
                            this.VisibleWailt(false);
                            return;
                        }
                    }
                    this.VisibleWailt(false);
                }
                catch (Exception ex)
                {
                    THOKUtil.ShowError("执行失败，原因：" + ex.Message);
                    this.VisibleWailt(false);
                    return;
                }
            }
            else
            {
                THOKUtil.ShowInfo("当前操作失败！原因：没有选择数据，请选择！");
                this.VisibleWailt(false);
                return;
            }
        }

        //读取RFID
        private string ScanningRFID(string bb_area_type)
        {
            List<string> listRfid = new List<string>();

            if (bb_area_type == "0")
            {
                this.VisibleWailt(true);
                try
                {
                    listRfid = rRfid.LoadTagList(port, 115200, out errInfo);
                }
                catch (Exception ex)
                {
                    this.VisibleWailt(false);
                    THOKUtil.ShowError("扫描RFID失败，请检查串口是否匹配！原因：" + ex.Message + "," + RfidCode);
                    return null;
                }

                Application.DoEvents();

                if (listRfid != null)
                {
                    if (listRfid.Count > 0)
                    {
                        //MessageBox.Show("[" + RfidCode + "]");
                        RfidCode = listRfid[0].ToString();
                        return RfidCode;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
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

            this.VisibleWailt(true);
            DataTable billTable = wave.ImportData(BillString, billNo).Tables["DETAIL"];
            InTask = true;
            if (billTable != null && billTable.Rows.Count != 0)
            {
                dgvMain.DataSource = billTable;
                InTask = false;
                this.VisibleWailt(false);

                //double sum = 0;
                //foreach (DataRow row in billTable.Rows)
                //{
                //    sum += double.Parse(row["bb_handle_num"].ToString());
                //}
                //string billType = "";
                //switch (BillTypes)
                //{
                //    case "1": billType = "上架清单"; break;
                //    case "2": billType = "盘点清单"; break;
                //    case "3": billType = "移位清单"; break;
                //    case "4": billType = "下架清单"; break;
                //    default: billType = "异常单据"; break;
                //}
                //THOKUtil.ShowInfo("当前【" + billType + "】订单总数量：" + sum);
            }
            else
            {
                dgvMain.DataSource = null;
                InTask = false;
                this.VisibleWailt(false);
                THOKUtil.ShowError("当前没有数据！");
            }
        }
        private string getBrandInfo()
        {
            List<string> listRfid = new List<string>();
            this.VisibleWailt(true);
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

        public void VisibleWailt(bool b)
        {
            if (b == true)
            {
                this.plWailt.Visible = true;
                this.plWailt.Left = (this.dgvMain.Width - this.plWailt.Width) / 2;
                this.plWailt.Top = (this.dgvMain.Height - this.plWailt.Height) / 2;
            }
            else
            {
                this.plWailt.Visible = false;
            }
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
        private void btnOpType_Click(object sender, EventArgs e)
        {
            if (btnOpType.Text != "正常")
            {
                btnOpType.Text = "正常";
                OperateType = "NoReal";

                dgvMain.DataSource = wave.ImportData(BillString, billNo).Tables["DETAIL"];
            }
            else
            {
                btnOpType.Text = "实时";
                OperateType = "Real";

                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += new EventHandler(CyleTimer_Tick);
                timer.Start();
            }
        }

        /// <summary>获得出库剩余的烟量</summary>
        private DataTable GetStockOut()
        { 
            DataTable dt = new DataTable();
            string sql = @"SELECT CIGARETTECODE,COUNT(CIGARETTECODE) FROM AS_STOCK_OUT WHERE STATE=0
                           GROUP BY CIGARETTECODE HAVING count(*)<10";
            dt = SQLHelper.GetDataTable(sql);
            return dt;
        }
        /// <summary>处理字符串，取得字符，传来的String</summary>
        private string MakeString(DataTable dt, string field)
        {
            string list = "''";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list += ",'" + row["" + field + ""].ToString() + "'";
                }
            }
            return list;
        }
        private void Real()
        {
            dgvMain.DataSource = null;

            DataTable dt = null;
            DataTable dtLc = this.GetTest();// wave.ImportData(BillString, billNo).Tables["DETAIL"];
            DataTable dtStockOut = this.GetStockOut();
            if (dtStockOut.Rows.Count > 0 && dtLc.Rows.Count > 0)
            {
                string codeList = this.MakeString(dtStockOut, "CIGARETTECODE");
                dt = new DataTable();
                dt.Columns.Add("CIGARETTECODE", typeof(string));
                dt.Columns.Add("QUANTITY", typeof(Int32));

                foreach (DataRow row in dtStockOut.Rows)
                {
                    DataRow[] row_2 = dtLc.Select("CIGARETTECODE IN (" + row["CIGARETTECODE"] + ")");
                    if (row_2.Length > 0)
                    {
                        dt.Rows.Add(row_2[0].ItemArray);
                    }
                }
                dgvMain.DataSource = dt;
            }
        }
        private void CyleTimer_Tick(object sender, EventArgs e)
        {
            if (OperateType == "Real")
            {
                if (BillTypes == "4")
                {
                    this.Real();
                    this.btnOpType.Text = DateTime.Now.ToString("mm:ss");
                }
            }
        }
        private DataTable GetTest()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CIGARETTECODE", typeof(string));
            dt.Columns.Add("QUANTITY", typeof(Int32));

            DataRow dr1 = dt.NewRow();
            dr1["CIGARETTECODE"] = "5301043";
            dr1["QUANTITY"] = "10";
            DataRow dr2 = dt.NewRow();
            dr2["CIGARETTECODE"] = "5301043";
            dr2["QUANTITY"] = "20";
            DataRow dr3 = dt.NewRow();
            dr3["CIGARETTECODE"] = "3101009";
            dr3["QUANTITY"] = "30";
            DataRow dr4 = dt.NewRow();
            dr4["CIGARETTECODE"] = "3101009";
            dr4["QUANTITY"] = "40";

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dt.Rows.Add(dr4);

            return dt;
        }
    }
}

