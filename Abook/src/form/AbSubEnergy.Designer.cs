// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System.ComponentModel;

    /// <summary>
    /// 光熱費サブフォームデザイナ
    /// </summary>
    public partial class AbSubEnergy
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
            System.Windows.Forms.DataGridViewCellStyle styleElYr = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl04 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl05 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl06 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl07 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl08 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl09 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl01 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl02 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleEl03 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGsYr = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs04 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs05 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs06 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs07 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs08 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs09 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs01 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs02 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGs03 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWtYr = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt04 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt05 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt06 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt07 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt08 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt09 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt01 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt02 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleWt03 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabEl = new System.Windows.Forms.TabPage();
            this.TabGs = new System.Windows.Forms.TabPage();
            this.TabWt = new System.Windows.Forms.TabPage();
            this.DgvEl = new System.Windows.Forms.DataGridView();
            this.DgvGs = new System.Windows.Forms.DataGridView();
            this.DgvWt = new System.Windows.Forms.DataGridView();
            this.ColElYr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEl03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGsYr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGs03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWtYr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColWt03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabControl.SuspendLayout();
            this.TabEl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvEl)).BeginInit();
            this.TabGs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvGs)).BeginInit();
            this.TabWt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvWt)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabEl);
            this.TabControl.Controls.Add(this.TabGs);
            this.TabControl.Controls.Add(this.TabWt);
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(704, 308);
            this.TabControl.TabIndex = 0;
            // 
            // TabEl
            // 
            this.TabEl.Controls.Add(this.DgvEl);
            this.TabEl.Location = new System.Drawing.Point(4, 22);
            this.TabEl.Name = "TabEl";
            this.TabEl.Padding = new System.Windows.Forms.Padding(3);
            this.TabEl.Size = new System.Drawing.Size(696, 282);
            this.TabEl.TabIndex = 1;
            this.TabEl.Text = "電気代";
            this.TabEl.UseVisualStyleBackColor = true;
            // 
            // DgvEl
            // 
            this.DgvEl.AllowUserToAddRows = false;
            this.DgvEl.AllowUserToDeleteRows = false;
            this.DgvEl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvEl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ColElYr, this.ColEl04, this.ColEl05, this.ColEl06, this.ColEl07, this.ColEl08, this.ColEl09, this.ColEl10, this.ColEl11, this.ColEl12, this.ColEl01, this.ColEl02, this.ColEl03 });
            this.DgvEl.Location = new System.Drawing.Point(2, 3);
            this.DgvEl.Name = "DgvEl";
            this.DgvEl.ReadOnly = true;
            this.DgvEl.RowHeadersWidth = 24;
            this.DgvEl.RowTemplate.Height = 21;
            this.DgvEl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvEl.Size = new System.Drawing.Size(691, 275);
            this.DgvEl.TabIndex = 2;
            // 
            // TabGs
            // 
            this.TabGs.Controls.Add(this.DgvGs);
            this.TabGs.Location = new System.Drawing.Point(4, 22);
            this.TabGs.Name = "TabGs";
            this.TabGs.Padding = new System.Windows.Forms.Padding(3);
            this.TabGs.Size = new System.Drawing.Size(696, 282);
            this.TabGs.TabIndex = 3;
            this.TabGs.Text = "ガス代";
            this.TabGs.UseVisualStyleBackColor = true;
            // 
            // DgvGs
            // 
            this.DgvGs.AllowUserToAddRows = false;
            this.DgvGs.AllowUserToDeleteRows = false;
            this.DgvGs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvGs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ColGsYr, this.ColGs04, this.ColGs05, this.ColGs06, this.ColGs07, this.ColGs08, this.ColGs09, this.ColGs10, this.ColGs11, this.ColGs12, this.ColGs01, this.ColGs02, this.ColGs03 });
            this.DgvGs.Location = new System.Drawing.Point(2, 3);
            this.DgvGs.Name = "DgvGs";
            this.DgvGs.ReadOnly = true;
            this.DgvGs.RowHeadersWidth = 24;
            this.DgvGs.RowTemplate.Height = 21;
            this.DgvGs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvGs.Size = new System.Drawing.Size(691, 275);
            this.DgvGs.TabIndex = 4;
            // 
            // TabWt
            // 
            this.TabWt.Controls.Add(this.DgvWt);
            this.TabWt.Location = new System.Drawing.Point(4, 22);
            this.TabWt.Name = "TabWt";
            this.TabWt.Padding = new System.Windows.Forms.Padding(3);
            this.TabWt.Size = new System.Drawing.Size(696, 282);
            this.TabWt.TabIndex = 5;
            this.TabWt.Text = "水道代";
            this.TabWt.UseVisualStyleBackColor = true;
            // 
            // DgvWt
            // 
            this.DgvWt.AllowUserToAddRows = false;
            this.DgvWt.AllowUserToDeleteRows = false;
            this.DgvWt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvWt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ColWtYr, this.ColWt04, this.ColWt05, this.ColWt06, this.ColWt07, this.ColWt08, this.ColWt09, this.ColWt10, this.ColWt11, this.ColWt12, this.ColWt01, this.ColWt02, this.ColWt03 });
            this.DgvWt.Location = new System.Drawing.Point(2, 3);
            this.DgvWt.Name = "DgvWt";
            this.DgvWt.ReadOnly = true;
            this.DgvWt.RowHeadersWidth = 24;
            this.DgvWt.RowTemplate.Height = 21;
            this.DgvWt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvWt.Size = new System.Drawing.Size(691, 275);
            this.DgvWt.TabIndex = 6;
            // 
            // ColElYr
            // 
            styleElYr.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColElYr.DefaultCellStyle = styleElYr;
            this.ColElYr.HeaderText = "年度";
            this.ColElYr.Name = "ColElYr";
            this.ColElYr.ReadOnly = true;
            this.ColElYr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColElYr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColElYr.Width = 45;
            // 
            // ColEl04
            // 
            styleEl04.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl04.Format = "C0";
            this.ColEl04.DefaultCellStyle = styleEl04;
            this.ColEl04.HeaderText = "4月";
            this.ColEl04.Name = "ColEl04";
            this.ColEl04.ReadOnly = true;
            this.ColEl04.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl04.Width = 50;
            // 
            // ColEl05
            // 
            styleEl05.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl05.Format = "C0";
            this.ColEl05.DefaultCellStyle = styleEl05;
            this.ColEl05.HeaderText = "5月";
            this.ColEl05.Name = "ColEl05";
            this.ColEl05.ReadOnly = true;
            this.ColEl05.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl05.Width = 50;
            // 
            // ColEl06
            // 
            styleEl06.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl06.Format = "C0";
            this.ColEl06.DefaultCellStyle = styleEl06;
            this.ColEl06.HeaderText = "6月";
            this.ColEl06.Name = "ColEl06";
            this.ColEl06.ReadOnly = true;
            this.ColEl06.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl06.Width = 50;
            // 
            // ColEl07
            // 
            styleEl07.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl07.Format = "C0";
            this.ColEl07.DefaultCellStyle = styleEl07;
            this.ColEl07.HeaderText = "7月";
            this.ColEl07.Name = "ColEl07";
            this.ColEl07.ReadOnly = true;
            this.ColEl07.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl07.Width = 50;
            // 
            // ColEl08
            // 
            styleEl08.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl08.Format = "C0";
            this.ColEl08.DefaultCellStyle = styleEl08;
            this.ColEl08.HeaderText = "8月";
            this.ColEl08.Name = "ColEl08";
            this.ColEl08.ReadOnly = true;
            this.ColEl08.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl08.Width = 50;
            // 
            // ColEl09
            // 
            styleEl09.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl09.Format = "C0";
            this.ColEl09.DefaultCellStyle = styleEl09;
            this.ColEl09.HeaderText = "9月";
            this.ColEl09.Name = "ColEl09";
            this.ColEl09.ReadOnly = true;
            this.ColEl09.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl09.Width = 50;
            // 
            // ColEl10
            // 
            styleEl10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl10.Format = "C0";
            this.ColEl10.DefaultCellStyle = styleEl10;
            this.ColEl10.HeaderText = "10月";
            this.ColEl10.Name = "ColEl10";
            this.ColEl10.ReadOnly = true;
            this.ColEl10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl10.Width = 50;
            // 
            // ColEl11
            // 
            styleEl11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl11.Format = "C0";
            this.ColEl11.DefaultCellStyle = styleEl11;
            this.ColEl11.HeaderText = "11月";
            this.ColEl11.Name = "ColEl11";
            this.ColEl11.ReadOnly = true;
            this.ColEl11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl11.Width = 50;
            // 
            // ColEl12
            // 
            styleEl12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl12.Format = "C0";
            this.ColEl12.DefaultCellStyle = styleEl12;
            this.ColEl12.HeaderText = "12月";
            this.ColEl12.Name = "ColEl12";
            this.ColEl12.ReadOnly = true;
            this.ColEl12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl12.Width = 50;
            // 
            // ColEl01
            // 
            styleEl01.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl01.Format = "C0";
            this.ColEl01.DefaultCellStyle = styleEl01;
            this.ColEl01.HeaderText = "1月";
            this.ColEl01.Name = "ColEl01";
            this.ColEl01.ReadOnly = true;
            this.ColEl01.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl01.Width = 50;
            // 
            // ColEl02
            // 
            styleEl02.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl02.Format = "C0";
            this.ColEl02.DefaultCellStyle = styleEl02;
            this.ColEl02.HeaderText = "2月";
            this.ColEl02.Name = "ColEl02";
            this.ColEl02.ReadOnly = true;
            this.ColEl02.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl02.Width = 50;
            // 
            // ColEl03
            // 
            styleEl03.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleEl03.Format = "C0";
            this.ColEl03.DefaultCellStyle = styleEl03;
            this.ColEl03.HeaderText = "3月";
            this.ColEl03.Name = "ColEl03";
            this.ColEl03.ReadOnly = true;
            this.ColEl03.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColEl03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColEl03.Width = 50;
            // 
            // ColGsYr
            // 
            styleGsYr.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColGsYr.DefaultCellStyle = styleGsYr;
            this.ColGsYr.HeaderText = "年度";
            this.ColGsYr.Name = "ColGsYr";
            this.ColGsYr.ReadOnly = true;
            this.ColGsYr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGsYr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGsYr.Width = 45;
            // 
            // ColGs04
            // 
            styleGs04.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs04.Format = "C0";
            this.ColGs04.DefaultCellStyle = styleGs04;
            this.ColGs04.HeaderText = "4月";
            this.ColGs04.Name = "ColGs04";
            this.ColGs04.ReadOnly = true;
            this.ColGs04.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs04.Width = 50;
            // 
            // ColGs05
            // 
            styleGs05.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs05.Format = "C0";
            this.ColGs05.DefaultCellStyle = styleGs05;
            this.ColGs05.HeaderText = "5月";
            this.ColGs05.Name = "ColGs05";
            this.ColGs05.ReadOnly = true;
            this.ColGs05.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs05.Width = 50;
            // 
            // ColGs06
            // 
            styleGs06.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs06.Format = "C0";
            this.ColGs06.DefaultCellStyle = styleGs06;
            this.ColGs06.HeaderText = "6月";
            this.ColGs06.Name = "ColGs06";
            this.ColGs06.ReadOnly = true;
            this.ColGs06.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs06.Width = 50;
            // 
            // ColGs07
            // 
            styleGs07.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs07.Format = "C0";
            this.ColGs07.DefaultCellStyle = styleGs07;
            this.ColGs07.HeaderText = "7月";
            this.ColGs07.Name = "ColGs07";
            this.ColGs07.ReadOnly = true;
            this.ColGs07.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs07.Width = 50;
            // 
            // ColGs08
            // 
            styleGs08.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs08.Format = "C0";
            this.ColGs08.DefaultCellStyle = styleGs08;
            this.ColGs08.HeaderText = "8月";
            this.ColGs08.Name = "ColGs08";
            this.ColGs08.ReadOnly = true;
            this.ColGs08.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs08.Width = 50;
            // 
            // ColGs09
            // 
            styleGs09.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs09.Format = "C0";
            this.ColGs09.DefaultCellStyle = styleGs09;
            this.ColGs09.HeaderText = "9月";
            this.ColGs09.Name = "ColGs09";
            this.ColGs09.ReadOnly = true;
            this.ColGs09.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs09.Width = 50;
            // 
            // ColGs10
            // 
            styleGs10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs10.Format = "C0";
            this.ColGs10.DefaultCellStyle = styleGs10;
            this.ColGs10.HeaderText = "10月";
            this.ColGs10.Name = "ColGs10";
            this.ColGs10.ReadOnly = true;
            this.ColGs10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs10.Width = 50;
            // 
            // ColGs11
            // 
            styleGs11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs11.Format = "C0";
            this.ColGs11.DefaultCellStyle = styleGs11;
            this.ColGs11.HeaderText = "11月";
            this.ColGs11.Name = "ColGs11";
            this.ColGs11.ReadOnly = true;
            this.ColGs11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs11.Width = 50;
            // 
            // ColGs12
            // 
            styleGs12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs12.Format = "C0";
            this.ColGs12.DefaultCellStyle = styleGs12;
            this.ColGs12.HeaderText = "12月";
            this.ColGs12.Name = "ColGs12";
            this.ColGs12.ReadOnly = true;
            this.ColGs12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs12.Width = 50;
            // 
            // ColGs01
            // 
            styleGs01.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs01.Format = "C0";
            this.ColGs01.DefaultCellStyle = styleGs01;
            this.ColGs01.HeaderText = "1月";
            this.ColGs01.Name = "ColGs01";
            this.ColGs01.ReadOnly = true;
            this.ColGs01.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs01.Width = 50;
            // 
            // ColGs02
            // 
            styleGs02.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs02.Format = "C0";
            this.ColGs02.DefaultCellStyle = styleGs02;
            this.ColGs02.HeaderText = "2月";
            this.ColGs02.Name = "ColGs02";
            this.ColGs02.ReadOnly = true;
            this.ColGs02.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs02.Width = 50;
            // 
            // ColGs03
            // 
            styleGs03.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleGs03.Format = "C0";
            this.ColGs03.DefaultCellStyle = styleGs03;
            this.ColGs03.HeaderText = "3月";
            this.ColGs03.Name = "ColGs03";
            this.ColGs03.ReadOnly = true;
            this.ColGs03.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColGs03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColGs03.Width = 50;
            // 
            // ColWtYr
            // 
            styleWtYr.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColWtYr.DefaultCellStyle = styleWtYr;
            this.ColWtYr.HeaderText = "年度";
            this.ColWtYr.Name = "ColWtYr";
            this.ColWtYr.ReadOnly = true;
            this.ColWtYr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWtYr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWtYr.Width = 45;
            // 
            // ColWt04
            // 
            styleWt04.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt04.Format = "C0";
            this.ColWt04.DefaultCellStyle = styleWt04;
            this.ColWt04.HeaderText = "4月";
            this.ColWt04.Name = "ColWt04";
            this.ColWt04.ReadOnly = true;
            this.ColWt04.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt04.Width = 50;
            // 
            // ColWt05
            // 
            styleWt05.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt05.Format = "C0";
            this.ColWt05.DefaultCellStyle = styleWt05;
            this.ColWt05.HeaderText = "5月";
            this.ColWt05.Name = "ColWt05";
            this.ColWt05.ReadOnly = true;
            this.ColWt05.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt05.Width = 50;
            // 
            // ColWt06
            // 
            styleWt06.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt06.Format = "C0";
            this.ColWt06.DefaultCellStyle = styleWt06;
            this.ColWt06.HeaderText = "6月";
            this.ColWt06.Name = "ColWt06";
            this.ColWt06.ReadOnly = true;
            this.ColWt06.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt06.Width = 50;
            // 
            // ColWt07
            // 
            styleWt07.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt07.Format = "C0";
            this.ColWt07.DefaultCellStyle = styleWt07;
            this.ColWt07.HeaderText = "7月";
            this.ColWt07.Name = "ColWt07";
            this.ColWt07.ReadOnly = true;
            this.ColWt07.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt07.Width = 50;
            // 
            // ColWt08
            // 
            styleWt08.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt08.Format = "C0";
            this.ColWt08.DefaultCellStyle = styleWt08;
            this.ColWt08.HeaderText = "8月";
            this.ColWt08.Name = "ColWt08";
            this.ColWt08.ReadOnly = true;
            this.ColWt08.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt08.Width = 50;
            // 
            // ColWt09
            // 
            styleWt09.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt09.Format = "C0";
            this.ColWt09.DefaultCellStyle = styleWt09;
            this.ColWt09.HeaderText = "9月";
            this.ColWt09.Name = "ColWt09";
            this.ColWt09.ReadOnly = true;
            this.ColWt09.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt09.Width = 50;
            // 
            // ColWt10
            // 
            styleWt10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt10.Format = "C0";
            this.ColWt10.DefaultCellStyle = styleWt10;
            this.ColWt10.HeaderText = "10月";
            this.ColWt10.Name = "ColWt10";
            this.ColWt10.ReadOnly = true;
            this.ColWt10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt10.Width = 50;
            // 
            // ColWt11
            // 
            styleWt11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt11.Format = "C0";
            this.ColWt11.DefaultCellStyle = styleWt11;
            this.ColWt11.HeaderText = "11月";
            this.ColWt11.Name = "ColWt11";
            this.ColWt11.ReadOnly = true;
            this.ColWt11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt11.Width = 50;
            // 
            // ColWt12
            // 
            styleWt12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt12.Format = "C0";
            this.ColWt12.DefaultCellStyle = styleWt12;
            this.ColWt12.HeaderText = "12月";
            this.ColWt12.Name = "ColWt12";
            this.ColWt12.ReadOnly = true;
            this.ColWt12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt12.Width = 50;
            // 
            // ColWt01
            // 
            styleWt01.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt01.Format = "C0";
            this.ColWt01.DefaultCellStyle = styleWt01;
            this.ColWt01.HeaderText = "1月";
            this.ColWt01.Name = "ColWt01";
            this.ColWt01.ReadOnly = true;
            this.ColWt01.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt01.Width = 50;
            // 
            // ColWt02
            // 
            styleWt02.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt02.Format = "C0";
            this.ColWt02.DefaultCellStyle = styleWt02;
            this.ColWt02.HeaderText = "2月";
            this.ColWt02.Name = "ColWt02";
            this.ColWt02.ReadOnly = true;
            this.ColWt02.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt02.Width = 50;
            // 
            // ColWt03
            // 
            styleWt03.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            styleWt03.Format = "C0";
            this.ColWt03.DefaultCellStyle = styleWt03;
            this.ColWt03.HeaderText = "3月";
            this.ColWt03.Name = "ColWt03";
            this.ColWt03.ReadOnly = true;
            this.ColWt03.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColWt03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColWt03.Width = 50;
            // 
            // AbSubEnergy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 306);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbSubEnergy";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "光熱費";
            this.Load += new System.EventHandler(this.AbSubEnergy_Load);
            this.TabControl.ResumeLayout(false);
            this.TabEl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvEl)).EndInit();
            this.TabGs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvGs)).EndInit();
            this.TabWt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvWt)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabEl;
        private System.Windows.Forms.TabPage TabGs;
        private System.Windows.Forms.TabPage TabWt;
        private System.Windows.Forms.DataGridView DgvEl;
        private System.Windows.Forms.DataGridView DgvGs;
        private System.Windows.Forms.DataGridView DgvWt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColElYr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl04;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl05;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl06;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl07;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl08;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl09;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl01;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEl03;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGsYr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs04;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs05;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs06;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs07;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs08;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs09;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs01;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGs03;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWtYr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt04;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt05;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt06;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt07;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt08;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt09;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt10;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt01;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt02;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColWt03;
    }
}