// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
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
    }
}
