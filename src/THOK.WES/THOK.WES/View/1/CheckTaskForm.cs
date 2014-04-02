using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace THOK.WES.View
{
    public partial class CheckTaskForm : THOK.WES.View.BaseTaskForm
    {
        public CheckTaskForm()
        {
            InitializeComponent();         
            BillTypes = "2";
            BillString = "STOCKTAKE";
            ReturnString = "StockTakeConfirm";
        }
    }
}

