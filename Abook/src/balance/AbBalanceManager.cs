// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CHK  = Abook.AbUtilities.CHK;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 収支情報管理クラス
    /// </summary>
    public class AbBalanceManager
    {
        /// <summary>収支情報リスト</summary>
        private List<AbBalance> abBalances;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        public AbBalanceManager(List<AbExpense> expenses)
        {
            CHK.ExpNull(expenses);

            abBalances = expenses.Where(exp =>
                !TYPE.PRIVATE.Contains(exp.Type)
            ).GroupBy(exp =>
                exp.Date.Month == 3 ? exp.Date.Year - 1 :
                exp.Date.Month == 2 ? exp.Date.Year - 1 :
                exp.Date.Month == 1 ? exp.Date.Year - 1 :
                                      exp.Date.Year
            ).Select(gObj =>
                new AbBalance(
                    gObj.Key,
                    gObj.Where(exp => TYPE.BALANCE.EARN.Contains(exp.Type)).Sum(exp => exp.Cost),
                    gObj.Where(exp => TYPE.BALANCE.EXPE.Contains(exp.Type)).Sum(exp => exp.Cost),
                    gObj.Where(exp => exp.Type == TYPE.SPCL).Sum(exp => exp.Cost),
                    gObj.Sum  (exp => TYPE.BALANCE.EARN.Contains(exp.Type) ? exp.Cost : -exp.Cost)
                )
            ).ToList();

            //合計
            if (expenses.Count > 0)
            {
                var total = new AbBalance(
                    9999,
                    abBalances.Sum(bln => bln.Earn),
                    abBalances.Sum(bln => bln.Expense),
                    abBalances.Sum(bln => bln.Special),
                    abBalances.Sum(bln => bln.Balance)
                );
                abBalances.Add(total);
            }
        }

        /// <summary>
        /// 収支情報リスト
        /// </summary>
        /// <returns>収支情報リスト</returns>
        public IEnumerable<AbBalance> Balances()
        {
            var orderd = abBalances.OrderBy(bln => bln.Year);
            foreach (var bln in orderd) yield return bln;
        }
    }
}
