namespace THOK.WES.View
{
    partial class BaseTaskForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.sslBillID = new System.Windows.Forms.ToolStripStatusLabel();
            this.sslOperator = new System.Windows.Forms.ToolStripStatusLabel();
            this.CyleTimer = new System.Windows.Forms.Timer(this.components);
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.sbShelf = new System.Windows.Forms.VScrollBar();
            this.plWailt = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlData = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnOpType = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.bb_order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_detail_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_operate_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_area_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_cargo_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_brand_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_brand_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_unit_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_handle_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_inventory_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_data_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_pallet_move_flg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_pallet_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_cell_rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_stock_rfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_shelf_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_corporation_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bb_corporation_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTool.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.ssMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.pnlChart.SuspendLayout();
            this.plWailt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTool
            // 
            this.pnlTool.Controls.Add(this.btnExit);
            this.pnlTool.Controls.Add(this.btnOpType);
            this.pnlTool.Controls.Add(this.btnConfirm);
            this.pnlTool.Controls.Add(this.btnSearch);
            this.pnlTool.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTool.Size = new System.Drawing.Size(804, 46);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.plWailt);
            this.pnlContent.Controls.Add(this.dgvMain);
            this.pnlContent.Controls.Add(this.ssMain);
            this.pnlContent.Controls.Add(this.pnlChart);
            this.pnlContent.Controls.Add(this.pnlData);
            this.pnlContent.Location = new System.Drawing.Point(0, 46);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Size = new System.Drawing.Size(804, 231);
            // 
            // pnlMain
            // 
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Size = new System.Drawing.Size(804, 277);
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sslBillID,
            this.sslOperator});
            this.ssMain.Location = new System.Drawing.Point(0, 209);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(804, 22);
            this.ssMain.TabIndex = 0;
            this.ssMain.Text = "statusStrip1";
            // 
            // sslBillID
            // 
            this.sslBillID.Name = "sslBillID";
            this.sslBillID.Size = new System.Drawing.Size(56, 17);
            this.sslBillID.Text = "单据号：";
            // 
            // sslOperator
            // 
            this.sslOperator.Name = "sslOperator";
            this.sslOperator.Size = new System.Drawing.Size(56, 17);
            this.sslOperator.Text = "操作员：";
            // 
            // CyleTimer
            // 
            this.CyleTimer.Tick += new System.EventHandler(this.CyleTimer_Tick);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.BackgroundColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeight = 22;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bb_order_id,
            this.bb_detail_id,
            this.bb_operate_type,
            this.bb_area_type,
            this.bb_cargo_no,
            this.bb_brand_id,
            this.bb_brand_name,
            this.bb_unit_name,
            this.bb_handle_num,
            this.bb_inventory_num,
            this.bb_data_time,
            this.bb_unit,
            this.bb_pallet_move_flg,
            this.bb_pallet_no,
            this.bb_cell_rfid,
            this.bb_stock_rfid,
            this.bb_shelf_no,
            this.bb_type,
            this.bb_corporation_id,
            this.bb_corporation_name});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 132);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowHeadersVisible = false;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(804, 77);
            this.dgvMain.TabIndex = 1;
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.SystemColors.Info;
            this.pnlChart.Controls.Add(this.sbShelf);
            this.pnlChart.Location = new System.Drawing.Point(3, 138);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(1022, 89);
            this.pnlChart.TabIndex = 2;
            // 
            // sbShelf
            // 
            this.sbShelf.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbShelf.LargeChange = 30;
            this.sbShelf.Location = new System.Drawing.Point(1003, 0);
            this.sbShelf.Maximum = 60;
            this.sbShelf.Name = "sbShelf";
            this.sbShelf.Size = new System.Drawing.Size(19, 89);
            this.sbShelf.SmallChange = 30;
            this.sbShelf.TabIndex = 0;
            this.sbShelf.Value = 1;
            // 
            // plWailt
            // 
            this.plWailt.Controls.Add(this.label1);
            this.plWailt.Controls.Add(this.pictureBox1);
            this.plWailt.Location = new System.Drawing.Point(273, 39);
            this.plWailt.Name = "plWailt";
            this.plWailt.Size = new System.Drawing.Size(258, 85);
            this.plWailt.TabIndex = 2;
            this.plWailt.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "正在处理数据，请稍等";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::THOK.WES.Properties.Resources.loading;
            this.pictureBox1.Location = new System.Drawing.Point(158, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 38);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlData
            // 
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(804, 132);
            this.pnlData.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Image = global::THOK.WES.Properties.Resources.onebit_02;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(48, 44);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "查询";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConfirm.Image = global::THOK.WES.Properties.Resources.accept;
            this.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConfirm.Location = new System.Drawing.Point(48, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(48, 44);
            this.btnConfirm.TabIndex = 20;
            this.btnConfirm.Text = "完成";
            this.btnConfirm.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnOpType
            // 
            this.btnOpType.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpType.Image = global::THOK.WES.Properties.Resources.onebit_10;
            this.btnOpType.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOpType.Location = new System.Drawing.Point(96, 0);
            this.btnOpType.Name = "btnOpType";
            this.btnOpType.Size = new System.Drawing.Size(48, 44);
            this.btnOpType.TabIndex = 22;
            this.btnOpType.Text = "正常";
            this.btnOpType.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpType.UseVisualStyleBackColor = true;
            this.btnOpType.Visible = false;
            this.btnOpType.Click += new System.EventHandler(this.btnOpType_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnExit.Image = global::THOK.WES.Properties.Resources.shut_down;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(144, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(48, 44);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "退出";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // bb_order_id
            // 
            this.bb_order_id.DataPropertyName = "bb_order_id";
            this.bb_order_id.HeaderText = "主单编码";
            this.bb_order_id.Name = "bb_order_id";
            this.bb_order_id.ReadOnly = true;
            // 
            // bb_detail_id
            // 
            this.bb_detail_id.DataPropertyName = "bb_detail_id";
            this.bb_detail_id.HeaderText = "细单单号";
            this.bb_detail_id.Name = "bb_detail_id";
            this.bb_detail_id.ReadOnly = true;
            // 
            // bb_operate_type
            // 
            this.bb_operate_type.DataPropertyName = "bb_operate_type";
            this.bb_operate_type.HeaderText = "类型";
            this.bb_operate_type.Name = "bb_operate_type";
            this.bb_operate_type.ReadOnly = true;
            // 
            // bb_area_type
            // 
            this.bb_area_type.DataPropertyName = "bb_area_type";
            this.bb_area_type.HeaderText = "库区类型";
            this.bb_area_type.Name = "bb_area_type";
            this.bb_area_type.ReadOnly = true;
            this.bb_area_type.Visible = false;
            // 
            // bb_cargo_no
            // 
            this.bb_cargo_no.DataPropertyName = "bb_cargo_no";
            this.bb_cargo_no.HeaderText = "货位ID";
            this.bb_cargo_no.Name = "bb_cargo_no";
            this.bb_cargo_no.ReadOnly = true;
            // 
            // bb_brand_id
            // 
            this.bb_brand_id.DataPropertyName = "bb_brand_id";
            this.bb_brand_id.HeaderText = "商品编码";
            this.bb_brand_id.Name = "bb_brand_id";
            this.bb_brand_id.ReadOnly = true;
            // 
            // bb_brand_name
            // 
            this.bb_brand_name.DataPropertyName = "bb_brand_name";
            this.bb_brand_name.FillWeight = 180F;
            this.bb_brand_name.HeaderText = "商品名称";
            this.bb_brand_name.Name = "bb_brand_name";
            this.bb_brand_name.ReadOnly = true;
            // 
            // bb_unit_name
            // 
            this.bb_unit_name.DataPropertyName = "bb_unit_name";
            this.bb_unit_name.HeaderText = "单位名称";
            this.bb_unit_name.Name = "bb_unit_name";
            this.bb_unit_name.ReadOnly = true;
            // 
            // bb_handle_num
            // 
            this.bb_handle_num.DataPropertyName = "bb_handle_num";
            this.bb_handle_num.HeaderText = "数量";
            this.bb_handle_num.Name = "bb_handle_num";
            this.bb_handle_num.ReadOnly = true;
            // 
            // bb_inventory_num
            // 
            this.bb_inventory_num.DataPropertyName = "bb_inventory_num";
            this.bb_inventory_num.HeaderText = "库存数量";
            this.bb_inventory_num.Name = "bb_inventory_num";
            this.bb_inventory_num.ReadOnly = true;
            this.bb_inventory_num.Visible = false;
            // 
            // bb_data_time
            // 
            this.bb_data_time.DataPropertyName = "bb_data_time";
            this.bb_data_time.HeaderText = "时间";
            this.bb_data_time.Name = "bb_data_time";
            this.bb_data_time.ReadOnly = true;
            this.bb_data_time.Visible = false;
            // 
            // bb_unit
            // 
            this.bb_unit.DataPropertyName = "bb_unit";
            this.bb_unit.HeaderText = "计量单位";
            this.bb_unit.Name = "bb_unit";
            this.bb_unit.ReadOnly = true;
            this.bb_unit.Visible = false;
            // 
            // bb_pallet_move_flg
            // 
            this.bb_pallet_move_flg.DataPropertyName = "bb_pallet_move_flg";
            this.bb_pallet_move_flg.HeaderText = "移动标志";
            this.bb_pallet_move_flg.Name = "bb_pallet_move_flg";
            this.bb_pallet_move_flg.ReadOnly = true;
            this.bb_pallet_move_flg.Visible = false;
            // 
            // bb_pallet_no
            // 
            this.bb_pallet_no.DataPropertyName = "bb_pallet_no";
            this.bb_pallet_no.HeaderText = "托盘ID";
            this.bb_pallet_no.Name = "bb_pallet_no";
            this.bb_pallet_no.ReadOnly = true;
            this.bb_pallet_no.Visible = false;
            // 
            // bb_cell_rfid
            // 
            this.bb_cell_rfid.DataPropertyName = "bb_cell_rfid";
            this.bb_cell_rfid.HeaderText = "货位RFID";
            this.bb_cell_rfid.Name = "bb_cell_rfid";
            this.bb_cell_rfid.ReadOnly = true;
            this.bb_cell_rfid.Visible = false;
            // 
            // bb_stock_rfid
            // 
            this.bb_stock_rfid.DataPropertyName = "bb_stock_rfid";
            this.bb_stock_rfid.HeaderText = "托盘RFID";
            this.bb_stock_rfid.Name = "bb_stock_rfid";
            this.bb_stock_rfid.ReadOnly = true;
            this.bb_stock_rfid.Visible = false;
            // 
            // bb_shelf_no
            // 
            this.bb_shelf_no.DataPropertyName = "bb_shelf_no";
            this.bb_shelf_no.HeaderText = "货架";
            this.bb_shelf_no.Name = "bb_shelf_no";
            this.bb_shelf_no.ReadOnly = true;
            this.bb_shelf_no.Visible = false;
            // 
            // bb_type
            // 
            this.bb_type.DataPropertyName = "bb_type";
            this.bb_type.HeaderText = "业务类型";
            this.bb_type.Name = "bb_type";
            this.bb_type.ReadOnly = true;
            this.bb_type.Visible = false;
            // 
            // bb_corporation_id
            // 
            this.bb_corporation_id.DataPropertyName = "bb_corporation_id";
            this.bb_corporation_id.HeaderText = "公司代码";
            this.bb_corporation_id.Name = "bb_corporation_id";
            this.bb_corporation_id.ReadOnly = true;
            this.bb_corporation_id.Visible = false;
            // 
            // bb_corporation_name
            // 
            this.bb_corporation_name.DataPropertyName = "bb_corporation_name";
            this.bb_corporation_name.HeaderText = "公司名称";
            this.bb_corporation_name.Name = "bb_corporation_name";
            this.bb_corporation_name.ReadOnly = true;
            this.bb_corporation_name.Visible = false;
            // 
            // BaseTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(804, 277);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "BaseTaskForm";
            this.Text = "盘点作业";
            this.pnlTool.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.pnlChart.ResumeLayout(false);
            this.plWailt.ResumeLayout(false);
            this.plWailt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel sslBillID;
        private System.Windows.Forms.ToolStripStatusLabel sslOperator;
        protected System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel plWailt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn @BillType;
        private System.Windows.Forms.DataGridViewTextBoxColumn @BillNo;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.VScrollBar sbShelf;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnConfirm;
        protected System.Windows.Forms.Button btnSearch;
        protected System.Windows.Forms.Button btnOpType;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Timer CyleTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_detail_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_operate_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_area_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_cargo_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_brand_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_brand_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_unit_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_handle_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_inventory_num;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_data_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_pallet_move_flg;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_pallet_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_cell_rfid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_stock_rfid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_shelf_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_corporation_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bb_corporation_name;
    }
}
