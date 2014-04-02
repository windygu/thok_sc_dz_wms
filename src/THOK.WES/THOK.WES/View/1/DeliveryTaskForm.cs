using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace THOK.WES.View
{
    public partial class DeliveryTaskForm : THOK.WES.View.BaseTaskForm
    {
        public DeliveryTaskForm()
        {
            InitializeComponent();
            BillTypes= "5";
            this.btnOpType.Visible = true;
            BillString = "STOCKMOVE";
            ReturnString = "StockOutConfirm";
        }
    }
}

