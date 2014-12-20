namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EX  = Abook.AbException.EX;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// 支出情報管理クラス
    /// </summary>
    public class AbExpenseManager
    {
        /// <summary>集計値</summary>
        private AbSummary abCurrentSummary;
        /// <summary>集計値リスト</summary>
        private List<AbSummary> abSummaries;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="summaries">集計値リスト</param>
        public AbExpenseManager(DateTime date, List<AbSummary> summaries)
        {
            if (summaries == null)
            {
                AbException.Throw(EX.SUMMARIES_NULL);
            }
            this.abSummaries = summaries;
            SetCurrentSummary(date);
        }

        /// <summary>
        /// 集計値設定
        /// </summary>
        /// <param name="date">対象日付</param>
        private void SetCurrentSummary(DateTime date)
        {
            var emptySummary = new AbSummary(date, new List<AbExpense>());
            var currentSummary = abSummaries.Where(sum =>
                sum.Year == date.Year && sum.Month == date.Month
            ).FirstOrDefault();
            abCurrentSummary = currentSummary == null ? emptySummary : currentSummary;
        }

        /// <summary>
        /// 現在集計値の日付を取得
        /// </summary>
        /// <returns>現在集計値の日付</returns>
        public DateTime CurrentDate
        {
            get
            {
                return new DateTime(abCurrentSummary.Year, abCurrentSummary.Month, 1);
            }
        }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get { return CurrentDate.ToString(FMT.TITLE); }
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        /// <param name="type">種別</param>
        /// <returns>集計値</returns>
        public decimal GetCost(string type)
        {
            return abCurrentSummary.GetCostByType(type);
        }

        /// <summary>
        /// 前年集計
        /// </summary>
        public void PrevYear()
        {
            var date = CurrentDate.AddYears(-1);
            SetCurrentSummary(date);
        }

        /// <summary>
        /// 前月集計
        /// </summary>
        public void PrevMonth()
        {
            var date = CurrentDate.AddMonths(-1);
            SetCurrentSummary(date);
        }

        /// <summary>
        /// 翌月集計
        /// </summary>
        public void NextMonth()
        {
            var date = CurrentDate.AddMonths(1);
            SetCurrentSummary(date);
        }

        /// <summary>
        /// 翌年集計
        /// </summary>
        public void NextYear()
        {
            var date = CurrentDate.AddYears(1);
            SetCurrentSummary(date);
        }
    }
}
