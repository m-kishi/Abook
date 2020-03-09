// ------------------------------------------------------------
// © 2010 Masaaki Kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using CHK = Abook.AbUtilities.CHK;
    using MSG = Abook.AbUtilities.MSG;

    /// <summary>
    /// アップロードサブフォーム
    /// </summary>
    public partial class AbSubUpload : Form
    {
        /// <summary>CSVファイル</summary>
        private string CSV { get; set; }
        /// <summary>ログインURL</summary>
        private string URL_LOGIN  { get; set; }
        /// <summary>アップロードURL</summary>
        private string URL_UPLOAD { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="csv">CSVファイル</param>
        /// <param name="login ">ログインURL</param>
        /// <param name="upload">アップロードURL</param>
        public AbSubUpload(string csv, string login, string upload)
        {
            this.CSV = csv;
            this.URL_LOGIN = login;
            this.URL_UPLOAD = upload;

            InitializeComponent();
        }

        /// <summary>
        /// フォーム表示
        /// </summary>
        private void AbSubUpload_Load(object sender, EventArgs e)
        {
            ToggleView(true);
        }

        /// <summary>
        /// 処理中は閉じない
        /// </summary>
        private void AbSubUpload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BackgroundWorker.IsBusy) e.Cancel = true;
            if (!e.Cancel)
            {
                BackgroundWorker.Dispose();
            }
        }

        /// <summary>
        /// アップロード
        /// </summary>
        private void BtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                CHK.MailNull(TxtMail.Text);
                CHK.PassNull(TxtPass.Text);
                ToggleView(false);
                var param = new string[] { TxtMail.Text, TxtPass.Text };
                BackgroundWorker.RunWorkerAsync(param);
            }
            catch (AbException ex)
            {
                MSG.Error(ex.Message);
            }
        }

        /// <summary>
        /// バックグラウンド処理開始
        /// </summary>
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var param = (string[])e.Argument;
            e.Result = AbUploaders.SendUploadRequest(
                CSV,
                param[0],
                param[1],
                URL_LOGIN,
                URL_UPLOAD
            );
        }

        /// <summary>
        /// バックグランド処理終了
        /// </summary>
        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ToggleView(true);
                MSG.Error(e.Error.Message);
            }
            else if (e.Cancelled)
            {
            }
            else
            {
                MSG.OK("アップロード", "成功しました。");
                this.Close();
            }
        }

        /// <summary>
        /// 表示切替
        /// </summary>
        /// <param name="enabled">true:認証情報入力表示 false:プログレスバー表示</param>
        private void ToggleView(bool enabled)
        {
            LblMail.Visible = enabled;
            TxtMail.Visible = enabled;
            LblPass.Visible = enabled;
            TxtPass.Visible = enabled;
            BtnUpload.Enabled = enabled;
            BtnCancel.Enabled = enabled;
            PboxProgress.Visible = !enabled;
        }

        /// <summary>
        /// キャンセル
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
