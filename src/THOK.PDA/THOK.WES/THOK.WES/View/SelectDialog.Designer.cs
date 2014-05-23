namespace THOK.WES.View
{
    partial class SelectDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.cbBillID = new System.Windows.Forms.ComboBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbBillID
            // 
            this.cbBillID.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular);
            this.cbBillID.Location = new System.Drawing.Point(14, 42);
            this.cbBillID.Name = "cbBillID";
            this.cbBillID.Size = new System.Drawing.Size(303, 52);
            this.cbBillID.TabIndex = 8;
            // 
            // lblCaption
            // 
            this.lblCaption.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular);
            this.lblCaption.Location = new System.Drawing.Point(14, 10);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(184, 16);
            this.lblCaption.Text = "请选择要进行作业的单据";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 47);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "   取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(69, 108);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 47);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "   确认";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SelectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(334, 168);
            this.ControlBox = false;
            this.Controls.Add(this.cbBillID);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Menu = this.mainMenu1;
            this.Name = "SelectDialog";
            this.Text = "SelectDialog";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cbBillID;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}