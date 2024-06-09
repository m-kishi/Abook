// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System.Collections.Generic;
    using System.Linq;
    using COL = Abook.AbConstants.COL.FINANCE;
    using FMT = Abook.AbConstants.FMT;
    using UTL = Abook.AbUtilities;

    /// <summary>
    /// 投資タブ
    /// </summary>
    public partial class AbFormMain
    {
        /// <summary>投資情報管理</summary>
        private AbFinanceManager abFinanceManager;

        /// <summary>
        /// 投資タブ初期化
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        private void InitTabFinance(List<AbExpense> expenses)
        {
            abFinanceManager = new AbFinanceManager(expenses);
            SetTabFinance();
        }

        /// <summary>
        /// 投資タブ表示
        /// </summary>
        private void SetTabFinance()
        {
            DgvFinance.Rows.Clear();
            var finances = abFinanceManager.Finances();
            if (finances.Count() > 0)
            {
                var i = 0;
                DgvFinance.Rows.Add(finances.Count());
                foreach (var fnc in finances)
                {
                    var row = DgvFinance.Rows[i++];
                    row.Cells[COL.DATE].Value = fnc.Date.ToString(FMT.DATE);
                    row.Cells[COL.NAME].Value = fnc.Name;
                    row.Cells[COL.COST].Value = fnc.Cost;
                    row.Cells[COL.TTAL].Value = fnc.Ttal;
                    row.Cells[COL.NOTE].Value = fnc.Note;
                    UTL.SetToolTipAndColor(row, COL.NAME, fnc.Note);
                }
            }

            DgvFinance.ClearSelection();
            if (DgvFinance.Rows.Count > 0)
            {
                var idx = DgvFinance.Rows.Count - 1;
                DgvFinance.Rows[idx].Selected = true;
                DgvFinance.FirstDisplayedScrollingRowIndex = idx;
                DgvFinance.Rows[idx].Cells[COL.TTAL].Selected = true;
            }
        }
    }
}
