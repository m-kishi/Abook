using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Abook
{
    /// <summary>
    /// メイン画面フォーム
    /// </summary>
    public partial class AbFormMain : Form
    {
        public AbFormMain()
        {
            InitializeComponent();
        }

        /// <summary>日付(集計用)</summary>
        private DateTime dtENow;

        /// <summary>日付(グラフ用)</summary>
        private DateTime dtGNow;

        /// <summary>データ管理(集計用)</summary>
        private AbExpenseManager abEManager;

        /// <summary>データ管理(グラフ用)</summary>
        private AbGraphManager abGManager;

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbFormMain_Load(object sender, EventArgs e)
        {
            try
            {
                dtENow = DateTime.Now;
                dtGNow = DateTime.Now;
                abEManager = new AbExpenseManager(AbCommonConst.DB_NAME, dtENow);
                abGManager = new AbGraphManager(dtGNow, abEManager.AbExpenses);
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

            setTabAccount();
            this.Icon = SystemIcons.Application;
        }

        /// <summary>
        /// タブ切り替えイベント
        /// </summary>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0: //家計簿画面
                    setTabAccount();
                    break;
                case 1: //月集計画面
                    setTabSummary(dtENow.Year, dtENow.Month);
                    break;
                case 2: //グラフ画面
                    Invalidate();
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

        #region "メニュー"

        /// <summary>
        /// アプリケーション終了
        /// </summary>
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// バージョン情報表示
        /// </summary>
        private void menuItemVersion_Click(object sender, EventArgs e)
        {
            AbFormVersion frmVersion = new AbFormVersion();
            frmVersion.ShowDialog();

        }

        #endregion


        #region "家計簿画面"

        /// <summary>
        /// 家計簿画面
        /// </summary>
        private void setTabAccount()
        {
            if (abEManager.AbExpenses.Count > 0)
            {
                int idx = 0;
                dgView.Rows.Clear();
                dgView.Rows.Add(abEManager.AbExpenses.Count);

                DataGridViewRow row;
                foreach (AbExpense exp in abEManager.AbExpenses)
                {
                    row = dgView.Rows[idx++];
                    row.Cells["colDate"].Value = exp.Date.ToShortDateString();
                    row.Cells["colName"].Value = exp.Name;
                    row.Cells["colType"].Value = exp.Type;
                    row.Cells["colPrice"].Value = exp.Price.ToString();
                }
            }

            dgView.ClearSelection();
            if (dgView.Rows.Count > 0)
            {
                dgView.FirstDisplayedScrollingRowIndex = dgView.Rows.Count - 1;
                dgView.Rows[dgView.Rows.Count - 1].Cells["colDate"].Selected = true;
            }
        }

        /// <summary>
        /// DataGridView を貼り付け可能にする
        /// </summary>
        private void dgView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                dgView.CurrentCell.Value = Clipboard.GetText();
                autoComplete(dgView.CurrentCell.RowIndex, dgView.CurrentCell.ColumnIndex);
            }
        }

        /// <summary>
        /// DB ファイルへ書き出し
        /// </summary>
        private void btnEntry_Click(object sender, EventArgs e)
        {
            //レコード 0 件
            if (dgView.Rows.Count == 0)
            {
                MessageBox.Show(
                    "レコードが1件もありません。",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //未入力の行は削除
            List<int> idxs = new List<int>();
            foreach (DataGridViewRow row in dgView.Rows)
            {
                if (string.IsNullOrEmpty(row.Cells["colName"].Value as string))
                {
                    idxs.Add(row.Index);
                }
            }

            idxs.Reverse();
            foreach (int i in idxs)
            {
                dgView.Rows.RemoveAt(i);
            }

            if (dgViewValidate())
            {
                try
                {
                    abEManager = new AbExpenseManager(dgView);
                    abEManager.writeDB(AbCommonConst.DB_NAME);
                    MessageBox.Show(
                        "正常に登録しました。",
                        "登録完了",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk
                    );
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

                abEManager = new AbExpenseManager(AbCommonConst.DB_NAME, dtENow);
                abGManager = new AbGraphManager(dtGNow, abEManager.AbExpenses);
            }
        }

        /// <summary>
        /// 新規行追加
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgView.Rows.Add(AbCommonConst.ADD_ROW_SIZE);
            for (int i = dgView.Rows.Count - AbCommonConst.ADD_ROW_SIZE; i < dgView.Rows.Count; i++)
            {
                dgView.Rows[i].Cells["colDate"].Value = DateTime.Today.ToShortDateString();
            }
        }

        /// <summary>
        /// セルの編集終了後に種別の自動補完を行う
        /// </summary>
        private void dgView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            autoComplete(e.RowIndex, e.ColumnIndex);
        }

        /// <summary>
        /// 種別の自動補完
        /// </summary>
        private void autoComplete(int row, int col)
        {
            if (col != 1) return;

            string name = dgView.Rows[row].Cells[col].Value as string;
            if (name != null)
            {
                Dictionary<string, int> counter = new Dictionary<string, int>();
                foreach (AbExpense exp in abEManager.AbExpenses)
                {
                    if (exp.Name == name)
                    {
                        if (counter.ContainsKey(exp.Type))
                        {
                            counter[exp.Type] += 1;
                        }
                        else
                        {
                            counter.Add(exp.Type, 1);
                        }
                    }
                }

                int cntMax = 0;
                string typeName = string.Empty;
                foreach (KeyValuePair<string, int> pair in counter)
                {
                    if (cntMax <= pair.Value)
                    {
                        cntMax = pair.Value;
                        typeName = pair.Key;
                    }
                }

                if (cntMax > 0)
                {
                    dgView.Rows[row].Cells["colType"].Value = typeName;
                }
            }
        }

        /// <summary>
        /// 登録前チェック
        /// 日付、種別、金額が入力されていなければエラー
        /// </summary>
        private bool dgViewValidate()
        {
            bool result = true;
            foreach (DataGridViewRow row in dgView.Rows)
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

        #endregion


        #region "月集計画面"

        /// <summary>
        /// 前年表示
        /// </summary>
        private void btnPrevY_Click(object sender, EventArgs e)
        {
            dtENow = dtENow.AddYears(-1);
            reloadSummary();
        }

        /// <summary>
        /// 前月表示
        /// </summary>
        private void btnPrevM_Click(object sender, EventArgs e)
        {
            dtENow = dtENow.AddMonths(-1);
            reloadSummary();
        }

        /// <summary>
        /// 翌月表示
        /// </summary>
        private void btnNextM_Click(object sender, EventArgs e)
        {
            dtENow = dtENow.AddMonths(1);
            reloadSummary();
        }

        /// <summary>
        /// 翌年表示
        /// </summary>
        private void btnNextY_Click(object sender, EventArgs e)
        {
            dtENow = dtENow.AddYears(1);
            reloadSummary();
        }

        /// <summary>
        /// 集計データ再読み込み
        /// </summary>
        public void reloadSummary()
        {
            abEManager.reload(dtENow);
            setTabSummary(dtENow.Year, dtENow.Month);
        }

        /// <summary>
        /// 月集計画面表示
        /// </summary>
        private void setTabSummary(int y, int m)
        {
            lblToday.Text     = string.Format("{0}年{1:d2}月", y, m);
            val_01食費.Text   = string.Format("{0:c}", abEManager.GetPrice("食費"  ));
            val_02外食費.Text = string.Format("{0:c}", abEManager.GetPrice("外食費"));
            val_03備品.Text   = string.Format("{0:c}", abEManager.GetPrice("備品"  ));
            val_04雑貨.Text   = string.Format("{0:c}", abEManager.GetPrice("雑貨"  ));
            val_05タイズ.Text = string.Format("{0:c}", abEManager.GetPrice("タイズ"));
            val_06小遣い.Text = string.Format("{0:c}", abEManager.GetPrice("小遣い"));
            val_07医療費.Text = string.Format("{0:c}", abEManager.GetPrice("医療費"));
            val_08交通費.Text = string.Format("{0:c}", abEManager.GetPrice("交通費"));
            val_09遊行費.Text = string.Format("{0:c}", abEManager.GetPrice("遊行費"));
            val_10家賃.Text   = string.Format("{0:c}", abEManager.GetPrice("家賃"  ));
            val_11電気代.Text = string.Format("{0:c}", abEManager.GetPrice("電気代"));
            val_12ガス代.Text = string.Format("{0:c}", abEManager.GetPrice("ガス代"));
            val_13水道代.Text = string.Format("{0:c}", abEManager.GetPrice("水道代"));
            val_14携帯代.Text = string.Format("{0:c}", abEManager.GetPrice("携帯代"));
            val_15保険料.Text = string.Format("{0:c}", abEManager.GetPrice("保険料"));
            val_16手数料.Text = string.Format("{0:c}", abEManager.GetPrice("手数料"));
            val_17その他.Text = string.Format("{0:c}", abEManager.GetPrice("その他"));
            val_18合計.Text   = string.Format("{0:c}", abEManager.GetPrice("合計"  ));
            val_19貯金.Text   = string.Format("{0:c}", abEManager.GetPrice("貯金"  ));
        }

        #endregion


        #region "グラフ画面"

        /// <summary>
        /// 前年表示
        /// </summary>
        private void btnGPrevY_Click(object sender, EventArgs e)
        {
            dtGNow = dtGNow.AddYears(-1);
            reloadGraph();
        }

        /// <summary>
        /// 前月表示
        /// </summary>
        private void btnGPrevM_Click(object sender, EventArgs e)
        {
            dtGNow = dtGNow.AddMonths(-1);
            reloadGraph();
        }

        /// <summary>
        /// 翌月表示
        /// </summary>
        private void btnGNextM_Click(object sender, EventArgs e)
        {
            dtGNow = dtGNow.AddMonths(1);
            reloadGraph();
        }

        /// <summary>
        /// 翌年表示
        /// </summary>
        private void btnGNextY_Click(object sender, EventArgs e)
        {
            dtGNow = dtGNow.AddYears(1);
            reloadGraph();
        }

        /// <summary>
        /// グラフデータ再読み込み
        /// </summary>
        private void reloadGraph()
        {
            abGManager.reload(dtGNow);
            setTabGraph(picbGraph.CreateGraphics());
        }

        /// <summary>
        /// グラフ描画イベント
        /// </summary>
        private void picbGraph_Paint(object sender, PaintEventArgs e)
        {
            setTabGraph(e.Graphics);
        }

        /// <summary>
        /// グラフ描画
        /// </summary>
        private void setTabGraph(Graphics g)
        {
            g.Clear(Color.Black);

            abGManager.drawGraph(g);

            lblYear.Text = string.Format("～{0}年{1:d2}月", dtGNow.Year, dtGNow.Month);
            lblX6.Text = dtGNow.Month.ToString("00");
            lblX5.Text = dtGNow.AddMonths( -2).Month.ToString("00");
            lblX4.Text = dtGNow.AddMonths( -4).Month.ToString("00");
            lblX3.Text = dtGNow.AddMonths( -6).Month.ToString("00");
            lblX2.Text = dtGNow.AddMonths( -8).Month.ToString("00");
            lblX1.Text = dtGNow.AddMonths(-10).Month.ToString("00");
        }

        #endregion
    }
}
