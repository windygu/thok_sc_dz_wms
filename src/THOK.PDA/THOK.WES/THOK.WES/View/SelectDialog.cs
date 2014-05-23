using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace THOK.WES.View
{
    public partial class SelectDialog : Form
    {
        public SelectDialog()
        {
            InitializeComponent();
        }

        private string selectedBillID;
        public string SelectedBillID
        {
            get { return selectedBillID; }
            set { selectedBillID = value; }
        }

        public SelectDialog(List<string> list)
        {
            InitializeComponent();
            foreach (string row in list)
            {
                cbBillID.Items.Add(row);
            }
            cbBillID.DisplayMember = "BillNo";
            cbBillID.ValueMember = "BillNo";
            cbBillID.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.SelectedBillID = this.cbBillID.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}