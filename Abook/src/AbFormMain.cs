namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

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
        private AbGraphManager abGraphManager;

        /// <summary>データ管理(特別支出用)</summary>
        private AbSpecialManager abSpecialManager;

        /// <summary>自動補完</summary>
        private AbComplement abComplement;

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbFormMain_Load(object sender, EventArgs e)
        {
            try
            {
                Icon = SystemIcons.Application;

                var abExpenses = AbDBManager.LoadFromFile(AbCommonConst.DB_NAME);
                SetViewExpense(abExpenses);
                GenerateManagers(abExpenses);

                abComplement = new AbComplement(abExpenses);
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
            abGraphManager = new AbGraphManager(DateTime.Now, abSummaries);

            abSpecialManager = new AbSpecialManager(abExpenses);
        }

        /// <summary>
        /// タブ切り替えイベント
        /// </summary>
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0: //支出登録
                    //SetViewExpense();
                    break;

                case 1: //月別表示
                    SetViewSummary();
                    break;

                case 2: //グラフ
                    Invalidate();
                    break;

                case 3: //特別支出
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
                        row.Cells["colDate"].Value  = exp.Date.ToShortDateString();
                        row.Cells["colName"].Value  = exp.Name;
                        row.Cells["colType"].Value  = exp.Type;
                        row.Cells["colPrice"].Value = exp.Price.ToString();
                    }
                }

                DgvExpense.ClearSelection();
                if (DgvExpense.Rows.Count > 0)
                {
                    DgvExpense.FirstDisplayedScrollingRowIndex = DgvExpense.Rows.Count - 1;
                    DgvExpense.Rows[DgvExpense.Rows.Count - 1].Cells["colDate"].Selected = true;
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
                    row.Cells["colType"].Value = abComplement.GetType(Clipboard.GetText());
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

            RemoveEmptyRows();

            if (DgvExpenseValidate())
            {
                try
                {
                    var abExpenses = AbDBManager.StoreToFile(AbCommonConst.DB_NAME, DgvExpense);

                    MessageBox.Show(
                        "正常に登録しました。",
                        "登録完了",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk
                    );

                    SetViewExpense(abExpenses);
                    GenerateManagers(abExpenses);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
        }

        /// <summary>
        /// プロパティ(DataGridView)
        /// </summary>
        public DataGridView DataGridView
        {
            get { return this.DgvExpense; }
        }

        /// <summary>
        /// 新規行追加
        /// </summary>
        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            DgvExpense.Rows.Add(AbCommonConst.ADD_ROW_SIZE);
            for (int i = DgvExpense.Rows.Count - AbCommonConst.ADD_ROW_SIZE; i < DgvExpense.Rows.Count; i++)
            {
                DgvExpense.Rows[i].Cells["colDate"].Value = DateTime.Today.ToShortDateString();
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
                if (string.IsNullOrEmpty(row.Cells["colName"].Value as string))
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
                row.Cells["colType"].Value = abComplement.GetType(row.Cells["colName"].Value as string);
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
                result &= !string.IsNullOrEmpty(row.Cells["colDate"].Value as string);
                result &= !string.IsNullOrEmpty(row.Cells["colName"].Value as string);
                result &= !string.IsNullOrEmpty(row.Cells["colType"].Value as string);
                result &= !string.IsNullOrEmpty(row.Cells["colPrice"].Value as string);
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
            LblSummary.Text     = abExpenseManager.ToString();
            LblYen01食費.Text   = abExpenseManager.GetPrice("食費"  );
            LblYen02外食費.Text = abExpenseManager.GetPrice("外食費");
            LblYen03雑貨.Text   = abExpenseManager.GetPrice("雑貨"  );
            LblYen04交際費.Text = abExpenseManager.GetPrice("交際費");
            LblYen05交通費.Text = abExpenseManager.GetPrice("交通費");
            LblYen06遊行費.Text = abExpenseManager.GetPrice("遊行費");
            LblYen07家賃.Text   = abExpenseManager.GetPrice("家賃"  );
            LblYen08光熱費.Text = abExpenseManager.GetPrice("光熱費");
            LblYen09通信費.Text = abExpenseManager.GetPrice("通信費");
            LblYen10医療費.Text = abExpenseManager.GetPrice("医療費");
            LblYen11保険料.Text = abExpenseManager.GetPrice("保険料");
            LblYen12その他.Text = abExpenseManager.GetPrice("その他");
            LblYen13合計.Text   = abExpenseManager.GetPrice("合計"  );
            LblYen14残金.Text   = abExpenseManager.GetPrice("残金"  );
        }

        /// <summary>
        /// 前年表示
        /// </summary>
        private void BtnGraphPrevYear_Click(object sender, EventArgs e)
        {
            abGraphManager.PrevYear();
            SetViewGraph(PboxGraph.CreateGraphics());
        }

        /// <summary>
        /// 前月表示
        /// </summary>
        private void BtnGraphPrevMonth_Click(object sender, EventArgs e)
        {
            abGraphManager.PrevMonth();
            SetViewGraph(PboxGraph.CreateGraphics());
        }

        /// <summary>
        /// 翌月表示
        /// </summary>
        private void BtnGraphNextMonth_Click(object sender, EventArgs e)
        {
            abGraphManager.NextMonth();
            SetViewGraph(PboxGraph.CreateGraphics());
        }

        /// <summary>
        /// 翌年表示
        /// </summary>
        private void BtnGraphNextYear_Click(object sender, EventArgs e)
        {
            abGraphManager.NextYear();
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
            abGraphManager.DrawGraph(g);

            LblGraph.Text = abGraphManager.ToString();
            LblX6.Text    = abGraphManager.GetMonth(0);
            LblX5.Text    = abGraphManager.GetMonth(-2);
            LblX4.Text    = abGraphManager.GetMonth(-4);
            LblX3.Text    = abGraphManager.GetMonth(-6);
            LblX2.Text    = abGraphManager.GetMonth(-8);
            LblX1.Text    = abGraphManager.GetMonth(-10);
        }

        /// <summary>
        /// 特別支出画面
        /// </summary>
        private void SetViewBalance()
        {
            DgvBalance.Rows.Clear();
            DgvBalance.Rows.Add(abSpecialManager.GetEnumerator().Count());

            int i = 0;
            foreach (var spc in abSpecialManager.GetEnumerator())
            {
                DataGridViewRow row = DgvBalance.Rows[i++];
                row.Cells["ColYear"].Value = spc.Year;
                row.Cells["ColEarn"].Value = spc.Earn;
                row.Cells["ColExpense"].Value = spc.Expense;
                row.Cells["ColSpecial"].Value = spc.Special;
                row.Cells["ColBalance"].Value = spc.Balance;
            }
        }
    }
}
