using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOK.WES.Util;

namespace THOK.WES.View
{
    public partial class DetailForm : Form
    {
        private DataTable detailTable = null;
        public int Index;
        private DataRow detailRow = null;
        private string billType = "";
        private string detailID = "";
        private string billID = "";
        private WaveData wave = new WaveData();
        protected string ReturnString = "";

        public DetailForm(string billType, string detailID, string billID, DataTable table)
        {
            InitializeComponent();

            this.billType = billType;
            this.detailID = detailID;
            this.billID = billID;
            detailTable = table;
            if (this.billType == "5")
            {
                this.button1.Visible = true;
                this.button2.Visible = true;
                this.button3.Visible = true;
                this.button4.Visible = true;
            }
            else
            {
                this.button1.Visible = false;
                this.button2.Visible = false;
                this.button3.Visible = false;
                this.button4.Visible = false;
            }
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            switch (billType)
            {
                case "1":
                    this.label2.Text = "入库单据明细";
                    break;
                case "2":
                    this.label2.Text = "出库单据明细";
                    break;
                case "3":
                    this.label2.Text = "移库单据明细";
                    break;
                case "4":
                    this.label2.Text = "盘点单据明细";
                    break;
            }
            detailRow = detailTable.Select(string.Format("DetailID = {0}", detailID))[0];
            this.lbID.Text = detailRow["DetailID"].ToString();
            this.lbStorageID.Text = detailRow["operateStorageName"].ToString();
            this.lbTobacconame.Text = detailRow["operateProductName"].ToString();
            this.lbPiece.Text = detailRow["operatePieceQuantity"].ToString();
            this.lbItem.Text = detailRow["operateBarQuantity"].ToString();
            this.lbState.Text = detailRow["StatusName"].ToString();
            this.lbType.Text = detailRow["operateName"].ToString();
            this.lbBillid.Text = billID;

            if (detailRow["targetStorageName"].ToString() != "")
            {
                this.lbType.Text = this.lbType.Text + "->" + detailRow["targetStorageName"].ToString();
            }
            WaitCursor.Restore();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GenerateEmptyTables();
                DataRow detailRows = ds.Tables["DETAIL"].NewRow();
                detailRow = detailTable.Select(string.Format("DetailID = {0}", detailID))[0];
                detailRows["bb_detail_id"] = this.lbID.Text.ToString();
                detailRows["bb_operate_type"] = detailRow["bb_operate_type"].ToString();
                detailRows["bb_pallet_move_flg"] = detailRow["bb_pallet_move_flg"].ToString();
                detailRows["bb_cargo_no"] = detailRow["bb_cargo_no"].ToString();
                detailRows["bb_pallet_no"] = detailRow["bb_pallet_no"].ToString();
                detailRows["bb_brand_id"] = detailRow["bb_brand_id"].ToString();
                detailRows["bb_brand_name"] = detailRow["bb_brand_name"].ToString();
                detailRows["bb_handle_num"] = Convert.ToDecimal(detailRow["bb_handle_num"].ToString());
                detailRows["bb_inventory_num"] = Convert.ToDecimal(detailRow["bb_inventory_num"].ToString());
                detailRows["bb_unit"] = detailRow["bb_unit"].ToString();
                detailRows["bb_operator_name"] = "PDA";
                detailRows["bb_operate_date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                ds.Tables["DETAIL"].Rows.Add(detailRows);
                wave.confirmData(ds.Tables["DETAIL"], ReturnString);
                MessageBox.Show("确认成功!");
                BaseTaskForm baseTaskForm = new BaseTaskForm(this.billType, billID);
                if (this.Index > 0)
                {
                    baseTaskForm.index = this.Index;
                }
                baseTaskForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                WaitCursor.Restore();
                MessageBox.Show(ex.Message);
                this.Close();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WaitCursor.Set();
            try
            {
                BaseTaskForm baseTaskForm = new BaseTaskForm(this.billType, billID);
                baseTaskForm.index = this.Index;
                baseTaskForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                WaitCursor.Restore();
                MessageBox.Show("读取数据失败!" + ex.Message);
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

    }
}