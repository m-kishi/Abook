// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using System.IO;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT   = AbTestTool;
    using DB   = Abook.AbConstants.DB;
    using COL  = Abook.AbConstants.COL.BALANCE;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 収支タブテスト
    /// </summary>
    [TestFixture]
    public class AbTestTabBalance : AbTestFormBase
    {
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EXIST = "AbTestTabBalanceExist.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EMPTY = "AbTestTabBalanceEmpty.db";
        /// <summary>タブインデックス</summary>
        private const int TAB_IDX = 3;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_FILE_EXIST, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;

                sw.WriteLine(TT.ToDBFileFormat("2009-04-01", "name", TYPE.EARN, "800000"));
                sw.WriteLine(TT.ToDBFileFormat("2009-04-01", "name", TYPE.EARN, "900000"));
                sw.WriteLine(TT.ToDBFileFormat("2009-04-01", "name", TYPE.FOOD, "200000"));
                sw.WriteLine(TT.ToDBFileFormat("2009-04-01", "name", TYPE.FOOD, "350000"));
                sw.WriteLine(TT.ToDBFileFormat("2009-04-01", "name", TYPE.SPCL,  "80000"));
                sw.WriteLine(TT.ToDBFileFormat("2009-04-01", "name", TYPE.SPCL,  "50000"));
                sw.WriteLine(TT.ToDBFileFormat("2009-04-30", "name", TYPE.BNUS,  "10000"));
                sw.WriteLine(TT.ToDBFileFormat("2009-04-30", "name", TYPE.PRVI,  "11000"));

                sw.WriteLine(TT.ToDBFileFormat("2010-03-01", "name", TYPE.EARN, "200000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-03-01", "name", TYPE.EARN, "400000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-03-01", "name", TYPE.FOOD, "300000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-03-01", "name", TYPE.FOOD, "250000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-03-01", "name", TYPE.SPCL,  "20000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-03-01", "name", TYPE.SPCL,  "30000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-03-31", "name", TYPE.BNUS,  "15000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-03-31", "name", TYPE.PRVO,  "10000"));

                sw.WriteLine(TT.ToDBFileFormat("2010-04-01", "name", TYPE.EARN, "600000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-04-01", "name", TYPE.EARN, "800000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-04-01", "name", TYPE.FOOD, "200000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-04-01", "name", TYPE.FOOD, "250000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-04-01", "name", TYPE.SPCL,  "20000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-04-01", "name", TYPE.SPCL,  "40000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-04-30", "name", TYPE.BNUS,   "1000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-04-30", "name", TYPE.PRVI,  "30000"));

                sw.WriteLine(TT.ToDBFileFormat("2011-03-01", "name", TYPE.EARN, "300000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-03-01", "name", TYPE.EARN, "700000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-03-01", "name", TYPE.FOOD, "100000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-03-01", "name", TYPE.FOOD, "450000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-03-01", "name", TYPE.SPCL,  "60000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-03-01", "name", TYPE.SPCL,  "18000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-03-31", "name", TYPE.BNUS,   "2000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-03-31", "name", TYPE.PRVO,   "9000"));

                sw.WriteLine(TT.ToDBFileFormat("2011-04-01", "name", TYPE.EARN,      "0"));
                sw.WriteLine(TT.ToDBFileFormat("2011-04-01", "name", TYPE.EARN,      "0"));
                sw.WriteLine(TT.ToDBFileFormat("2011-04-01", "name", TYPE.FOOD, "300000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-04-01", "name", TYPE.FOOD, "900000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-04-01", "name", TYPE.SPCL,  "80000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-04-01", "name", TYPE.SPCL,  "20000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-04-01", "name", TYPE.PRVI,  "30000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-04-01", "name", TYPE.FNCE, "123456"));

                sw.WriteLine(TT.ToDBFileFormat("2012-01-01", "name", TYPE.FNCE, "654321"));
                sw.Close();
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (File.Exists(DB_FILE_EXIST)) File.Delete(DB_FILE_EXIST);
            if (File.Exists(DB_FILE_EMPTY)) File.Delete(DB_FILE_EMPTY);
        }

        /// <summary>
        /// レコード数のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithCount()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);
            Assert.AreEqual(5, CtDgvBalance().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (データなし)
        /// </summary>
        [Test]
        public void DgvBalanceWithCountWithEmptyData()
        {
            ShowFormMain(DB_FILE_EMPTY, TAB_IDX);
            Assert.AreEqual(0, CtDgvBalance().Rows.Count);
        }

        /// <summary>
        /// DataGridView
        /// セル選択位置のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithSelection()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            var row = dgvBalance.SelectedRows[0];
            var cell = dgvBalance.Rows[dgvBalance.Rows.Count - 1].Cells[COL.YEAR];

            Assert.True(row.Selected);
            Assert.True(cell.Selected);
            Assert.AreEqual(4, row.Index);
            Assert.AreEqual(1, dgvBalance.SelectedRows.Count);
        }

        /// <summary>
        /// DataGridView
        /// スクロールバーのテスト
        /// </summary>
        [Ignore]
        public void DgvPrivateWithScrollBar()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            var row = dgvPrivate.SelectedRows[0];

            // テストデータではスクロールが発生しないので手動確認することにして無視
            Assert.AreEqual(dgvPrivate.FirstDisplayedCell.RowIndex, row.Index - 9);
        }

        /// <summary>
        /// 年度のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithYear()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(2009, dgvBalance.Rows[0].Cells[COL.YEAR].Value);
            Assert.AreEqual(2010, dgvBalance.Rows[1].Cells[COL.YEAR].Value);
            Assert.AreEqual(2011, dgvBalance.Rows[2].Cells[COL.YEAR].Value);
            Assert.AreEqual(2012, dgvBalance.Rows[3].Cells[COL.YEAR].Value);
            Assert.AreEqual(9999, dgvBalance.Rows[4].Cells[COL.YEAR].Value);
        }

        /// <summary>
        /// 収入のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithEarn()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(2325000, dgvBalance.Rows[0].Cells[COL.EARN].Value);
            Assert.AreEqual(2403000, dgvBalance.Rows[1].Cells[COL.EARN].Value);
            Assert.AreEqual(      0, dgvBalance.Rows[2].Cells[COL.EARN].Value);
            Assert.AreEqual(      0, dgvBalance.Rows[3].Cells[COL.EARN].Value);
            Assert.AreEqual(4728000, dgvBalance.Rows[4].Cells[COL.EARN].Value);
        }

        /// <summary>
        /// 支出のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithExpense()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(1100000, dgvBalance.Rows[0].Cells[COL.EXPC].Value);
            Assert.AreEqual(1000000, dgvBalance.Rows[1].Cells[COL.EXPC].Value);
            Assert.AreEqual(1200000, dgvBalance.Rows[2].Cells[COL.EXPC].Value);
            Assert.AreEqual(      0, dgvBalance.Rows[3].Cells[COL.EXPC].Value);
            Assert.AreEqual(3300000, dgvBalance.Rows[4].Cells[COL.EXPC].Value);
        }

        /// <summary>
        /// 特出のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithSpecial()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(180000, dgvBalance.Rows[0].Cells[COL.SPCL].Value);
            Assert.AreEqual(138000, dgvBalance.Rows[1].Cells[COL.SPCL].Value);
            Assert.AreEqual(100000, dgvBalance.Rows[2].Cells[COL.SPCL].Value);
            Assert.AreEqual(     0, dgvBalance.Rows[3].Cells[COL.SPCL].Value);
            Assert.AreEqual(418000, dgvBalance.Rows[4].Cells[COL.SPCL].Value);
        }

        /// <summary>
        /// 収支のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithBalance()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual( 1045000, dgvBalance.Rows[0].Cells[COL.BLNC].Value);
            Assert.AreEqual( 1265000, dgvBalance.Rows[1].Cells[COL.BLNC].Value);
            Assert.AreEqual(-1300000, dgvBalance.Rows[2].Cells[COL.BLNC].Value);
            Assert.AreEqual(       0, dgvBalance.Rows[3].Cells[COL.BLNC].Value);
            Assert.AreEqual( 1010000, dgvBalance.Rows[4].Cells[COL.BLNC].Value);
        }

        /// <summary>
        /// 投資のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithFinance()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvBalance = CtDgvBalance();
            Assert.AreEqual(     0, dgvBalance.Rows[0].Cells[COL.FNCE].Value);
            Assert.AreEqual(     0, dgvBalance.Rows[1].Cells[COL.FNCE].Value);
            Assert.AreEqual(123456, dgvBalance.Rows[2].Cells[COL.FNCE].Value);
            Assert.AreEqual(654321, dgvBalance.Rows[3].Cells[COL.FNCE].Value);
            Assert.AreEqual(777777, dgvBalance.Rows[4].Cells[COL.FNCE].Value);
        }
    }
}
