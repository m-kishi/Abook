// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using CHK = Abook.AbUtilities.CHK;
    using COL = Abook.AbConstants.COL.EXPENSE;
    using FMT = Abook.AbConstants.FMT;
    using MSG = Abook.AbUtilities.MSG;

    /// <summary>
    /// 種別サブフォーム
    /// </summary>
    public partial class AbSubType : Form
    {
        /// <summary>種別</summary>
        private string type;
        /// <summary>対象年月</summary>
        private DateTime dtCurrent;
        /// <summary>支出情報リスト</summary>
        private List<AbExpense> abExpenses;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="type"    >種別          </param>
        /// <param name="current" >対象年月      </param>
        /// <param name="expenses">支出情報リスト</param>
        public AbSubType(string type, DateTime current, List<AbExpense> expenses)
        {
            this.type = type;
            this.dtCurrent = current;
            this.abExpenses = expenses;

            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbSubType_Load(object sender, EventArgs e)
        {
            this.Text = type;
            try
            {
                SetDgvExpense(FilterByDateType(abExpenses));
            }
            catch (AbException ex)
            {
                MSG.Error(ex.Message);
                this.Close();
            }
        }

        /// <summary>
        /// 対象の支出情報リストを抽出
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        /// <returns>対象の支出情報リスト</returns>
        private List<AbExpense> FilterByDateType(List<AbExpense> expenses)
        {
            CHK.ExpNull(expenses);
            return expenses.Where(exp =>
                   exp.Date.Year  == dtCurrent.Year
                && exp.Date.Month == dtCurrent.Month
                && exp.Type       == type
            ).ToList();
        }

        /// <summary>
        /// 支出情報の表示
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        private void SetDgvExpense(List<AbExpense> expenses)
        {
            DgvExpense.Rows.Clear();
            DgvExpense.ClearSelection();
            if (expenses != null && expenses.Count > 0)
            {
                DgvExpense.Rows.Add(expenses.Count);

                int idx = 0;
                foreach (var exp in expenses)
                {
                    var row = DgvExpense.Rows[idx++];
                    row.Cells[COL.DATE].Value = exp.Date.ToString(FMT.DATE);
                    row.Cells[COL.NAME].Value = exp.Name;
                    row.Cells[COL.TYPE].Value = exp.Type;
                    row.Cells[COL.COST].Value = exp.Cost;
                    row.Cells[COL.NAME].ToolTipText = exp.Note;
                }
                DgvExpense.FirstDisplayedScrollingRowIndex = 0;
            }
        }
    }
}
