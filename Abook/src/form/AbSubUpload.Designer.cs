namespace Abook
{
    using System.ComponentModel;

    /// <summary>
    /// アップロードサブフォームデザイナ
    /// </summary>
    partial class AbSubUpload
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
            var resources = new ComponentResourceManager(typeof(AbSubUpload));
            this.LblMail = new System.Windows.Forms.Label();
            this.LblPass = new System.Windows.Forms.Label();
            this.TxtMail = new System.Windows.Forms.TextBox();
            this.TxtPass = new System.Windows.Forms.TextBox();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PboxProgress = new System.Windows.Forms.PictureBox();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.PboxProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // LblMail
            // 
            this.LblMail.AutoSize = true;
            this.LblMail.Location = new System.Drawing.Point(19, 15);
            this.LblMail.Name = "LblMail";
            this.LblMail.Size = new System.Drawing.Size(32, 12);
            this.LblMail.TabIndex = 0;
            this.LblMail.Text = "Mail :";
            // 
            // LblPass
            // 
            this.LblPass.AutoSize = true;
            this.LblPass.Location = new System.Drawing.Point(15, 40);
            this.LblPass.Name = "LblPass";
            this.LblPass.Size = new System.Drawing.Size(36, 12);
            this.LblPass.TabIndex = 1;
            this.LblPass.Text = "Pass :";
            // 
            // TxtMail
            // 
            this.TxtMail.Location = new System.Drawing.Point(57, 12);
            this.TxtMail.Name = "TxtMail";
            this.TxtMail.Size = new System.Drawing.Size(180, 19);
            this.TxtMail.TabIndex = 2;
            // 
            // TxtPass
            // 
            this.TxtPass.Location = new System.Drawing.Point(57, 37);
            this.TxtPass.Name = "TxtPass";
            this.TxtPass.Size = new System.Drawing.Size(180, 19);
            this.TxtPass.TabIndex = 3;
            // 
            // BtnUpload
            // 
            this.BtnUpload.Click += new System.EventHandler(BtnUpload_Click);
            this.BtnUpload.Location = new System.Drawing.Point(81, 62);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(75, 23);
            this.BtnUpload.TabIndex = 4;
            this.BtnUpload.Text = "アップロード";
            this.BtnUpload.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Click += new System.EventHandler(BtnCancel_Click);
            this.BtnCancel.Location = new System.Drawing.Point(162, 62);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // PboxProgress
            // 
            this.PboxProgress.Image = ((System.Drawing.Image)(resources.GetObject("PboxProgress.Image")));
            this.PboxProgress.Location = new System.Drawing.Point(16, 25);
            this.PboxProgress.Name = "PboxProgress";
            this.PboxProgress.Size = new System.Drawing.Size(221, 20);
            this.PboxProgress.TabIndex = 6;
            this.PboxProgress.TabStop = false;
            // 
            // BackgroundWorker
            // 
            this.BackgroundWorker.WorkerSupportsCancellation = true;
            this.BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_DoWork);
            this.BackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_RunWorkerCompleted);
            // 
            // AbSubUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 96);
            this.Controls.Add(this.LblMail);
            this.Controls.Add(this.LblPass);
            this.Controls.Add(this.TxtMail);
            this.Controls.Add(this.TxtPass);
            this.Controls.Add(this.BtnUpload);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.PboxProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbSubUpload";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "アップロード";
            this.Load += new System.EventHandler(this.AbSubUpload_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AbSubUpload_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PboxProgress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label LblMail;
        private System.Windows.Forms.Label LblPass;
        private System.Windows.Forms.TextBox TxtMail;
        private System.Windows.Forms.TextBox TxtPass;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.PictureBox PboxProgress;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
    }
}