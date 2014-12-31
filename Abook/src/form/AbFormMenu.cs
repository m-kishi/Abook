﻿namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using MSG = Abook.AbUtilities.MSG;
    using UPD = Abook.AbConstants.UPD;

    /// <summary>
    /// メイン画面メニュー
    /// </summary>
    public partial class AbFormMain : Form
    {
        /// <summary>UPDファイル</summary>
        public string UPD_FILE { get; set; }
        /// <summary>リクエストURL</summary>
        public string UPD_URL { get; set; }

        /// <summary>
        /// アップロードのパラメタ設定
        /// </summary>
        /// <param name="UPD">UPDファイル</param>
        /// <param name="URL">リクエストURL</param>
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
            var dialogResult = MSG.Confirm("確認", "アップロードします。");
            if (dialogResult == DialogResult.OK)
            {
                var formUpload = new AbSubUpload(DB, UPD_FILE, UPD_URL);
                var result = formUpload.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    MSG.OK("アップロード完了", "アップロードに成功しました。");
                }
                else if (result != DialogResult.Cancel)
                {
                    MSG.Error("アップロード失敗", "アップロードに失敗しました。");
                }
                formUpload.Dispose();
            }
        }
    }
}
