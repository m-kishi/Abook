namespace Abook
{
    using System.ComponentModel;

    /// <summary>
    /// メイン画面フォームデザイナ
    /// </summary>
    partial class AbFormMain
    {
        /// <summary>デザイナ変数</summary>
        private IContainer components = null;

        /// <summary>
        /// リソース破棄
        /// </summary>
        /// <param name="disposing">マネージリソース破棄</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// コンポーネント初期化
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle styleDate    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleName    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleType    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleCost    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleYear    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEarn    = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleExpense = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleSpecial = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleBalance = new System.Windows.Forms.DataGridViewCellStyle();
            this.MenuStrip     = new System.Windows.Forms.MenuStrip();
            this.MenuFile      = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit      = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp      = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVersion   = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl    = new System.Windows.Forms.TabControl();
            this.TabExpense    = new System.Windows.Forms.TabPage();
            this.BtnEntry      = new System.Windows.Forms.Button();
            this.BtnAddRow     = new System.Windows.Forms.Button();
            this.DgvExpense    = new System.Windows.Forms.DataGridView();
            this.ColDate       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCost       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabSummary    = new System.Windows.Forms.TabPage();
            this.HeadSummary   = new Abook.AbHeaderControl();
            this.LblFood       = new Abook.AbLabelControl();
            this.LblOtfd       = new Abook.AbLabelControl();
            this.LblGood       = new Abook.AbLabelControl();
            this.LblFrnd       = new Abook.AbLabelControl();
            this.LblTrfc       = new Abook.AbLabelControl();
            this.LblPlay       = new Abook.AbLabelControl();
            this.LblHous       = new Abook.AbLabelControl();
            this.LblEngy       = new Abook.AbLabelControl();
            this.LblCnct       = new Abook.AbLabelControl();
            this.LblMedi       = new Abook.AbLabelControl();
            this.LblInsu       = new Abook.AbLabelControl();
            this.LblOthr       = new Abook.AbLabelControl();
            this.LblTtal       = new Abook.AbLabelControl();
            this.LblBlnc       = new Abook.AbLabelControl();
            this.LblLine1      = new System.Windows.Forms.Label();
            this.LblLine2      = new System.Windows.Forms.Label();
            this.TabGraphic    = new System.Windows.Forms.TabPage();
            this.HeadGraphic   = new Abook.AbHeaderControl();
            this.PboxGraph     = new System.Windows.Forms.PictureBox();
            this.LblLineRed    = new System.Windows.Forms.Label();
            this.LblLineOrange = new System.Windows.Forms.Label();
            this.LblLineYellow = new System.Windows.Forms.Label();
            this.LblLineGray   = new System.Windows.Forms.Label();
            this.LblLineBlue   = new System.Windows.Forms.Label();
            this.LblLineFood   = new System.Windows.Forms.Label();
            this.LblLineOtfd   = new System.Windows.Forms.Label();
            this.LblLineEl     = new System.Windows.Forms.Label();
            this.LblLineGS     = new System.Windows.Forms.Label();
            this.LblLineWT     = new System.Windows.Forms.Label();
            this.LblX1         = new System.Windows.Forms.Label();
            this.LblX2         = new System.Windows.Forms.Label();
            this.LblX3         = new System.Windows.Forms.Label();
            this.LblX4         = new System.Windows.Forms.Label();
            this.LblX5         = new System.Windows.Forms.Label();
            this.LblX6         = new System.Windows.Forms.Label();
            this.LblYen5000    = new System.Windows.Forms.Label();
            this.LblYen10000   = new System.Windows.Forms.Label();
            this.TabBalance    = new System.Windows.Forms.TabPage();
            this.DgvBalance    = new System.Windows.Forms.DataGridView();
            this.ColYear       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEarn       = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColExpense    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSpecial    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBalance    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuStrip.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.TabExpense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpense)).BeginInit();
            this.TabSummary.SuspendLayout();
            this.TabGraphic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PboxGraph)).BeginInit();
            this.TabBalance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuFile, this.MenuHelp });
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(416, 24);
            this.MenuStrip.TabIndex = 0;
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuExit });
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
            this.MenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.MenuVersion });
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
            this.TabControl.Controls.Add(this.TabGraphic);
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
            this.TabExpense.Controls.Add(this.BtnEntry);
            this.TabExpense.Controls.Add(this.BtnAddRow);
            this.TabExpense.Controls.Add(this.DgvExpense);
            this.TabExpense.Location = new System.Drawing.Point(4, 21);
            this.TabExpense.Name = "TabExpense";
            this.TabExpense.Padding = new System.Windows.Forms.Padding(3);
            this.TabExpense.Size = new System.Drawing.Size(408, 291);
            this.TabExpense.TabIndex = 2;
            this.TabExpense.Text = "支出";
            this.TabExpense.UseVisualStyleBackColor = true;
            // 
            // BtnEntry
            // 
            this.BtnEntry.Location = new System.Drawing.Point(301, 6);
            this.BtnEntry.Name = "BtnEntry";
            this.BtnEntry.Size = new System.Drawing.Size(50, 23);
            this.BtnEntry.TabIndex = 3;
            this.BtnEntry.Text = "登録";
            this.BtnEntry.UseVisualStyleBackColor = true;
            this.BtnEntry.Click += new System.EventHandler(this.BtnEntry_Click);
            // 
            // BtnAddRow
            // 
            this.BtnAddRow.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnAddRow.Location = new System.Drawing.Point(361, 6);
            this.BtnAddRow.Name = "BtnAddRow";
            this.BtnAddRow.Size = new System.Drawing.Size(37, 23);
            this.BtnAddRow.TabIndex = 4;
            this.BtnAddRow.Text = "＋";
            this.BtnAddRow.UseVisualStyleBackColor = true;
            this.BtnAddRow.Click += new System.EventHandler(this.BtnAddRow_Click);
            // 
            // DgvExpense
            // 
            this.DgvExpense.AllowUserToAddRows = false;
            this.DgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ColDate, this.ColName, this.ColType, this.ColCost });
            this.DgvExpense.Location = new System.Drawing.Point(6, 35);
            this.DgvExpense.Name = "DgvExpense";
            this.DgvExpense.RowHeadersWidth = 24;
            this.DgvExpense.RowTemplate.Height = 21;
            this.DgvExpense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvExpense.Size = new System.Drawing.Size(392, 246);
            this.DgvExpense.TabIndex = 5;
            this.DgvExpense.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvExpense_CellEndEdit);
            this.DgvExpense.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvExpense_KeyDown);
            // 
            // ColDate
            // 
            styleDate.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColDate.DefaultCellStyle = styleDate;
            this.ColDate.HeaderText = "日付";
            this.ColDate.Name = "ColDate";
            this.ColDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColDate.Width = 90;
            // 
            // ColName
            // 
            styleName.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColName.DefaultCellStyle = styleName;
            this.ColName.HeaderText = "名称";
            this.ColName.Name = "ColName";
            this.ColName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColName.Width = 120;
            // 
            // ColType
            // 
            styleType.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColType.DefaultCellStyle = styleType;
            this.ColType.HeaderText = "種別";
            this.ColType.Name = "ColType";
            this.ColType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColType.Width = 75;
            // 
            // ColCost
            // 
            styleCost.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleCost.Format = "N0";
            this.ColCost.DefaultCellStyle = styleCost;
            this.ColCost.HeaderText = "金額";
            this.ColCost.Name = "ColCost";
            this.ColCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCost.Width = 60;
            // 
            // TabSummary
            // 
            this.TabSummary.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabSummary.Controls.Add(this.HeadSummary);
            this.TabSummary.Controls.Add(this.LblFood);
            this.TabSummary.Controls.Add(this.LblOtfd);
            this.TabSummary.Controls.Add(this.LblGood);
            this.TabSummary.Controls.Add(this.LblFrnd);
            this.TabSummary.Controls.Add(this.LblTrfc);
            this.TabSummary.Controls.Add(this.LblPlay);
            this.TabSummary.Controls.Add(this.LblHous);
            this.TabSummary.Controls.Add(this.LblEngy);
            this.TabSummary.Controls.Add(this.LblCnct);
            this.TabSummary.Controls.Add(this.LblMedi);
            this.TabSummary.Controls.Add(this.LblInsu);
            this.TabSummary.Controls.Add(this.LblOthr);
            this.TabSummary.Controls.Add(this.LblTtal);
            this.TabSummary.Controls.Add(this.LblBlnc);
            this.TabSummary.Controls.Add(this.LblLine1);
            this.TabSummary.Controls.Add(this.LblLine2);
            this.TabSummary.Location = new System.Drawing.Point(4, 21);
            this.TabSummary.Name = "TabSummary";
            this.TabSummary.Padding = new System.Windows.Forms.Padding(3);
            this.TabSummary.Size = new System.Drawing.Size(408, 291);
            this.TabSummary.TabIndex = 6;
            this.TabSummary.Text = "集計";
            this.TabSummary.UseVisualStyleBackColor = true;
            // 
            // HeadSummary
            // 
            this.HeadSummary.Location = new System.Drawing.Point(84, 6);
            this.HeadSummary.Name = "HeadSummary";
            this.HeadSummary.Size = new System.Drawing.Size(227, 29);
            this.HeadSummary.TabIndex = 7;
            this.HeadSummary.Title = "9999年99月";
            this.HeadSummary.PrevYearClick  += new System.EventHandler(this.HeadSummary_PrevYearClick);
            this.HeadSummary.PrevMonthClick += new System.EventHandler(this.HeadSummary_PrevMonthClick);
            this.HeadSummary.NextMonthClick += new System.EventHandler(this.HeadSummary_NextMonthClick);
            this.HeadSummary.NextYearClick  += new System.EventHandler(this.HeadSummary_NextYearClick);
            // 
            // LblFood
            // 
            this.LblFood.Label = "食費";
            this.LblFood.Location = new System.Drawing.Point(36, 50);
            this.LblFood.Name = "LblFood";
            this.LblFood.Size = new System.Drawing.Size(120, 12);
            this.LblFood.TabIndex = 8;
            // 
            // LblOtfd
            // 
            this.LblOtfd.Label = "外食費";
            this.LblOtfd.Location = new System.Drawing.Point(36, 73);
            this.LblOtfd.Name = "LblOtfd";
            this.LblOtfd.Size = new System.Drawing.Size(120, 12);
            this.LblOtfd.TabIndex = 9;
            // 
            // LblGood
            // 
            this.LblGood.Label = "雑貨";
            this.LblGood.Location = new System.Drawing.Point(36, 116);
            this.LblGood.Name = "LblGood";
            this.LblGood.Size = new System.Drawing.Size(120, 12);
            this.LblGood.TabIndex = 10;
            // 
            // LblFrnd
            // 
            this.LblFrnd.Label = "交際費";
            this.LblFrnd.Location = new System.Drawing.Point(36, 139);
            this.LblFrnd.Name = "LblFrnd";
            this.LblFrnd.Size = new System.Drawing.Size(120, 12);
            this.LblFrnd.TabIndex = 11;
            // 
            // LblTrfc
            // 
            this.LblTrfc.Label = "交通費";
            this.LblTrfc.Location = new System.Drawing.Point(36, 162);
            this.LblTrfc.Name = "LblTrfc";
            this.LblTrfc.Size = new System.Drawing.Size(120, 12);
            this.LblTrfc.TabIndex = 12;
            // 
            // LblPlay
            // 
            this.LblPlay.Label = "遊行費";
            this.LblPlay.Location = new System.Drawing.Point(36, 185);
            this.LblPlay.Name = "LblPlay";
            this.LblPlay.Size = new System.Drawing.Size(120, 12);
            this.LblPlay.TabIndex = 13;
            // 
            // LblHous
            // 
            this.LblHous.Label = "家賃";
            this.LblHous.Location = new System.Drawing.Point(217, 50);
            this.LblHous.Name = "LblHous";
            this.LblHous.Size = new System.Drawing.Size(120, 12);
            this.LblHous.TabIndex = 14;
            // 
            // LblEngy
            // 
            this.LblEngy.Label = "光熱費";
            this.LblEngy.Location = new System.Drawing.Point(217, 73);
            this.LblEngy.Name = "LblEngy";
            this.LblEngy.Size = new System.Drawing.Size(120, 12);
            this.LblEngy.TabIndex = 15;
            // 
            // LblCnct
            // 
            this.LblCnct.Label = "通信費";
            this.LblCnct.Location = new System.Drawing.Point(217, 116);
            this.LblCnct.Name = "LblCnct";
            this.LblCnct.Size = new System.Drawing.Size(120, 12);
            this.LblCnct.TabIndex = 16;
            // 
            // LblMedi
            // 
            this.LblMedi.Label = "医療費";
            this.LblMedi.Location = new System.Drawing.Point(217, 139);
            this.LblMedi.Name = "LblMedi";
            this.LblMedi.Size = new System.Drawing.Size(120, 12);
            this.LblMedi.TabIndex = 17;
            // 
            // LblInsu
            // 
            this.LblInsu.Label = "保険料";
            this.LblInsu.Location = new System.Drawing.Point(217, 162);
            this.LblInsu.Name = "LblInsu";
            this.LblInsu.Size = new System.Drawing.Size(120, 12);
            this.LblInsu.TabIndex = 18;
            // 
            // LblOthr
            // 
            this.LblOthr.Label = "その他";
            this.LblOthr.Location = new System.Drawing.Point(217, 185);
            this.LblOthr.Name = "LblOthr";
            this.LblOthr.Size = new System.Drawing.Size(120, 12);
            this.LblOthr.TabIndex = 19;
            // 
            // LblTtal
            // 
            this.LblTtal.Label = "合計";
            this.LblTtal.Location = new System.Drawing.Point(217, 228);
            this.LblTtal.Name = "LblTtal";
            this.LblTtal.Size = new System.Drawing.Size(120, 12);
            this.LblTtal.TabIndex = 20;
            // 
            // LblBlnc
            // 
            this.LblBlnc.Label = "残金";
            this.LblBlnc.Location = new System.Drawing.Point(217, 251);
            this.LblBlnc.Name = "LblBlnc";
            this.LblBlnc.Size = new System.Drawing.Size(120, 12);
            this.LblBlnc.TabIndex = 21;
            // 
            // LblLine1
            // 
            this.LblLine1.AutoSize = true;
            this.LblLine1.Location = new System.Drawing.Point(26, 96);
            this.LblLine1.Name = "LblLine1";
            this.LblLine1.Size = new System.Drawing.Size(323, 12);
            this.LblLine1.TabIndex = 22;
            this.LblLine1.Text = "-----------------------------------------------------";
            // 
            // LblLine2
            // 
            this.LblLine2.AutoSize = true;
            this.LblLine2.Location = new System.Drawing.Point(206, 208);
            this.LblLine2.Name = "LblLine2";
            this.LblLine2.Size = new System.Drawing.Size(143, 12);
            this.LblLine2.TabIndex = 23;
            this.LblLine2.Text = "-----------------------";
            // 
            // TabGraphic
            // 
            this.TabGraphic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabGraphic.Controls.Add(this.HeadGraphic);
            this.TabGraphic.Controls.Add(this.PboxGraph);
            this.TabGraphic.Controls.Add(this.LblLineRed);
            this.TabGraphic.Controls.Add(this.LblLineOrange);
            this.TabGraphic.Controls.Add(this.LblLineYellow);
            this.TabGraphic.Controls.Add(this.LblLineGray);
            this.TabGraphic.Controls.Add(this.LblLineBlue);
            this.TabGraphic.Controls.Add(this.LblLineEl);
            this.TabGraphic.Controls.Add(this.LblLineGS);
            this.TabGraphic.Controls.Add(this.LblLineWT);
            this.TabGraphic.Controls.Add(this.LblLineOtfd);
            this.TabGraphic.Controls.Add(this.LblLineFood);
            this.TabGraphic.Controls.Add(this.LblX1);
            this.TabGraphic.Controls.Add(this.LblX2);
            this.TabGraphic.Controls.Add(this.LblX3);
            this.TabGraphic.Controls.Add(this.LblX4);
            this.TabGraphic.Controls.Add(this.LblX5);
            this.TabGraphic.Controls.Add(this.LblX6);
            this.TabGraphic.Controls.Add(this.LblYen5000);
            this.TabGraphic.Controls.Add(this.LblYen10000);
            this.TabGraphic.Location = new System.Drawing.Point(4, 21);
            this.TabGraphic.Name = "TabGraphic";
            this.TabGraphic.Padding = new System.Windows.Forms.Padding(3);
            this.TabGraphic.Size = new System.Drawing.Size(408, 291);
            this.TabGraphic.TabIndex = 24;
            this.TabGraphic.Text = "グラフ";
            this.TabGraphic.UseVisualStyleBackColor = true;
            // 
            // HeadGraphic
            // 
            this.HeadGraphic.Location = new System.Drawing.Point(84, 6);
            this.HeadGraphic.Name = "HeadGraphic";
            this.HeadGraphic.Size = new System.Drawing.Size(227, 29);
            this.HeadGraphic.TabIndex = 25;
            this.HeadGraphic.Title = "9999年99月";
            this.HeadGraphic.PrevYearClick  += new System.EventHandler(this.HeadGraphic_PrevYearClick);
            this.HeadGraphic.PrevMonthClick += new System.EventHandler(this.HeadGraphic_PrevMonthClick);
            this.HeadGraphic.NextMonthClick += new System.EventHandler(this.HeadGraphic_NextMonthClick);
            this.HeadGraphic.NextYearClick  += new System.EventHandler(this.HeadGraphic_NextYearClick);
            // 
            // PboxGraph
            // 
            this.PboxGraph.BackColor = System.Drawing.SystemColors.ControlText;
            this.PboxGraph.Location = new System.Drawing.Point(49, 51);
            this.PboxGraph.Name = "PboxGraph";
            this.PboxGraph.Size = new System.Drawing.Size(349, 218);
            this.PboxGraph.TabIndex = 38;
            this.PboxGraph.TabStop = false;
            this.PboxGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.PboxGraph_Paint);
            // 
            // LblLineRed
            // 
            this.LblLineRed.AutoSize = true;
            this.LblLineRed.ForeColor = System.Drawing.Color.Red;
            this.LblLineRed.Location = new System.Drawing.Point(49, 36);
            this.LblLineRed.Name = "LblLineRed";
            this.LblLineRed.Size = new System.Drawing.Size(17, 12);
            this.LblLineRed.TabIndex = 26;
            this.LblLineRed.Text = "--";
            // 
            // LblLineOrange
            // 
            this.LblLineOrange.AutoSize = true;
            this.LblLineOrange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LblLineOrange.Location = new System.Drawing.Point(97, 36);
            this.LblLineOrange.Name = "LblLineOrange";
            this.LblLineOrange.Size = new System.Drawing.Size(17, 12);
            this.LblLineOrange.TabIndex = 28;
            this.LblLineOrange.Text = "--";
            // 
            // LblLineYellow
            // 
            this.LblLineYellow.AutoSize = true;
            this.LblLineYellow.ForeColor = System.Drawing.Color.Yellow;
            this.LblLineYellow.Location = new System.Drawing.Point(160, 36);
            this.LblLineYellow.Name = "LblLineYellow";
            this.LblLineYellow.Size = new System.Drawing.Size(17, 12);
            this.LblLineYellow.TabIndex = 30;
            this.LblLineYellow.Text = "--";
            // 
            // LblLineGray
            // 
            this.LblLineGray.AutoSize = true;
            this.LblLineGray.ForeColor = System.Drawing.Color.Silver;
            this.LblLineGray.Location = new System.Drawing.Point(228, 36);
            this.LblLineGray.Name = "LblLineGray";
            this.LblLineGray.Size = new System.Drawing.Size(17, 12);
            this.LblLineGray.TabIndex = 32;
            this.LblLineGray.Text = "--";
            // 
            // LblLineBlue
            // 
            this.LblLineBlue.AutoSize = true;
            this.LblLineBlue.ForeColor = System.Drawing.Color.Blue;
            this.LblLineBlue.Location = new System.Drawing.Point(290, 36);
            this.LblLineBlue.Name = "LblLineBlue";
            this.LblLineBlue.Size = new System.Drawing.Size(17, 12);
            this.LblLineBlue.TabIndex = 34;
            this.LblLineBlue.Text = "--";
            // 
            // LblLineFood
            // 
            this.LblLineFood.AutoSize = true;
            this.LblLineFood.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblLineFood.Location = new System.Drawing.Point(63, 36);
            this.LblLineFood.Name = "LblLineFood";
            this.LblLineFood.Size = new System.Drawing.Size(29, 12);
            this.LblLineFood.TabIndex = 27;
            this.LblLineFood.Text = "食費";
            // 
            // LblLineOtfd
            // 
            this.LblLineOtfd.AutoSize = true;
            this.LblLineOtfd.Location = new System.Drawing.Point(112, 36);
            this.LblLineOtfd.Name = "LblLineOtfd";
            this.LblLineOtfd.Size = new System.Drawing.Size(41, 12);
            this.LblLineOtfd.TabIndex = 29;
            this.LblLineOtfd.Text = "外食費";
            // 
            // LblLineEl
            // 
            this.LblLineEl.AutoSize = true;
            this.LblLineEl.Location = new System.Drawing.Point(176, 36);
            this.LblLineEl.Name = "LblLineEl";
            this.LblLineEl.Size = new System.Drawing.Size(41, 12);
            this.LblLineEl.TabIndex = 31;
            this.LblLineEl.Text = "電気代";
            // 
            // LblLineGS
            // 
            this.LblLineGS.AutoSize = true;
            this.LblLineGS.Location = new System.Drawing.Point(243, 36);
            this.LblLineGS.Name = "LblLineGS";
            this.LblLineGS.Size = new System.Drawing.Size(36, 12);
            this.LblLineGS.TabIndex = 33;
            this.LblLineGS.Text = "ガス代";
            // 
            // LblLineWT
            // 
            this.LblLineWT.AutoSize = true;
            this.LblLineWT.Location = new System.Drawing.Point(306, 36);
            this.LblLineWT.Name = "LblLineWT";
            this.LblLineWT.Size = new System.Drawing.Size(41, 12);
            this.LblLineWT.TabIndex = 35;
            this.LblLineWT.Text = "水道代";
            // 
            // LblX1
            // 
            this.LblX1.AutoSize = true;
            this.LblX1.Location = new System.Drawing.Point(95, 271);
            this.LblX1.Name = "LblX1";
            this.LblX1.Size = new System.Drawing.Size(17, 12);
            this.LblX1.TabIndex = 39;
            this.LblX1.Text = "x1";
            // 
            // LblX2
            // 
            this.LblX2.AutoSize = true;
            this.LblX2.Location = new System.Drawing.Point(149, 272);
            this.LblX2.Name = "LblX2";
            this.LblX2.Size = new System.Drawing.Size(17, 12);
            this.LblX2.TabIndex = 40;
            this.LblX2.Text = "x2";
            // 
            // LblX3
            // 
            this.LblX3.AutoSize = true;
            this.LblX3.Location = new System.Drawing.Point(203, 272);
            this.LblX3.Name = "LblX3";
            this.LblX3.Size = new System.Drawing.Size(17, 12);
            this.LblX3.TabIndex = 41;
            this.LblX3.Text = "x3";
            // 
            // LblX4
            // 
            this.LblX4.AutoSize = true;
            this.LblX4.Location = new System.Drawing.Point(256, 272);
            this.LblX4.Name = "LblX4";
            this.LblX4.Size = new System.Drawing.Size(17, 12);
            this.LblX4.TabIndex = 42;
            this.LblX4.Text = "x4";
            // 
            // LblX5
            // 
            this.LblX5.AutoSize = true;
            this.LblX5.Location = new System.Drawing.Point(310, 272);
            this.LblX5.Name = "LblX5";
            this.LblX5.Size = new System.Drawing.Size(17, 12);
            this.LblX5.TabIndex = 43;
            this.LblX5.Text = "x5";
            // 
            // LblX6
            // 
            this.LblX6.AutoSize = true;
            this.LblX6.Location = new System.Drawing.Point(364, 272);
            this.LblX6.Name = "LblX6";
            this.LblX6.Size = new System.Drawing.Size(17, 12);
            this.LblX6.TabIndex = 44;
            this.LblX6.Text = "x6";
            // 
            // LblYen5000
            // 
            this.LblYen5000.AutoSize = true;
            this.LblYen5000.Location = new System.Drawing.Point(1, 191);
            this.LblYen5000.MinimumSize = new System.Drawing.Size(49, 12);
            this.LblYen5000.Name = "LblYen5000";
            this.LblYen5000.Size = new System.Drawing.Size(49, 12);
            this.LblYen5000.TabIndex = 37;
            this.LblYen5000.Text = "\\5,000";
            this.LblYen5000.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblYen10000
            // 
            this.LblYen10000.AutoSize = true;
            this.LblYen10000.Location = new System.Drawing.Point(1, 118);
            this.LblYen10000.MinimumSize = new System.Drawing.Size(49, 12);
            this.LblYen10000.Name = "LblYen10000";
            this.LblYen10000.Size = new System.Drawing.Size(49, 12);
            this.LblYen10000.TabIndex = 36;
            this.LblYen10000.Text = "\\10,000";
            this.LblYen10000.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TabBalance
            // 
            this.TabBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TabBalance.Controls.Add(this.DgvBalance);
            this.TabBalance.Location = new System.Drawing.Point(4, 21);
            this.TabBalance.Name = "TabBalance";
            this.TabBalance.Padding = new System.Windows.Forms.Padding(3);
            this.TabBalance.Size = new System.Drawing.Size(408, 291);
            this.TabBalance.TabIndex = 45;
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
            this.DgvBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ColYear, this.ColEarn, this.ColExpense, this.ColSpecial, this.ColBalance });
            this.DgvBalance.Location = new System.Drawing.Point(6, 6);
            this.DgvBalance.MultiSelect = false;
            this.DgvBalance.Name = "DgvBalance";
            this.DgvBalance.ReadOnly = true;
            this.DgvBalance.RowHeadersWidth = 24;
            this.DgvBalance.RowTemplate.Height = 21;
            this.DgvBalance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvBalance.Size = new System.Drawing.Size(392, 275);
            this.DgvBalance.TabIndex = 46;
            // 
            // ColYear
            // 
            styleYear.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColYear.DefaultCellStyle = styleYear;
            this.ColYear.HeaderText = "年度";
            this.ColYear.Name = "ColYear";
            this.ColYear.ReadOnly = true;
            this.ColYear.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColYear.Width = 45;
            // 
            // ColEarn
            // 
            styleEarn.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEarn.Format = "C0";
            this.ColEarn.DefaultCellStyle = styleEarn;
            this.ColEarn.HeaderText = "収入";
            this.ColEarn.Name = "ColEarn";
            this.ColEarn.ReadOnly = true;
            this.ColEarn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEarn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEarn.Width = 75;
            // 
            // ColExpense
            // 
            styleExpense.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleExpense.Format = "C0";
            this.ColExpense.DefaultCellStyle = styleExpense;
            this.ColExpense.HeaderText = "支出";
            this.ColExpense.Name = "ColExpense";
            this.ColExpense.ReadOnly = true;
            this.ColExpense.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColExpense.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColExpense.Width = 75;
            // 
            // ColSpecial
            // 
            styleSpecial.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleSpecial.Format = "C0";
            this.ColSpecial.DefaultCellStyle = styleSpecial;
            this.ColSpecial.HeaderText = "特出";
            this.ColSpecial.Name = "ColSpecial";
            this.ColSpecial.ReadOnly = true;
            this.ColSpecial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColSpecial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColSpecial.Width = 75;
            // 
            // ColBalance
            // 
            styleBalance.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleBalance.Format = "C0";
            this.ColBalance.DefaultCellStyle = styleBalance;
            this.ColBalance.HeaderText = "収支";
            this.ColBalance.Name = "ColBalance";
            this.ColBalance.ReadOnly = true;
            this.ColBalance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColBalance.Width = 75;
            // 
            // AbFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 343);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.TabControl);
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
            this.TabGraphic.ResumeLayout(false);
            this.TabGraphic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PboxGraph)).EndInit();
            this.TabBalance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.ToolStripMenuItem MenuVersion;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabExpense;
        private System.Windows.Forms.Button BtnEntry;
        private System.Windows.Forms.Button BtnAddRow;
        private System.Windows.Forms.DataGridView DgvExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCost;
        private System.Windows.Forms.TabPage TabSummary;
        private AbHeaderControl HeadSummary;
        private AbLabelControl LblFood;
        private AbLabelControl LblOtfd;
        private AbLabelControl LblGood;
        private AbLabelControl LblFrnd;
        private AbLabelControl LblTrfc;
        private AbLabelControl LblPlay;
        private AbLabelControl LblHous;
        private AbLabelControl LblEngy;
        private AbLabelControl LblCnct;
        private AbLabelControl LblMedi;
        private AbLabelControl LblInsu;
        private AbLabelControl LblOthr;
        private AbLabelControl LblTtal;
        private AbLabelControl LblBlnc;
        private System.Windows.Forms.Label LblLine1;
        private System.Windows.Forms.Label LblLine2;
        private System.Windows.Forms.TabPage TabGraphic;
        private AbHeaderControl HeadGraphic;
        private System.Windows.Forms.PictureBox PboxGraph;
        private System.Windows.Forms.Label LblLineRed;
        private System.Windows.Forms.Label LblLineOrange;
        private System.Windows.Forms.Label LblLineYellow;
        private System.Windows.Forms.Label LblLineGray;
        private System.Windows.Forms.Label LblLineBlue;
        private System.Windows.Forms.Label LblLineFood;
        private System.Windows.Forms.Label LblLineOtfd;
        private System.Windows.Forms.Label LblLineEl;
        private System.Windows.Forms.Label LblLineGS;
        private System.Windows.Forms.Label LblLineWT;
        private System.Windows.Forms.Label LblX1;
        private System.Windows.Forms.Label LblX2;
        private System.Windows.Forms.Label LblX3;
        private System.Windows.Forms.Label LblX4;
        private System.Windows.Forms.Label LblX5;
        private System.Windows.Forms.Label LblX6;
        private System.Windows.Forms.Label LblYen5000;
        private System.Windows.Forms.Label LblYen10000;
        private System.Windows.Forms.TabPage TabBalance;
        private System.Windows.Forms.DataGridView DgvBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEarn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSpecial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBalance;
    }
}
