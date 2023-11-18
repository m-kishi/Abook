// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT   = AbTestTool;
    using EX   = Abook.AbException.EX;
    using DB   = Abook.AbConstants.DB;
    using NAME = Abook.AbConstants.NAME;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 光熱費サブフォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestSubEnergy : NUnitFormTest
    {
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EMPTY     = "AbTestSubEnergyEmpty.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_ONLY_EL   = "AbTestSubEnergyOnlyEl.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_ONLY_GS   = "AbTestSubEnergyOnlyGs.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_ONLY_WT   = "AbTestSubEnergyOnlyWt.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_ENERGIES  = "AbTestSubEnergies.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_ONLY_ZERO = "AbTestSubEnergyOnly0.db";
        /// <summary>対象:光熱費サブフォーム</summary>
        protected AbSubEnergy form;

        /// <summary>月表示用クラス</summary>
        private class MSG
        {
            /// <summary>1月</summary>
            public const string MONTH01 = "1月";
            /// <summary>2月</summary>
            public const string MONTH02 = "2月";
            /// <summary>3月</summary>
            public const string MONTH03 = "3月";
            /// <summary>4月</summary>
            public const string MONTH04 = "4月";
            /// <summary>5月</summary>
            public const string MONTH05 = "5月";
            /// <summary>6月</summary>
            public const string MONTH06 = "6月";
            /// <summary>7月</summary>
            public const string MONTH07 = "7月";
            /// <summary>8月</summary>
            public const string MONTH08 = "8月";
            /// <summary>9月</summary>
            public const string MONTH09 = "9月";
            /// <summary>10月</summary>
            public const string MONTH10 = "10月";
            /// <summary>11月</summary>
            public const string MONTH11 = "11月";
            /// <summary>12月</summary>
            public const string MONTH12 = "12月";
        }

        /// <summary>
        /// Setup
        /// </summary>
        public override void Setup()
        {
            base.Setup();
        }

        /// <summary>
        /// TearDown
        /// </summary>
        public override void TearDown()
        {
            try
            {
                CtAbSubEnergy().Close();
            }
            catch (NoSuchControlException)
            {
                // すでに閉じられている
            }
            base.TearDown();
        }

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_FILE_ONLY_EL, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2015-04-07", NAME.EL, TYPE.ENGY, "1600"));
                sw.WriteLine(TT.ToDBFileFormat("2015-04-08", NAME.EL, TYPE.ENGY, "1700"));
                sw.WriteLine(TT.ToDBFileFormat("2015-05-09", NAME.EL, TYPE.ENGY, "1800"));
                sw.WriteLine(TT.ToDBFileFormat("2015-05-10", NAME.EL, TYPE.ENGY, "1900"));
                sw.WriteLine(TT.ToDBFileFormat("2015-07-11", NAME.EL, TYPE.ENGY, "2000"));
                sw.WriteLine(TT.ToDBFileFormat("2015-07-12", NAME.EL, TYPE.ENGY, "2100"));
                sw.WriteLine(TT.ToDBFileFormat("2015-07-13", NAME.EL, TYPE.ENGY, "2200"));
                sw.WriteLine(TT.ToDBFileFormat("2015-08-14", NAME.EL, TYPE.ENGY, "2300"));
                sw.WriteLine(TT.ToDBFileFormat("2015-08-15", NAME.EL, TYPE.ENGY, "2400"));
                sw.WriteLine(TT.ToDBFileFormat("2015-08-16", NAME.EL, TYPE.ENGY, "2500"));
                sw.WriteLine(TT.ToDBFileFormat("2015-08-17", NAME.EL, TYPE.ENGY, "2600"));
                sw.WriteLine(TT.ToDBFileFormat("2015-08-18", NAME.EL, TYPE.ENGY, "2700"));
                sw.WriteLine(TT.ToDBFileFormat("2015-09-19", NAME.EL, TYPE.ENGY, "2800"));
                sw.WriteLine(TT.ToDBFileFormat("2015-10-20", NAME.EL, TYPE.ENGY, "2900"));
                sw.WriteLine(TT.ToDBFileFormat("2015-11-21", NAME.EL, TYPE.ENGY, "3000"));
                sw.WriteLine(TT.ToDBFileFormat("2016-01-01", NAME.EL, TYPE.ENGY, "1000"));
                sw.WriteLine(TT.ToDBFileFormat("2016-01-02", NAME.EL, TYPE.ENGY, "1100"));
                sw.WriteLine(TT.ToDBFileFormat("2016-02-03", NAME.EL, TYPE.ENGY, "1200"));
                sw.WriteLine(TT.ToDBFileFormat("2016-02-04", NAME.EL, TYPE.ENGY, "1300"));
                sw.WriteLine(TT.ToDBFileFormat("2016-03-05", NAME.EL, TYPE.ENGY, "1400"));
                sw.WriteLine(TT.ToDBFileFormat("2016-03-06", NAME.EL, TYPE.ENGY, "1500"));
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(DB_FILE_ONLY_GS, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2015-04-04", NAME.GS, TYPE.ENGY, "2600"));
                sw.WriteLine(TT.ToDBFileFormat("2015-05-05", NAME.GS, TYPE.ENGY, "2800"));
                sw.WriteLine(TT.ToDBFileFormat("2015-06-06", NAME.GS, TYPE.ENGY, "3000"));
                sw.WriteLine(TT.ToDBFileFormat("2015-07-07", NAME.GS, TYPE.ENGY, "3200"));
                sw.WriteLine(TT.ToDBFileFormat("2015-08-08", NAME.GS, TYPE.ENGY, "3400"));
                sw.WriteLine(TT.ToDBFileFormat("2015-09-09", NAME.GS, TYPE.ENGY, "3600"));
                sw.WriteLine(TT.ToDBFileFormat("2015-10-10", NAME.GS, TYPE.ENGY, "3800"));
                sw.WriteLine(TT.ToDBFileFormat("2015-11-11", NAME.GS, TYPE.ENGY, "4000"));
                sw.WriteLine(TT.ToDBFileFormat("2015-12-12", NAME.GS, TYPE.ENGY, "4200"));
                sw.WriteLine(TT.ToDBFileFormat("2016-01-13", NAME.GS, TYPE.ENGY, "4400"));
                sw.WriteLine(TT.ToDBFileFormat("2016-02-14", NAME.GS, TYPE.ENGY, "4600"));
                sw.WriteLine(TT.ToDBFileFormat("2016-03-15", NAME.GS, TYPE.ENGY, "4800"));
                sw.WriteLine(TT.ToDBFileFormat("2016-04-16", NAME.GS, TYPE.ENGY, "5000"));
                sw.WriteLine(TT.ToDBFileFormat("2016-05-17", NAME.GS, TYPE.ENGY, "5200"));
                sw.WriteLine(TT.ToDBFileFormat("2016-06-18", NAME.GS, TYPE.ENGY, "5400"));
                sw.WriteLine(TT.ToDBFileFormat("2016-07-19", NAME.GS, TYPE.ENGY, "5600"));
                sw.WriteLine(TT.ToDBFileFormat("2016-08-20", NAME.GS, TYPE.ENGY, "5800"));
                sw.WriteLine(TT.ToDBFileFormat("2016-09-21", NAME.GS, TYPE.ENGY, "6000"));
                sw.WriteLine(TT.ToDBFileFormat("2016-10-22", NAME.GS, TYPE.ENGY, "6200"));
                sw.WriteLine(TT.ToDBFileFormat("2016-11-23", NAME.GS, TYPE.ENGY, "6400"));
                sw.WriteLine(TT.ToDBFileFormat("2016-12-24", NAME.GS, TYPE.ENGY, "6600"));
                sw.WriteLine(TT.ToDBFileFormat("2017-01-01", NAME.GS, TYPE.ENGY, "2000"));
                sw.WriteLine(TT.ToDBFileFormat("2017-02-02", NAME.GS, TYPE.ENGY, "2200"));
                sw.WriteLine(TT.ToDBFileFormat("2017-03-03", NAME.GS, TYPE.ENGY, "2400"));
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(DB_FILE_ONLY_WT, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2015-04-04", NAME.WT, TYPE.ENGY, "1300"));
                sw.WriteLine(TT.ToDBFileFormat("2015-05-05", NAME.WT, TYPE.ENGY, "1400"));
                sw.WriteLine(TT.ToDBFileFormat("2015-06-06", NAME.WT, TYPE.ENGY, "1500"));
                sw.WriteLine(TT.ToDBFileFormat("2015-07-07", NAME.WT, TYPE.ENGY, "1600"));
                sw.WriteLine(TT.ToDBFileFormat("2015-08-08", NAME.WT, TYPE.ENGY, "1700"));
                sw.WriteLine(TT.ToDBFileFormat("2015-09-09", NAME.WT, TYPE.ENGY, "1800"));
                sw.WriteLine(TT.ToDBFileFormat("2015-10-10", NAME.WT, TYPE.ENGY, "1900"));
                sw.WriteLine(TT.ToDBFileFormat("2015-11-11", NAME.WT, TYPE.ENGY, "2000"));
                sw.WriteLine(TT.ToDBFileFormat("2015-12-12", NAME.WT, TYPE.ENGY, "2100"));
                sw.WriteLine(TT.ToDBFileFormat("2016-01-01", NAME.WT, TYPE.ENGY, "1000"));
                sw.WriteLine(TT.ToDBFileFormat("2016-02-02", NAME.WT, TYPE.ENGY, "1100"));
                sw.WriteLine(TT.ToDBFileFormat("2016-03-03", NAME.WT, TYPE.ENGY, "1200"));
                sw.WriteLine(TT.ToDBFileFormat("2017-04-16", NAME.WT, TYPE.ENGY, "2500"));
                sw.WriteLine(TT.ToDBFileFormat("2017-05-17", NAME.WT, TYPE.ENGY, "2600"));
                sw.WriteLine(TT.ToDBFileFormat("2017-06-18", NAME.WT, TYPE.ENGY, "2700"));
                sw.WriteLine(TT.ToDBFileFormat("2017-07-19", NAME.WT, TYPE.ENGY, "2800"));
                sw.WriteLine(TT.ToDBFileFormat("2017-08-20", NAME.WT, TYPE.ENGY, "2900"));
                sw.WriteLine(TT.ToDBFileFormat("2017-09-21", NAME.WT, TYPE.ENGY, "3000"));
                sw.WriteLine(TT.ToDBFileFormat("2017-10-22", NAME.WT, TYPE.ENGY, "3100"));
                sw.WriteLine(TT.ToDBFileFormat("2017-11-23", NAME.WT, TYPE.ENGY, "3200"));
                sw.WriteLine(TT.ToDBFileFormat("2017-12-24", NAME.WT, TYPE.ENGY, "3300"));
                sw.WriteLine(TT.ToDBFileFormat("2018-01-13", NAME.WT, TYPE.ENGY, "2200"));
                sw.WriteLine(TT.ToDBFileFormat("2018-02-14", NAME.WT, TYPE.ENGY, "2300"));
                sw.WriteLine(TT.ToDBFileFormat("2018-03-15", NAME.WT, TYPE.ENGY, "2400"));
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(DB_FILE_ENERGIES, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2009-04-30", NAME.EL, TYPE.ENGY, "1804")); sw.WriteLine(TT.ToDBFileFormat("2009-04-30", NAME.GS, TYPE.ENGY, "5422")); sw.WriteLine(TT.ToDBFileFormat("2009-04-30", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2009-05-31", NAME.EL, TYPE.ENGY, "1359")); sw.WriteLine(TT.ToDBFileFormat("2009-05-31", NAME.GS, TYPE.ENGY, "4462")); sw.WriteLine(TT.ToDBFileFormat("2009-05-31", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2009-06-30", NAME.EL, TYPE.ENGY, "1550")); sw.WriteLine(TT.ToDBFileFormat("2009-06-30", NAME.GS, TYPE.ENGY, "4659")); sw.WriteLine(TT.ToDBFileFormat("2009-06-30", NAME.WT, TYPE.ENGY, "1896"));
                sw.WriteLine(TT.ToDBFileFormat("2009-07-31", NAME.EL, TYPE.ENGY, "3780")); sw.WriteLine(TT.ToDBFileFormat("2009-07-31", NAME.GS, TYPE.ENGY, "4363")); sw.WriteLine(TT.ToDBFileFormat("2009-07-31", NAME.WT, TYPE.ENGY, "1896"));
                sw.WriteLine(TT.ToDBFileFormat("2009-08-31", NAME.EL, TYPE.ENGY, "3853")); sw.WriteLine(TT.ToDBFileFormat("2009-08-31", NAME.GS, TYPE.ENGY, "3969")); sw.WriteLine(TT.ToDBFileFormat("2009-08-31", NAME.WT, TYPE.ENGY, "1896"));
                sw.WriteLine(TT.ToDBFileFormat("2009-09-30", NAME.EL, TYPE.ENGY, "3143")); sw.WriteLine(TT.ToDBFileFormat("2009-09-30", NAME.GS, TYPE.ENGY, "3771")); sw.WriteLine(TT.ToDBFileFormat("2009-09-30", NAME.WT, TYPE.ENGY, "1896"));
                sw.WriteLine(TT.ToDBFileFormat("2009-10-31", NAME.EL, TYPE.ENGY, "1416")); sw.WriteLine(TT.ToDBFileFormat("2009-10-31", NAME.GS, TYPE.ENGY, "3820")); sw.WriteLine(TT.ToDBFileFormat("2009-10-31", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2009-11-30", NAME.EL, TYPE.ENGY, "1250")); sw.WriteLine(TT.ToDBFileFormat("2009-11-30", NAME.GS, TYPE.ENGY, "4857")); sw.WriteLine(TT.ToDBFileFormat("2009-11-30", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2009-12-31", NAME.EL, TYPE.ENGY,  "501")); sw.WriteLine(TT.ToDBFileFormat("2009-12-31", NAME.GS, TYPE.ENGY, "1995")); sw.WriteLine(TT.ToDBFileFormat("2009-12-31", NAME.WT, TYPE.ENGY, "1462"));
                sw.WriteLine(TT.ToDBFileFormat("2010-01-31", NAME.EL, TYPE.ENGY,  "708")); sw.WriteLine(TT.ToDBFileFormat("2010-01-31", NAME.GS, TYPE.ENGY, "3031")); sw.WriteLine(TT.ToDBFileFormat("2010-01-31", NAME.WT, TYPE.ENGY, "1462"));
                sw.WriteLine(TT.ToDBFileFormat("2010-02-28", NAME.EL, TYPE.ENGY,  "690")); sw.WriteLine(TT.ToDBFileFormat("2010-02-28", NAME.GS, TYPE.ENGY, "3574")); sw.WriteLine(TT.ToDBFileFormat("2010-02-28", NAME.WT, TYPE.ENGY, "1558"));
                sw.WriteLine(TT.ToDBFileFormat("2010-03-31", NAME.EL, TYPE.ENGY, "1673")); sw.WriteLine(TT.ToDBFileFormat("2010-03-31", NAME.GS, TYPE.ENGY, "6574")); sw.WriteLine(TT.ToDBFileFormat("2010-03-31", NAME.WT, TYPE.ENGY, "1558"));
                sw.WriteLine(TT.ToDBFileFormat("2010-04-30", NAME.EL, TYPE.ENGY, "1926")); sw.WriteLine(TT.ToDBFileFormat("2010-04-30", NAME.GS, TYPE.ENGY, "6213")); sw.WriteLine(TT.ToDBFileFormat("2010-04-30", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2010-05-31", NAME.EL, TYPE.ENGY, "1321")); sw.WriteLine(TT.ToDBFileFormat("2010-05-31", NAME.GS, TYPE.ENGY, "4413")); sw.WriteLine(TT.ToDBFileFormat("2010-05-31", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2010-06-30", NAME.EL, TYPE.ENGY, "1475")); sw.WriteLine(TT.ToDBFileFormat("2010-06-30", NAME.GS, TYPE.ENGY, "4464")); sw.WriteLine(TT.ToDBFileFormat("2010-06-30", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2010-07-31", NAME.EL, TYPE.ENGY, "2045")); sw.WriteLine(TT.ToDBFileFormat("2010-07-31", NAME.GS, TYPE.ENGY, "4310")); sw.WriteLine(TT.ToDBFileFormat("2010-07-31", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2010-08-31", NAME.EL, TYPE.ENGY, "3147")); sw.WriteLine(TT.ToDBFileFormat("2010-08-31", NAME.GS, TYPE.ENGY, "3847")); sw.WriteLine(TT.ToDBFileFormat("2010-08-31", NAME.WT, TYPE.ENGY, "1896"));
                sw.WriteLine(TT.ToDBFileFormat("2010-09-30", NAME.EL, TYPE.ENGY, "2918")); sw.WriteLine(TT.ToDBFileFormat("2010-09-30", NAME.GS, TYPE.ENGY, "3538")); sw.WriteLine(TT.ToDBFileFormat("2010-09-30", NAME.WT, TYPE.ENGY, "1896"));
                sw.WriteLine(TT.ToDBFileFormat("2010-10-31", NAME.EL, TYPE.ENGY, "1306")); sw.WriteLine(TT.ToDBFileFormat("2010-10-31", NAME.GS, TYPE.ENGY, "3898")); sw.WriteLine(TT.ToDBFileFormat("2010-10-31", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2010-11-30", NAME.EL, TYPE.ENGY, "1791")); sw.WriteLine(TT.ToDBFileFormat("2010-11-30", NAME.GS, TYPE.ENGY, "5390")); sw.WriteLine(TT.ToDBFileFormat("2010-11-30", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2010-12-31", NAME.EL, TYPE.ENGY, "1573")); sw.WriteLine(TT.ToDBFileFormat("2010-12-31", NAME.GS, TYPE.ENGY, "5647")); sw.WriteLine(TT.ToDBFileFormat("2010-12-31", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2011-01-31", NAME.EL, TYPE.ENGY, "1675")); sw.WriteLine(TT.ToDBFileFormat("2011-01-31", NAME.GS, TYPE.ENGY, "5596")); sw.WriteLine(TT.ToDBFileFormat("2011-01-31", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2011-02-28", NAME.EL, TYPE.ENGY, "1783")); sw.WriteLine(TT.ToDBFileFormat("2011-02-28", NAME.GS, TYPE.ENGY, "5596")); sw.WriteLine(TT.ToDBFileFormat("2011-02-28", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2011-03-31", NAME.EL, TYPE.ENGY, "1357")); sw.WriteLine(TT.ToDBFileFormat("2011-03-31", NAME.GS, TYPE.ENGY, "5339")); sw.WriteLine(TT.ToDBFileFormat("2011-03-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2011-04-30", NAME.EL, TYPE.ENGY, "1426")); sw.WriteLine(TT.ToDBFileFormat("2011-04-30", NAME.GS, TYPE.ENGY, "5339")); sw.WriteLine(TT.ToDBFileFormat("2011-04-30", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2011-05-31", NAME.EL, TYPE.ENGY, "1174")); sw.WriteLine(TT.ToDBFileFormat("2011-05-31", NAME.GS, TYPE.ENGY, "4207")); sw.WriteLine(TT.ToDBFileFormat("2011-05-31", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2011-06-30", NAME.EL, TYPE.ENGY, "1266")); sw.WriteLine(TT.ToDBFileFormat("2011-06-30", NAME.GS, TYPE.ENGY, "4824")); sw.WriteLine(TT.ToDBFileFormat("2011-06-30", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2011-07-31", NAME.EL, TYPE.ENGY, "2010")); sw.WriteLine(TT.ToDBFileFormat("2011-07-31", NAME.GS, TYPE.ENGY, "4001")); sw.WriteLine(TT.ToDBFileFormat("2011-07-31", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2011-08-31", NAME.EL, TYPE.ENGY, "2257")); sw.WriteLine(TT.ToDBFileFormat("2011-08-31", NAME.GS, TYPE.ENGY, "3538")); sw.WriteLine(TT.ToDBFileFormat("2011-08-31", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2011-09-30", NAME.EL, TYPE.ENGY, "1998")); sw.WriteLine(TT.ToDBFileFormat("2011-09-30", NAME.GS, TYPE.ENGY, "3692")); sw.WriteLine(TT.ToDBFileFormat("2011-09-30", NAME.WT, TYPE.ENGY, "1848"));
                sw.WriteLine(TT.ToDBFileFormat("2011-10-31", NAME.EL, TYPE.ENGY, "1164")); sw.WriteLine(TT.ToDBFileFormat("2011-10-31", NAME.GS, TYPE.ENGY, "4053")); sw.WriteLine(TT.ToDBFileFormat("2011-10-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2011-11-30", NAME.EL, TYPE.ENGY, "1369")); sw.WriteLine(TT.ToDBFileFormat("2011-11-30", NAME.GS, TYPE.ENGY, "4876")); sw.WriteLine(TT.ToDBFileFormat("2011-11-30", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2011-12-31", NAME.EL, TYPE.ENGY, "1632")); sw.WriteLine(TT.ToDBFileFormat("2011-12-31", NAME.GS, TYPE.ENGY, "4979")); sw.WriteLine(TT.ToDBFileFormat("2011-12-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2012-01-31", NAME.EL, TYPE.ENGY, "1805")); sw.WriteLine(TT.ToDBFileFormat("2012-01-31", NAME.GS, TYPE.ENGY, "5133")); sw.WriteLine(TT.ToDBFileFormat("2012-01-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2012-02-29", NAME.EL, TYPE.ENGY, "1745")); sw.WriteLine(TT.ToDBFileFormat("2012-02-29", NAME.GS, TYPE.ENGY, "5339")); sw.WriteLine(TT.ToDBFileFormat("2012-02-29", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2012-03-31", NAME.EL, TYPE.ENGY, "1567")); sw.WriteLine(TT.ToDBFileFormat("2012-03-31", NAME.GS, TYPE.ENGY, "5184")); sw.WriteLine(TT.ToDBFileFormat("2012-03-31", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2012-04-30", NAME.EL, TYPE.ENGY, "1577")); sw.WriteLine(TT.ToDBFileFormat("2012-04-30", NAME.GS, TYPE.ENGY, "5544")); sw.WriteLine(TT.ToDBFileFormat("2012-04-30", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2012-05-31", NAME.EL, TYPE.ENGY, "1231")); sw.WriteLine(TT.ToDBFileFormat("2012-05-31", NAME.GS, TYPE.ENGY, "4506")); sw.WriteLine(TT.ToDBFileFormat("2012-05-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2012-06-30", NAME.EL, TYPE.ENGY, "1342")); sw.WriteLine(TT.ToDBFileFormat("2012-06-30", NAME.GS, TYPE.ENGY, "4342")); sw.WriteLine(TT.ToDBFileFormat("2012-06-30", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2012-07-31", NAME.EL, TYPE.ENGY, "2267")); sw.WriteLine(TT.ToDBFileFormat("2012-07-31", NAME.GS, TYPE.ENGY, "3937")); sw.WriteLine(TT.ToDBFileFormat("2012-07-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2012-08-31", NAME.EL, TYPE.ENGY, "2659")); sw.WriteLine(TT.ToDBFileFormat("2012-08-31", NAME.GS, TYPE.ENGY, "3435")); sw.WriteLine(TT.ToDBFileFormat("2012-08-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2012-09-30", NAME.EL, TYPE.ENGY, "2533")); sw.WriteLine(TT.ToDBFileFormat("2012-09-30", NAME.GS, TYPE.ENGY, "3538")); sw.WriteLine(TT.ToDBFileFormat("2012-09-30", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2012-10-31", NAME.EL, TYPE.ENGY, "1374")); sw.WriteLine(TT.ToDBFileFormat("2012-10-31", NAME.GS, TYPE.ENGY, "4104")); sw.WriteLine(TT.ToDBFileFormat("2012-10-31", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2012-11-30", NAME.EL, TYPE.ENGY, "1298")); sw.WriteLine(TT.ToDBFileFormat("2012-11-30", NAME.GS, TYPE.ENGY, "5184")); sw.WriteLine(TT.ToDBFileFormat("2012-11-30", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2012-12-31", NAME.EL, TYPE.ENGY, "1636")); sw.WriteLine(TT.ToDBFileFormat("2012-12-31", NAME.GS, TYPE.ENGY, "5380")); sw.WriteLine(TT.ToDBFileFormat("2012-12-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2013-01-31", NAME.EL, TYPE.ENGY, "2296")); sw.WriteLine(TT.ToDBFileFormat("2013-01-31", NAME.GS, TYPE.ENGY, "5380")); sw.WriteLine(TT.ToDBFileFormat("2013-01-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2013-02-28", NAME.EL, TYPE.ENGY, "2071")); sw.WriteLine(TT.ToDBFileFormat("2013-02-28", NAME.GS, TYPE.ENGY, "5871")); sw.WriteLine(TT.ToDBFileFormat("2013-02-28", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2013-03-31", NAME.EL, TYPE.ENGY, "1588")); sw.WriteLine(TT.ToDBFileFormat("2013-03-31", NAME.GS, TYPE.ENGY, "5544")); sw.WriteLine(TT.ToDBFileFormat("2013-03-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2013-04-30", NAME.EL, TYPE.ENGY, "1443")); sw.WriteLine(TT.ToDBFileFormat("2013-04-30", NAME.GS, TYPE.ENGY, "5325")); sw.WriteLine(TT.ToDBFileFormat("2013-04-30", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2013-05-31", NAME.EL, TYPE.ENGY, "1603")); sw.WriteLine(TT.ToDBFileFormat("2013-05-31", NAME.GS, TYPE.ENGY, "4725")); sw.WriteLine(TT.ToDBFileFormat("2013-05-31", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2013-06-30", NAME.EL, TYPE.ENGY, "1651")); sw.WriteLine(TT.ToDBFileFormat("2013-06-30", NAME.GS, TYPE.ENGY, "3633")); sw.WriteLine(TT.ToDBFileFormat("2013-06-30", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2013-07-31", NAME.EL, TYPE.ENGY, "2485")); sw.WriteLine(TT.ToDBFileFormat("2013-07-31", NAME.GS, TYPE.ENGY, "3687")); sw.WriteLine(TT.ToDBFileFormat("2013-07-31", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2013-08-31", NAME.EL, TYPE.ENGY, "3455")); sw.WriteLine(TT.ToDBFileFormat("2013-08-31", NAME.GS, TYPE.ENGY, "3523")); sw.WriteLine(TT.ToDBFileFormat("2013-08-31", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2013-09-30", NAME.EL, TYPE.ENGY, "1892")); sw.WriteLine(TT.ToDBFileFormat("2013-09-30", NAME.GS, TYPE.ENGY, "3523")); sw.WriteLine(TT.ToDBFileFormat("2013-09-30", NAME.WT, TYPE.ENGY, "1799"));
                sw.WriteLine(TT.ToDBFileFormat("2013-10-31", NAME.EL, TYPE.ENGY, "2016")); sw.WriteLine(TT.ToDBFileFormat("2013-10-31", NAME.GS, TYPE.ENGY, "3906")); sw.WriteLine(TT.ToDBFileFormat("2013-10-31", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2013-11-30", NAME.EL, TYPE.ENGY, "1449")); sw.WriteLine(TT.ToDBFileFormat("2013-11-30", NAME.GS, TYPE.ENGY, "4452")); sw.WriteLine(TT.ToDBFileFormat("2013-11-30", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2013-12-31", NAME.EL, TYPE.ENGY, "1701")); sw.WriteLine(TT.ToDBFileFormat("2013-12-31", NAME.GS, TYPE.ENGY, "4943")); sw.WriteLine(TT.ToDBFileFormat("2013-12-31", NAME.WT, TYPE.ENGY, "1655"));
                sw.WriteLine(TT.ToDBFileFormat("2014-01-31", NAME.EL, TYPE.ENGY, "1760")); sw.WriteLine(TT.ToDBFileFormat("2014-01-31", NAME.GS, TYPE.ENGY, "5287")); sw.WriteLine(TT.ToDBFileFormat("2014-01-31", NAME.WT, TYPE.ENGY, "1655"));
                sw.WriteLine(TT.ToDBFileFormat("2014-02-28", NAME.EL, TYPE.ENGY, "1743")); sw.WriteLine(TT.ToDBFileFormat("2014-02-28", NAME.GS, TYPE.ENGY, "5758")); sw.WriteLine(TT.ToDBFileFormat("2014-02-28", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2014-03-31", NAME.EL, TYPE.ENGY, "1624")); sw.WriteLine(TT.ToDBFileFormat("2014-03-31", NAME.GS, TYPE.ENGY, "5287")); sw.WriteLine(TT.ToDBFileFormat("2014-03-31", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2014-04-30", NAME.EL, TYPE.ENGY, "1729")); sw.WriteLine(TT.ToDBFileFormat("2014-04-30", NAME.GS, TYPE.ENGY, "5405")); sw.WriteLine(TT.ToDBFileFormat("2014-04-30", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2014-05-31", NAME.EL, TYPE.ENGY, "1412")); sw.WriteLine(TT.ToDBFileFormat("2014-05-31", NAME.GS, TYPE.ENGY, "4713")); sw.WriteLine(TT.ToDBFileFormat("2014-05-31", NAME.WT, TYPE.ENGY, "1703"));
                sw.WriteLine(TT.ToDBFileFormat("2014-06-30", NAME.EL, TYPE.ENGY, "1517")); sw.WriteLine(TT.ToDBFileFormat("2014-06-30", NAME.GS, TYPE.ENGY, "4501")); sw.WriteLine(TT.ToDBFileFormat("2014-06-30", NAME.WT, TYPE.ENGY, "1801"));
                sw.WriteLine(TT.ToDBFileFormat("2014-07-31", NAME.EL, TYPE.ENGY, "2350")); sw.WriteLine(TT.ToDBFileFormat("2014-07-31", NAME.GS, TYPE.ENGY, "4209")); sw.WriteLine(TT.ToDBFileFormat("2014-07-31", NAME.WT, TYPE.ENGY, "1801"));
                sw.WriteLine(TT.ToDBFileFormat("2014-08-31", NAME.EL, TYPE.ENGY, "2294")); sw.WriteLine(TT.ToDBFileFormat("2014-08-31", NAME.GS, TYPE.ENGY, "3801")); sw.WriteLine(TT.ToDBFileFormat("2014-08-31", NAME.WT, TYPE.ENGY, "1851"));
                sw.WriteLine(TT.ToDBFileFormat("2014-09-30", NAME.EL, TYPE.ENGY, "2304")); sw.WriteLine(TT.ToDBFileFormat("2014-09-30", NAME.GS, TYPE.ENGY, "4326")); sw.WriteLine(TT.ToDBFileFormat("2014-09-30", NAME.WT, TYPE.ENGY, "1851"));
                sw.WriteLine(TT.ToDBFileFormat("2014-10-31", NAME.EL, TYPE.ENGY, "1433")); sw.WriteLine(TT.ToDBFileFormat("2014-10-31", NAME.GS, TYPE.ENGY, "4501")); sw.WriteLine(TT.ToDBFileFormat("2014-10-31", NAME.WT, TYPE.ENGY, "1801"));
                sw.WriteLine(TT.ToDBFileFormat("2014-11-30", NAME.EL, TYPE.ENGY, "1477")); sw.WriteLine(TT.ToDBFileFormat("2014-11-30", NAME.GS, TYPE.ENGY, "5026")); sw.WriteLine(TT.ToDBFileFormat("2014-11-30", NAME.WT, TYPE.ENGY, "1801"));
                sw.WriteLine(TT.ToDBFileFormat("2014-12-31", NAME.EL, TYPE.ENGY, "1498")); sw.WriteLine(TT.ToDBFileFormat("2014-12-31", NAME.GS, TYPE.ENGY, "5492")); sw.WriteLine(TT.ToDBFileFormat("2014-12-31", NAME.WT, TYPE.ENGY, "1801"));
                sw.WriteLine(TT.ToDBFileFormat("2015-01-31", NAME.EL, TYPE.ENGY, "1860")); sw.WriteLine(TT.ToDBFileFormat("2015-01-31", NAME.GS, TYPE.ENGY, "5551")); sw.WriteLine(TT.ToDBFileFormat("2015-01-31", NAME.WT, TYPE.ENGY, "1801"));
                sw.WriteLine(TT.ToDBFileFormat("2015-02-28", NAME.EL, TYPE.ENGY, "1413")); sw.WriteLine(TT.ToDBFileFormat("2015-02-28", NAME.GS, TYPE.ENGY, "6116")); sw.WriteLine(TT.ToDBFileFormat("2015-02-28", NAME.WT, TYPE.ENGY, "1751"));
                sw.WriteLine(TT.ToDBFileFormat("2015-03-31", NAME.EL, TYPE.ENGY, "1506")); sw.WriteLine(TT.ToDBFileFormat("2015-03-31", NAME.GS, TYPE.ENGY, "5772")); sw.WriteLine(TT.ToDBFileFormat("2015-03-31", NAME.WT, TYPE.ENGY, "1751"));
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(DB_FILE_ONLY_ZERO, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2016-06-30", NAME.EL, TYPE.ENGY, "0"));
                sw.WriteLine(TT.ToDBFileFormat("2016-06-30", NAME.GS, TYPE.ENGY, "0"));
                sw.WriteLine(TT.ToDBFileFormat("2016-06-30", NAME.WT, TYPE.ENGY, "0"));
                sw.Close();
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (File.Exists(DB_FILE_EMPTY    )) File.Delete(DB_FILE_EMPTY);
            if (File.Exists(DB_FILE_ONLY_EL  )) File.Delete(DB_FILE_ONLY_EL);
            if (File.Exists(DB_FILE_ONLY_GS  )) File.Delete(DB_FILE_ONLY_GS);
            if (File.Exists(DB_FILE_ONLY_WT  )) File.Delete(DB_FILE_ONLY_WT);
            if (File.Exists(DB_FILE_ENERGIES )) File.Delete(DB_FILE_ENERGIES);
            if (File.Exists(DB_FILE_ONLY_ZERO)) File.Delete(DB_FILE_ONLY_ZERO);
        }

        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="dbFile">DBファイル</param>
        protected void ShowSubEnergy(string dbFile)
        {
            form = new AbSubEnergy(AbDBManager.Load(dbFile));
            form.Show();
        }

        /// <summary>
        /// 光熱費サブフォーム取得
        /// </summary>
        /// <returns>光熱費サブフォーム</returns>
        protected Form CtAbSubEnergy()
        {
            var finder = new FormFinder();
            return finder.Find(typeof(AbSubEnergy).Name);
        }

        /// <summary>
        /// 電気代ビュー取得
        /// </summary>
        /// <returns>電気代ビュー</returns>
        protected DataGridView CtDgvEl()
        {
            return (new Finder<DataGridView>("DgvEl", form).Find());
        }

        /// <summary>
        /// ガス代ビュー取得
        /// </summary>
        /// <returns>ガス代ビュー</returns>
        protected DataGridView CtDgvGs()
        {
            return (new Finder<DataGridView>("DgvGs", form).Find());
        }

        /// <summary>
        /// 水道代ビュー取得
        /// </summary>
        /// <returns>水道代ビュー</returns>
        protected DataGridView CtDgvWt()
        {
            return (new Finder<DataGridView>("DgvWt", form).Find());
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報リストがNULL
        /// </summary>
        [Test]
        public void AbSubEnergyWithNullExpenses()
        {
            var ex = Assert.Throws<AbException>(() =>
                new AbSubEnergy(null)
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// タイトルテスト
        /// </summary>
        [Test]
        public void LoadWithTitle()
        {
            ShowSubEnergy(DB_FILE_EMPTY);
            Assert.AreEqual("光熱費", form.Text);
        }

        /// <summary>
        /// レコード数のテスト
        /// 電気代:データなし
        /// </summary>
        [Test]
        public void DgvElWithCountWithEmptyData()
        {
            ShowSubEnergy(DB_FILE_EMPTY);
            Assert.AreEqual(0, CtDgvEl().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// ガス代:データなし
        /// </summary>
        [Test]
        public void DgvGsWithCountWithEmptyData()
        {
            ShowSubEnergy(DB_FILE_EMPTY);
            Assert.AreEqual(0, CtDgvGs().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// 水道代:データなし
        /// </summary>
        [Test]
        public void DgvWtWithCountWithEmptyData()
        {
            ShowSubEnergy(DB_FILE_EMPTY);
            Assert.AreEqual(0, CtDgvWt().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// 電気代のみ
        /// </summary>
        [Test]
        public void DgvCountWithOnlyEl()
        {
            ShowSubEnergy(DB_FILE_ONLY_EL);
            Assert.AreEqual(1, CtDgvEl().Rows.Count);
            Assert.AreEqual(1, CtDgvGs().Rows.Count);
            Assert.AreEqual(1, CtDgvWt().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// ガス代のみ
        /// </summary>
        [Test]
        public void DgvCountWithOnlyGs()
        {
            ShowSubEnergy(DB_FILE_ONLY_GS);
            Assert.AreEqual(2, CtDgvEl().Rows.Count);
            Assert.AreEqual(2, CtDgvGs().Rows.Count);
            Assert.AreEqual(2, CtDgvWt().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// 水道代のみ
        /// </summary>
        [Test]
        public void DgvCountWithOnlyWt()
        {
            ShowSubEnergy(DB_FILE_ONLY_WT);
            Assert.AreEqual(3, CtDgvEl().Rows.Count);
            Assert.AreEqual(3, CtDgvGs().Rows.Count);
            Assert.AreEqual(3, CtDgvWt().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// </summary>
        [Test]
        public void DgvCountWithEnergies()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);
            Assert.AreEqual(6, CtDgvEl().Rows.Count);
            Assert.AreEqual(6, CtDgvGs().Rows.Count);
            Assert.AreEqual(6, CtDgvWt().Rows.Count);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 電気代のみ
        /// </summary>
        [Test]
        public void DgvValueWithOnlyEl()
        {
            ShowSubEnergy(DB_FILE_ONLY_EL);

            var dgv = CtDgvEl();
            var row = dgv.Rows[0];
            Assert.AreEqual( 2015, row.Cells[ 0].Value);
            Assert.AreEqual( 3300, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual( 3700, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual( null, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual( 6300, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(12500, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual( 2800, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual( 2900, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual( 3000, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual( null, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual( 2100, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual( 2500, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual( 2900, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// ガス代のみ
        /// </summary>
        [Test]
        public void DgvValueWithOnlyGs()
        {
            ShowSubEnergy(DB_FILE_ONLY_GS);

            var dgv = CtDgvGs();
            var row1 = dgv.Rows[0];
            Assert.AreEqual(2015, row1.Cells[ 0].Value);
            Assert.AreEqual(2600, row1.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(2800, row1.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(3000, row1.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(3200, row1.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3400, row1.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(3600, row1.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(3800, row1.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(4000, row1.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(4200, row1.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(4400, row1.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(4600, row1.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(4800, row1.Cells[12].Value, MSG.MONTH03);

            var row2 = dgv.Rows[1];
            Assert.AreEqual(2016, row2.Cells[ 0].Value);
            Assert.AreEqual(5000, row2.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(5200, row2.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(5400, row2.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(5600, row2.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(5800, row2.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(6000, row2.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(6200, row2.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(6400, row2.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(6600, row2.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(2000, row2.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(2200, row2.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(2400, row2.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 水道代のみ
        /// </summary>
        [Test]
        public void DgvValueWithOnlyWt()
        {
            ShowSubEnergy(DB_FILE_ONLY_WT);

            var dgv = CtDgvWt();
            var row1 = dgv.Rows[0];
            Assert.AreEqual(2015, row1.Cells[ 0].Value);
            Assert.AreEqual(1300, row1.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1400, row1.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1500, row1.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(1600, row1.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(1700, row1.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1800, row1.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1900, row1.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(2000, row1.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(2100, row1.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1000, row1.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1100, row1.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1200, row1.Cells[12].Value, MSG.MONTH03);

            var row2 = dgv.Rows[1];
            Assert.AreEqual(2016, row2.Cells[ 0].Value);
            Assert.AreEqual(null, row2.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(null, row2.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(null, row2.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(null, row2.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(null, row2.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(null, row2.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(null, row2.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(null, row2.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(null, row2.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(null, row2.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(null, row2.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(null, row2.Cells[12].Value, MSG.MONTH03);

            var row3 = dgv.Rows[2];
            Assert.AreEqual(2017, row3.Cells[ 0].Value);
            Assert.AreEqual(2500, row3.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(2600, row3.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(2700, row3.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(2800, row3.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(2900, row3.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(3000, row3.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(3100, row3.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(3200, row3.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(3300, row3.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(2200, row3.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(2300, row3.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(2400, row3.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2009年電気代
        /// </summary>
        [Test]
        public void DgvValueWithEl2009()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvEl();
            var row = dgv.Rows[0];
            Assert.AreEqual(2009, row.Cells[ 0].Value);
            Assert.AreEqual(1804, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1359, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1550, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(3780, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3853, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(3143, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1416, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1250, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual( 501, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual( 708, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual( 690, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1673, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2010年電気代
        /// </summary>
        [Test]
        public void DgvValueWithEl2010()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvEl();
            var row = dgv.Rows[1];
            Assert.AreEqual(2010, row.Cells[ 0].Value);
            Assert.AreEqual(1926, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1321, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1475, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(2045, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3147, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(2918, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1306, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1791, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1573, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1675, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1783, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1357, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2011年電気代
        /// </summary>
        [Test]
        public void DgvValueWithEl2011()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvEl();
            var row = dgv.Rows[2];
            Assert.AreEqual(2011, row.Cells[ 0].Value);
            Assert.AreEqual(1426, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1174, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1266, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(2010, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(2257, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1998, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1164, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1369, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1632, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1805, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1745, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1567, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2012年電気代
        /// </summary>
        [Test]
        public void DgvValueWithEl2012()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvEl();
            var row = dgv.Rows[3];
            Assert.AreEqual(2012, row.Cells[ 0].Value);
            Assert.AreEqual(1577, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1231, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1342, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(2267, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(2659, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(2533, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1374, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1298, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1636, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(2296, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(2071, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1588, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2013年電気代
        /// </summary>
        [Test]
        public void DgvValueWithEl2013()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvEl();
            var row = dgv.Rows[4];
            Assert.AreEqual(2013, row.Cells[ 0].Value);
            Assert.AreEqual(1443, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1603, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1651, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(2485, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3455, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1892, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(2016, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1449, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1701, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1760, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1743, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1624, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2014年電気代
        /// </summary>
        [Test]
        public void DgvValueWithEl2014()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvEl();
            var row = dgv.Rows[5];
            Assert.AreEqual(2014, row.Cells[ 0].Value);
            Assert.AreEqual(1729, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1412, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1517, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(2350, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(2294, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(2304, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1433, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1477, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1498, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1860, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1413, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1506, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2009年ガス代
        /// </summary>
        [Test]
        public void DgvValueWithGs2009()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvGs();
            var row = dgv.Rows[0];
            Assert.AreEqual(2009, row.Cells[ 0].Value);
            Assert.AreEqual(5422, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(4462, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(4659, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(4363, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3969, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(3771, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(3820, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(4857, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1995, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(3031, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(3574, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(6574, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2010年ガス代
        /// </summary>
        [Test]
        public void DgvValueWithGs2010()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvGs();
            var row = dgv.Rows[1];
            Assert.AreEqual(2010, row.Cells[ 0].Value);
            Assert.AreEqual(6213, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(4413, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(4464, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(4310, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3847, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(3538, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(3898, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(5390, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(5647, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(5596, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(5596, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(5339, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2011年ガス代
        /// </summary>
        [Test]
        public void DgvValueWithGs2011()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvGs();
            var row = dgv.Rows[2];
            Assert.AreEqual(2011, row.Cells[ 0].Value);
            Assert.AreEqual(5339, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(4207, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(4824, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(4001, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3538, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(3692, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(4053, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(4876, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(4979, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(5133, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(5339, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(5184, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2012年ガス代
        /// </summary>
        [Test]
        public void DgvValueWithGs2012()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvGs();
            var row = dgv.Rows[3];
            Assert.AreEqual(2012, row.Cells[ 0].Value);
            Assert.AreEqual(5544, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(4506, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(4342, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(3937, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3435, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(3538, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(4104, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(5184, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(5380, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(5380, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(5871, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(5544, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2013年ガス代
        /// </summary>
        [Test]
        public void DgvValueWithGs2013()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvGs();
            var row = dgv.Rows[4];
            Assert.AreEqual(2013, row.Cells[ 0].Value);
            Assert.AreEqual(5325, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(4725, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(3633, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(3687, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3523, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(3523, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(3906, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(4452, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(4943, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(5287, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(5758, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(5287, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2014年ガス代
        /// </summary>
        [Test]
        public void DgvValueWithGs2014()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvGs();
            var row = dgv.Rows[5];
            Assert.AreEqual(2014, row.Cells[ 0].Value);
            Assert.AreEqual(5405, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(4713, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(4501, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(4209, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(3801, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(4326, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(4501, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(5026, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(5492, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(5551, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(6116, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(5772, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2009年水道代
        /// </summary>
        [Test]
        public void DgvValueWithWt2009()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvWt();
            var row = dgv.Rows[0];
            Assert.AreEqual(2009, row.Cells[ 0].Value);
            Assert.AreEqual(1848, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1848, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1896, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(1896, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(1896, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1896, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1848, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1848, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1462, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1462, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1558, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1558, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2010年水道代
        /// </summary>
        [Test]
        public void DgvValueWithWt2010()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvWt();
            var row = dgv.Rows[1];
            Assert.AreEqual(2010, row.Cells[ 0].Value);
            Assert.AreEqual(1848, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1848, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1848, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(1848, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(1896, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1896, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1799, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1799, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1799, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1799, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1751, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1751, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2011年水道代
        /// </summary>
        [Test]
        public void DgvValueWithWt2011()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvWt();
            var row = dgv.Rows[2];
            Assert.AreEqual(2011, row.Cells[ 0].Value);
            Assert.AreEqual(1703, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1703, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1848, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(1848, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(1848, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1848, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1751, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1751, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1751, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1751, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1703, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1703, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2012年水道代
        /// </summary>
        [Test]
        public void DgvValueWithWt2012()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvWt();
            var row = dgv.Rows[3];
            Assert.AreEqual(2012, row.Cells[ 0].Value);
            Assert.AreEqual(1751, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1751, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1751, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(1751, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(1751, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1751, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1799, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1799, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1751, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1751, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1751, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1751, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2013年水道代
        /// </summary>
        [Test]
        public void DgvValueWithWt2013()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvWt();
            var row = dgv.Rows[4];
            Assert.AreEqual(2013, row.Cells[ 0].Value);
            Assert.AreEqual(1799, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1799, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1703, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(1703, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(1799, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1799, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1703, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1703, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1655, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1655, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1703, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1703, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 光熱費のテスト
        /// 2014年水道代
        /// </summary>
        [Test]
        public void DgvValueWithWt2014()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvWt();
            var row = dgv.Rows[5];
            Assert.AreEqual(2014, row.Cells[ 0].Value);
            Assert.AreEqual(1703, row.Cells[ 1].Value, MSG.MONTH04);
            Assert.AreEqual(1703, row.Cells[ 2].Value, MSG.MONTH05);
            Assert.AreEqual(1801, row.Cells[ 3].Value, MSG.MONTH06);
            Assert.AreEqual(1801, row.Cells[ 4].Value, MSG.MONTH07);
            Assert.AreEqual(1851, row.Cells[ 5].Value, MSG.MONTH08);
            Assert.AreEqual(1851, row.Cells[ 6].Value, MSG.MONTH09);
            Assert.AreEqual(1801, row.Cells[ 7].Value, MSG.MONTH10);
            Assert.AreEqual(1801, row.Cells[ 8].Value, MSG.MONTH11);
            Assert.AreEqual(1801, row.Cells[ 9].Value, MSG.MONTH12);
            Assert.AreEqual(1801, row.Cells[10].Value, MSG.MONTH01);
            Assert.AreEqual(1751, row.Cells[11].Value, MSG.MONTH02);
            Assert.AreEqual(1751, row.Cells[12].Value, MSG.MONTH03);
        }

        /// <summary>
        /// 最大値のテスト
        /// 電気代のみ
        /// </summary>
        [Test]
        public void DgvMaxWithOnlyEl()
        {
            ShowSubEnergy(DB_FILE_ONLY_EL);

            var dgv = CtDgvEl();
            var row1 = dgv.Rows[0];

            // 1年分しかデータがないためすべて最大値になる
            Assert.AreEqual(Color.Red, row1.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Red, row1.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            // 6月は電気代なし
            Assert.AreEqual(Color.Red, row1.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Red, row1.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Red, row1.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Red, row1.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Red, row1.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            // 12月は電気代なし
            Assert.AreEqual(Color.Red, row1.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Red, row1.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row1.Cells[11].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最大値のテスト
        /// ガス代のみ
        /// </summary>
        [Test]
        public void DgvMaxWithOnlyGs()
        {
            ShowSubEnergy(DB_FILE_ONLY_GS);

            var dgv = CtDgvGs();
            var row1 = dgv.Rows[0];
            var row2 = dgv.Rows[1];
            Assert.AreEqual(Color.Red, row2.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Red, row2.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Red, row2.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Red, row2.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Red, row2.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Red, row2.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Red, row2.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Red, row2.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Red, row2.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Red, row1.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Red, row1.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row1.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最大値のテスト
        /// 水道代のみ
        /// </summary>
        [Test]
        public void DgvMaxWithOnlyWt()
        {
            ShowSubEnergy(DB_FILE_ONLY_WT);

            var dgv = CtDgvWt();
            var row2 = dgv.Rows[2];

            // 2017年がすべて最大
            Assert.AreEqual(Color.Red, row2.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Red, row2.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Red, row2.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Red, row2.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Red, row2.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Red, row2.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Red, row2.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Red, row2.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Red, row2.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Red, row2.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Red, row2.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row2.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最小値のテスト
        /// 電気代のみ
        /// </summary>
        [Test]
        public void DgvMinWithOnlyEl()
        {
            ShowSubEnergy(DB_FILE_ONLY_EL);

            var dgv = CtDgvEl();
            var row1 = dgv.Rows[0];

            // 1年分しかデータがないためすべて最大値になる
            Assert.AreEqual(Color.Red, row1.Cells[1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Red, row1.Cells[2].Style.ForeColor, MSG.MONTH05);
            // 6月は電気代なし
            Assert.AreEqual(Color.Red, row1.Cells[4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Red, row1.Cells[5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Red, row1.Cells[6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Red, row1.Cells[7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Red, row1.Cells[8].Style.ForeColor, MSG.MONTH11);
            // 12月は電気代なし
            Assert.AreEqual(Color.Red, row1.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Red, row1.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row1.Cells[11].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最小値のテスト
        /// ガス代のみ
        /// </summary>
        [Test]
        public void DgvMinWithOnlyGs()
        {
            ShowSubEnergy(DB_FILE_ONLY_GS);

            var dgv = CtDgvGs();
            var row1 = dgv.Rows[0];
            var row2 = dgv.Rows[1];
            Assert.AreEqual(Color.Blue, row1.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Blue, row1.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Blue, row1.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Blue, row1.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Blue, row1.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Blue, row1.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Blue, row1.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Blue, row1.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Blue, row1.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Blue, row2.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Blue, row2.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Blue, row2.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最小値のテスト
        /// 水道代のみ
        /// </summary>
        [Test]
        public void DgvMinWithOnlyWt()
        {
            ShowSubEnergy(DB_FILE_ONLY_WT);

            var dgv = CtDgvWt();
            var row1 = dgv.Rows[0];

            // 2015年がすべて最小
            Assert.AreEqual(Color.Blue, row1.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Blue, row1.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Blue, row1.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Blue, row1.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Blue, row1.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Blue, row1.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Blue, row1.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Blue, row1.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Blue, row1.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Blue, row1.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Blue, row1.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Blue, row1.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最大値のテスト
        /// 電気代
        /// </summary>
        [Test]
        public void DgvMaxWithEl()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvEl();
            var row1 = dgv.Rows[0];
            var row2 = dgv.Rows[1];
            var row4 = dgv.Rows[3];
            var row5 = dgv.Rows[4];
            Assert.AreEqual(Color.Red, row2.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Red, row5.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Red, row5.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Red, row1.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Red, row1.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Red, row1.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Red, row5.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Red, row2.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Red, row5.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Red, row4.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Red, row4.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row1.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最大値のテスト
        /// ガス代
        /// </summary>
        [Test]
        public void DgvMaxWithGs()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvGs();
            var row1 = dgv.Rows[0];
            var row2 = dgv.Rows[1];
            var row3 = dgv.Rows[2];
            var row5 = dgv.Rows[4];
            var row6 = dgv.Rows[5];
            Assert.AreEqual(Color.Red, row2.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Red, row5.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Red, row3.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Red, row1.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Red, row1.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Red, row6.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Red, row6.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Red, row2.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Red, row2.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Red, row2.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Red, row6.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row1.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最大値のテスト
        /// 水道代
        /// </summary>
        [Test]
        public void DgvMaxWithWt()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvWt();
            var row1 = dgv.Rows[0];
            var row2 = dgv.Rows[1];
            var row4 = dgv.Rows[3];
            var row6 = dgv.Rows[5];
            Assert.AreEqual(Color.Red, row1.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Red, row2.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Red, row1.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Red, row2.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Red, row1.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Red, row1.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Red, row1.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Red, row2.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Red, row1.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Red, row2.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Red, row1.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Red, row1.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Red, row6.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Red, row6.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Red, row2.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row4.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row6.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Red, row2.Cells[12].Style.ForeColor, MSG.MONTH03);
            Assert.AreEqual(Color.Red, row4.Cells[12].Style.ForeColor, MSG.MONTH03);
            Assert.AreEqual(Color.Red, row6.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最小値のテスト
        /// 電気代
        /// </summary>
        [Test]
        public void DgvMinWithEl()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvEl();
            var row1 = dgv.Rows[0];
            var row2 = dgv.Rows[1];
            var row3 = dgv.Rows[2];
            var row5 = dgv.Rows[4];
            Assert.AreEqual(Color.Blue, row3.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Blue, row3.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Blue, row3.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Blue, row3.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Blue, row3.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Blue, row5.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Blue, row3.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Blue, row1.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Blue, row1.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Blue, row1.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Blue, row1.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Blue, row2.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最小値のテスト
        /// ガス代
        /// </summary>
        [Test]
        public void DgvMinWithGs()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvGs();
            var row1 = dgv.Rows[0];
            var row3 = dgv.Rows[2];
            var row4 = dgv.Rows[3];
            var row5 = dgv.Rows[4];
            Assert.AreEqual(Color.Blue, row5.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Blue, row3.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Blue, row5.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Blue, row5.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Blue, row4.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Blue, row5.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Blue, row1.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Blue, row5.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Blue, row1.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Blue, row1.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Blue, row1.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Blue, row3.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 最小値のテスト
        /// 水道代
        /// </summary>
        [Test]
        public void DgvMinWithWt()
        {
            ShowSubEnergy(DB_FILE_ENERGIES);

            var dgv = CtDgvWt();
            var row1 = dgv.Rows[0];
            var row3 = dgv.Rows[2];
            var row4 = dgv.Rows[3];
            var row5 = dgv.Rows[4];
            var row6 = dgv.Rows[5];
            Assert.AreEqual(Color.Blue, row3.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Blue, row6.Cells[ 1].Style.ForeColor, MSG.MONTH04);
            Assert.AreEqual(Color.Blue, row3.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Blue, row6.Cells[ 2].Style.ForeColor, MSG.MONTH05);
            Assert.AreEqual(Color.Blue, row5.Cells[ 3].Style.ForeColor, MSG.MONTH06);
            Assert.AreEqual(Color.Blue, row5.Cells[ 4].Style.ForeColor, MSG.MONTH07);
            Assert.AreEqual(Color.Blue, row4.Cells[ 5].Style.ForeColor, MSG.MONTH08);
            Assert.AreEqual(Color.Blue, row4.Cells[ 6].Style.ForeColor, MSG.MONTH09);
            Assert.AreEqual(Color.Blue, row5.Cells[ 7].Style.ForeColor, MSG.MONTH10);
            Assert.AreEqual(Color.Blue, row5.Cells[ 8].Style.ForeColor, MSG.MONTH11);
            Assert.AreEqual(Color.Blue, row1.Cells[ 9].Style.ForeColor, MSG.MONTH12);
            Assert.AreEqual(Color.Blue, row1.Cells[10].Style.ForeColor, MSG.MONTH01);
            Assert.AreEqual(Color.Blue, row1.Cells[11].Style.ForeColor, MSG.MONTH02);
            Assert.AreEqual(Color.Blue, row1.Cells[12].Style.ForeColor, MSG.MONTH03);
        }

        /// <summary>
        /// 0円の光熱費しかない場合のテスト
        /// エラーにならずに表示されればそれでOK
        /// </summary>
        [Test]
        public void DgvErrorNotOccuredWithOnlyZero()
        {
            ShowSubEnergy(DB_FILE_ONLY_ZERO);

            var rowEl = CtDgvEl().Rows[0];
            Assert.AreEqual(0, rowEl.Cells[3].Value, MSG.MONTH06);
            var rowGs = CtDgvGs().Rows[0];
            Assert.AreEqual(0, rowGs.Cells[3].Value, MSG.MONTH06);
            var rowWt = CtDgvWt().Rows[0];
            Assert.AreEqual(0, rowWt.Cells[3].Value, MSG.MONTH06);
        }
    }
}
