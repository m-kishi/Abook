namespace Abook
{
    using System.ComponentModel;

    /// <summary>
    /// ラベルコントロールデザイナ
    /// </summary>
    public partial class AbLabelControl
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
            this._Label = new System.Windows.Forms.Label();
            this._Value = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _Label
            // 
            this._Label.AutoSize = true;
            this._Label.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._Label.Location = new System.Drawing.Point(3, 0);
            this._Label.Name = "_Label";
            this._Label.Size = new System.Drawing.Size(32, 12);
            this._Label.TabIndex = 0;
            this._Label.Text = "Label";
            // 
            // _Value
            // 
            this._Value.AutoSize = true;
            this._Value.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this._Value.Location = new System.Drawing.Point(62, 0);
            this._Value.MinimumSize = new System.Drawing.Size(55, 12);
            this._Value.Name = "_Value";
            this._Value.Size = new System.Drawing.Size(55, 12);
            this._Value.TabIndex = 1;
            this._Value.Text = "\\999,999";
            this._Value.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AbLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._Label);
            this.Controls.Add(this._Value);
            this.Name = "AbLabelControl";
            this.Size = new System.Drawing.Size(120, 12);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label _Label;
        private System.Windows.Forms.Label _Value;
    }
}
