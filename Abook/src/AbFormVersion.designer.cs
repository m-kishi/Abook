namespace Abook
{
    partial class AbFormVersion
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
            this.PboxIcon = new System.Windows.Forms.PictureBox();
            this.LblProduct = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblCopyright = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.BtnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PboxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // PboxIcon
            // 
            this.PboxIcon.Location = new System.Drawing.Point(12, 12);
            this.PboxIcon.Name = "PboxIcon";
            this.PboxIcon.Size = new System.Drawing.Size(32, 32);
            this.PboxIcon.TabIndex = 0;
            this.PboxIcon.TabStop = false;
            // 
            // LblProduct
            // 
            this.LblProduct.AutoSize = true;
            this.LblProduct.Location = new System.Drawing.Point(57, 12);
            this.LblProduct.Name = "LblProduct";
            this.LblProduct.Size = new System.Drawing.Size(44, 12);
            this.LblProduct.TabIndex = 1;
            this.LblProduct.Text = "Product";
            // 
            // LblVersion
            // 
            this.LblVersion.AutoSize = true;
            this.LblVersion.Location = new System.Drawing.Point(57, 33);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(44, 12);
            this.LblVersion.TabIndex = 2;
            this.LblVersion.Text = "Version";
            // 
            // LblCopyright
            // 
            this.LblCopyright.AutoSize = true;
            this.LblCopyright.Location = new System.Drawing.Point(57, 54);
            this.LblCopyright.Name = "LblCopyright";
            this.LblCopyright.Size = new System.Drawing.Size(54, 12);
            this.LblCopyright.TabIndex = 3;
            this.LblCopyright.Text = "Copyright";
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Location = new System.Drawing.Point(57, 75);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(63, 12);
            this.LblDescription.TabIndex = 4;
            this.LblDescription.Text = "Description";
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(80, 99);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 5;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // AbFormVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 131);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.LblCopyright);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblProduct);
            this.Controls.Add(this.PboxIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbFormVersion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AbFormVersion";
            this.Load += new System.EventHandler(this.AbFormVersion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PboxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PboxIcon;
        private System.Windows.Forms.Label LblProduct;
        private System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.Label LblCopyright;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Button BtnOK;
    }
}