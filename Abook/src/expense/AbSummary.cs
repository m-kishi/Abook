namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EX   = Abook.AbException.EX;
    using FMT  = Abook.AbConstants.FMT;
    using NAME = Abook.AbConstants.NAME;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 集計値クラス
    /// </summary>
    public partial class AbSummary
    {
        /// <summary>集計年</summary>
        public int Year { get; private set; }

        /// <summary>集計月</summary>
        public int Month { get; private set; }

        /// <summary>種別ごとの集計値</summary>
        private Dictionary<string, decimal> dicSumByType;

        /// <summary>名前ごとの集計値</summary>
        private Dictionary<string, decimal> dicSumByName;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="date">集計日付</param>
        /// <param name="expenses">支出レコードリスト</param>
        public AbSummary(DateTime date, List<AbExpense> expenses)
        {
            Year = date.Year;
            Month = date.Month;
            dicSumByType = SummaryByType(expenses);
            dicSumByName = SummaryByName(expenses);
        }

        /// <summary>
        /// 種別ごとの集計
        /// </summary>
        /// <param name="expenses">支出レコードリスト</param>
        /// <returns>種別ごとの集計</returns>
        private Dictionary<string, decimal> SummaryByType(List<AbExpense> expenses)
        {
            var dic = new Dictionary<string, decimal>();
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }
            foreach (var gObj in expenses.GroupBy(exp => exp.Type))
            {
                dic.Add(gObj.Key, gObj.Sum(exp => exp.Cost));
            }

            var total = expenses.Where(exp =>
                exp.Type != TYPE.EARN && exp.Type != TYPE.SPCL
            ).Sum(exp => exp.Cost);
            dic.Add(TYPE.TTAL, total);

            var earn = dic.ContainsKey(TYPE.EARN) ? dic[TYPE.EARN] : decimal.Zero;
            var balance = earn - total;
            dic.Add(TYPE.BLNC, balance);

            return dic;
        }

        /// <summary>
        /// 名前ごとの集計
        /// </summary>
        /// <param name="expenses">支出レコードリスト</param>
        /// <returns>名前ごとの集計</returns>
        private Dictionary<string, decimal> SummaryByName(List<AbExpense> expenses)
        {
            var dic = new Dictionary<string, decimal>();
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }
            var names = new string[] { NAME.EL, NAME.GS, NAME.WT };
            var filter = expenses.Where(exp => names.Contains(exp.Name));
            foreach (var gObj in filter.GroupBy(exp => exp.Name))
            {
                dic.Add(gObj.Key, gObj.Sum(exp => exp.Cost));
            }
            return dic;
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        /// <param name="type">種別</param>
        /// <returns>集計値</returns>
        public decimal GetCostByType(string type)
        {
            if (string.IsNullOrEmpty(type)) { return decimal.Zero; }
            return dicSumByType.ContainsKey(type) ? dicSumByType[type] : decimal.Zero;
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns>集計値</returns>
        public decimal GetCostByName(string name)
        {
            if (string.IsNullOrEmpty(name)) { return decimal.Zero; }
            return dicSumByName.ContainsKey(name) ? dicSumByName[name] : decimal.Zero;
        }
    }

    /// <summary>
    /// 集計値クラス
    /// static メソッド定義
    /// </summary>
    public partial class AbSummary
    {
        /// <summary>
        /// 集計値リスト生成
        /// </summary>
        /// <param name="expenses">支出レコードリスト</param>
        /// <returns>集計値リスト</returns>
        public static List<AbSummary> GetSummaries(List<AbExpense> expenses)
        {
            var summaries = new List<AbSummary>();
            if (expenses == null)
            {
                AbException.Throw(EX.EXPENSES_NULL);
            }
            var expGroups = expenses.GroupBy(exp =>
                exp.Date.ToString(FMT.MONTHLY_GROUP)
            );
            foreach (var span in expGroups.Select(gObj => gObj.Key))
            {
                var date = DateTime.ParseExact(string.Format(FMT.DAILY_GROUP, span), FMT.DATE, null);
                var filter = expenses.Where(exp =>
                    exp.Date.Year == date.Year && exp.Date.Month == date.Month
                ).ToList();
                summaries.Add(new AbSummary(date, filter));
            }
            return summaries;
        }
    }
}
