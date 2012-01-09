namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 集計値クラス
    /// </summary>
    public class AbSummary
    {
        /// <summary>集計年</summary>
        private int year;

        /// <summary>集計月</summary>
        private int month;

        /// <summary>種別ごとの集計値</summary>
        private Dictionary<string, int> dicSumByType;

        /// <summary>名前ごとの集計値</summary>
        private Dictionary<string, int> dicSumByName;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbSummary(DateTime dtNow, IEnumerable<AbExpense> abExpenses)
        {
            if (abExpenses == null)
            {
                throw new ArgumentException("支出リストが指定されませんでした。");
            }

            year = dtNow.Year;
            month = dtNow.Month;

            dicSumByType = new Dictionary<string, int>();
            dicSumByName = new Dictionary<string, int>();

            SummaryByType(abExpenses);
            SummaryByName(abExpenses);
        }

        /// <summary>
        /// 種別ごとの集計
        /// </summary>
        private void SummaryByType(IEnumerable<AbExpense> abExpenses)
        {
            foreach (var gObj in abExpenses.GroupBy(exp => exp.Type))
            {
                dicSumByType.Add(gObj.Key, gObj.Sum(exp => exp.Price));
            }
            dicSumByType.Add(
                "合計",
                abExpenses.Where(exp =>
                    exp.Type != "収入" && exp.Type != "特出"
                ).Sum(exp => exp.Price)
            );
            dicSumByType.Add("残金", GetPriceByType("収入") - GetPriceByType("合計"));
        }

        /// <summary>
        /// 名前ごとの集計
        /// </summary>
        private void SummaryByName(IEnumerable<AbExpense> abExpenses)
        {
            foreach (var gObj in abExpenses.GroupBy(exp => exp.Name))
            {
                dicSumByName.Add(gObj.Key, gObj.Sum(exp => exp.Price));
            }
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        public int GetPriceByType(string type)
        {
            if (string.IsNullOrEmpty(type)) { return 0; }
            return dicSumByType.ContainsKey(type) ? dicSumByType[type] : 0;
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        public int GetPriceByName(string name)
        {
            if (string.IsNullOrEmpty(name)) { return 0; }
            return dicSumByName.ContainsKey(name) ? dicSumByName[name] : 0;
        }

        /// <summary>
        /// 集計値抽出条件
        /// </summary>
        public bool Predicate(DateTime dt)
        {
            return (year == dt.Year && month == dt.Month);
        }

        /// <summary>
        /// 集計値リスト生成
        /// </summary>
        public static List<AbSummary> GetSummaries(List<AbExpense> abExpenses)
        {
            if (abExpenses == null)
            {
                throw new ArgumentException("支出リストが指定されませんでした。");
            }

            DateTime dtStr;
            DateTime dtEnd;
            List<AbSummary> abSummaries = new List<AbSummary>();

            var expGroups = abExpenses.GroupBy(exp =>
                string.Format("{0}/{1:00}", exp.Date.Year, exp.Date.Month)
            );

            foreach (var span in expGroups.Select(gObj => gObj.Key))
            {
                dtStr = DateTime.Parse(string.Format("{0}/{1}", span, "01"));
                dtEnd = dtStr.AddMonths(1).AddDays(-1);

                abSummaries.Add(
                    new AbSummary(
                        dtStr,
                        abExpenses.Where(exp =>
                            dtStr <= exp.Date && exp.Date <= dtEnd
                        )
                    )
                );
            }

            return abSummaries;
        }
    }
}
