namespace Abook
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class AbTestGraphManager
    {
        private DateTime argDtToday;
        private List<AbSummary> argAbSummaries;
        private AbGraphManager abGraphManager;

        [SetUp]
        public void SetUp()
        {
            argDtToday = new DateTime(2011, 3, 11);
            argAbSummaries = AbSummary.GetSummaries(
                AbDBManager.LoadFromFile("In_AbGraphManagerTest.db")
            );

            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);
        }

        [Test]
        public void AbGraphManagerWithNullSummaries()
        {
            argAbSummaries = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbGraphManager(argDtToday, argAbSummaries); }
            );
        }

        [Test]
        public void GetMonthWithSomePattern()
        {
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);
            Assert.AreEqual("03", abGraphManager.GetMonth(0));
            Assert.AreEqual("01", abGraphManager.GetMonth(-2));
            Assert.AreEqual("11", abGraphManager.GetMonth(-4));
            Assert.AreEqual("09", abGraphManager.GetMonth(-6));
            Assert.AreEqual("07", abGraphManager.GetMonth(-8));
            Assert.AreEqual("05", abGraphManager.GetMonth(-10));
        }

        [Test]
        public void ToStringWithDtNow()
        {
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);
            Assert.AreEqual("～2011年03月", abGraphManager.ToString());
        }

        [Test]
        public void PrevYearWith1Time()
        {
            argDtToday = new DateTime(2011, 4, 30);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.PrevYear();

            Assert.AreEqual("～2010年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(100, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(118, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(190, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(127, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(191, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void PrevYearWith2Times()
        {
            argDtToday = new DateTime(2011, 4, 30);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.PrevYear();
            abGraphManager.PrevYear();

            Assert.AreEqual("～2009年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual( 87, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual( 52, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(191, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(139, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(191, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void PrevYearWith3Times()
        {
            argDtToday = new DateTime(2011, 4, 30);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.PrevYear();
            abGraphManager.PrevYear();
            abGraphManager.PrevYear();

            Assert.AreEqual("～2008年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void PrevYearWith4Times()
        {
            argDtToday = new DateTime(2011, 4, 30);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.PrevYear();
            abGraphManager.PrevYear();
            abGraphManager.PrevYear();
            abGraphManager.PrevYear();

            Assert.AreEqual("～2007年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void PrevMonthWith1Time()
        {
            argDtToday = new DateTime(2009, 6, 30);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.PrevMonth();

            Assert.AreEqual("～2009年05月", abGraphManager.ToString());
            Assert.AreEqual("05", abGraphManager.GetMonth(0));
            Assert.AreEqual("03", abGraphManager.GetMonth(-2));
            Assert.AreEqual("01", abGraphManager.GetMonth(-4));
            Assert.AreEqual("11", abGraphManager.GetMonth(-6));
            Assert.AreEqual("09", abGraphManager.GetMonth(-8));
            Assert.AreEqual("07", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual( 25, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual( 88, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(198, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(153, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(191, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void PrevMonthWith2Times()
        {
            argDtToday = new DateTime(2009, 6, 30);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.PrevMonth();
            abGraphManager.PrevMonth();

            Assert.AreEqual("～2009年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual( 87, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual( 52, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(191, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(139, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(191, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void PrevMonthWith3Times()
        {
            argDtToday = new DateTime(2009, 6, 30);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.PrevMonth();
            abGraphManager.PrevMonth();
            abGraphManager.PrevMonth();

            Assert.AreEqual("～2009年03月", abGraphManager.ToString());
            Assert.AreEqual("03", abGraphManager.GetMonth(0));
            Assert.AreEqual("01", abGraphManager.GetMonth(-2));
            Assert.AreEqual("11", abGraphManager.GetMonth(-4));
            Assert.AreEqual("09", abGraphManager.GetMonth(-6));
            Assert.AreEqual("07", abGraphManager.GetMonth(-8));
            Assert.AreEqual("05", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void PrevMonthWith4Times()
        {
            argDtToday = new DateTime(2009, 6, 30);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.PrevMonth();
            abGraphManager.PrevMonth();
            abGraphManager.PrevMonth();
            abGraphManager.PrevMonth();

            Assert.AreEqual("～2009年02月", abGraphManager.ToString());
            Assert.AreEqual("02", abGraphManager.GetMonth(0));
            Assert.AreEqual("12", abGraphManager.GetMonth(-2));
            Assert.AreEqual("10", abGraphManager.GetMonth(-4));
            Assert.AreEqual("08", abGraphManager.GetMonth(-6));
            Assert.AreEqual("06", abGraphManager.GetMonth(-8));
            Assert.AreEqual("04", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void NextMonthWith1Time()
        {
            argDtToday = new DateTime(2011, 2, 28);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.NextMonth();

            Assert.AreEqual("～2011年03月", abGraphManager.ToString());
            Assert.AreEqual("03", abGraphManager.GetMonth(0));
            Assert.AreEqual("01", abGraphManager.GetMonth(-2));
            Assert.AreEqual("11", abGraphManager.GetMonth(-4));
            Assert.AreEqual("09", abGraphManager.GetMonth(-6));
            Assert.AreEqual("07", abGraphManager.GetMonth(-8));
            Assert.AreEqual("05", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(123, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(103, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(198, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(140, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(192, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void NextMonthWith2Times()
        {
            argDtToday = new DateTime(2011, 2, 28);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.NextMonth();
            abGraphManager.NextMonth();

            Assert.AreEqual("～2011年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(125, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(120, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(197, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(140, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(193, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void NextMonthWith3Times()
        {
            argDtToday = new DateTime(2011, 2, 28);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.NextMonth();
            abGraphManager.NextMonth();
            abGraphManager.NextMonth();

            Assert.AreEqual("～2011年05月", abGraphManager.ToString());
            Assert.AreEqual("05", abGraphManager.GetMonth(0));
            Assert.AreEqual("03", abGraphManager.GetMonth(-2));
            Assert.AreEqual("01", abGraphManager.GetMonth(-4));
            Assert.AreEqual("11", abGraphManager.GetMonth(-6));
            Assert.AreEqual("09", abGraphManager.GetMonth(-8));
            Assert.AreEqual("07", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void NextMonthWith4Times()
        {
            argDtToday = new DateTime(2011, 2, 28);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.NextMonth();
            abGraphManager.NextMonth();
            abGraphManager.NextMonth();
            abGraphManager.NextMonth();

            Assert.AreEqual("～2011年06月", abGraphManager.ToString());
            Assert.AreEqual("06", abGraphManager.GetMonth(0));
            Assert.AreEqual("04", abGraphManager.GetMonth(-2));
            Assert.AreEqual("02", abGraphManager.GetMonth(-4));
            Assert.AreEqual("12", abGraphManager.GetMonth(-6));
            Assert.AreEqual("10", abGraphManager.GetMonth(-8));
            Assert.AreEqual("08", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void NextYearWith1Time()
        {
            argDtToday = new DateTime(2009, 4, 1);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.NextYear();

            Assert.AreEqual("～2010年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(100, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(118, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(190, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(127, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(191, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void NextYearWith2Times()
        {
            argDtToday = new DateTime(2009, 4, 1);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.NextYear();
            abGraphManager.NextYear();

            Assert.AreEqual("～2011年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(125, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(120, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(197, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(140, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(193, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void NextYearWith3Times()
        {
            argDtToday = new DateTime(2009, 4, 1);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.NextYear();
            abGraphManager.NextYear();
            abGraphManager.NextYear();

            Assert.AreEqual("～2012年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }

        [Test]
        public void NextYearWith4Times()
        {
            argDtToday = new DateTime(2009, 4, 1);
            abGraphManager = new AbGraphManager(argDtToday, argAbSummaries);

            abGraphManager.NextYear();
            abGraphManager.NextYear();
            abGraphManager.NextYear();
            abGraphManager.NextYear();

            Assert.AreEqual("～2013年04月", abGraphManager.ToString());
            Assert.AreEqual("04", abGraphManager.GetMonth(0));
            Assert.AreEqual("02", abGraphManager.GetMonth(-2));
            Assert.AreEqual("12", abGraphManager.GetMonth(-4));
            Assert.AreEqual("10", abGraphManager.GetMonth(-6));
            Assert.AreEqual("08", abGraphManager.GetMonth(-8));
            Assert.AreEqual("06", abGraphManager.GetMonth(-10));

            Assert.AreEqual(322, abGraphManager.AbGraphDatas[0].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[0].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[1].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[1].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[2].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[2].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[3].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[3].Points[12].Y);
            Assert.AreEqual(322, abGraphManager.AbGraphDatas[4].Points[12].X);
            Assert.AreEqual(218, abGraphManager.AbGraphDatas[4].Points[12].Y);
        }
    }
}
