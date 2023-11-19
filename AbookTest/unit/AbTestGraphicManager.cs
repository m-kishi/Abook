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
    /// 推移情報管理テスト
    /// </summary>
    [TestFixture]
    public class AbTestGraphicManager
    {
        /// <summary>引数:日付</summary>
        private DateTime argDate;
        /// <summary>引数:月次情報リスト</summary>
        private List<AbSummary> argSummaries;
        /// <summary>対象:推移情報管理</summary>
        private AbGraphicManager abGraphicManager;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argDate = new DateTime(2011, 3, 11);
            argSummaries = new List<AbSummary>();
            abGraphicManager = new AbGraphicManager(argDate, argSummaries);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:月次情報リストがNULL
        /// </summary>
        [Test]
        public void AbGraphManagerWithNullSummaries()
        {
            argSummaries = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbGraphicManager(argDate, argSummaries)
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
            var expected = argDate.ToString(FMT.TITLE);
            Assert.AreEqual(expected, abGraphicManager.Title);
        }

        /// <summary>
        /// 月表示
        /// </summary>
        /// <param name="prev">月指定</param>
        /// <param name="expected">期待値</param>
        [TestCase( 8, "11")]
        [TestCase( 1, "04")]
        [TestCase( 0, "03")]
        [TestCase(-2, "01")]
        [TestCase(-6, "09")]
        public void GetMonth(int prev, string expected)
        {
            Assert.AreEqual(expected, abGraphicManager.GetMonth(prev));
        }

        /// <summary>
        /// 前年へ切り替え
        /// </summary>
        /// <param name="prev">月指定</param>
        /// <param name="expected">期待値</param>
        [TestCase(  0, "03")]
        [TestCase( -2, "01")]
        [TestCase( -4, "11")]
        [TestCase( -6, "09")]
        [TestCase( -8, "07")]
        [TestCase(-10, "05")]
        public void PrevYear(int prev, string expected)
        {
            abGraphicManager.PrevYear();

            var dtPrev = argDate.AddYears(-1);
            var title = dtPrev.ToString(FMT.TITLE);

            Assert.AreEqual(title, abGraphicManager.Title);
            Assert.AreEqual(expected, abGraphicManager.GetMonth(prev));
        }

        /// <summary>
        /// 前月へ切り替え
        /// </summary>
        /// <param name="prev">月指定</param>
        /// <param name="expected">期待値</param>
        [TestCase(  0, "02")]
        [TestCase( -2, "12")]
        [TestCase( -4, "10")]
        [TestCase( -6, "08")]
        [TestCase( -8, "06")]
        [TestCase(-10, "04")]
        public void PrevMonth(int prev, string expected)
        {
            abGraphicManager.PrevMonth();

            var dtPrev = argDate.AddMonths(-1);
            var title = dtPrev.ToString(FMT.TITLE);

            Assert.AreEqual(title, abGraphicManager.Title);
            Assert.AreEqual(expected, abGraphicManager.GetMonth(prev));
        }

        /// <summary>
        /// 翌月へ切り替え
        /// </summary>
        /// <param name="prev">月指定</param>
        /// <param name="expected">期待値</param>
        [TestCase(  0, "04")]
        [TestCase( -2, "02")]
        [TestCase( -4, "12")]
        [TestCase( -6, "10")]
        [TestCase( -8, "08")]
        [TestCase(-10, "06")]
        public void NextMonth(int prev, string expected)
        {
            abGraphicManager.NextMonth();

            var dtNext = argDate.AddMonths(1);
            var title = dtNext.ToString(FMT.TITLE);

            Assert.AreEqual(title, abGraphicManager.Title);
            Assert.AreEqual(expected, abGraphicManager.GetMonth(prev));
        }

        /// <summary>
        /// 翌年へ切り替え
        /// </summary>
        /// <param name="prev">月指定</param>
        /// <param name="expected">期待値</param>
        [TestCase(  0, "03")]
        [TestCase( -2, "01")]
        [TestCase( -4, "11")]
        [TestCase( -6, "09")]
        [TestCase( -8, "07")]
        [TestCase(-10, "05")]
        public void NextYear(int prev, string expected)
        {
            abGraphicManager.NextYear();

            var dtNext = argDate.AddYears(1);
            var title = dtNext.ToString(FMT.TITLE);

            Assert.AreEqual(title, abGraphicManager.Title);
            Assert.AreEqual(expected, abGraphicManager.GetMonth(prev));
        }
    }
}
