using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using THOK.WES.Util;

namespace THOK.PDA.View
{
    public partial class MainForm : Form
    {     
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            this.ReadMasterBill("1");
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            this.ReadMasterBill("2");
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.ReadMasterBill("3");
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            this.ReadMasterBill("4");
        }

        private void ReadMasterBill(string billType)
        {
            try
            {
                //WaitCursor.Set();
                MasterForm masterForm = new MasterForm(billType);
                masterForm.Show();
                this.Visible = false;
            }
            catch (Exception ex)
            {
                WaitCursor.Restore();
                MessageBox.Show("获取数据出错!" + ex.Message);
            }      
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}