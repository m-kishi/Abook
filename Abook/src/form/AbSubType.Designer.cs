// ------------------------------------------------------------
// © 2010 Masaaki Kishi
// ------------------------------------------------------------
namespace Abook
{
    using System.ComponentModel;

    /// <summary>
    /// 種別明細サブフォームデザイナ
    /// </summary>
    partial class AbSubType
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
            this.DgvExpense = new System.Windows.Forms.DataGridView();
            this.ColDate    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColType    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCost    = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpense)).BeginInit();
            this.SuspendLayout();
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
            this.DgvExpense.Location = new System.Drawing.Point(2, 2);
            this.DgvExpense.Name = "DgvExpense";
            this.DgvExpense.ReadOnly = true;
            this.DgvExpense.RowHeadersWidth = 24;
            this.DgvExpense.RowTemplate.Height = 21;
            this.DgvExpense.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvExpense.Size = new System.Drawing.Size(392, 130);
            this.DgvExpense.TabIndex = 0;
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
            // AbSubType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 132);
            this.Controls.Add(this.DgvExpense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbSubType";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AbSubType";
            this.Load += new System.EventHandler(this.AbSubType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvExpense)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView DgvExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCost;
    }
}