namespace AbookTest
{
    using Abook;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using EX   = Abook.AbException.EX;
    using NAME = Abook.AbConstants.NAME;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 集計値テスト
    /// </summary>
    [TestFixture]
    public class AbTestSummary
    {
        /// <summary>引数:日付</summary>
        private DateTime argDate;
        /// <summary>引数:支出レコードリスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>対象:集計値</summary>
        private AbSummary abSummary;

        [SetUp]
        public void SetUp()
        {
            argDate = new DateTime(2011, 3, 15);
            argExpenses = GenerateExpenses();
            abSummary = new AbSummary(argDate, argExpenses);
        }

        /// <summary>
        /// 支出レコードリスト生成
        /// </summary>
        /// <returns>支出レコードリスト</returns>
        private List<AbExpense> GenerateExpenses()
        {
            var expenses = new List<AbExpense>();
            expenses.Add(new AbExpense("2011-03-01", "FOOD", TYPE.FOOD, "100"));
            expenses.Add(new AbExpense("2011-03-02", "FOOD", TYPE.FOOD, "110"));
            expenses.Add(new AbExpense("2011-03-03", "OTFD", TYPE.OTFD, "200"));
            expenses.Add(new AbExpense("2011-03-04", "OTFD", TYPE.OTFD, "210"));
            expenses.Add(new AbExpense("2011-03-05", "GOOD", TYPE.GOOD, "300"));
            expenses.Add(new AbExpense("2011-03-06", "GOOD", TYPE.GOOD, "310"));
            expenses.Add(new AbExpense("2011-03-07", "FRND", TYPE.FRND, "400"));
            expenses.Add(new AbExpense("2011-03-08", "FRND", TYPE.FRND, "410"));
            expenses.Add(new AbExpense("2011-03-09", "TRFC", TYPE.TRFC, "500"));
            expenses.Add(new AbExpense("2011-03-10", "TRFC", TYPE.TRFC, "510"));
            expenses.Add(new AbExpense("2011-03-11", "PLAY", TYPE.PLAY, "600"));
            expenses.Add(new AbExpense("2011-03-12", "PLAY", TYPE.PLAY, "610"));
            expenses.Add(new AbExpense("2011-03-13", "HOUS", TYPE.HOUS, "700"));
            expenses.Add(new AbExpense("2011-03-14", "HOUS", TYPE.HOUS, "710"));
            expenses.Add(new AbExpense("2011-03-15", NAME.EL, TYPE.ENGY, "800"));
            expenses.Add(new AbExpense("2011-03-16", NAME.EL, TYPE.ENGY, "810"));
            expenses.Add(new AbExpense("2011-03-17", NAME.GS, TYPE.ENGY, "820"));
            expenses.Add(new AbExpense("2011-03-18", NAME.GS, TYPE.ENGY, "830"));
            expenses.Add(new AbExpense("2011-03-19", NAME.WT, TYPE.ENGY, "840"));
            expenses.Add(new AbExpense("2011-03-20", NAME.WT, TYPE.ENGY, "850"));
            expenses.Add(new AbExpense("2011-03-21", "CNCT", TYPE.CNCT, "900"));
            expenses.Add(new AbExpense("2011-03-22", "CNCT", TYPE.CNCT, "910"));
            expenses.Add(new AbExpense("2011-03-23", "MEDI", TYPE.MEDI, "1000"));
            expenses.Add(new AbExpense("2011-03-24", "MEDI", TYPE.MEDI, "1100"));
            expenses.Add(new AbExpense("2011-03-25", "INSU", TYPE.INSU, "2000"));
            expenses.Add(new AbExpense("2011-03-26", "INSU", TYPE.INSU, "2100"));
            expenses.Add(new AbExpense("2011-03-27", "OTHR", TYPE.OTHR, "3000"));
            expenses.Add(new AbExpense("2011-03-28", "OTHR", TYPE.OTHR, "3100"));
            expenses.Add(new AbExpense("2011-03-29", "EARN", TYPE.EARN, "100000"));
            expenses.Add(new AbExpense("2011-03-30", "EARN", TYPE.EARN, "110000"));
            expenses.Add(new AbExpense("2011-03-31", "BNUS", TYPE.BNUS, "200000"));
            expenses.Add(new AbExpense("2011-03-31", "BNUS", TYPE.BNUS, "300000"));
            expenses.Add(new AbExpense("2011-03-31", "SPCL", TYPE.SPCL, "20000"));
            expenses.Add(new AbExpense("2011-03-31", "SPCL", TYPE.SPCL, "21000"));
            return expenses;
        }

        /// <summary>
        /// コンストラクタ
        /// 集計年のテスト
        /// </summary>
        [Test]
        public void AbSummaryWithYear()
        {
            Assert.AreEqual(argDate.Year, abSummary.Year);
        }

        /// <summary>
        /// コンストラクタ
        /// 集計月のテスト
        /// </summary>
        [Test]
        public void AbSummaryWithMonth()
        {
            Assert.AreEqual(argDate.Month, abSummary.Month);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出レコードリストが NULL
        /// </summary>
        [Test]
        public void AbSummaryWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                { new AbSummary(argDate, argExpenses); }
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// 集計値取得
        /// 引数:種別が NULL
        /// </summary>
        [Test]
        public void GetCostByTypeWithNullType()
        {
            Assert.AreEqual(0, abSummary.GetCostByType(null));
        }

        /// <summary>
        /// 集計値取得
        /// 引数:種別が空文字列
        /// </summary>
        [Test]
        public void GetCostByTypeWithEmptyType()
        {
            Assert.AreEqual(0, abSummary.GetCostByType(string.Empty));
        }

        /// <summary>
        /// 集計値取得
        /// 支出レコードリストが空リスト
        /// </summary>
        [Test]
        public void GetCostByTypeWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abSummary = new AbSummary(argDate, argExpenses);

            Assert.AreEqual(argDate.Year, abSummary.Year);
            Assert.AreEqual(argDate.Month, abSummary.Month);
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.FOOD));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.OTFD));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.GOOD));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.FRND));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.TRFC));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.PLAY));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.HOUS));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.ENGY));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.CNCT));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.MEDI));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.INSU));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.OTHR));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.TTAL));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.EARN));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.BLNC));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.BNUS));
            Assert.AreEqual(0, abSummary.GetCostByType(TYPE.SPCL));
            Assert.AreEqual(0, abSummary.GetCostByType("not match"));
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        [Test]
        public void GetCostByTypeWithExpenses()
        {
            Assert.AreEqual(argDate.Year, abSummary.Year);
            Assert.AreEqual(argDate.Month, abSummary.Month);
            Assert.AreEqual(   210, abSummary.GetCostByType(TYPE.FOOD));
            Assert.AreEqual(   410, abSummary.GetCostByType(TYPE.OTFD));
            Assert.AreEqual(   610, abSummary.GetCostByType(TYPE.GOOD));
            Assert.AreEqual(   810, abSummary.GetCostByType(TYPE.FRND));
            Assert.AreEqual(  1010, abSummary.GetCostByType(TYPE.TRFC));
            Assert.AreEqual(  1210, abSummary.GetCostByType(TYPE.PLAY));
            Assert.AreEqual(  1410, abSummary.GetCostByType(TYPE.HOUS));
            Assert.AreEqual(  4950, abSummary.GetCostByType(TYPE.ENGY));
            Assert.AreEqual(  1810, abSummary.GetCostByType(TYPE.CNCT));
            Assert.AreEqual(  2100, abSummary.GetCostByType(TYPE.MEDI));
            Assert.AreEqual(  4100, abSummary.GetCostByType(TYPE.INSU));
            Assert.AreEqual(  6100, abSummary.GetCostByType(TYPE.OTHR));
            Assert.AreEqual( 24730, abSummary.GetCostByType(TYPE.TTAL));
            Assert.AreEqual(210000, abSummary.GetCostByType(TYPE.EARN));
            Assert.AreEqual(185270, abSummary.GetCostByType(TYPE.BLNC));
            Assert.AreEqual(500000, abSummary.GetCostByType(TYPE.BNUS));
            Assert.AreEqual( 41000, abSummary.GetCostByType(TYPE.SPCL));
            Assert.AreEqual(     0, abSummary.GetCostByType("not match"));
        }

        /// <summary>
        /// 集計値取得
        /// 引数:名称が NULL
        /// </summary>
        [Test]
        public void GetCostByNameWithNullName()
        {
            Assert.AreEqual(0, abSummary.GetCostByName(null));
        }

        /// <summary>
        /// 集計値取得
        /// 引数:名称が空文字列
        /// </summary>
        [Test]
        public void GetCostByNameWithEmptyName()
        {
            Assert.AreEqual(0, abSummary.GetCostByName(string.Empty));
        }

        /// <summary>
        /// 集計値取得
        /// 支出レコードリストが空リスト
        /// </summary>
        [Test]
        public void GetCostByNameWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abSummary = new AbSummary(argDate, argExpenses);

            Assert.AreEqual(argDate.Year, abSummary.Year);
            Assert.AreEqual(argDate.Month, abSummary.Month);
            Assert.AreEqual(0, abSummary.GetCostByName("FOOD"));
            Assert.AreEqual(0, abSummary.GetCostByName("OTFD"));
            Assert.AreEqual(0, abSummary.GetCostByName("GOOD"));
            Assert.AreEqual(0, abSummary.GetCostByName("FRND"));
            Assert.AreEqual(0, abSummary.GetCostByName("TRFC"));
            Assert.AreEqual(0, abSummary.GetCostByName("PLAY"));
            Assert.AreEqual(0, abSummary.GetCostByName("HOUS"));
            Assert.AreEqual(0, abSummary.GetCostByName(NAME.EL));
            Assert.AreEqual(0, abSummary.GetCostByName(NAME.GS));
            Assert.AreEqual(0, abSummary.GetCostByName(NAME.WT));
            Assert.AreEqual(0, abSummary.GetCostByName("CNCT"));
            Assert.AreEqual(0, abSummary.GetCostByName("MEDI"));
            Assert.AreEqual(0, abSummary.GetCostByName("INSU"));
            Assert.AreEqual(0, abSummary.GetCostByName("OTHR"));
            Assert.AreEqual(0, abSummary.GetCostByName("EARN"));
            Assert.AreEqual(0, abSummary.GetCostByName("BNUS"));
            Assert.AreEqual(0, abSummary.GetCostByName("SPCL"));
            Assert.AreEqual(0, abSummary.GetCostByName("not match"));
        }

        /// <summary>
        /// 集計値取得
        /// </summary>
        [Test]
        public void GetCostByNameWithExpenses()
        {
            Assert.AreEqual(argDate.Year, abSummary.Year);
            Assert.AreEqual(argDate.Month, abSummary.Month);
            Assert.AreEqual(   0, abSummary.GetCostByName("FOOD"));
            Assert.AreEqual(   0, abSummary.GetCostByName("OTFD"));
            Assert.AreEqual(   0, abSummary.GetCostByName("GOOD"));
            Assert.AreEqual(   0, abSummary.GetCostByName("FRND"));
            Assert.AreEqual(   0, abSummary.GetCostByName("TRFC"));
            Assert.AreEqual(   0, abSummary.GetCostByName("PLAY"));
            Assert.AreEqual(   0, abSummary.GetCostByName("HOUS"));
            Assert.AreEqual(1610, abSummary.GetCostByName(NAME.EL));
            Assert.AreEqual(1650, abSummary.GetCostByName(NAME.GS));
            Assert.AreEqual(1690, abSummary.GetCostByName(NAME.WT));
            Assert.AreEqual(   0, abSummary.GetCostByName("CNCT"));
            Assert.AreEqual(   0, abSummary.GetCostByName("MEDI"));
            Assert.AreEqual(   0, abSummary.GetCostByName("INSU"));
            Assert.AreEqual(   0, abSummary.GetCostByName("OTHR"));
            Assert.AreEqual(   0, abSummary.GetCostByName("EARN"));
            Assert.AreEqual(   0, abSummary.GetCostByName("BNUS"));
            Assert.AreEqual(   0, abSummary.GetCostByName("SPCL"));
            Assert.AreEqual(   0, abSummary.GetCostByName("not match"));
        }
    }

    /// <summary>
    /// 集計値テスト
    /// </summary>
    [TestFixture]
    public class AbTestStaticSummary
    {
        /// <summary>引数:支出レコードリスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>対象:集計値リスト</summary>
        private List<AbSummary> abSummaries;

        [SetUp]
        public void SetUp()
        {
            argExpenses = GenerateExpenses();
            abSummaries = AbSummary.GetSummaries(argExpenses);
        }

        /// <summary>
        /// 支出レコードリスト生成
        /// </summary>
        /// <returns>支出レコードリスト</returns>
        private List<AbExpense> GenerateExpenses()
        {
            var expenses = new List<AbExpense>();
            expenses.Add(new AbExpense("2011-03-01", "FOOD", TYPE.FOOD, "100"));
            expenses.Add(new AbExpense("2011-03-02", "FOOD", TYPE.FOOD, "110"));
            expenses.Add(new AbExpense("2011-03-03", "OTFD", TYPE.OTFD, "200"));
            expenses.Add(new AbExpense("2011-03-04", "OTFD", TYPE.OTFD, "210"));
            expenses.Add(new AbExpense("2011-03-05", "GOOD", TYPE.GOOD, "300"));
            expenses.Add(new AbExpense("2011-03-06", "GOOD", TYPE.GOOD, "310"));
            expenses.Add(new AbExpense("2011-03-07", "FRND", TYPE.FRND, "400"));
            expenses.Add(new AbExpense("2011-03-08", "FRND", TYPE.FRND, "410"));
            expenses.Add(new AbExpense("2011-03-09", "TRFC", TYPE.TRFC, "500"));
            expenses.Add(new AbExpense("2011-03-10", "TRFC", TYPE.TRFC, "510"));
            expenses.Add(new AbExpense("2011-03-11", "PLAY", TYPE.PLAY, "600"));
            expenses.Add(new AbExpense("2011-03-12", "PLAY", TYPE.PLAY, "610"));
            expenses.Add(new AbExpense("2011-03-13", "HOUS", TYPE.HOUS, "700"));
            expenses.Add(new AbExpense("2011-03-14", "HOUS", TYPE.HOUS, "710"));
            expenses.Add(new AbExpense("2011-03-15", NAME.EL, TYPE.ENGY, "800"));
            expenses.Add(new AbExpense("2011-03-16", NAME.EL, TYPE.ENGY, "810"));
            expenses.Add(new AbExpense("2011-03-17", NAME.GS, TYPE.ENGY, "820"));
            expenses.Add(new AbExpense("2011-03-18", NAME.GS, TYPE.ENGY, "830"));
            expenses.Add(new AbExpense("2011-03-19", NAME.WT, TYPE.ENGY, "840"));
            expenses.Add(new AbExpense("2011-03-20", NAME.WT, TYPE.ENGY, "850"));
            expenses.Add(new AbExpense("2011-03-21", "CNCT", TYPE.CNCT, "900"));
            expenses.Add(new AbExpense("2011-03-22", "CNCT", TYPE.CNCT, "910"));
            expenses.Add(new AbExpense("2011-03-23", "MEDI", TYPE.MEDI, "1000"));
            expenses.Add(new AbExpense("2011-03-24", "MEDI", TYPE.MEDI, "1100"));
            expenses.Add(new AbExpense("2011-03-25", "INSU", TYPE.INSU, "2000"));
            expenses.Add(new AbExpense("2011-03-26", "INSU", TYPE.INSU, "2100"));
            expenses.Add(new AbExpense("2011-03-27", "OTHR", TYPE.OTHR, "3000"));
            expenses.Add(new AbExpense("2011-03-28", "OTHR", TYPE.OTHR, "3100"));
            expenses.Add(new AbExpense("2011-03-29", "EARN", TYPE.EARN, "100000"));
            expenses.Add(new AbExpense("2011-03-30", "EARN", TYPE.EARN, "110000"));
            expenses.Add(new AbExpense("2011-03-31", "BNUS", TYPE.BNUS, "200000"));
            expenses.Add(new AbExpense("2011-03-31", "BNUS", TYPE.BNUS, "300000"));
            expenses.Add(new AbExpense("2011-03-31", "SPCL", TYPE.SPCL, "20000"));
            expenses.Add(new AbExpense("2011-03-31", "SPCL", TYPE.SPCL, "21000"));
            expenses.Add(new AbExpense("2011-04-01", "FOOD", TYPE.FOOD, "200"));
            expenses.Add(new AbExpense("2011-04-02", "FOOD", TYPE.FOOD, "210"));
            expenses.Add(new AbExpense("2011-04-03", "OTFD", TYPE.OTFD, "400"));
            expenses.Add(new AbExpense("2011-04-04", "OTFD", TYPE.OTFD, "410"));
            expenses.Add(new AbExpense("2011-04-05", "GOOD", TYPE.GOOD, "500"));
            expenses.Add(new AbExpense("2011-04-06", "GOOD", TYPE.GOOD, "510"));
            expenses.Add(new AbExpense("2011-04-07", "FRND", TYPE.FRND, "600"));
            expenses.Add(new AbExpense("2011-04-08", "FRND", TYPE.FRND, "610"));
            expenses.Add(new AbExpense("2011-04-09", "TRFC", TYPE.TRFC, "1000"));
            expenses.Add(new AbExpense("2011-04-10", "TRFC", TYPE.TRFC, "1010"));
            expenses.Add(new AbExpense("2011-04-11", "PLAY", TYPE.PLAY, "1200"));
            expenses.Add(new AbExpense("2011-04-12", "PLAY", TYPE.PLAY, "1210"));
            expenses.Add(new AbExpense("2011-04-13", "HOUS", TYPE.HOUS, "1400"));
            expenses.Add(new AbExpense("2011-04-14", "HOUS", TYPE.HOUS, "1410"));
            expenses.Add(new AbExpense("2011-04-15", NAME.EL, TYPE.ENGY, "1600"));
            expenses.Add(new AbExpense("2011-04-16", NAME.EL, TYPE.ENGY, "1610"));
            expenses.Add(new AbExpense("2011-04-17", NAME.GS, TYPE.ENGY, "1620"));
            expenses.Add(new AbExpense("2011-04-18", NAME.GS, TYPE.ENGY, "1630"));
            expenses.Add(new AbExpense("2011-04-19", NAME.WT, TYPE.ENGY, "1640"));
            expenses.Add(new AbExpense("2011-04-20", NAME.WT, TYPE.ENGY, "1650"));
            expenses.Add(new AbExpense("2011-04-21", "CNCT", TYPE.CNCT, "1800"));
            expenses.Add(new AbExpense("2011-04-22", "CNCT", TYPE.CNCT, "1810"));
            expenses.Add(new AbExpense("2011-04-23", "MEDI", TYPE.MEDI, "2000"));
            expenses.Add(new AbExpense("2011-04-24", "MEDI", TYPE.MEDI, "2100"));
            expenses.Add(new AbExpense("2011-04-25", "INSU", TYPE.INSU, "4000"));
            expenses.Add(new AbExpense("2011-04-26", "INSU", TYPE.INSU, "4100"));
            expenses.Add(new AbExpense("2011-04-27", "OTHR", TYPE.OTHR, "6000"));
            expenses.Add(new AbExpense("2011-04-28", "OTHR", TYPE.OTHR, "6100"));
            expenses.Add(new AbExpense("2011-04-29", "EARN", TYPE.EARN, "200000"));
            expenses.Add(new AbExpense("2011-04-30", "EARN", TYPE.EARN, "210000"));
            expenses.Add(new AbExpense("2011-04-30", "SPCL", TYPE.SPCL, "40000"));
            expenses.Add(new AbExpense("2011-04-30", "SPCL", TYPE.SPCL, "41000"));
            return expenses;
        }

        /// <summary>
        /// 集計値リスト生成
        /// 引数:支出レコードリストが NULL
        /// </summary>
        [Test]
        public void GetSummariesWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                { AbSummary.GetSummaries(argExpenses); }
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// 集計値リスト生成
        /// 引数:支出レコードリストが空リスト
        /// </summary>
        [Test]
        public void GetSummariesWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abSummaries = AbSummary.GetSummaries(argExpenses);

            Assert.IsEmpty(abSummaries);
        }

        /// <summary>
        /// 集計値リスト生成
        /// 集計値リスト数のテスト
        /// </summary>
        [Test]
        public void GetSummariesWithCount()
        {
            Assert.AreEqual(2, abSummaries.Count);
        }

        /// <summary>
        /// 集計値リスト生成
        /// 集計値リスト要素のテスト
        /// </summary>
        [Test]
        public void GetSummariesWithExpenses()
        {
            var date = new DateTime(2011, 3, 1);
            foreach (var sum in abSummaries)
            {
                Assert.AreEqual(date.Year, sum.Year);
                Assert.AreEqual(date.Month, sum.Month);
                date = date.AddMonths(1);
            }
        }

        /// <summary>
        /// 集計値リスト生成
        /// 2011年2月の集計値のテスト
        /// </summary>
        [Test]
        public void GetSummariesWith_2011_02_Summary()
        {
            var date = new DateTime(2011, 2, 1);
            var abSummary = abSummaries.Where(
                sum => sum.Year == date.Year && sum.Month == date.Month
            ).FirstOrDefault();
            Assert.IsNull(abSummary);
        }

        /// <summary>
        /// 集計値リスト生成
        /// 2011年3月の集計値のテスト
        /// </summary>
        [Test]
        public void GetSummariesWith_2011_03_Summary()
        {
            var date = new DateTime(2011, 3, 1);
            var abSummary = abSummaries.Where(sum =>
                sum.Year == date.Year && sum.Month == date.Month
            ).FirstOrDefault();

            Assert.IsNotNull(abSummary);
            Assert.AreEqual(date.Year, abSummary.Year);
            Assert.AreEqual(date.Month, abSummary.Month);
            Assert.AreEqual(   210, abSummary.GetCostByType(TYPE.FOOD));
            Assert.AreEqual(   410, abSummary.GetCostByType(TYPE.OTFD));
            Assert.AreEqual(   610, abSummary.GetCostByType(TYPE.GOOD));
            Assert.AreEqual(   810, abSummary.GetCostByType(TYPE.FRND));
            Assert.AreEqual(  1010, abSummary.GetCostByType(TYPE.TRFC));
            Assert.AreEqual(  1210, abSummary.GetCostByType(TYPE.PLAY));
            Assert.AreEqual(  1410, abSummary.GetCostByType(TYPE.HOUS));
            Assert.AreEqual(  4950, abSummary.GetCostByType(TYPE.ENGY));
            Assert.AreEqual(  1810, abSummary.GetCostByType(TYPE.CNCT));
            Assert.AreEqual(  2100, abSummary.GetCostByType(TYPE.MEDI));
            Assert.AreEqual(  4100, abSummary.GetCostByType(TYPE.INSU));
            Assert.AreEqual(  6100, abSummary.GetCostByType(TYPE.OTHR));
            Assert.AreEqual( 24730, abSummary.GetCostByType(TYPE.TTAL));
            Assert.AreEqual(210000, abSummary.GetCostByType(TYPE.EARN));
            Assert.AreEqual(185270, abSummary.GetCostByType(TYPE.BLNC));
            Assert.AreEqual(500000, abSummary.GetCostByType(TYPE.BNUS));
            Assert.AreEqual( 41000, abSummary.GetCostByType(TYPE.SPCL));
            Assert.AreEqual(     0, abSummary.GetCostByType("not match"));
        }

        /// <summary>
        /// 集計値リスト生成
        /// 2011年4月の集計値のテスト
        /// </summary>
        [Test]
        public void GetSummariesWith_2011_04_Summary()
        {
            var date = new DateTime(2011, 4, 1);
            var abSummary = abSummaries.Where(sum =>
                sum.Year == date.Year && sum.Month == date.Month
            ).FirstOrDefault();

            Assert.IsNotNull(abSummary);
            Assert.AreEqual(date.Year, abSummary.Year);
            Assert.AreEqual(date.Month, abSummary.Month);
            Assert.AreEqual(   410, abSummary.GetCostByType(TYPE.FOOD));
            Assert.AreEqual(   810, abSummary.GetCostByType(TYPE.OTFD));
            Assert.AreEqual(  1010, abSummary.GetCostByType(TYPE.GOOD));
            Assert.AreEqual(  1210, abSummary.GetCostByType(TYPE.FRND));
            Assert.AreEqual(  2010, abSummary.GetCostByType(TYPE.TRFC));
            Assert.AreEqual(  2410, abSummary.GetCostByType(TYPE.PLAY));
            Assert.AreEqual(  2810, abSummary.GetCostByType(TYPE.HOUS));
            Assert.AreEqual(  9750, abSummary.GetCostByType(TYPE.ENGY));
            Assert.AreEqual(  3610, abSummary.GetCostByType(TYPE.CNCT));
            Assert.AreEqual(  4100, abSummary.GetCostByType(TYPE.MEDI));
            Assert.AreEqual(  8100, abSummary.GetCostByType(TYPE.INSU));
            Assert.AreEqual( 12100, abSummary.GetCostByType(TYPE.OTHR));
            Assert.AreEqual( 48330, abSummary.GetCostByType(TYPE.TTAL));
            Assert.AreEqual(410000, abSummary.GetCostByType(TYPE.EARN));
            Assert.AreEqual(361670, abSummary.GetCostByType(TYPE.BLNC));
            Assert.AreEqual(     0, abSummary.GetCostByType(TYPE.BNUS));
            Assert.AreEqual( 81000, abSummary.GetCostByType(TYPE.SPCL));
            Assert.AreEqual(     0, abSummary.GetCostByType("not match"));
        }
    }
}
