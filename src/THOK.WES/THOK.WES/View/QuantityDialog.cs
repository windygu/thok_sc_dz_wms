using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace THOK.WES.View
{
    public partial class QuantityDialog : Form
    {
        private int piece = 0;
        public int Piece
        {
            get { return piece; }
            set { piece = value;}
        }

        public QuantityDialog()
        {
            InitializeComponent();
        }

        private void RefreshData()
        {
            lblPiece.Text = piece.ToString();           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnPieceUp_Click(object sender, EventArgs e)
        {
            piece++;
            RefreshData();
        }

        private void btnPieceDown_Click(object sender, EventArgs e)
        {
            piece--;
            if (piece < 0)
                piece = 0;
            RefreshData();
        }

        private void btnItemUp_Click(object sender, EventArgs e)
        {
         
            RefreshData();
        }

        private void btnItemDown_Click(object sender, EventArgs e)
        {
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