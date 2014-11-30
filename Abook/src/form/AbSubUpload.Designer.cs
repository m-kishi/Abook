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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AbSubUpload));
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PboxProgress = new System.Windows.Forms.PictureBox();
            this.BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.PboxProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // PboxProgress
            // 
            this.PboxProgress.Image = ((System.Drawing.Image)(resources.GetObject("PboxProgress.Image")));
            this.PboxProgress.Location = new System.Drawing.Point(12, 12);
            this.PboxProgress.Name = "PboxProgress";
            this.PboxProgress.Size = new System.Drawing.Size(221, 20);
            this.PboxProgress.TabIndex = 0;
            this.PboxProgress.TabStop = false;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(85, 39);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
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
            this.ClientSize = new System.Drawing.Size(244, 70);
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
            this.Shown += new System.EventHandler(this.AbSubUpload_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AbSubUpload_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PboxProgress)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.PictureBox PboxProgress;
        private System.ComponentModel.BackgroundWorker BackgroundWorker;
    }
}