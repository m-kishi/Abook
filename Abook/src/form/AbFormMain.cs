namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using CSV = Abook.AbConstants.CSV;

    /// <summary>
    /// メイン画面フォーム
    /// </summary>
    public partial class AbFormMain : Form
    {
        /// <summary>
        /// アプリケーションメイン
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AbFormMain());
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbFormMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbFormMain_Load(object sender, EventArgs e)
        {
            Icon = SystemIcons.Application;
            try
            {
                InitFormMain(AbDBManager.Load(CSV.DB));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Application.Exit();
            }
        }

        /// <summary>
        /// メイン画面初期化
        /// </summary>
        /// <param name="expenses">支出レコードリスト</param>
        private void InitFormMain(List<AbExpense> expenses)
        {
            var summaries = AbSummary.GetSummaries(expenses);
            InitTabExpense(expenses);
            InitTabBalance(expenses);
            InitTabSummary(summaries);
            InitTabGraphic(summaries);
        }

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
    }
}
