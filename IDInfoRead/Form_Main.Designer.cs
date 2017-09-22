namespace IDInfoRead
{
    partial class Form_Main
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
            CloseComm();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_Gender = new System.Windows.Forms.Label();
            this.lbl_Birth = new System.Windows.Forms.Label();
            this.lbl_Folk = new System.Windows.Forms.Label();
            this.lbl_Address = new System.Windows.Forms.Label();
            this.lbl_ID = new System.Windows.Forms.Label();
            this.lbl_Agency = new System.Windows.Forms.Label();
            this.lbl_Validity = new System.Windows.Forms.Label();
            this.pB_Photo = new System.Windows.Forms.PictureBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Gender = new System.Windows.Forms.Label();
            this.label_Folk = new System.Windows.Forms.Label();
            this.label_Birth = new System.Windows.Forms.Label();
            this.label_Address = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.label_Agency = new System.Windows.Forms.Label();
            this.label_Validity = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbar_IPSet = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_IPSet = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Photo)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Name.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Name.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Name.Location = new System.Drawing.Point(4, 0);
            this.lbl_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(132, 48);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "姓名";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Gender
            // 
            this.lbl_Gender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Gender.AutoSize = true;
            this.lbl_Gender.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Gender.Location = new System.Drawing.Point(4, 48);
            this.lbl_Gender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Gender.Name = "lbl_Gender";
            this.lbl_Gender.Size = new System.Drawing.Size(132, 48);
            this.lbl_Gender.TabIndex = 1;
            this.lbl_Gender.Text = "性别";
            this.lbl_Gender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Birth
            // 
            this.lbl_Birth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Birth.AutoSize = true;
            this.lbl_Birth.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Birth.Location = new System.Drawing.Point(4, 144);
            this.lbl_Birth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Birth.Name = "lbl_Birth";
            this.lbl_Birth.Size = new System.Drawing.Size(132, 48);
            this.lbl_Birth.TabIndex = 2;
            this.lbl_Birth.Text = "出生";
            this.lbl_Birth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Folk
            // 
            this.lbl_Folk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Folk.AutoSize = true;
            this.lbl_Folk.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Folk.Location = new System.Drawing.Point(4, 96);
            this.lbl_Folk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Folk.Name = "lbl_Folk";
            this.lbl_Folk.Size = new System.Drawing.Size(132, 48);
            this.lbl_Folk.TabIndex = 3;
            this.lbl_Folk.Text = "民族";
            this.lbl_Folk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Address
            // 
            this.lbl_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Address.AutoSize = true;
            this.lbl_Address.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Address.Location = new System.Drawing.Point(4, 192);
            this.lbl_Address.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.Size = new System.Drawing.Size(132, 48);
            this.lbl_Address.TabIndex = 4;
            this.lbl_Address.Text = "住址";
            this.lbl_Address.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ID
            // 
            this.lbl_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ID.AutoSize = true;
            this.lbl_ID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_ID.Location = new System.Drawing.Point(4, 240);
            this.lbl_ID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ID.Name = "lbl_ID";
            this.lbl_ID.Size = new System.Drawing.Size(132, 48);
            this.lbl_ID.TabIndex = 5;
            this.lbl_ID.Text = "身份证号";
            this.lbl_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Agency
            // 
            this.lbl_Agency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Agency.AutoSize = true;
            this.lbl_Agency.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Agency.Location = new System.Drawing.Point(4, 288);
            this.lbl_Agency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Agency.Name = "lbl_Agency";
            this.lbl_Agency.Size = new System.Drawing.Size(132, 48);
            this.lbl_Agency.TabIndex = 6;
            this.lbl_Agency.Text = "签发机关";
            this.lbl_Agency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Validity
            // 
            this.lbl_Validity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Validity.AutoSize = true;
            this.lbl_Validity.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Validity.Location = new System.Drawing.Point(4, 336);
            this.lbl_Validity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Validity.Name = "lbl_Validity";
            this.lbl_Validity.Size = new System.Drawing.Size(132, 52);
            this.lbl_Validity.TabIndex = 7;
            this.lbl_Validity.Text = "有效期限";
            this.lbl_Validity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pB_Photo
            // 
            this.pB_Photo.BackColor = System.Drawing.Color.Transparent;
            this.pB_Photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pB_Photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB_Photo.Location = new System.Drawing.Point(684, 5);
            this.pB_Photo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pB_Photo.Name = "pB_Photo";
            this.tableLayoutPanel1.SetRowSpan(this.pB_Photo, 3);
            this.pB_Photo.Size = new System.Drawing.Size(103, 134);
            this.pB_Photo.TabIndex = 8;
            this.pB_Photo.TabStop = false;
            // 
            // label_Name
            // 
            this.label_Name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(144, 0);
            this.label_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(532, 48);
            this.label_Name.TabIndex = 10;
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Gender
            // 
            this.label_Gender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Gender.AutoSize = true;
            this.label_Gender.Location = new System.Drawing.Point(144, 48);
            this.label_Gender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Gender.Name = "label_Gender";
            this.label_Gender.Size = new System.Drawing.Size(532, 48);
            this.label_Gender.TabIndex = 11;
            this.label_Gender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Folk
            // 
            this.label_Folk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Folk.AutoSize = true;
            this.label_Folk.Location = new System.Drawing.Point(144, 96);
            this.label_Folk.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Folk.Name = "label_Folk";
            this.label_Folk.Size = new System.Drawing.Size(532, 48);
            this.label_Folk.TabIndex = 12;
            this.label_Folk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Birth
            // 
            this.label_Birth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Birth.AutoSize = true;
            this.label_Birth.Location = new System.Drawing.Point(144, 144);
            this.label_Birth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Birth.Name = "label_Birth";
            this.label_Birth.Size = new System.Drawing.Size(532, 48);
            this.label_Birth.TabIndex = 13;
            this.label_Birth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Address
            // 
            this.label_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Address.AutoSize = true;
            this.label_Address.Location = new System.Drawing.Point(144, 192);
            this.label_Address.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(532, 48);
            this.label_Address.TabIndex = 14;
            this.label_Address.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ID
            // 
            this.label_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ID.AutoSize = true;
            this.label_ID.Location = new System.Drawing.Point(144, 240);
            this.label_ID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(532, 48);
            this.label_ID.TabIndex = 15;
            this.label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Agency
            // 
            this.label_Agency.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Agency.AutoSize = true;
            this.label_Agency.Location = new System.Drawing.Point(144, 288);
            this.label_Agency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Agency.Name = "label_Agency";
            this.label_Agency.Size = new System.Drawing.Size(532, 48);
            this.label_Agency.TabIndex = 16;
            this.label_Agency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Validity
            // 
            this.label_Validity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Validity.AutoSize = true;
            this.label_Validity.Location = new System.Drawing.Point(144, 336);
            this.label_Validity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Validity.Name = "label_Validity";
            this.label_Validity.Size = new System.Drawing.Size(532, 52);
            this.label_Validity.TabIndex = 17;
            this.label_Validity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbar_IPSet});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(791, 24);
            this.toolStrip1.TabIndex = 20;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // toolbar_IPSet
            // 
            this.toolbar_IPSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbar_IPSet.Image = ((System.Drawing.Image)(resources.GetObject("toolbar_IPSet.Image")));
            this.toolbar_IPSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbar_IPSet.Name = "toolbar_IPSet";
            this.toolbar_IPSet.Size = new System.Drawing.Size(60, 21);
            this.toolbar_IPSet.Text = "端口配置";
            this.toolbar_IPSet.Click += new System.EventHandler(this.toolbar_IPSet_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LimeGreen;
            this.statusStrip1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 413);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(791, 30);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 22;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_Status
            // 
            this.lbl_Status.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_Status.Name = "lbl_Status";
            this.lbl_Status.Size = new System.Drawing.Size(772, 25);
            this.lbl_Status.Spring = true;
            this.lbl_Status.Text = "请放卡...";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.6278F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.3722F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_Name, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Gender, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Folk, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Birth, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_Folk, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_Gender, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pB_Photo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Validity, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Address, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_Agency, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lbl_ID, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label_ID, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Agency, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label_Address, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Validity, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label_Birth, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 388);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "身份证信息读取助手";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_IPSet});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(791, 25);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu_IPSet
            // 
            this.menu_IPSet.Name = "menu_IPSet";
            this.menu_IPSet.Size = new System.Drawing.Size(68, 21);
            this.menu_IPSet.Text = "端口配置";
            this.menu_IPSet.Click += new System.EventHandler(this.menu_IPSet_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(791, 443);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "身份证信息读取助手";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosing_Handle);
            this.Resize += new System.EventHandler(this.Form_Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pB_Photo)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_Gender; 
        private System.Windows.Forms.Label lbl_Birth;
        private System.Windows.Forms.Label lbl_Folk;
        private System.Windows.Forms.Label lbl_Address;
        private System.Windows.Forms.Label lbl_ID;
        private System.Windows.Forms.Label lbl_Agency;
        private System.Windows.Forms.Label lbl_Validity;
        private System.Windows.Forms.PictureBox pB_Photo;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Gender;
        private System.Windows.Forms.Label label_Folk;
        private System.Windows.Forms.Label label_Birth;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.Label label_ID;
        private System.Windows.Forms.Label label_Agency;
        private System.Windows.Forms.Label label_Validity;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbar_IPSet;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_Status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu_IPSet;
    }
}

