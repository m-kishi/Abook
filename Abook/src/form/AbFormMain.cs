namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using COL  = Abook.AbConstants.COL;
    using CSV  = Abook.AbConstants.CSV;
    using DGV  = Abook.AbConstants.DGV;
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;
    using UTIL = Abook.AbUtilities;

    /// <summary>
    /// メイン画面フォーム
    /// </summary>
    public partial class AbFormMain : Form
    {
        public AbFormMain()
        {
            InitializeComponent();
        }

        /// <summary>データ管理(集計用)</summary>
        private AbExpenseManager abExpenseManager;

        /// <summary>データ管理(グラフ用)</summary>
        private AbGraphicManager abGraphicManager;

        /// <summary>データ管理(収支用)</summary>
        private AbBalanceManager abBalanceManager;

        /// <summary>自動補完</summary>
        private AbComplete abComplete;

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbFormMain_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = SystemIcons.Application;

                var abExpenses = AbDBManager.Load(CSV.DB);
                SetViewExpense(abExpenses);
                GenerateManagers(abExpenses);

                abComplete = new AbComplete(abExpenses);
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
        /// マネージャ生成
        /// </summary>
        private void GenerateManagers(List<AbExpense> abExpenses)
        {
            var abSummaries = AbSummary.GetSummaries(abExpenses);

            abExpenseManager = new AbExpenseManager(DateTime.Now, abSummaries);
            abGraphicManager = new AbGraphicManager(DateTime.Now, abSummaries);

            abBalanceManager = new AbBalanceManager(abExpenses);
        }

        /// <summary>
        /// タブ切り替えイベント
        /// </summary>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0: // 支出登録
                    // SetViewExpense();
                    break;

                case 1: // 月別表示
                    SetViewSummary();
                    break;

                case 2: // グラフ
                    Invalidate();
                    break;

                case 3: // 特別支出
                    SetViewBalance();
                    break;

                default:
                    MessageBox.Show(
                        "不明なタブが選択されました。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    break;
            }
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
            (new AbFormVersion()).ShowDialog();
        }

        /// <summary>
        /// 支出登録画面
        /// </summary>
        private void SetViewExpense(List<AbExpense> abExpenses)
        {
            try
            {
                if (abExpenses.Count > 0)
                {
                    int idx = 0;
                    DgvExpense.Rows.Clear();
                    DgvExpense.Rows.Add(abExpenses.Count);

                    foreach (var exp in abExpenses)
                    {
                        var row = DgvExpense.Rows[idx++];
                        row.Cells[COL.DATE].Value = exp.Date.ToString(FMT.DATE);
                        row.Cells[COL.NAME].Value = exp.Name;
                        row.Cells[COL.TYPE].Value = exp.Type;
                        row.Cells[COL.COST].Value = exp.Cost.ToString();
                    }
                }

                DgvExpense.ClearSelection();
                if (DgvExpense.Rows.Count > 0)
                {
                    DgvExpense.FirstDisplayedScrollingRowIndex = DgvExpense.Rows.Count - 1;
                    DgvExpense.Rows[DgvExpense.Rows.Count - 1].Cells[COL.DATE].Selected = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// <summary>
        /// DataGridView へペースト
        /// </summary>
        private void DgvExpense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                DgvExpense.CurrentCell.Value = Clipboard.GetText();

                if (DgvExpense.CurrentCell.ColumnIndex == 1)
                {
                    DataGridViewRow row = DgvExpense.Rows[DgvExpense.CurrentCell.RowIndex];
                    row.Cells[COL.TYPE].Value = abComplete.GetType(Clipboard.GetText());
                }
            }
        }

        /// <summary>
        /// DB ファイルへ書き出し
        /// </summary>
        private void BtnEntry_Click(object sender, EventArgs e)
        {
            if (DgvExpense.Rows.Count == 0)
            {
                MessageBox.Show(
                    "レコードが1件もありません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //RemoveEmptyRows();

            //if (DgvExpenseValidate())
            //{
            var errLine = 0;
            try
            {
                var expenses = AbDBManager.Load(DgvExpense, out errLine);

                AbDBManager.Store(CSV.DB, expenses);

                SetViewExpense(expenses);

                GenerateManagers(expenses);

                MessageBox.Show(
                    "正常に登録しました。",
                    "登録完了",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk
                );
            }
            catch (AbException ex)
            {
                var errIdx = errLine - 1;
                DgvExpense.ClearSelection();
                DgvExpense.Rows[errIdx].Selected = true;
                DgvExpense.FirstDisplayedScrollingRowIndex = errIdx;

                MessageBox.Show(
                    ex.Message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }
            //}
        }

        /// <summary>
        /// 新規行追加
        /// </summary>
        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            DgvExpense.Rows.Add(DGV.NEW_ROW_SIZE);
            for (int i = DgvExpense.Rows.Count - DGV.NEW_ROW_SIZE; i < DgvExpense.Rows.Count; i++)
            {
                DgvExpense.Rows[i].Cells[COL.DATE].Value = DateTime.Today.ToString(FMT.DATE);
            }
        }

        /// <summary>
        /// 未入力行削除
        /// </summary>
        private void RemoveEmptyRows()
        {
            var idxEmpties = new List<int>();
            foreach (DataGridViewRow row in DgvExpense.Rows)
            {
                if (string.IsNullOrEmpty(row.Cells[COL.NAME].Value as string))
                {
                    idxEmpties.Add(row.Index);
                }
            }

            idxEmpties.Reverse();
            foreach (int i in idxEmpties)
            {
                DgvExpense.Rows.RemoveAt(i);
            }
        }

        /// <summary>
        /// セルの編集終了後に種別の自動補完を行う
        /// </summary>
        private void DgvExpense_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvExpense.CurrentCell.ColumnIndex == 1)
            {
                DataGridViewRow row = DgvExpense.Rows[DgvExpense.CurrentCell.RowIndex];
                row.Cells[COL.TYPE].Value = abComplete.GetType(row.Cells[COL.NAME].Value as string);
            }
        }

        /// <summary>
        /// 登録前チェック
        /// 日付、名前、種別、金額が入力されていなければエラー
        /// </summary>
        private bool DgvExpenseValidate()
        {
            bool result = true;
            foreach (DataGridViewRow row in DgvExpense.Rows)
            {
                result &= !string.IsNullOrEmpty(row.Cells[COL.DATE].Value as string);
                result &= !string.IsNullOrEmpty(row.Cells[COL.NAME].Value as string);
                result &= !string.IsNullOrEmpty(row.Cells[COL.TYPE].Value as string);
                result &= !string.IsNullOrEmpty(row.Cells[COL.COST].Value as string);
            }

            if (result == false)
            {
                MessageBox.Show(
                    "入力されていない項目があります。",
                    "登録前チェック",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return result;
        }

        /// <summary>
        /// 前年表示
        /// </summary>
        private void BtnExpPrevYear_Click(object sender, EventArgs e)
        {
            abExpenseManager.PrevYear();
            SetViewSummary();
        }

        /// <summary>
        /// 前月表示
        /// </summary>
        private void BtnExpPrevMonth_Click(object sender, EventArgs e)
        {
            abExpenseManager.PrevMonth();
            SetViewSummary();
        }

        /// <summary>
        /// 翌月表示
        /// </summary>
        private void BtnExpNextMonth_Click(object sender, EventArgs e)
        {
            abExpenseManager.NextMonth();
            SetViewSummary();
        }

        /// <summary>
        /// 翌年表示
        /// </summary>
        private void BtnExpNextYear_Click(object sender, EventArgs e)
        {
            abExpenseManager.NextYear();
            SetViewSummary();
        }

        /// <summary>
        /// 月集計画面表示
        /// </summary>
        private void SetViewSummary()
        {
            LblSummary.Text = abExpenseManager.Title;
            LblYen01食費.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.FOOD));
            LblYen02外食費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.OTFD));
            LblYen03雑貨.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.GOOD));
            LblYen04交際費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.FRND));
            LblYen05交通費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.TRFC));
            LblYen06遊行費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.PLAY));
            LblYen07家賃.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.HOUS));
            LblYen08光熱費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.ENGY));
            LblYen09通信費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.CNCT));
            LblYen10医療費.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.MEDI));
            LblYen11保険料.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.INSU));
            LblYen12その他.Text = UTIL.ToYen(abExpenseManager.GetCost(TYPE.OTHR));
            LblYen13合計.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.TTAL));
            LblYen14残金.Text   = UTIL.ToYen(abExpenseManager.GetCost(TYPE.BLNC));
        }

        /// <summary>
        /// 前年表示
        /// </summary>
        private void BtnGraphPrevYear_Click(object sender, EventArgs e)
        {
            abGraphicManager.PrevYear();
            SetViewGraph(PboxGraph.CreateGraphics());
        }

        /// <summary>
        /// 前月表示
        /// </summary>
        private void BtnGraphPrevMonth_Click(object sender, EventArgs e)
        {
            abGraphicManager.PrevMonth();
            SetViewGraph(PboxGraph.CreateGraphics());
        }

        /// <summary>
        /// 翌月表示
        /// </summary>
        private void BtnGraphNextMonth_Click(object sender, EventArgs e)
        {
            abGraphicManager.NextMonth();
            SetViewGraph(PboxGraph.CreateGraphics());
        }

        /// <summary>
        /// 翌年表示
        /// </summary>
        private void BtnGraphNextYear_Click(object sender, EventArgs e)
        {
            abGraphicManager.NextYear();
            SetViewGraph(PboxGraph.CreateGraphics());
        }

        /// <summary>
        /// グラフ描画イベント
        /// </summary>
        private void PboxGraph_Paint(object sender, PaintEventArgs e)
        {
            SetViewGraph(e.Graphics);
        }

        /// <summary>
        /// グラフ描画
        /// </summary>
        private void SetViewGraph(Graphics g)
        {
            g.Clear(Color.Black);
            abGraphicManager.DrawGraph(g);

            LblGraph.Text = abGraphicManager.Title;
            LblX6.Text    = abGraphicManager.GetMonth(0);
            LblX5.Text    = abGraphicManager.GetMonth(-2);
            LblX4.Text    = abGraphicManager.GetMonth(-4);
            LblX3.Text    = abGraphicManager.GetMonth(-6);
            LblX2.Text    = abGraphicManager.GetMonth(-8);
            LblX1.Text    = abGraphicManager.GetMonth(-10);
        }

        /// <summary>
        /// 特別支出画面
        /// </summary>
        private void SetViewBalance()
        {
            DgvBalance.Rows.Clear();
            DgvBalance.Rows.Add(abBalanceManager.Balances().Count());

            int i = 0;
            foreach (var bln in abBalanceManager.Balances())
            {
                DataGridViewRow row = DgvBalance.Rows[i++];
                row.Cells[COL.YEAR].Value = bln.Year;
                row.Cells[COL.EARN].Value = bln.Earn;
                row.Cells[COL.EXPENSE].Value = bln.Expense;
                row.Cells[COL.SPECIAL].Value = bln.Special;
                row.Cells[COL.BALANCE].Value = bln.Balance;
            }
        }
    }
}
