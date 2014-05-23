using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOK.WES.View;
using THOK.WES;

namespace THOK.PDA.View
{
    public partial class MasterForm : Form
    {
        List<string> listBill = null;//读取订单号
        WaveData waveData = new WaveData();

        string billType = null;
        string billString = null;
        string billNo = null;

        public MasterForm(string billType0,string billString0)
        {
            InitializeComponent();
            billType = billType0;
            billString = billString0;

            ReadMasterBill(billType);
        }

        void ReadMasterBill(string billType)
        {
            listBill = waveData.ScanNewBill("ScanNewBill", billType);
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
            RefreshData();
        }

        void RefreshData()
        {
            if (listBill == null)
            {
                dataGrid1.DataSource = null;
                return;
            }
            DataTable billTable = waveData.ImportData(billString, billNo).Tables["DETAIL"];
           
            if (billTable != null && billTable.Rows.Count != 0)
            {
                dataGrid1.DataSource = billTable;
            }
            else
            {
                dataGrid1.DataSource = null;
                MessageBox.Show("当前没有数据！");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dataGrid1.DataSource != null)
            {
                string bb_area_type = dataGrid1[dataGrid1.CurrentRowIndex, 18].ToString();
                //0:主储存区,1:零件烟区,2:零条烟区
                if (bb_area_type == "0")
                {
                    DataSet ds = GenerateEmptyTables();

                    DataRow detailRow = ds.Tables["DETAIL"].NewRow();
                    //主表信息
                    detailRow["bb_result_info"] = "0";
                    detailRow["bb_type"] = billString;
                    detailRow["bb_order_id"] = dataGrid1[dataGrid1.CurrentRowIndex, 2].ToString();
                    detailRow["bb_pda_device_id"] = "PDA";
                    detailRow["bb_confirmor_name"] = "PDA";
                    detailRow["bb_confirm_date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    detailRow["bb_corporation_id"] = dataGrid1[dataGrid1.CurrentRowIndex, 6].ToString();
                    detailRow["bb_corporation_name"] = dataGrid1[dataGrid1.CurrentRowIndex, 7].ToString();
                    //细表信息
                    detailRow["bb_detail_id"] = dataGrid1[dataGrid1.CurrentRowIndex, 8].ToString();
                    detailRow["bb_operate_type"] = dataGrid1[dataGrid1.CurrentRowIndex,9].ToString();
                    detailRow["bb_pallet_move_flg"] = dataGrid1[dataGrid1.CurrentRowIndex, 10].ToString();
                    detailRow["bb_cargo_no"] = dataGrid1[dataGrid1.CurrentRowIndex, 11].ToString();
                    if (billType == "1")
                    {
                        detailRow["bb_pallet_no"] = "getRFID()";//此标签改为RFID传入值
                    }
                    else
                    {
                        detailRow["bb_pallet_no"] = dataGrid1[dataGrid1.CurrentRowIndex, 12].ToString();
                    }
                    detailRow["bb_brand_id"] = dataGrid1[dataGrid1.CurrentRowIndex, 13].ToString();
                    detailRow["bb_brand_name"] = dataGrid1[dataGrid1.CurrentRowIndex, 14].ToString();
                    detailRow["bb_handle_num"] = Convert.ToDecimal(dataGrid1[dataGrid1.CurrentRowIndex, 15].ToString());
                    detailRow["bb_inventory_num"] = Convert.ToDecimal(dataGrid1[dataGrid1.CurrentRowIndex, 16].ToString());
                    detailRow["bb_unit"] = dataGrid1[dataGrid1.CurrentRowIndex, 17].ToString();
                    detailRow["bb_operator_name"] = "PDA";
                    detailRow["bb_operate_date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    ConfirmDialog confirmForm = new ConfirmDialog(billType,
                        dataGrid1[dataGrid1.CurrentRowIndex, 11].ToString(),
                        dataGrid1[dataGrid1.CurrentRowIndex, 11].ToString(),
                        dataGrid1[dataGrid1.CurrentRowIndex, 9].ToString(),
                        dataGrid1[dataGrid1.CurrentRowIndex, 14].ToString());
                    confirmForm.Piece = Convert.ToInt32(dataGrid1[dataGrid1.CurrentRowIndex, 15].ToString());
                    confirmForm.Bar = 0;
                    if (confirmForm.ShowDialog() == DialogResult.OK)
                    {
                        if (billType == "2")
                        {
                            detailRow["bb_inventory_num"] = confirmForm.Piece;
                        }
                        ds.Tables["DETAIL"].Rows.Add(detailRow);
                        try
                        {
                            if (billType == "1")
                            {
                                waveData.confirmData(ds.Tables["DETAIL"], billType);
                            }
                            else
                            {
                                if (detailRow["bb_pallet_no"].ToString() == "" || detailRow["bb_pallet_no"].ToString() == null)
                                {
                                    try
                                    {
                                        waveData.confirmData(ds.Tables["DETAIL"], billType);
                                        MessageBox.Show("操作完成");
                                        this.RefreshData();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("操作失败！Catch：" + ex.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("RFID不匹配！请选择正确的货位，重新出库！");
                                    return;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("执行浪潮confirmData失败！原因：" + ex.Message);
                            return;
                        }
                    }
                }
            }
        }

        DataSet GenerateEmptyTables()
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