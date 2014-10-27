namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using CSV = Abook.AbConstants.CSV;

    /// <summary>
    /// メイン画面フォーム
    /// </summary>
    public partial class AbFormMain : Form
    {
        /// <summary>DB ファイル</summary>
        public string DB { get; private set; }

        /// <summary>
        /// アプリケーションメイン
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(AbException.ApplicationThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AbFormMain(CSV.DB));
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="DB">DB ファイル</param>
        public AbFormMain(string DB)
        {
            this.DB = DB;
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
                InitFormMain(AbDBManager.Load(DB));
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
        /// <param name="expenses">支出情報リスト</param>
        private void InitFormMain(List<AbExpense> expenses)
        {
            var summaries = AbSummary.GetSummaries(expenses);
            InitTabExpense(expenses);
            InitTabBalance(expenses);
            InitTabPrivate(expenses);
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
        /// アップロード
        /// </summary>
        private void MenuUpload_Click(object sender, EventArgs e)
        {
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
