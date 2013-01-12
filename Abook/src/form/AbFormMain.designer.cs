namespace Abook
{
    partial class AbFormMain
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabExpense = new System.Windows.Forms.TabPage();
            this.BtnAddRow = new System.Windows.Forms.Button();
            this.DgvExpense = new System.Windows.Forms.DataGridView();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEntry = new System.Windows.Forms.Button();
            this.TabSummary = new System.Windows.Forms.TabPage();
            this.HeadSummary = new Abook.AbHeaderControl();
            this.LblLine2 = new System.Windows.Forms.Label();
            this.LblLine = new System.Windows.Forms.Label();
            this.TabGraph = new System.Windows.Forms.TabPage();
            this.LblLineBlue = new System.Windows.Forms.Label();
            this.LblLineGray = new System.Windows.Forms.Label();
            this.LblLineYellow = new System.Windows.Forms.Label();
            this.LblLineOrange = new System.Windows.Forms.Label();
            this.LblLineRed = new System.Windows.Forms.Label();
            this.LblLine水道代 = new System.Windows.Forms.Label();
            this.LblLineガス代 = new System.Windows.Forms.Label();
            this.LblLine電気代 = new System.Windows.Forms.Label();
            this.LblLine外食費 = new System.Windows.Forms.Label();
            this.LblLine食費 = new System.Windows.Forms.Label();
            this.PboxGraph = new System.Windows.Forms.PictureBox();
            this.LblX6 = new System.Windows.Forms.Label();
            this.LblX5 = new System.Windows.Forms.Label();
            this.LblX4 = new System.Windows.Forms.Label();
            this.LblX3 = new System.Windows.Forms.Label();
            this.LblX2 = new System.Windows.Forms.Label();
            this.LblX1 = new System.Windows.Forms.Label();
            this.LblYen10000 = new System.Windows.Forms.Label();
            this.LblYen5000 = new System.Windows.Forms.Label();
            this.TabBalance = new System.Windows.Forms.TabPage();
            this.DgvBalance = new System.Windows.Forms.DataGridView();
            this.ColYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEarn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExpense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSpecial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblHous = new Abook.AbLabelControl();
            this.LblPlay = new Abook.AbLabelControl();
            this.LblTrfc = new Abook.AbLabelControl();
            this.LblFrnd = new Abook.AbLabelControl();
            this.LblGood = new Abook.AbLabelControl();
            this.LblOtfd = new Abook.AbLabelControl();
            this.LblFood = new Abook.AbLabelControl();
            this.LblEngy = new Abook.AbLabelControl();
            this.LblCnct = new Abook.AbLabelControl();
            this.LblMedi = new Abook.AbLabelControl();
            this.LblInsu = new Abook.AbLabelControl();
            this.LblOthr = new Abook.AbLabelControl();
            this.LblTtal = new Abook.AbLabelControl();
            this.LblBlnc = new Abook.AbLabelControl();
            this.HeadGraphic = new Abook.AbHeaderControl();
            this.MenuStrip.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpense)).BeginInit();
            this.TabSummary.SuspendLayout();
            this.TabGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PboxGraph)).BeginInit();
            this.TabBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuHelp});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(416, 24);
            this.MenuStrip.TabIndex = 0;
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(66, 20);
            this.MenuFile.Text = "ファイル(&F)";
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(110, 22);
            this.MenuExit.Text = "終了(&Q)";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuVersion});
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(62, 20);
            this.MenuHelp.Text = "ヘルプ(&H)";
            // 
            // MenuVersion
            // 
            this.MenuVersion.Name = "MenuVersion";
            this.MenuVersion.Size = new System.Drawing.Size(155, 22);
            this.MenuVersion.Text = "バージョン情報(&A)";
            this.MenuVersion.Click += new System.EventHandler(this.MenuVersion_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabExpense);
            this.TabControl.Controls.Add(this.TabSummary);
            this.TabControl.Controls.Add(this.TabGraph);
            this.TabControl.Controls.Add(this.TabBalance);
            this.TabControl.Location = new System.Drawing.Point(0, 27);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(416, 316);
            this.TabControl.TabIndex = 1;
            // 
            // TabExpense
            // 
            this.TabExpense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabExpense.Controls.Add(this.BtnAddRow);
            this.TabExpense.Controls.Add(this.DgvExpense);
            this.TabExpense.Controls.Add(this.BtnEntry);
            this.TabExpense.Location = new System.Drawing.Point(4, 21);
            this.TabExpense.Name = "TabExpense";
            this.TabExpense.Padding = new System.Windows.Forms.Padding(3);
            this.TabExpense.Size = new System.Drawing.Size(408, 291);
            this.TabExpense.TabIndex = 1;
            this.TabExpense.Text = "支出";
            this.TabExpense.UseVisualStyleBackColor = true;
            // 
            // BtnAddRow
            // 
            this.BtnAddRow.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnAddRow.Location = new System.Drawing.Point(361, 6);
            this.BtnAddRow.Name = "BtnAddRow";
            this.BtnAddRow.Size = new System.Drawing.Size(37, 23);
            this.BtnAddRow.TabIndex = 1;
            this.BtnAddRow.Text = "＋";
            this.BtnAddRow.UseVisualStyleBackColor = true;
            this.BtnAddRow.Click += new System.EventHandler(this.BtnAddRow_Click);
            // 
            // DgvExpense
            // 
            this.DgvExpense.AllowUserToAddRows = false;
            this.DgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDate,
            this.ColName,
            this.ColType,
            this.ColCost});
            this.DgvExpense.Location = new System.Drawing.Point(6, 35);
            this.DgvExpense.Name = "DgvExpense";
            this.DgvExpense.RowHeadersWidth = 24;
            this.DgvExpense.RowTemplate.Height = 21;
            this.DgvExpense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvExpense.Size = new System.Drawing.Size(392, 246);
            this.DgvExpense.TabIndex = 2;
            this.DgvExpense.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvExpense_CellEndEdit);
            this.DgvExpense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvExpense_KeyDown);
            // 
            // ColDate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColDate.HeaderText = "日付";
            this.ColDate.Name = "ColDate";
            this.ColDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDate.Width = 90;
            // 
            // ColName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColName.HeaderText = "名称";
            this.ColName.Name = "ColName";
            this.ColName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColName.Width = 120;
            // 
            // ColType
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColType.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColType.HeaderText = "種別";
            this.ColType.Name = "ColType";
            this.ColType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColType.Width = 75;
            // 
            // ColCost
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.ColCost.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColCost.HeaderText = "金額";
            this.ColCost.Name = "ColCost";
            this.ColCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCost.Width = 60;
            // 
            // BtnEntry
            // 
            this.BtnEntry.Location = new System.Drawing.Point(301, 6);
            this.BtnEntry.Name = "BtnEntry";
            this.BtnEntry.Size = new System.Drawing.Size(50, 23);
            this.BtnEntry.TabIndex = 0;
            this.BtnEntry.Text = "登録";
            this.BtnEntry.UseVisualStyleBackColor = true;
            this.BtnEntry.Click += new System.EventHandler(this.BtnEntry_Click);
            // 
            // TabSummary
            // 
            this.TabSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabSummary.Controls.Add(this.HeadSummary);
            this.TabSummary.Controls.Add(this.LblBlnc);
            this.TabSummary.Controls.Add(this.LblTtal);
            this.TabSummary.Controls.Add(this.LblOthr);
            this.TabSummary.Controls.Add(this.LblInsu);
            this.TabSummary.Controls.Add(this.LblMedi);
            this.TabSummary.Controls.Add(this.LblCnct);
            this.TabSummary.Controls.Add(this.LblEngy);
            this.TabSummary.Controls.Add(this.LblHous);
            this.TabSummary.Controls.Add(this.LblPlay);
            this.TabSummary.Controls.Add(this.LblTrfc);
            this.TabSummary.Controls.Add(this.LblFrnd);
            this.TabSummary.Controls.Add(this.LblGood);
            this.TabSummary.Controls.Add(this.LblOtfd);
            this.TabSummary.Controls.Add(this.LblFood);
            this.TabSummary.Controls.Add(this.LblLine2);
            this.TabSummary.Controls.Add(this.LblLine);
            this.TabSummary.Location = new System.Drawing.Point(4, 21);
            this.TabSummary.Name = "TabSummary";
            this.TabSummary.Padding = new System.Windows.Forms.Padding(3);
            this.TabSummary.Size = new System.Drawing.Size(408, 291);
            this.TabSummary.TabIndex = 0;
            this.TabSummary.Text = "集計";
            this.TabSummary.UseVisualStyleBackColor = true;
            // 
            // HeadSummary
            // 
            this.HeadSummary.Location = new System.Drawing.Point(84, 6);
            this.HeadSummary.Name = "HeadSummary";
            this.HeadSummary.Size = new System.Drawing.Size(227, 29);
            this.HeadSummary.TabIndex = 61;
            this.HeadSummary.Title = "9999年99月";
            this.HeadSummary.NextYearClick += new System.EventHandler(this.HeadSummary_NextYearClick);
            this.HeadSummary.NextMonthClick += new System.EventHandler(this.HeadSummary_NextMonthClick);
            this.HeadSummary.PrevYearClick += new System.EventHandler(this.HeadSummary_PrevYearClick);
            this.HeadSummary.PrevMonthClick += new System.EventHandler(this.HeadSummary_PrevMonthClick);
            // 
            // LblLine2
            // 
            this.LblLine2.AutoSize = true;
            this.LblLine2.Location = new System.Drawing.Point(206, 208);
            this.LblLine2.Name = "LblLine2";
            this.LblLine2.Size = new System.Drawing.Size(143, 12);
            this.LblLine2.TabIndex = 46;
            this.LblLine2.Text = "-----------------------";
            // 
            // LblLine
            // 
            this.LblLine.AutoSize = true;
            this.LblLine.Location = new System.Drawing.Point(26, 96);
            this.LblLine.Name = "LblLine";
            this.LblLine.Size = new System.Drawing.Size(323, 12);
            this.LblLine.TabIndex = 15;
            this.LblLine.Text = "-----------------------------------------------------";
            // 
            // TabGraph
            // 
            this.TabGraph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabGraph.Controls.Add(this.HeadGraphic);
            this.TabGraph.Controls.Add(this.LblLineBlue);
            this.TabGraph.Controls.Add(this.LblLineGray);
            this.TabGraph.Controls.Add(this.LblLineYellow);
            this.TabGraph.Controls.Add(this.LblLineOrange);
            this.TabGraph.Controls.Add(this.LblLineRed);
            this.TabGraph.Controls.Add(this.LblLine水道代);
            this.TabGraph.Controls.Add(this.LblLineガス代);
            this.TabGraph.Controls.Add(this.LblLine電気代);
            this.TabGraph.Controls.Add(this.LblLine外食費);
            this.TabGraph.Controls.Add(this.LblLine食費);
            this.TabGraph.Controls.Add(this.PboxGraph);
            this.TabGraph.Controls.Add(this.LblX6);
            this.TabGraph.Controls.Add(this.LblX5);
            this.TabGraph.Controls.Add(this.LblX4);
            this.TabGraph.Controls.Add(this.LblX3);
            this.TabGraph.Controls.Add(this.LblX2);
            this.TabGraph.Controls.Add(this.LblX1);
            this.TabGraph.Controls.Add(this.LblYen10000);
            this.TabGraph.Controls.Add(this.LblYen5000);
            this.TabGraph.Location = new System.Drawing.Point(4, 21);
            this.TabGraph.Name = "TabGraph";
            this.TabGraph.Padding = new System.Windows.Forms.Padding(3);
            this.TabGraph.Size = new System.Drawing.Size(408, 291);
            this.TabGraph.TabIndex = 2;
            this.TabGraph.Text = "グラフ";
            this.TabGraph.UseVisualStyleBackColor = true;
            // 
            // LblLineBlue
            // 
            this.LblLineBlue.AutoSize = true;
            this.LblLineBlue.ForeColor = System.Drawing.Color.Blue;
            this.LblLineBlue.Location = new System.Drawing.Point(290, 36);
            this.LblLineBlue.Name = "LblLineBlue";
            this.LblLineBlue.Size = new System.Drawing.Size(17, 12);
            this.LblLineBlue.TabIndex = 26;
            this.LblLineBlue.Text = "--";
            // 
            // LblLineGray
            // 
            this.LblLineGray.AutoSize = true;
            this.LblLineGray.ForeColor = System.Drawing.Color.Silver;
            this.LblLineGray.Location = new System.Drawing.Point(228, 36);
            this.LblLineGray.Name = "LblLineGray";
            this.LblLineGray.Size = new System.Drawing.Size(17, 12);
            this.LblLineGray.TabIndex = 25;
            this.LblLineGray.Text = "--";
            // 
            // LblLineYellow
            // 
            this.LblLineYellow.AutoSize = true;
            this.LblLineYellow.ForeColor = System.Drawing.Color.Yellow;
            this.LblLineYellow.Location = new System.Drawing.Point(160, 36);
            this.LblLineYellow.Name = "LblLineYellow";
            this.LblLineYellow.Size = new System.Drawing.Size(17, 12);
            this.LblLineYellow.TabIndex = 24;
            this.LblLineYellow.Text = "--";
            // 
            // LblLineOrange
            // 
            this.LblLineOrange.AutoSize = true;
            this.LblLineOrange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LblLineOrange.Location = new System.Drawing.Point(97, 36);
            this.LblLineOrange.Name = "LblLineOrange";
            this.LblLineOrange.Size = new System.Drawing.Size(17, 12);
            this.LblLineOrange.TabIndex = 23;
            this.LblLineOrange.Text = "--";
            // 
            // LblLineRed
            // 
            this.LblLineRed.AutoSize = true;
            this.LblLineRed.ForeColor = System.Drawing.Color.Red;
            this.LblLineRed.Location = new System.Drawing.Point(49, 36);
            this.LblLineRed.Name = "LblLineRed";
            this.LblLineRed.Size = new System.Drawing.Size(17, 12);
            this.LblLineRed.TabIndex = 22;
            this.LblLineRed.Text = "--";
            // 
            // LblLine水道代
            // 
            this.LblLine水道代.AutoSize = true;
            this.LblLine水道代.Location = new System.Drawing.Point(306, 36);
            this.LblLine水道代.Name = "LblLine水道代";
            this.LblLine水道代.Size = new System.Drawing.Size(41, 12);
            this.LblLine水道代.TabIndex = 21;
            this.LblLine水道代.Text = "水道代";
            // 
            // LblLineガス代
            // 
            this.LblLineガス代.AutoSize = true;
            this.LblLineガス代.Location = new System.Drawing.Point(243, 36);
            this.LblLineガス代.Name = "LblLineガス代";
            this.LblLineガス代.Size = new System.Drawing.Size(36, 12);
            this.LblLineガス代.TabIndex = 20;
            this.LblLineガス代.Text = "ガス代";
            // 
            // LblLine電気代
            // 
            this.LblLine電気代.AutoSize = true;
            this.LblLine電気代.Location = new System.Drawing.Point(176, 36);
            this.LblLine電気代.Name = "LblLine電気代";
            this.LblLine電気代.Size = new System.Drawing.Size(41, 12);
            this.LblLine電気代.TabIndex = 19;
            this.LblLine電気代.Text = "電気代";
            // 
            // LblLine外食費
            // 
            this.LblLine外食費.AutoSize = true;
            this.LblLine外食費.Location = new System.Drawing.Point(112, 36);
            this.LblLine外食費.Name = "LblLine外食費";
            this.LblLine外食費.Size = new System.Drawing.Size(41, 12);
            this.LblLine外食費.TabIndex = 18;
            this.LblLine外食費.Text = "外食費";
            // 
            // LblLine食費
            // 
            this.LblLine食費.AutoSize = true;
            this.LblLine食費.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblLine食費.Location = new System.Drawing.Point(63, 36);
            this.LblLine食費.Name = "LblLine食費";
            this.LblLine食費.Size = new System.Drawing.Size(29, 12);
            this.LblLine食費.TabIndex = 17;
            this.LblLine食費.Text = "食費";
            // 
            // PboxGraph
            // 
            this.PboxGraph.BackColor = System.Drawing.SystemColors.ControlText;
            this.PboxGraph.Location = new System.Drawing.Point(49, 51);
            this.PboxGraph.Name = "PboxGraph";
            this.PboxGraph.Size = new System.Drawing.Size(349, 218);
            this.PboxGraph.TabIndex = 16;
            this.PboxGraph.TabStop = false;
            this.PboxGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.PboxGraph_Paint);
            // 
            // LblX6
            // 
            this.LblX6.AutoSize = true;
            this.LblX6.Location = new System.Drawing.Point(364, 272);
            this.LblX6.Name = "LblX6";
            this.LblX6.Size = new System.Drawing.Size(17, 12);
            this.LblX6.TabIndex = 15;
            this.LblX6.Text = "x6";
            // 
            // LblX5
            // 
            this.LblX5.AutoSize = true;
            this.LblX5.Location = new System.Drawing.Point(310, 272);
            this.LblX5.Name = "LblX5";
            this.LblX5.Size = new System.Drawing.Size(17, 12);
            this.LblX5.TabIndex = 14;
            this.LblX5.Text = "x5";
            // 
            // LblX4
            // 
            this.LblX4.AutoSize = true;
            this.LblX4.Location = new System.Drawing.Point(256, 272);
            this.LblX4.Name = "LblX4";
            this.LblX4.Size = new System.Drawing.Size(17, 12);
            this.LblX4.TabIndex = 13;
            this.LblX4.Text = "x4";
            // 
            // LblX3
            // 
            this.LblX3.AutoSize = true;
            this.LblX3.Location = new System.Drawing.Point(203, 272);
            this.LblX3.Name = "LblX3";
            this.LblX3.Size = new System.Drawing.Size(17, 12);
            this.LblX3.TabIndex = 12;
            this.LblX3.Text = "x3";
            // 
            // LblX2
            // 
            this.LblX2.AutoSize = true;
            this.LblX2.Location = new System.Drawing.Point(149, 272);
            this.LblX2.Name = "LblX2";
            this.LblX2.Size = new System.Drawing.Size(17, 12);
            this.LblX2.TabIndex = 11;
            this.LblX2.Text = "x2";
            // 
            // LblX1
            // 
            this.LblX1.AutoSize = true;
            this.LblX1.Location = new System.Drawing.Point(95, 271);
            this.LblX1.Name = "LblX1";
            this.LblX1.Size = new System.Drawing.Size(17, 12);
            this.LblX1.TabIndex = 10;
            this.LblX1.Text = "x1";
            // 
            // LblYen10000
            // 
            this.LblYen10000.AutoSize = true;
            this.LblYen10000.Location = new System.Drawing.Point(1, 118);
            this.LblYen10000.MinimumSize = new System.Drawing.Size(49, 12);
            this.LblYen10000.Name = "LblYen10000";
            this.LblYen10000.Size = new System.Drawing.Size(49, 12);
            this.LblYen10000.TabIndex = 9;
            this.LblYen10000.Text = "\\10,000";
            this.LblYen10000.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblYen5000
            // 
            this.LblYen5000.AutoSize = true;
            this.LblYen5000.Location = new System.Drawing.Point(1, 191);
            this.LblYen5000.MinimumSize = new System.Drawing.Size(49, 12);
            this.LblYen5000.Name = "LblYen5000";
            this.LblYen5000.Size = new System.Drawing.Size(49, 12);
            this.LblYen5000.TabIndex = 7;
            this.LblYen5000.Text = "\\5,000";
            this.LblYen5000.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TabBalance
            // 
            this.TabBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabBalance.Controls.Add(this.DgvBalance);
            this.TabBalance.Location = new System.Drawing.Point(4, 21);
            this.TabBalance.Name = "TabBalance";
            this.TabBalance.Padding = new System.Windows.Forms.Padding(3);
            this.TabBalance.Size = new System.Drawing.Size(408, 291);
            this.TabBalance.TabIndex = 3;
            this.TabBalance.Text = "収支";
            this.TabBalance.UseVisualStyleBackColor = true;
            // 
            // DgvBalance
            // 
            this.DgvBalance.AllowUserToAddRows = false;
            this.DgvBalance.AllowUserToDeleteRows = false;
            this.DgvBalance.AllowUserToResizeColumns = false;
            this.DgvBalance.AllowUserToResizeRows = false;
            this.DgvBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColYear,
            this.ColEarn,
            this.ColExpense,
            this.ColSpecial,
            this.ColBalance});
            this.DgvBalance.Location = new System.Drawing.Point(6, 6);
            this.DgvBalance.MultiSelect = false;
            this.DgvBalance.Name = "DgvBalance";
            this.DgvBalance.ReadOnly = true;
            this.DgvBalance.RowHeadersWidth = 24;
            this.DgvBalance.RowTemplate.Height = 21;
            this.DgvBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvBalance.Size = new System.Drawing.Size(392, 275);
            this.DgvBalance.TabIndex = 64;
            // 
            // ColYear
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColYear.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColYear.HeaderText = "年度";
            this.ColYear.Name = "ColYear";
            this.ColYear.ReadOnly = true;
            this.ColYear.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColYear.Width = 45;
            // 
            // ColEarn
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C0";
            this.ColEarn.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColEarn.HeaderText = "収入";
            this.ColEarn.Name = "ColEarn";
            this.ColEarn.ReadOnly = true;
            this.ColEarn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEarn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEarn.Width = 75;
            // 
            // ColExpense
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C0";
            this.ColExpense.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColExpense.HeaderText = "支出";
            this.ColExpense.Name = "ColExpense";
            this.ColExpense.ReadOnly = true;
            this.ColExpense.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColExpense.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColExpense.Width = 75;
            // 
            // ColSpecial
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C0";
            this.ColSpecial.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColSpecial.HeaderText = "特出";
            this.ColSpecial.Name = "ColSpecial";
            this.ColSpecial.ReadOnly = true;
            this.ColSpecial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColSpecial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSpecial.Width = 75;
            // 
            // ColBalance
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C0";
            this.ColBalance.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColBalance.HeaderText = "収支";
            this.ColBalance.Name = "ColBalance";
            this.ColBalance.ReadOnly = true;
            this.ColBalance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColBalance.Width = 75;
            // 
            // LblHous
            // 
            this.LblHous.Label = "家賃";
            this.LblHous.Location = new System.Drawing.Point(217, 50);
            this.LblHous.Name = "LblHous";
            this.LblHous.Size = new System.Drawing.Size(120, 12);
            this.LblHous.TabIndex = 53;
            // 
            // LblPlay
            // 
            this.LblPlay.Label = "遊行費";
            this.LblPlay.Location = new System.Drawing.Point(36, 185);
            this.LblPlay.Name = "LblPlay";
            this.LblPlay.Size = new System.Drawing.Size(120, 12);
            this.LblPlay.TabIndex = 52;
            // 
            // LblTrfc
            // 
            this.LblTrfc.Label = "交通費";
            this.LblTrfc.Location = new System.Drawing.Point(36, 162);
            this.LblTrfc.Name = "LblTrfc";
            this.LblTrfc.Size = new System.Drawing.Size(120, 12);
            this.LblTrfc.TabIndex = 51;
            // 
            // LblFrnd
            // 
            this.LblFrnd.Label = "交際費";
            this.LblFrnd.Location = new System.Drawing.Point(36, 139);
            this.LblFrnd.Name = "LblFrnd";
            this.LblFrnd.Size = new System.Drawing.Size(120, 12);
            this.LblFrnd.TabIndex = 50;
            // 
            // LblGood
            // 
            this.LblGood.Label = "雑貨";
            this.LblGood.Location = new System.Drawing.Point(36, 116);
            this.LblGood.Name = "LblGood";
            this.LblGood.Size = new System.Drawing.Size(120, 12);
            this.LblGood.TabIndex = 49;
            // 
            // LblOtfd
            // 
            this.LblOtfd.Label = "外食費";
            this.LblOtfd.Location = new System.Drawing.Point(36, 73);
            this.LblOtfd.Name = "LblOtfd";
            this.LblOtfd.Size = new System.Drawing.Size(120, 12);
            this.LblOtfd.TabIndex = 48;
            // 
            // LblFood
            // 
            this.LblFood.Label = "食費";
            this.LblFood.Location = new System.Drawing.Point(36, 50);
            this.LblFood.Name = "LblFood";
            this.LblFood.Size = new System.Drawing.Size(120, 12);
            this.LblFood.TabIndex = 47;
            // 
            // LblEngy
            // 
            this.LblEngy.Label = "光熱費";
            this.LblEngy.Location = new System.Drawing.Point(217, 73);
            this.LblEngy.Name = "LblEngy";
            this.LblEngy.Size = new System.Drawing.Size(120, 12);
            this.LblEngy.TabIndex = 54;
            // 
            // LblCnct
            // 
            this.LblCnct.Label = "通信費";
            this.LblCnct.Location = new System.Drawing.Point(217, 116);
            this.LblCnct.Name = "LblCnct";
            this.LblCnct.Size = new System.Drawing.Size(120, 12);
            this.LblCnct.TabIndex = 55;
            // 
            // LblMedi
            // 
            this.LblMedi.Label = "医療費";
            this.LblMedi.Location = new System.Drawing.Point(217, 139);
            this.LblMedi.Name = "LblMedi";
            this.LblMedi.Size = new System.Drawing.Size(120, 12);
            this.LblMedi.TabIndex = 56;
            // 
            // LblInsu
            // 
            this.LblInsu.Label = "保険料";
            this.LblInsu.Location = new System.Drawing.Point(217, 162);
            this.LblInsu.Name = "LblInsu";
            this.LblInsu.Size = new System.Drawing.Size(120, 12);
            this.LblInsu.TabIndex = 57;
            // 
            // LblOthr
            // 
            this.LblOthr.Label = "その他";
            this.LblOthr.Location = new System.Drawing.Point(217, 185);
            this.LblOthr.Name = "LblOthr";
            this.LblOthr.Size = new System.Drawing.Size(120, 12);
            this.LblOthr.TabIndex = 58;
            // 
            // LblTtal
            // 
            this.LblTtal.Label = "合計";
            this.LblTtal.Location = new System.Drawing.Point(217, 228);
            this.LblTtal.Name = "LblTtal";
            this.LblTtal.Size = new System.Drawing.Size(120, 12);
            this.LblTtal.TabIndex = 59;
            // 
            // LblBlnc
            // 
            this.LblBlnc.Label = "残金";
            this.LblBlnc.Location = new System.Drawing.Point(217, 251);
            this.LblBlnc.Name = "LblBlnc";
            this.LblBlnc.Size = new System.Drawing.Size(120, 12);
            this.LblBlnc.TabIndex = 60;
            // 
            // HeadGraphic
            // 
            this.HeadGraphic.Location = new System.Drawing.Point(84, 6);
            this.HeadGraphic.Name = "HeadGraphic";
            this.HeadGraphic.Size = new System.Drawing.Size(227, 29);
            this.HeadGraphic.TabIndex = 27;
            this.HeadGraphic.Title = "9999年99月";
            this.HeadGraphic.NextYearClick += new System.EventHandler(this.HeadGraphic_NextYearClick);
            this.HeadGraphic.NextMonthClick += new System.EventHandler(this.HeadGraphic_NextMonthClick);
            this.HeadGraphic.PrevYearClick += new System.EventHandler(this.HeadGraphic_PrevYearClick);
            this.HeadGraphic.PrevMonthClick += new System.EventHandler(this.HeadGraphic_PrevMonthClick);
            // 
            // AbFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 343);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "AbFormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abook";
            this.Load += new System.EventHandler(this.AbFormMain_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.TabExpense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpense)).EndInit();
            this.TabSummary.ResumeLayout(false);
            this.TabSummary.PerformLayout();
            this.TabGraph.ResumeLayout(false);
            this.TabGraph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PboxGraph)).EndInit();
            this.TabBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuVersion;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabSummary;
        private System.Windows.Forms.TabPage TabExpense;
        private System.Windows.Forms.Label LblLine;
        private System.Windows.Forms.Button BtnEntry;
        private System.Windows.Forms.DataGridView DgvExpense;
        private System.Windows.Forms.Button BtnAddRow;
        private System.Windows.Forms.TabPage TabGraph;
        private System.Windows.Forms.Label LblX1;
        private System.Windows.Forms.Label LblYen10000;
        private System.Windows.Forms.Label LblYen5000;
        private System.Windows.Forms.PictureBox PboxGraph;
        private System.Windows.Forms.Label LblX6;
        private System.Windows.Forms.Label LblX5;
        private System.Windows.Forms.Label LblX4;
        private System.Windows.Forms.Label LblX3;
        private System.Windows.Forms.Label LblX2;
        private System.Windows.Forms.Label LblLine2;
        private System.Windows.Forms.Label LblLine水道代;
        private System.Windows.Forms.Label LblLineガス代;
        private System.Windows.Forms.Label LblLine電気代;
        private System.Windows.Forms.Label LblLine外食費;
        private System.Windows.Forms.Label LblLine食費;
        private System.Windows.Forms.Label LblLineBlue;
        private System.Windows.Forms.Label LblLineGray;
        private System.Windows.Forms.Label LblLineYellow;
        private System.Windows.Forms.Label LblLineOrange;
        private System.Windows.Forms.Label LblLineRed;
        private System.Windows.Forms.TabPage TabBalance;
        private System.Windows.Forms.DataGridView DgvBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEarn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSpecial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBalance;
        private AbLabelControl LblFood;
        private AbLabelControl LblPlay;
        private AbLabelControl LblTrfc;
        private AbLabelControl LblFrnd;
        private AbLabelControl LblGood;
        private AbLabelControl LblOtfd;
        private AbLabelControl LblHous;
        private AbLabelControl LblOthr;
        private AbLabelControl LblInsu;
        private AbLabelControl LblMedi;
        private AbLabelControl LblCnct;
        private AbLabelControl LblEngy;
        private AbLabelControl LblBlnc;
        private AbLabelControl LblTtal;
        private AbHeaderControl HeadSummary;
        private AbHeaderControl HeadGraphic;
    }
}