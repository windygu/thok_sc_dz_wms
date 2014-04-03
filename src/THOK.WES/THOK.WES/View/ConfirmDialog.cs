using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace THOK.WES.View
{
    public partial class ConfirmDialog : Form
    {
        private int piece = 0;
        public int Piece
        {
            get { return piece; }
            set { piece = value;}
        }
        private int bar = 0;
        public int Bar
        {
            get { return bar; }
            set {bar = value; }
        }

        private string storageName = "";
        private string targetStorageName = "";
        private string operateName = "";
        private string tobaccoName = "";

        public ConfirmDialog(string billType, string storageID,string targetStorageName,string operateName, string tobaccoName)
        {
            InitializeComponent();
            this.storageName = storageID;
            this.targetStorageName = targetStorageName;
            this.operateName = operateName;
            this.tobaccoName = tobaccoName;

            if (billType != "2")
            {
                btnItemUp.Enabled = false;
                btnItemDown.Enabled = false;
            }
        }

        private void RefreshData()
        {
            lblBar.Text = piece.ToString();
            label3.Text = "作业储位：" + this.storageName;
            label4.Text = "操作类型：" + this.operateName + (this.targetStorageName != ""?"->" + this.targetStorageName:""); 
            label5.Text = "卷烟名称：" + this.tobaccoName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnBarUp_Click(object sender, EventArgs e)
        {
            bar++;
            RefreshData();
        }

        private void btnBarDown_Click(object sender, EventArgs e)
        {
            bar--;
            if (bar < 0)
                bar = 0;
            RefreshData();
        }

        private void ConfirmDialog_Paint(object sender, PaintEventArgs e)
        {
            RefreshData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}