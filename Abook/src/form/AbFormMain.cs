// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    using DB  = Abook.AbConstants.DB;
    using MSG = Abook.AbUtilities.MSG;

    /// <summary>
    /// メイン画面フォーム
    /// </summary>
    public partial class AbFormMain : Form
    {
        /// <summary>DBファイル</summary>
        public string DB_FILE { get; private set; }

        /// <summary>支出情報リスト</summary>
        private List<AbExpense> abExpenses;

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

            var form = new AbFormMain(DB.NAME);
            Application.Run(form);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dbFile">DBファイル</param>
        public AbFormMain(string dbFile)
        {
            this.DB_FILE = dbFile;
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbFormMain_Load(object sender, EventArgs e)
        {
            try
            {
                abExpenses = AbDBManager.Load(DB_FILE);
                InitFormMain(abExpenses);
            }
            catch (Exception ex)
            {
                MSG.Abort(ex.Message);
                this.Close();

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
            InitTabFinance(expenses);
            InitTabSummary(summaries);
            InitTabGraphic(summaries);
        }
    }
}
