// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System.Collections.Generic;
    using System.Linq;
    using COL = Abook.AbConstants.COL.BALANCE;

    /// <summary>
    /// 収支タブ
    /// </summary>
    public partial class AbFormMain
    {
        /// <summary>収支情報管理</summary>
        private AbBalanceManager abBalanceManager;

        /// <summary>
        /// 収支タブ初期化
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        private void InitTabBalance(List<AbExpense> expenses)
        {
            abBalanceManager = new AbBalanceManager(expenses);
            SetTabBalance();
        }

        /// <summary>
        /// 収支タブ表示
        /// </summary>
        private void SetTabBalance()
        {
            DgvBalance.Rows.Clear();
            var balances = abBalanceManager.Balances();
            if (balances.Count() > 0)
            {
                var i = 0;
                DgvBalance.Rows.Add(balances.Count());
                foreach (var bln in balances)
                {
                    var row = DgvBalance.Rows[i++];
                    row.Cells[COL.YEAR].Value = bln.Year;
                    row.Cells[COL.EARN].Value = bln.Earn;
                    row.Cells[COL.EXPC].Value = bln.Expense;
                    row.Cells[COL.SPCL].Value = bln.Special;
                    row.Cells[COL.BLNC].Value = bln.Balance;
                }
            }

            DgvBalance.ClearSelection();
            if (DgvBalance.Rows.Count > 0)
            {
                var idx = DgvBalance.Rows.Count - 1;
                DgvBalance.Rows[idx].Selected = true;
                DgvBalance.FirstDisplayedScrollingRowIndex = idx;
                DgvBalance.Rows[idx].Cells[COL.YEAR].Selected = true;
            }
        }
    }
}
