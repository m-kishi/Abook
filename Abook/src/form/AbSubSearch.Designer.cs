// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System.ComponentModel;

    /// <summary>
    /// 検索サブフォーム
    /// </summary>
    partial class AbSubSearch
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
            System.Windows.Forms.DataGridViewCellStyle styleDate = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleName = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleType = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleCost = new System.Windows.Forms.DataGridViewCellStyle();
            this.CmbName    = new System.Windows.Forms.ComboBox();
            this.BtnSearch  = new System.Windows.Forms.Button();
            this.DgvExpense = new System.Windows.Forms.DataGridView();
            this.ColDate    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCost    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // CmbName
            // 
            this.CmbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbName.DropDownHeight = 242;
            this.CmbName.FormattingEnabled = true;
            this.CmbName.IntegralHeight = false;
            this.CmbName.Location = new System.Drawing.Point(12, 12);
            this.CmbName.Name = "CmbName";
            this.CmbName.Size = new System.Drawing.Size(336, 20);
            this.CmbName.TabIndex = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(354, 10);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(50, 23);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "検索";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnEntry_Click);
            // 
            // DgvExpense
            // 
            this.DgvExpense.AllowUserToAddRows = false;
            this.DgvExpense.AllowUserToDeleteRows = false;
            this.DgvExpense.AllowUserToResizeColumns = false;
            this.DgvExpense.AllowUserToResizeRows = false;
            this.DgvExpense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvExpense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ColDate, this.ColName, this.ColType, this.ColCost });
            this.DgvExpense.Location = new System.Drawing.Point(12, 39);
            this.DgvExpense.Name = "DgvExpense";
            this.DgvExpense.ReadOnly = true;
            this.DgvExpense.RowHeadersWidth = 24;
            this.DgvExpense.RowTemplate.Height = 21;
            this.DgvExpense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvExpense.Size = new System.Drawing.Size(392, 234);
            this.DgvExpense.TabIndex = 2;
            // 
            // ColDate
            // 
            styleDate.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColDate.DefaultCellStyle = styleDate;
            this.ColDate.HeaderText = "日付";
            this.ColDate.Name = "ColDate";
            this.ColDate.ReadOnly = true;
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
            this.ColName.ReadOnly = true;
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
            this.ColType.ReadOnly = true;
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
            this.ColCost.ReadOnly = true;
            this.ColCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCost.Width = 60;
            // 
            // AbSubSearch
            // 
            this.AcceptButton = this.BtnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 284);
            this.Controls.Add(this.CmbName);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.DgvExpense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbSubSearch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "支出検索";
            this.Load += new System.EventHandler(this.AbSubSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpense)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ComboBox CmbName;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DataGridView DgvExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCost;
    }
}