﻿namespace Abook
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// アップロードサブフォーム
    /// </summary>
    public partial class AbSubUpload : Form
    {
        /// <summary>DB ファイル</summary>
        private string DB { get; set; }
        /// <summary>UPD ファイル</summary>
        private string UPD { get; set; }
        /// <summary>リクエスト URL</summary>
        private string URL { get; set; }

        /// <summary>処理中フラグ</summary>
        public bool IsRunning { get; private set; }
        /// <summary>サーバからの応答</summary>
        public string Response { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="DB">DB ファイル</param>
        /// <param name="UPD">UPD ファイル</param>
        /// <param name="URL">リクエスト URL</param>
        public AbSubUpload(string DB, string UPD, string URL)
        {
            this.DB  = DB;
            this.UPD = UPD;
            this.URL = URL;
            InitializeComponent();
        }

        /// <summary>
        /// フォーム表示
        /// </summary>
        private void AbSubUpload_Shown(object sender, EventArgs e)
        {
            IsRunning = true;
            BackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 処理中は閉じない
        /// </summary>
        private void AbSubUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BackgroundWorker.IsBusy) e.Cancel = true;
        }

        /// <summary>
        /// バックグラウンド処理開始
        /// </summary>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            AbUploaders.Prepare(UPD, AbDBManager.Load(DB));
            e.Result = AbUploaders.SendUploadRequest(URL, UPD);
        }

        /// <summary>
        /// バックグランド処理終了
        /// </summary>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsRunning = false;
            if (e.Error != null)
            {
                MessageBox.Show(
                    e.Error.Message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                DialogResult = DialogResult.Abort;
            }
            else if (e.Cancelled)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                Response = e.Result.ToString();
                DialogResult = DialogResult.OK;
            }
            BackgroundWorker.Dispose();
            this.Close();
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = false;
            BackgroundWorker.CancelAsync();
        }
    }
}