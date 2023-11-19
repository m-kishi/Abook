// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CHK = Abook.AbUtilities.CHK;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// 支出情報管理クラス
    /// </summary>
    public class AbExpenseManager
    {
        /// <summary>月次情報</summary>
        private AbSummary abCurrentSummary;
        /// <summary>月次情報リスト</summary>
        private List<AbSummary> abSummaries;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="summaries">月次情報リスト</param>
        public AbExpenseManager(DateTime date, List<AbSummary> summaries)
        {
            CHK.SumNull(summaries);

            abSummaries = summaries;
            SetCurrentSummary(date);
        }

        /// <summary>
        /// 月次情報設定
        /// </summary>
        /// <param name="date">対象日付</param>
        private void SetCurrentSummary(DateTime date)
        {
            var emptySummary = new AbSummary(date, new List<AbExpense>());
            var currentSummary = abSummaries.Where(sum =>
                sum.Year == date.Year && sum.Month == date.Month
            ).FirstOrDefault();
            abCurrentSummary = (currentSummary == null) ? emptySummary : currentSummary;
        }

        /// <summary>
        /// 現在の月次情報の日付を取得
        /// </summary>
        /// <returns>現在の月次情報の日付</returns>
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
        /// 金額取得
        /// </summary>
        /// <param name="type">種別</param>
        /// <returns>金額</returns>
        public decimal GetCost(string type)
        {
            return abCurrentSummary.GetCostByType(type);
        }

        /// <summary>
        /// 前年へ切り替え
        /// </summary>
        public void PrevYear()
        {
            var date = CurrentDate.AddYears(-1);
            SetCurrentSummary(date);
        }

        /// <summary>
        /// 前月へ切り替え
        /// </summary>
        public void PrevMonth()
        {
            var date = CurrentDate.AddMonths(-1);
            SetCurrentSummary(date);
        }

        /// <summary>
        /// 翌月へ切り替え
        /// </summary>
        public void NextMonth()
        {
            var date = CurrentDate.AddMonths(1);
            SetCurrentSummary(date);
        }

        /// <summary>
        /// 翌年へ切り替え
        /// </summary>
        public void NextYear()
        {
            var date = CurrentDate.AddYears(1);
            SetCurrentSummary(date);
        }
    }
}
