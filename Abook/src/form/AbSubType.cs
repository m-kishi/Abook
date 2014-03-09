namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using EX  = Abook.AbException.EX;
    using COL = Abook.AbConstants.COL;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// 種別明細サブフォーム
    /// </summary>
    public partial class AbSubType : Form
    {
        /// <summary>種別</summary>
        private string Type { get; set; }

        /// <summary>対象年月</summary>
        private DateTime DtCurrent { get; set; }

        /// <summary>フォーム</summary>
        private AbFormMain MainForm { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parent" >フォーム</param>
        /// <param name="type"   >種別    </param>
        /// <param name="current">対象年月</param>
        public AbSubType(AbFormMain parent, string type, DateTime current)
        {
            Type = type;
            MainForm = parent;
            DtCurrent = current;

            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        private void AbSubType_Load(object sender, EventArgs e)
        {
            this.Text = Type;
            try
            {
                var expenses = AbDBManager.Load(MainForm.DB);
                SetDgvExpense(FilterByDateType(expenses));
            }
            catch (AbException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
            if (expenses == null) { AbException.Throw(EX.EXPENSES_NULL); }
            return expenses.Where(exp =>
                   exp.Date.Year  == DtCurrent.Year
                && exp.Date.Month == DtCurrent.Month
                && exp.Type       == Type
            ).ToList();
        }

        /// <summary>
        /// 種別明細表示
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
                }
                DgvExpense.FirstDisplayedScrollingRowIndex = 0;
            }
        }
    }
}
