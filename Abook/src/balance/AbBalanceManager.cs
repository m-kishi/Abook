namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EX   = Abook.AbException.EX;
    using FMT  = Abook.AbConstants.FMT;
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
            abBalances = new List<AbBalance>();
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }

            var expGroups = expenses.GroupBy(exp => exp.Date.Year);
            foreach (var year in expGroups.Select(gObj => gObj.Key))
            {
                //前年度
                var prevYear = year - 1;
                var prevBalances = abBalances.Where(bln => bln.Year == prevYear);
                if (prevBalances == null || prevBalances.Count() <= 0)
                {
                    var prevExpenses = SelectExpenses(prevYear, expenses);
                    if (prevExpenses != null && prevExpenses.Count() > 0)
                    {
                        abBalances.Add(CreateBalance(prevYear, prevExpenses));
                    }
                }

                //今年度
                var currentExpenses = SelectExpenses(year, expenses);
                if (currentExpenses != null && currentExpenses.Count() > 0)
                {
                    abBalances.Add(CreateBalance(year, currentExpenses));
                }
            }

            //合計
            if (expenses.Count > 0)
            {
                abBalances.Add(CreateBalance(9999, expenses));
            }
        }

        /// <summary>
        /// 年度内の支出を取得
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="expenses">支出情報リスト</param>
        /// <returns>年度内の支出情報リスト</returns>
        private List<AbExpense> SelectExpenses(int year, List<AbExpense> expenses)
        {
            var dtStr = DateTime.ParseExact(
                string.Format(FMT.TARGET_YEAR, year, FMT.START_YEAR),
                FMT.DATE,
                null
            );
            var dtEnd = dtStr.AddYears(1).AddDays(-1);

            return expenses.Where(exp =>
                dtStr <= exp.Date && exp.Date <= dtEnd
            ).ToList();
        }

        /// <summary>
        /// 収支情報生成
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="expenses">支出情報リスト</param>
        /// <returns>収支情報</returns>
        private AbBalance CreateBalance(int year, List<AbExpense> expenses)
        {
            var earn = GetEarn(expenses);
            var expense = GetExpense(expenses);
            var special = GetSpecial(expenses);
            var balance = GetBalance(expenses);

            return new AbBalance(year, earn, expense, special, balance);
        }

        /// <summary>
        /// 収入取得
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        /// <returns>収入</returns>
        private decimal GetEarn(List<AbExpense> expenses)
        {
            var earn = decimal.Zero;
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }

            var targets = new string[] { TYPE.EARN, TYPE.BNUS };
            var earnExpenses = expenses.Where(exp => targets.Contains(exp.Type));
            if (earnExpenses != null && earnExpenses.Count() > 0)
            {
                earn = earnExpenses.Sum(exp => exp.Cost);
            }
            return earn;
        }

        /// <summary>
        /// 支出取得
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        /// <returns>支出</returns>
        private decimal GetExpense(List<AbExpense> expenses)
        {
            var expense = decimal.Zero;
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }

            var excepts = TYPE.EXCEPTS;
            var expenseExpenses = expenses.Where(exp => !excepts.Contains(exp.Type));
            if (expenseExpenses != null && expenseExpenses.Count() > 0)
            {
                expense = expenseExpenses.Sum(exp => exp.Cost);
            }
            return expense;
        }

        /// <summary>
        /// 特出取得
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        /// <returns>特出</returns>
        private decimal GetSpecial(List<AbExpense> expenses)
        {
            var special = decimal.Zero;
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }

            var specialExpenses = expenses.Where(exp => exp.Type == TYPE.SPCL);
            if (specialExpenses != null && specialExpenses.Count() > 0)
            {
                special = specialExpenses.Sum(exp => exp.Cost);
            }
            return special;
        }

        /// <summary>
        /// 収支取得
        /// </summary>
        /// <param name="expenses">支出情報リスト</param>
        /// <returns>収支</returns>
        private decimal GetBalance(List<AbExpense> expenses)
        {
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }

            var earn = decimal.Zero;
            var targets = new string[] { TYPE.EARN, TYPE.BNUS };
            var earnExpenses = expenses.Where(exp => targets.Contains(exp.Type));
            if (earnExpenses != null && earnExpenses.Count() > 0)
            {
                earn = earnExpenses.Sum(exp => exp.Cost);
            }

            var excepts = targets.Concat((new string[] { TYPE.PRVI, TYPE.PRVO }).ToList());
            var expense = decimal.Zero;
            var expenseExpenses = expenses.Where(exp => !excepts.Contains(exp.Type));
            if (expenseExpenses != null && expenseExpenses.Count() > 0)
            {
                expense = expenseExpenses.Sum(exp => exp.Cost);
            }
            return earn - expense;
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
