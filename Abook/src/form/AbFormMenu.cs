namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using UPD = Abook.AbConstants.UPD;

    /// <summary>
    /// メイン画面メニュー
    /// </summary>
    public partial class AbFormMain : Form
    {
        /// <summary>UPD ファイル</summary>
        public string UPD_FILE { get; set; }

        /// <summary>リクエスト URL</summary>
        public string UPD_URL { get; set; }

        /// <summary>
        /// アップロードのパラメタ設定
        /// </summary>
        /// <param name="UPD">UPD ファイル</param>
        /// <param name="URL">リクエスト URL</param>
        public void SetUploadParameters(string UPD, string URL)
        {
            this.UPD_FILE = UPD;
            this.UPD_URL  = URL;
        }

        /// <summary>
        /// アップロード
        /// </summary>
        private void MenuUpload_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show(
                "アップロードします。",
                "確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            if (dialogResult == DialogResult.OK)
            {
                var formUpload = new AbSubUpload(DB, UPD_FILE, UPD_URL);
                var result = formUpload.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    MessageBox.Show(
                        "アップロードに成功しました。",
                        "アップロード完了",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk
                    );
                }
                else if (result != DialogResult.Cancel)
                {
                    MessageBox.Show(
                        "アップロードに失敗しました。",
                        "アップロード失敗",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                formUpload.Dispose();
            }
        }
    }
}
