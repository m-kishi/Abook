namespace Abook
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using MSG = Abook.AbUtilities.MSG;

    /// <summary>
    /// アップロードサブフォーム
    /// </summary>
    public partial class AbSubUpload : Form
    {
        /// <summary>CSVファイル</summary>
        private string CSV { get; set; }
        /// <summary>UPDファイル</summary>
        private string UPD { get; set; }
        /// <summary>リクエストURL</summary>
        private string URL { get; set; }
        /// <summary>処理中フラグ</summary>
        public bool IsRunning { get; private set; }
        /// <summary>サーバからの応答</summary>
        public string Response { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="CSV">CSVファイル</param>
        /// <param name="UPD">UPDファイル</param>
        /// <param name="URL">リクエストURL</param>
        public AbSubUpload(string CSV, string UPD, string URL)
        {
            this.CSV = CSV;
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
            AbUploaders.Prepare(UPD, AbDBManager.Load(CSV));
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
                MSG.Error(e.Error.Message);
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
