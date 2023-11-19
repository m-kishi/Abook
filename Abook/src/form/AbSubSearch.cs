// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using UTL = Abook.AbUtilities;
    using CHK = Abook.AbUtilities.CHK;
    using COL = Abook.AbConstants.COL.EXPENSE;
    using FMT = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 検索サブフォーム
    /// </summary>
    public partial class AbSubSearch : Form
    {
        /// <summary>支出情報リスト</summary>
        private List<AbExpense> abExpenses;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        public AbSubSearch(List<AbExpense> expenses)
        {
            InitializeComponent();

            CHK.ExpNull(expenses);
            this.abExpenses = expenses;
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbSubSearch_Load(object sender, EventArgs e)
        {
            var names = abExpenses.GroupBy(exp => exp.Name).Select(obj => obj.Key).ToList();
            names.Sort();

            var types = new List<string>() { "" };
            types.AddRange(TYPE.EXPENCE);

            CmbName.DataSource = names;
            CmbType.DataSource = types;
        }

        /// <summary>
        /// 検索
        /// </summary>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var text = CmbName.Text;
            var selectedIndex = CmbName.SelectedIndex;

            var predicate = new Func<AbExpense, bool>(exp =>
                exp.Name == text
            );
            if (selectedIndex < 0)
            {
                predicate = new Func<AbExpense, bool>(exp =>
                    exp.Name.Contains(text)
                );
            }

            var type = UTL.ToStr(CmbType.SelectedValue);
            if (!UTL.IsEmpty(type))
            {
                predicate = new Func<AbExpense, bool>(exp =>
                    exp.Name == text && exp.Type == type
                );
                if (selectedIndex < 0)
                {
                    predicate = new Func<AbExpense, bool>(exp =>
                        exp.Name.Contains(text) && exp.Type == type
                    );
                }
            }

            DgvExpense.Rows.Clear();
            var expenses = abExpenses.Where(predicate);
            if (expenses != null && expenses.Count() > 0)
            {
                DgvExpense.Rows.Add(expenses.Count());

                var idx = 0;
                foreach (var exp in expenses)
                {
                    var row = DgvExpense.Rows[idx++];
                    row.Cells[COL.DATE].Value = exp.Date.ToString(FMT.DATE);
                    row.Cells[COL.NAME].Value = exp.Name;
                    row.Cells[COL.TYPE].Value = exp.Type;
                    row.Cells[COL.COST].Value = exp.Cost;
                    UTL.SetToolTipAndColor(row, COL.NAME, exp.Note);
                }
                DgvExpense.FirstDisplayedScrollingRowIndex = 0;
            }
        }
    }
}
