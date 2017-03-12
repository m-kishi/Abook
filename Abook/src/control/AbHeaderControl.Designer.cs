// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System.ComponentModel;

    /// <summary>
    /// ヘッダーコントロールデザイナ
    /// </summary>
    public partial class AbHeaderControl
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
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnPrevYear  = new System.Windows.Forms.Button();
            this.BtnPrevMonth = new System.Windows.Forms.Button();
            this.BtnNextMonth = new System.Windows.Forms.Button();
            this.BtnNextYear  = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTitle.Location = new System.Drawing.Point(67, 6);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(96, 16);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "9999年99月";
            // 
            // BtnPrevYear
            // 
            this.BtnPrevYear.Location = new System.Drawing.Point(3, 3);
            this.BtnPrevYear.Name = "BtnPrevYear";
            this.BtnPrevYear.Size = new System.Drawing.Size(25, 23);
            this.BtnPrevYear.TabIndex = 1;
            this.BtnPrevYear.Text = "<<";
            this.BtnPrevYear.UseVisualStyleBackColor = true;
            this.BtnPrevYear.Click += new System.EventHandler(this.BtnPrevYear_Click);
            // 
            // BtnPrevMonth
            // 
            this.BtnPrevMonth.Location = new System.Drawing.Point(34, 3);
            this.BtnPrevMonth.Name = "BtnPrevMonth";
            this.BtnPrevMonth.Size = new System.Drawing.Size(25, 23);
            this.BtnPrevMonth.TabIndex = 2;
            this.BtnPrevMonth.Text = "<";
            this.BtnPrevMonth.UseVisualStyleBackColor = true;
            this.BtnPrevMonth.Click += new System.EventHandler(this.BtnPrevMonth_Click);
            // 
            // BtnNextMonth
            // 
            this.BtnNextMonth.Location = new System.Drawing.Point(167, 3);
            this.BtnNextMonth.Name = "BtnNextMonth";
            this.BtnNextMonth.Size = new System.Drawing.Size(25, 23);
            this.BtnNextMonth.TabIndex = 3;
            this.BtnNextMonth.Text = ">";
            this.BtnNextMonth.UseVisualStyleBackColor = true;
            this.BtnNextMonth.Click += new System.EventHandler(this.BtnNextMonth_Click);
            // 
            // BtnNextYear
            // 
            this.BtnNextYear.Location = new System.Drawing.Point(198, 3);
            this.BtnNextYear.Name = "BtnNextYear";
            this.BtnNextYear.Size = new System.Drawing.Size(25, 23);
            this.BtnNextYear.TabIndex = 4;
            this.BtnNextYear.Text = ">>";
            this.BtnNextYear.UseVisualStyleBackColor = true;
            this.BtnNextYear.Click += new System.EventHandler(this.BtnNextYear_Click);
            // 
            // AbHeaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.BtnPrevYear);
            this.Controls.Add(this.BtnPrevMonth);
            this.Controls.Add(this.BtnNextMonth);
            this.Controls.Add(this.BtnNextYear);
            this.Name = "AbHeaderControl";
            this.Size = new System.Drawing.Size(227, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Button BtnPrevYear;
        private System.Windows.Forms.Button BtnPrevMonth;
        private System.Windows.Forms.Button BtnNextMonth;
        private System.Windows.Forms.Button BtnNextYear;
    }
}
