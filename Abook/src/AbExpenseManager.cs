namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 支出データ管理クラス
    /// </summary>
    public class AbExpenseManager
    {
        /// <summary>集計対象年月</summary>
        private DateTime dtNow;

        /// <summary>集計値</summary>
        private AbSummary abSummary;

        /// <summary>集計値リスト</summary>
        private List<AbSummary> abSummaries;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AbExpenseManager(DateTime dtToday, List<AbSummary> abSummaries)
        {
            if (abSummaries == null)
            {
                throw new ArgumentException("集計値リストが設定されませんでした。");
            }

            this.dtNow = dtToday;
            this.abSummaries = abSummaries;

            SetCurrentSummary(() => { });
        }

        /// <summary>
        /// 集計値設定
        /// </summary>
        private void SetCurrentSummary(Action DtChange)
        {
            DtChange();

            var sums = abSummaries.Where(sum => sum.Predicate(dtNow));
            abSummary = (sums.Count() > 0) ? sums.First() : new AbSummary(dtNow, new List<AbExpense>());
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        public string GetPrice(string type)
        {
            return string.Format("{0:c}", abSummary.GetPriceByType(type));
        }

        /// <summary>
        /// 前年集計
        /// </summary>
        public void PrevYear()
        {
            SetCurrentSummary(() => { dtNow = dtNow.AddYears(-1); });
        }

        /// <summary>
        /// 前月集計
        /// </summary>
        public void PrevMonth()
        {
            SetCurrentSummary(() => { dtNow = dtNow.AddMonths(-1); });
        }

        /// <summary>
        /// 翌月集計
        /// </summary>
        public void NextMonth()
        {
            SetCurrentSummary(() => { dtNow = dtNow.AddMonths(1); });
        }

        /// <summary>
        /// 翌年集計
        /// </summary>
        public void NextYear()
        {
            SetCurrentSummary(() => { dtNow = dtNow.AddYears(1); });
        }

        /// <summary>
        /// 集計対象年月取得
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}年{1:d2}月", dtNow.Year, dtNow.Month);
        }
    }
}
