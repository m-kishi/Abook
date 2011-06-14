namespace Abook
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class AbTestExpenseManager
    {
        private DateTime argDtToday;
        private List<AbSummary> argAbSummaries;
        private AbExpenseManager abExpenseManager;

        [SetUp]
        public void SetUp()
        {
            argDtToday = new DateTime(2011, 3, 11);
            argAbSummaries = AbSummary.GetSummaries(
                AbDBManager.LoadFromFile("In_AbExpenseManagerTest.db")
            );

            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);
        }

        [Test]
        public void AbExpenseManagerWithNullSummaries()
        {
            argAbSummaries = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpenseManager(argDtToday, argAbSummaries); }
            );
        }

        [Test]
        public void GetPriceWithNullType()
        {
            Assert.AreEqual(string.Format("{0:c}",0), abExpenseManager.GetPrice(null));
        }

        [Test]
        public void GetPriceWithEmptyType()
        {
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice(string.Empty));
        }

        [Test]
        public void GetPriceWithEmptySummaries()
        {
            argAbSummaries = new List<AbSummary>();
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void GetPriceWithDtToday()
        {
            Assert.AreEqual(string.Format("{0:c}",   6527), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",   7904), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",   2930), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}",   5900), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",    930), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",   2000), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   8447), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1303), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",   2330), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",   9760), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",    525), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}",  94056), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 160059), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",  66003), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void ToStringWithDtNow()
        {
            Assert.AreEqual("2011年03月", abExpenseManager.ToString());
        }

        [Test]
        public void PrevYearWith1Time()
        {
            argDtToday = new DateTime(2011, 4, 30);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.PrevYear();

            Assert.AreEqual("2010年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}",   8074), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",   6820), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("雑貨  "));
            Assert.AreEqual(string.Format("{0:c}",   7300), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",   7940), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",   2535), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   9987), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1304), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",   2850), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",  15435), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 107745), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 164843), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",  57098), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void PrevYearWith2Times()
        {
            argDtToday = new DateTime(2011, 4, 30);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();

            Assert.AreEqual("2009年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}",   8967), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",  11355), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",   3194), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}",   5660), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",   4300), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",    579), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   9074), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1304), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",  15285), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 105218), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 110321), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",   5103), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void PrevYearWith3Times()
        {
            argDtToday = new DateTime(2011, 4, 30);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();

            Assert.AreEqual("2008年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void PrevYearWith4Times()
        {
            argDtToday = new DateTime(2011, 4, 30);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();
            abExpenseManager.PrevYear();

            Assert.AreEqual("2007年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void PrevMonthWith1Time()
        {
            argDtToday = new DateTime(2009, 6, 30);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.PrevMonth();

            Assert.AreEqual("2009年05月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}",  13216), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",   8890), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",   6966), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}",   5000), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",   9040), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",   4600), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   7669), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1304), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",   4880), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 107065), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 168102), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",  61037), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void PrevMonthWith2Times()
        {
            argDtToday = new DateTime(2009, 6, 30);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();

            Assert.AreEqual("2009年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}",   8967), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",  11355), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",   3194), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}",   5660), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",   4300), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",    579), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   9074), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1304), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",  15285), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 105218), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 110321), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",   5103), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void PrevMonthWith3Times()
        {
            argDtToday = new DateTime(2009, 6, 30);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();

            Assert.AreEqual("2009年03月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void PrevMonthWith4Times()
        {
            argDtToday = new DateTime(2009, 6, 30);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();
            abExpenseManager.PrevMonth();

            Assert.AreEqual("2009年02月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void NextMonthWith1Time()
        {
            argDtToday = new DateTime(2011, 2, 28);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.NextMonth();

            Assert.AreEqual("2011年03月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}",   6527), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",   7904), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",   2930), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}",   5900), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",    930), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",   2000), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   8447), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1303), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",   2330), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",   9760), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",    525), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}",  94056), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 160059), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",  66003), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void NextMonthWith2Times()
        {
            argDtToday = new DateTime(2011, 2, 28);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();

            Assert.AreEqual("2011年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}",   6390), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",   6730), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",   2171), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}",   4514), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",   7940), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",    649), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   8468), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1303), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",   2760), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",  15435), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 101860), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 159889), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",  58029), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void NextMonthWith3Times()
        {
            argDtToday = new DateTime(2011, 2, 28);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();

            Assert.AreEqual("2011年05月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void NextMonthWith4Times()
        {
            argDtToday = new DateTime(2011, 2, 28);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();
            abExpenseManager.NextMonth();

            Assert.AreEqual("2011年06月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void NextYearWith1Time()
        {
            argDtToday = new DateTime(2009, 4, 1);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.NextYear();

            Assert.AreEqual("2010年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}",   8074), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",   6820), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}",   7300), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",   7940), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",   2535), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   9987), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1304), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",   2850), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",  15435), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 107745), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 164843), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",  57098), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void NextYearWith2Times()
        {
            argDtToday = new DateTime(2009, 4, 1);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.NextYear();
            abExpenseManager.NextYear();

            Assert.AreEqual("2011年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}",   6390), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}",   6730), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}",   2171), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}",   4514), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}",   7940), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}",    649), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}",  45500), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}",   8468), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}",   1303), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}",   2760), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}",  15435), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 101860), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 159889), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}",  58029), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}",      0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void NextYearWith3Times()
        {
            argDtToday = new DateTime(2009, 4, 1);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();

            Assert.AreEqual("2012年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }

        [Test]
        public void NextYearWith4Times()
        {
            argDtToday = new DateTime(2009, 4, 1);
            abExpenseManager = new AbExpenseManager(argDtToday, argAbSummaries);

            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();
            abExpenseManager.NextYear();

            Assert.AreEqual("2013年04月", abExpenseManager.ToString());
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("食費"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("外食費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("雑貨"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交際費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("交通費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("遊行費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("家賃"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("光熱費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("通信費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("医療費"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("保険料"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("その他"));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("合計"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("収入"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("残金"  ));
            Assert.AreEqual(string.Format("{0:c}", 0), abExpenseManager.GetPrice("not match"));
        }
    }
}
