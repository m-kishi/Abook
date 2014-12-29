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
        public List<AbBalance> abBalances;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="abExpenses">支出情報リスト</param>
        public AbBalanceManager(List<AbExpense> expenses)
        {
            CHK.ChkExpNull(expenses);

            abBalances = expenses.Where(exp =>
                !TYPE.PRIVATE.Contains(exp.Type)
            ).GroupBy(exp =>
                exp.Date.Month == 3 ? exp.Date.Year - 1 :
                exp.Date.Month == 2 ? exp.Date.Year - 1 :
                exp.Date.Month == 1 ? exp.Date.Year - 1 :
                                      exp.Date.Year
            ).Select(exp =>
                new AbBalance(
                    exp.Key,
                    exp.Where(e => TYPE.BALANCE.EARN.Contains(e.Type)).Sum(e => e.Cost),
                    exp.Where(e => TYPE.BALANCE.EXPE.Contains(e.Type)).Sum(e => e.Cost),
                    exp.Where(e => e.Type == TYPE.SPCL).Sum(e => e.Cost),
                    exp.Sum  (e => TYPE.BALANCE.EARN.Contains(e.Type) ? e.Cost : -e.Cost)
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
            foreach (var bln in abBalances.OrderBy(bln => bln.Year))
            {
                yield return bln;
            }
        }
    }
}
