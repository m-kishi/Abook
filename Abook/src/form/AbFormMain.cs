// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
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

            var form = new AbFormMain(CSV.FILE);
            form.SetUploadParameters(UPD.URL_LOGIN, UPD.URL_UPLOAD);

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
                abExpenses = AbDBManager.Load(CSV_FILE);
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
            InitTabSummary(summaries);
            InitTabGraphic(summaries);
        }

        /// <summary>
        /// 備考をツールチップに表示
        /// </summary>
        /// <param name="row">行</param>
        /// <param name="col">列</param>
        /// <param name="note">備考</param>
        private void SetToolTipText(DataGridViewRow row, string col, string note)
        {
            row.Cells[col].ToolTipText = note;
        }
    }
}
