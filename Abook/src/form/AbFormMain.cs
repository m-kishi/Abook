namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using CSV = Abook.AbConstants.CSV;
    using MSG = Abook.AbUtilities.MSG;
    using UPD = Abook.AbConstants.UPD;

    /// <summary>
    /// メイン画面フォーム
    /// </summary>
    public partial class AbFormMain : Form
    {
        /// <summary>CSVファイル</summary>
        public string CSV_FILE { get; private set; }

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

            AbFormMain form = null;
            form = new AbFormMain(CSV.FILE);
            form.SetUploadParameters(UPD.FILE, UPD.URL);
            Application.Run(form);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="CSV">CSVファイル</param>
        public AbFormMain(string CSV)
        {
            this.CSV_FILE = CSV;
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbFormMain_Load(object sender, EventArgs e)
        {
            try
            {
                InitFormMain(AbDBManager.Load(CSV_FILE));
            }
            catch (Exception ex)
            {
                MSG.Error(ex.Message);
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
    }
}
