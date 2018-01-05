// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Windows.Forms;
    using MSG = Abook.AbUtilities.MSG;

    /// <summary>
    /// メイン画面メニュー
    /// </summary>
    public partial class AbFormMain : Form
    {
        /// <summary>ログインURL</summary>
        public string URL_LOGIN  { get; set; }
        /// <summary>アップロードURL</summary>
        public string URL_UPLOAD { get; set; }

        /// <summary>
        /// アプリケーション終了
        /// </summary>
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// バージョン情報表示
        /// </summary>
        private void MenuVersion_Click(object sender, EventArgs e)
        {
            var formVersion = new AbFormVersion();
            formVersion.ShowDialog();
        }

        /// <summary>
        /// 検索サブフォーム表示
        /// </summary>
        private void MenuSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var formSearch = new AbSubSearch(abExpenses);
                formSearch.ShowDialog();
            }
            catch (AbException ex)
            {
                MSG.Error(ex.Message);
            }
        }

        /// <summary>
        /// 光熱費情報表示
        /// </summary>
        private void MenuEnergy_Click(object sender, EventArgs e)
        {
            try
            {
                var formEnergy = new AbSubEnergy(abExpenses);
                formEnergy.ShowDialog();
            }
            catch (AbException ex)
            {
                MSG.Error(ex.Message);
            }
        }

        /// <summary>
        /// アップロードのパラメタ設定
        /// </summary>
        /// <param name="login">ログインURL</param>
        /// <param name="upload">アップロードURL</param>
        public void SetUploadParameters(string login, string upload)
        {
            this.URL_LOGIN = login;
            this.URL_UPLOAD = upload;
        }

        /// <summary>
        /// アップロード
        /// </summary>
        private void MenuUpload_Click(object sender, EventArgs e)
        {
            var formUpload = new AbSubUpload(CSV_FILE, URL_LOGIN, URL_UPLOAD);
            formUpload.ShowDialog();
        }
    }
}
