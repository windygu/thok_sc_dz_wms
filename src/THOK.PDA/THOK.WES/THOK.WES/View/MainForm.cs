using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOK.WES;
using THOK.WES.View;

namespace THOK.PDA.View
{
    public partial class MainForm : Form
    {
        List<string> listBill = null;//读取订单号
        string billNo = string.Empty;//选择主单
        WaveData wave = new WaveData();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            this.ReadMasterBill("1", "HITSHELF"); //上架
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            //this.ReadMasterBill("5", "STOCKMOVE");//下架

            listBill = wave.ScanNewBill("ScanNewBill", "5");
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
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.ReadMasterBill("2", "STOCKTAKE");//盘点
        }
        private void btnMove_Click(object sender, EventArgs e)
        {
            this.ReadMasterBill("3", "STOCKOUT"); //移位
        }
        private void ReadMasterBill(string billType, string billString)
        {
            MasterForm masterForm = new MasterForm(billType, billString);
            masterForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}