// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using EX  = Abook.AbException.EX;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// 支出情報管理テスト
    /// </summary>
    [TestFixture]
    public class AbTestExpenseManager
    {
        /// <summary>引数:日付</summary>
        private DateTime argDate;
        /// <summary>引数:集計値リスト</summary>
        private List<AbSummary> argSummaries;
        /// <summary>対象:支出情報管理</summary>
        private AbExpenseManager abExpenseManager;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argDate = new DateTime(2011, 4, 1);
            argSummaries = AbSummary.GetSummaries(GenerateExpenses());
            abExpenseManager = new AbExpenseManager(argDate, argSummaries);
        }

        /// <summary>
        /// 支出情報リスト生成
        /// </summary>
        /// <returns>支出情報リスト</returns>
        private List<AbExpense> GenerateExpenses()
        {
            var expenses = new List<AbExpense>();
            expenses.Add(new AbExpense("2009-04-01", "name", "食費", "100"));
            expenses.Add(new AbExpense("2010-04-01", "name", "食費", "200"));
            expenses.Add(new AbExpense("2011-02-01", "name", "食費", "300"));
            expenses.Add(new AbExpense("2011-03-01", "name", "食費", "400"));
            expenses.Add(new AbExpense("2011-04-01", "name", "食費", "500"));
            expenses.Add(new AbExpense("2011-05-01", "name", "食費", "600"));
            expenses.Add(new AbExpense("2011-06-01", "name", "食費", "700"));
            expenses.Add(new AbExpense("2012-04-01", "name", "食費", "800"));
            expenses.Add(new AbExpense("2013-04-01", "name", "食費", "900"));
            return expenses;
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:集計値リストがNULL
        /// </summary>
        [Test]
        public void AbExpenseManagerWithNullSummaries()
        {
            argSummaries = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpenseManager(argDate, argSummaries)
            );
            Assert.AreEqual(EX.SUMMARIES_NULL, ex.Message);
        }

        /// <summary>
        /// タイトル
        /// 初期値のテスト
        /// </summary>
        [Test]
        public void TitleWithCurrent()
        {
            Assert.AreEqual(argDate.ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 集計値リストが空リストのテスト
        /// </summary>
        [Test]
        public void TitleWithEmptySummaries()
        {
            Assert.AreEqual(argDate.ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 1年前のテスト
        /// </summary>
        [Test]
        public void TitleWith_1_PrevYear()
        {
            abExpenseManager.PrevYear();
            Assert.AreEqual(argDate.AddYears(-1).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 2年前のテスト
        /// </summary>
        [Test]
        public void TitleWith_2_PrevYear()
        {
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            Assert.AreEqual(argDate.AddYears(-2).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 3年前のテスト
        /// </summary>
        [Test]
        public void TitleWith_3_PrevYear()
        {
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            Assert.AreEqual(argDate.AddYears(-3).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 1ヶ月前のテスト
        /// </summary>
        [Test]
        public void TitleWith_1_PrevMonth()
        {
            abExpenseManager.PrevMonth();
            Assert.AreEqual(argDate.AddMonths(-1).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 2ヶ月前のテスト
        /// </summary>
        [Test]
        public void TitleWith_2_PrevMonth()
        {
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            Assert.AreEqual(argDate.AddMonths(-2).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 3ヶ月前のテスト
        /// </summary>
        [Test]
        public void TitleWith_3_PrevMonth()
        {
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            Assert.AreEqual(argDate.AddMonths(-3).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 1ヶ月後のテスト
        /// </summary>
        [Test]
        public void TitleWith_1_NextMonth()
        {
            abExpenseManager.NextMonth();
            Assert.AreEqual(argDate.AddMonths(1).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 2ヶ月後のテスト
        /// </summary>
        [Test]
        public void TitleWith_2_NextMonth()
        {
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            Assert.AreEqual(argDate.AddMonths(2).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 3ヶ月後のテスト
        /// </summary>
        [Test]
        public void TitleWith_3_NextMonth()
        {
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            Assert.AreEqual(argDate.AddMonths(3).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 1年後のテスト
        /// </summary>
        [Test]
        public void TitleWith_1_NextYear()
        {
            abExpenseManager.NextYear();
            Assert.AreEqual(argDate.AddYears(1).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 2年後のテスト
        /// </summary>
        [Test]
        public void TitleWith_2_NextYear()
        {
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            Assert.AreEqual(argDate.AddYears(2).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// タイトル
        /// 3年後のテスト
        /// </summary>
        [Test]
        public void TitleWith_3_NextYear()
        {
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            Assert.AreEqual(argDate.AddYears(3).ToString(FMT.TITLE), abExpenseManager.Title);
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        [Test]
        public void GetCostWithCurrent()
        {
            Assert.AreEqual(500, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 集計値取得
        /// 引数:種別がNULL
        /// </summary>
        [Test]
        public void GetCostWithNullType()
        {
            Assert.AreEqual(0, abExpenseManager.GetCost(null));
        }

        /// <summary>
        /// 集計値取得
        /// 引数:種別が空文字列
        /// </summary>
        [Test]
        public void GetCostWithEmptyType()
        {
            Assert.AreEqual(0, abExpenseManager.GetCost(string.Empty));
        }

        /// <summary>
        /// 集計値取得
        /// 集計値リストが空リスト
        /// </summary>
        [Test]
        public void GetCostWithEmptySummaries()
        {
            argSummaries = new List<AbSummary>();
            abExpenseManager = new AbExpenseManager(argDate, argSummaries);

            Assert.AreEqual(0, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 前年集計
        /// 1年前のテスト
        /// </summary>
        [Test]
        public void PrevYearWith_1_Time()
        {
            abExpenseManager.PrevYear();
            Assert.AreEqual(200, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 前年集計
        /// 2年前のテスト
        /// </summary>
        [Test]
        public void PrevYearWith_2_Times()
        {
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            Assert.AreEqual(100, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 前年集計
        /// 3年前のテスト
        /// </summary>
        [Test]
        public void PrevYearWith_3_Times()
        {
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            Assert.AreEqual(0, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 前月集計
        /// 1ヶ月前のテスト
        /// </summary>
        [Test]
        public void PrevMonthWith_1_Time()
        {
            abExpenseManager.PrevMonth();
            Assert.AreEqual(400, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 前月集計
        /// 2ヶ月前のテスト
        /// </summary>
        [Test]
        public void PrevMonthWith_2_Times()
        {
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            Assert.AreEqual(300, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 前月集計
        /// 3ヶ月前のテスト
        /// </summary>
        [Test]
        public void PrevMonthWith_3_Times()
        {
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            Assert.AreEqual(0, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 翌月集計
        /// 1ヵ月後のテスト
        /// </summary>
        [Test]
        public void NextMonthWith_1_Time()
        {
            abExpenseManager.NextMonth();
            Assert.AreEqual(600, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 翌月集計
        /// 2ヵ月後のテスト
        /// </summary>
        [Test]
        public void NextMonthWith_2_Times()
        {
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            Assert.AreEqual(700, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 翌月集計
        /// 3ヵ月後のテスト
        /// </summary>
        [Test]
        public void NextMonthWith_3_Times()
        {
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            Assert.AreEqual(0, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 翌年集計
        /// 1年後のテスト
        /// </summary>
        [Test]
        public void NextYearWith_1_Time()
        {
            abExpenseManager.NextYear();
            Assert.AreEqual(800, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 翌年集計
        /// 2年後のテスト
        /// </summary>
        [Test]
        public void NextYearWith_2_Times()
        {
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            Assert.AreEqual(900, abExpenseManager.GetCost("食費"));
        }

        /// <summary>
        /// 翌年集計
        /// 3年後のテスト
        /// </summary>
        [Test]
        public void NextYearWith_3_Times()
        {
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            Assert.AreEqual(0, abExpenseManager.GetCost("食費"));
        }
    }
}
