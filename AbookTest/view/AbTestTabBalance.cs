namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using COL  = Abook.AbConstants.COL;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 収支タブテスト
    /// </summary>
    [TestFixture]
    public class AbTestTabBalance : AbTestFormBase
    {
        /// <summary>DB ファイル</summary>
        private const string DB_EXIST = "AbTestTabBalanceExist.db";
        /// <summary>DB ファイル</summary>
        private const string DB_EMPTY = "AbTestTabBalanceEmpty.db";
        /// <summary>タブインデックス</summary>
        private const int TAB_IDX = 3;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_EXIST, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(ToCSV("2009-04-01", "name", TYPE.EARN, "800000"));
                sw.WriteLine(ToCSV("2009-04-01", "name", TYPE.EARN, "900000"));
                sw.WriteLine(ToCSV("2009-04-01", "name", TYPE.FOOD, "200000"));
                sw.WriteLine(ToCSV("2009-04-01", "name", TYPE.FOOD, "350000"));
                sw.WriteLine(ToCSV("2009-04-01", "name", TYPE.SPCL,  "80000"));
                sw.WriteLine(ToCSV("2009-04-01", "name", TYPE.SPCL,  "50000"));
                sw.WriteLine(ToCSV("2009-04-30", "name", TYPE.BNUS,  "10000"));

                sw.WriteLine(ToCSV("2010-03-01", "name", TYPE.EARN, "200000"));
                sw.WriteLine(ToCSV("2010-03-01", "name", TYPE.EARN, "400000"));
                sw.WriteLine(ToCSV("2010-03-01", "name", TYPE.FOOD, "300000"));
                sw.WriteLine(ToCSV("2010-03-01", "name", TYPE.FOOD, "250000"));
                sw.WriteLine(ToCSV("2010-03-01", "name", TYPE.SPCL,  "20000"));
                sw.WriteLine(ToCSV("2010-03-01", "name", TYPE.SPCL,  "30000"));
                sw.WriteLine(ToCSV("2010-03-31", "name", TYPE.BNUS,  "15000"));

                sw.WriteLine(ToCSV("2010-04-01", "name", TYPE.EARN, "600000"));
                sw.WriteLine(ToCSV("2010-04-01", "name", TYPE.EARN, "800000"));
                sw.WriteLine(ToCSV("2010-04-01", "name", TYPE.FOOD, "200000"));
                sw.WriteLine(ToCSV("2010-04-01", "name", TYPE.FOOD, "250000"));
                sw.WriteLine(ToCSV("2010-04-01", "name", TYPE.SPCL,  "20000"));
                sw.WriteLine(ToCSV("2010-04-01", "name", TYPE.SPCL,  "40000"));
                sw.WriteLine(ToCSV("2010-04-30", "name", TYPE.BNUS,   "1000"));

                sw.WriteLine(ToCSV("2011-03-01", "name", TYPE.EARN, "300000"));
                sw.WriteLine(ToCSV("2011-03-01", "name", TYPE.EARN, "700000"));
                sw.WriteLine(ToCSV("2011-03-01", "name", TYPE.FOOD, "100000"));
                sw.WriteLine(ToCSV("2011-03-01", "name", TYPE.FOOD, "450000"));
                sw.WriteLine(ToCSV("2011-03-01", "name", TYPE.SPCL,  "60000"));
                sw.WriteLine(ToCSV("2011-03-01", "name", TYPE.SPCL,  "18000"));
                sw.WriteLine(ToCSV("2011-03-31", "name", TYPE.BNUS,   "2000"));

                sw.WriteLine(ToCSV("2011-04-01", "name", TYPE.EARN,      "0"));
                sw.WriteLine(ToCSV("2011-04-01", "name", TYPE.EARN,      "0"));
                sw.WriteLine(ToCSV("2011-04-01", "name", TYPE.FOOD, "300000"));
                sw.WriteLine(ToCSV("2011-04-01", "name", TYPE.FOOD, "900000"));
                sw.WriteLine(ToCSV("2011-04-01", "name", TYPE.SPCL,  "80000"));
                sw.WriteLine(ToCSV("2011-04-01", "name", TYPE.SPCL,  "20000"));
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (System.IO.File.Exists(DB_EXIST)) System.IO.File.Delete(DB_EXIST);
            if (System.IO.File.Exists(DB_EMPTY)) System.IO.File.Delete(DB_EMPTY);
        }

        /// <summary>
        /// レコード数のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithCount()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            Assert.AreEqual(4, CtDgvBalance().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (データなし)
        /// </summary>
        [Test]
        public void DgvBalanceWithCountWithEmptyData()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            Assert.AreEqual(0, CtDgvBalance().Rows.Count);
        }

        /// <summary>
        /// 年度のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithYear()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(2009, dgvBalance.Rows[0].Cells[COL.YEAR].Value);
            Assert.AreEqual(2010, dgvBalance.Rows[1].Cells[COL.YEAR].Value);
            Assert.AreEqual(2011, dgvBalance.Rows[2].Cells[COL.YEAR].Value);
            Assert.AreEqual(9999, dgvBalance.Rows[3].Cells[COL.YEAR].Value);
        }

        /// <summary>
        /// 収入のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithEarn()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(2325000, dgvBalance.Rows[0].Cells[COL.EARN].Value);
            Assert.AreEqual(2403000, dgvBalance.Rows[1].Cells[COL.EARN].Value);
            Assert.AreEqual(      0, dgvBalance.Rows[2].Cells[COL.EARN].Value);
            Assert.AreEqual(4728000, dgvBalance.Rows[3].Cells[COL.EARN].Value);
        }

        /// <summary>
        /// 支出のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithExpense()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(1100000, dgvBalance.Rows[0].Cells[COL.EXPENSE].Value);
            Assert.AreEqual(1000000, dgvBalance.Rows[1].Cells[COL.EXPENSE].Value);
            Assert.AreEqual(1200000, dgvBalance.Rows[2].Cells[COL.EXPENSE].Value);
            Assert.AreEqual(3300000, dgvBalance.Rows[3].Cells[COL.EXPENSE].Value);
        }

        /// <summary>
        /// 特出のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithSpecial()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(180000, dgvBalance.Rows[0].Cells[COL.SPECIAL].Value);
            Assert.AreEqual(138000, dgvBalance.Rows[1].Cells[COL.SPECIAL].Value);
            Assert.AreEqual(100000, dgvBalance.Rows[2].Cells[COL.SPECIAL].Value);
            Assert.AreEqual(418000, dgvBalance.Rows[3].Cells[COL.SPECIAL].Value);
        }

        /// <summary>
        /// 収支のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithBalance()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual( 1045000, dgvBalance.Rows[0].Cells[COL.BALANCE].Value);
            Assert.AreEqual( 1265000, dgvBalance.Rows[1].Cells[COL.BALANCE].Value);
            Assert.AreEqual(-1300000, dgvBalance.Rows[2].Cells[COL.BALANCE].Value);
            Assert.AreEqual( 1010000, dgvBalance.Rows[3].Cells[COL.BALANCE].Value);
        }
    }
}
