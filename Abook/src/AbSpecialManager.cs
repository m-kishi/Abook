namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 特別支出管理クラス
    /// </summary>
    public class AbSpecialManager
    {
        /// <summary> 特別支出リスト </summary>
        public List<AbSpecial> abSpecials;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="abExpenses">支出レコードのリスト</param>
        public AbSpecialManager(List<AbExpense> abExpenses)
        {
            if (abExpenses == null)
            {
                throw new ArgumentException("支出リストが指定されませんでした。");
            }

            abSpecials = new List<AbSpecial>();

            var expGroups = abExpenses.GroupBy(exp => exp.Date.Year);
            foreach (var year in expGroups.Select(gObj => gObj.Key))
            {
                //前年度
                var py = year - 1;
                var prev = abSpecials.Where(spc => spc.Year == py);
                if (prev == null || prev.Count() <= 0)
                {
                    var exps = SelectExpenses(py, abExpenses);
                    if (exps != null && exps.Count() > 0)
                    {
                        abSpecials.Add(CreateSpecial(py, exps));
                    }
                }

                //今年度
                var now = SelectExpenses(year, abExpenses);
                if (now != null && now.Count() > 0)
                {
                    abSpecials.Add(CreateSpecial(year, now));
                }
            }

            //合計
            if (abExpenses.Count > 0)
            {
                abSpecials.Add(CreateSpecial(9999, abExpenses));
            }
        }

        /// <summary>
        /// 年度内の支出を取得
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="abExpenses">支出リスト</param>
        /// <returns>年度内の支出リスト</returns>
        private IEnumerable<AbExpense> SelectExpenses(int year, List<AbExpense> abExpenses)
        {
            var dtStr = DateTime.ParseExact(
                string.Format("{0}-{1}", year, "04-01")
              , "yyyy-MM-dd"
              , null
            );
            var dtEnd = dtStr.AddYears(1).AddDays(-1);

            return abExpenses.Where(exp => dtStr <= exp.Date && exp.Date <= dtEnd);
        }

        /// <summary>
        /// 収支レコード生成
        /// </summary>
        /// <param name="year">年度</param>
        /// <param name="abExpenses">支出リスト</param>
        /// <returns>収支レコード</returns>
        private AbSpecial CreateSpecial(int year, IEnumerable<AbExpense> abExpenses)
        {
            var earn = GetEarn(abExpenses);
            var expense = GetExpense(abExpenses);
            var special = GetSpecial(abExpenses);
            var balance = GetBalance(abExpenses);

            return new AbSpecial(year, earn, expense, special, balance);
        }

        /// <summary>
        /// 収入合計取得
        /// </summary>
        /// <param name="abExpenses">支出リスト</param>
        /// <returns>収入合計</returns>
        private int GetEarn(IEnumerable<AbExpense> abExpenses)
        {
            //引数チェック
            if (abExpenses == null)
            {
                throw new ArgumentException("支出リストが指定されませんでした。");
            }

            //収入合計
            var earn = 0;
            var expEarn = abExpenses.Where(exp => exp.Type == "収入");
            if (expEarn != null && expEarn.Count() > 0)
            {
                earn = expEarn.Select(exp => exp.Price).Sum();
            }
            return earn;
        }

        /// <summary>
        /// 支出合計取得
        /// </summary>
        /// <param name="abExpenses">支出リスト</param>
        /// <returns>支出合計</returns>
        private int GetExpense(IEnumerable<AbExpense> abExpenses)
        {
            //引数チェック
            if (abExpenses == null)
            {
                throw new ArgumentException("支出リストが指定されませんでした。");
            }

            //支出合計
            var expense = 0;
            var excepts = new string[] { "収入", "特出" };
            var expExpense = abExpenses.Where(exp => !excepts.Contains(exp.Type));
            if (expExpense != null && expExpense.Count() > 0)
            {
                expense = expExpense.Select(exp => exp.Price).Sum();
            }
            return expense;
        }

        /// <summary>
        /// 特出合計取得
        /// </summary>
        /// <param name="abExpenses">支出リスト</param>
        /// <returns>特出合計</returns>
        private int GetSpecial(IEnumerable<AbExpense> abExpenses)
        {
            //引数チェック
            if (abExpenses == null)
            {
                throw new ArgumentException("支出リストが指定されませんでした。");
            }

            //特出合計
            var special = 0;
            var expSpecial = abExpenses.Where(exp => exp.Type == "特出");
            if (expSpecial != null && expSpecial.Count() > 0)
            {
                special = expSpecial.Select(exp => exp.Price).Sum();
            }
            return special;
        }

        /// <summary>
        /// 残金合計取得
        /// </summary>
        /// <param name="abExpenses">支出リスト</param>
        /// <returns>残金合計</returns>
        private int GetBalance(IEnumerable<AbExpense> abExpenses)
        {
            //引数チェック
            if (abExpenses == null)
            {
                throw new ArgumentException("支出リストが指定されませんでした。");
            }

            //収入合計
            var earn = 0;
            var expEarn = abExpenses.Where(exp => exp.Type == "収入");
            if (expEarn != null && expEarn.Count() > 0)
            {
                earn = expEarn.Select(exp => exp.Price).Sum();
            }

            //支出合計
            var expense = 0;
            var expExpense = abExpenses.Where(exp => exp.Type != "収入");
            if (expExpense != null && expExpense.Count() > 0)
            {
                expense = expExpense.Select(exp => exp.Price).Sum();
            }

            //残金合計
            return earn - expense;
        }

        /// <summary>
        /// イテレータ
        /// </summary>
        /// <returns>支出リスト</returns>
        public IEnumerable<AbSpecial> GetEnumerator()
        {
            foreach (var spc in abSpecials.OrderBy(spc => spc.Year))
            {
                yield return spc;
            }
        }
    }
}
