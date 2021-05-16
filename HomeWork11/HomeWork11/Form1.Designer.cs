
namespace HomeWork8
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.selectBy = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchItem = new System.Windows.Forms.TextBox();
            this.odrDataGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.创建新订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除该订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改该订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.odrDetailsGridView = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加新订单明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除该订单明细ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.showSelect = new System.Windows.Forms.ListBox();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ordersDataSet = new HomeWork8.OrdersDataSet();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.odrDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.odrDetailsGridView)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.selectBy);
            this.panel1.Controls.Add(this.searchButton);
            this.panel1.Controls.Add(this.searchItem);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 70);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(370, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 7;
            // 
            // selectBy
            // 
            this.selectBy.FormattingEnabled = true;
            this.selectBy.Location = new System.Drawing.Point(13, 42);
            this.selectBy.Name = "selectBy";
            this.selectBy.Size = new System.Drawing.Size(121, 23);
            this.selectBy.TabIndex = 6;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(140, 11);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(74, 54);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "查询";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // searchItem
            // 
            this.searchItem.Location = new System.Drawing.Point(13, 11);
            this.searchItem.Name = "searchItem";
            this.searchItem.Size = new System.Drawing.Size(121, 25);
            this.searchItem.TabIndex = 0;
            // 
            // odrDataGridView
            // 
            this.odrDataGridView.AllowUserToAddRows = false;
            this.odrDataGridView.AllowUserToDeleteRows = false;
            this.odrDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.odrDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.odrDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.OrderDetails,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.odrDataGridView.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.odrDataGridView.Location = new System.Drawing.Point(3, 0);
            this.odrDataGridView.MultiSelect = false;
            this.odrDataGridView.Name = "odrDataGridView";
            this.odrDataGridView.ReadOnly = true;
            this.odrDataGridView.RowHeadersWidth = 51;
            this.odrDataGridView.RowTemplate.Height = 27;
            this.odrDataGridView.Size = new System.Drawing.Size(500, 360);
            this.odrDataGridView.TabIndex = 1;
            this.odrDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OdrGridView_CellMouseClick);
            this.odrDataGridView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OdrGridView_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建新订单ToolStripMenuItem,
            this.删除该订单ToolStripMenuItem,
            this.修改该订单ToolStripMenuItem,
            this.导入数据ToolStripMenuItem,
            this.导出数据ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 124);
            // 
            // 创建新订单ToolStripMenuItem
            // 
            this.创建新订单ToolStripMenuItem.Name = "创建新订单ToolStripMenuItem";
            this.创建新订单ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.创建新订单ToolStripMenuItem.Text = "创建新订单";
            this.创建新订单ToolStripMenuItem.Click += new System.EventHandler(this.创建新订单ToolStripMenuItem_Click);
            // 
            // 删除该订单ToolStripMenuItem
            // 
            this.删除该订单ToolStripMenuItem.Name = "删除该订单ToolStripMenuItem";
            this.删除该订单ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.删除该订单ToolStripMenuItem.Text = "删除该订单";
            this.删除该订单ToolStripMenuItem.Click += new System.EventHandler(this.删除该订单ToolStripMenuItem_Click);
            // 
            // 修改该订单ToolStripMenuItem
            // 
            this.修改该订单ToolStripMenuItem.Name = "修改该订单ToolStripMenuItem";
            this.修改该订单ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.修改该订单ToolStripMenuItem.Text = "修改该订单";
            this.修改该订单ToolStripMenuItem.Click += new System.EventHandler(this.修改该订单ToolStripMenuItem_Click);
            // 
            // 导入数据ToolStripMenuItem
            // 
            this.导入数据ToolStripMenuItem.Name = "导入数据ToolStripMenuItem";
            this.导入数据ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.导入数据ToolStripMenuItem.Text = "导入数据";
            this.导入数据ToolStripMenuItem.Click += new System.EventHandler(this.导入数据ToolStripMenuItem_Click);
            // 
            // 导出数据ToolStripMenuItem
            // 
            this.导出数据ToolStripMenuItem.Name = "导出数据ToolStripMenuItem";
            this.导出数据ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.导出数据ToolStripMenuItem.Text = "导出数据";
            this.导出数据ToolStripMenuItem.Click += new System.EventHandler(this.导出数据ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.odrDetailsGridView);
            this.panel2.Controls.Add(this.odrDataGridView);
            this.panel2.Location = new System.Drawing.Point(-1, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(939, 363);
            this.panel2.TabIndex = 2;
            // 
            // odrDetailsGridView
            // 
            this.odrDetailsGridView.AllowUserToAddRows = false;
            this.odrDetailsGridView.AllowUserToDeleteRows = false;
            this.odrDetailsGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.odrDetailsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.odrDetailsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8});
            this.odrDetailsGridView.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.odrDetailsGridView.Location = new System.Drawing.Point(509, 0);
            this.odrDetailsGridView.MultiSelect = false;
            this.odrDetailsGridView.Name = "odrDetailsGridView";
            this.odrDetailsGridView.ReadOnly = true;
            this.odrDetailsGridView.RowHeadersWidth = 51;
            this.odrDetailsGridView.RowTemplate.Height = 27;
            this.odrDetailsGridView.Size = new System.Drawing.Size(430, 360);
            this.odrDetailsGridView.TabIndex = 2;
            this.odrDetailsGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OdrDetailsGridView_CellMouseClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加新订单明细ToolStripMenuItem,
            this.删除该订单明细ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(184, 52);
            // 
            // 添加新订单明细ToolStripMenuItem
            // 
            this.添加新订单明细ToolStripMenuItem.Name = "添加新订单明细ToolStripMenuItem";
            this.添加新订单明细ToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.添加新订单明细ToolStripMenuItem.Text = "添加新订单明细";
            this.添加新订单明细ToolStripMenuItem.Click += new System.EventHandler(this.添加新订单明细ToolStripMenuItem_Click);
            // 
            // 删除该订单明细ToolStripMenuItem
            // 
            this.删除该订单明细ToolStripMenuItem.Name = "删除该订单明细ToolStripMenuItem";
            this.删除该订单明细ToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.删除该订单明细ToolStripMenuItem.Text = "删除该订单明细";
            this.删除该订单明细ToolStripMenuItem.Click += new System.EventHandler(this.删除该订单明细ToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.showSelect);
            this.panel3.Location = new System.Drawing.Point(225, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(713, 70);
            this.panel3.TabIndex = 3;
            // 
            // showSelect
            // 
            this.showSelect.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.showSelect.FormattingEnabled = true;
            this.showSelect.ItemHeight = 15;
            this.showSelect.Location = new System.Drawing.Point(3, 12);
            this.showSelect.Name = "showSelect";
            this.showSelect.Size = new System.Drawing.Size(703, 49);
            this.showSelect.TabIndex = 0;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TradeName";
            this.Column6.HeaderText = "货物名称";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "TradePrice";
            this.Column7.HeaderText = "货物价格";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "TradeAmount";
            this.Column8.HeaderText = "货物数量";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 125;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "OrderNumber";
            this.Column1.HeaderText = "订单号";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // OrderDetails
            // 
            this.OrderDetails.HeaderText = "orderDetails";
            this.OrderDetails.MinimumWidth = 6;
            this.OrderDetails.Name = "OrderDetails";
            this.OrderDetails.ReadOnly = true;
            this.OrderDetails.Visible = false;
            this.OrderDetails.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Client";
            this.Column2.HeaderText = "客户";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "OrderTime";
            this.Column3.HeaderText = "订单时间";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "OrderAddress";
            this.Column4.HeaderText = "订单地址";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "OrderAmount";
            this.Column5.HeaderText = "订单量";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.AllowNew = false;
            this.orderBindingSource.DataSource = this.ordersDataSet;
            this.orderBindingSource.Position = 0;
            // 
            // ordersDataSet
            // 
            this.ordersDataSet.DataSetName = "OrdersDataSet";
            this.ordersDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(942, 443);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximumSize = new System.Drawing.Size(960, 490);
            this.MinimumSize = new System.Drawing.Size(960, 490);
            this.Name = "Form1";
            this.Opacity = 0.9D;
            this.Text = "货单管理";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.odrDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.odrDetailsGridView)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox selectBy;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchItem;
        private System.Windows.Forms.DataGridView odrDataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 创建新订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除该订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改该订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出数据ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView odrDetailsGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 添加新订单明细ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除该订单明细ToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox showSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        internal System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private OrdersDataSet ordersDataSet;
    }
}

