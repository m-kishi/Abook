namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using COL  = Abook.AbConstants.COL;
    using CSV  = Abook.AbConstants.CSV;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 秘密収支タブテスト
    /// </summary>
    [TestFixture]
    public class AbTestTabPrivate : AbTestFormBase
    {
        /// <summary>DB ファイル</summary>
        private const string DB_EXIST = "AbTestTabPrivateExist.db";
        /// <summary>DB ファイル</summary>
        private const string DB_EMPTY = "AbTestTabPrivateEmpty.db";
        /// <summary>タブインデックス</summary>
        private const int TAB_IDX = 4;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_EXIST, false, CSV.ENCODING))
            {
                sw.WriteLine(ToCSV("2009-04-01", "private01", TYPE.PRVI, "10000"));
                sw.WriteLine(ToCSV("2009-05-01", "private02", TYPE.PRVI, "20000"));
                sw.WriteLine(ToCSV("2010-06-01", "private03", TYPE.PRVI, "30000"));
                sw.WriteLine(ToCSV("2010-06-30", "dummy"    , TYPE.FOOD, "35000"));
                sw.WriteLine(ToCSV("2010-07-01", "private04", TYPE.PRVO, "40000"));
                sw.WriteLine(ToCSV("2011-08-01", "private05", TYPE.PRVI, "50000"));
                sw.WriteLine(ToCSV("2011-09-01", "private06", TYPE.PRVI, "60000"));
                sw.WriteLine(ToCSV("2011-09-30", "dummy"    , TYPE.SPCL, "65000"));
                sw.WriteLine(ToCSV("2012-10-01", "private07", TYPE.PRVI, "70000"));
                sw.WriteLine(ToCSV("2012-11-01", "private08", TYPE.PRVO, "80000"));
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
        public void DgvPrivateWithCount()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            Assert.AreEqual(8, CtDgvPrivate().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (データなし)
        /// </summary>
        [Test]
        public void DgvPrivateWithCountWithEmptyData()
        {
            ShowFormMain(DB_EMPTY, TAB_IDX);

            Assert.AreEqual(0, CtDgvPrivate().Rows.Count);
        }

        /// <summary>
        /// 年月のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithDate()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual("2009-04", dgvPrivate.Rows[0].Cells[COL.PRIVATE.DATE].Value);
            Assert.AreEqual("2009-05", dgvPrivate.Rows[1].Cells[COL.PRIVATE.DATE].Value);
            Assert.AreEqual("2010-06", dgvPrivate.Rows[2].Cells[COL.PRIVATE.DATE].Value);
            Assert.AreEqual("2010-07", dgvPrivate.Rows[3].Cells[COL.PRIVATE.DATE].Value);
            Assert.AreEqual("2011-08", dgvPrivate.Rows[4].Cells[COL.PRIVATE.DATE].Value);
            Assert.AreEqual("2011-09", dgvPrivate.Rows[5].Cells[COL.PRIVATE.DATE].Value);
            Assert.AreEqual("2012-10", dgvPrivate.Rows[6].Cells[COL.PRIVATE.DATE].Value);
            Assert.AreEqual("2012-11", dgvPrivate.Rows[7].Cells[COL.PRIVATE.DATE].Value);
        }

        /// <summary>
        /// 名称のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithName()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual("private01", dgvPrivate.Rows[0].Cells[COL.PRIVATE.NAME].Value);
            Assert.AreEqual("private02", dgvPrivate.Rows[1].Cells[COL.PRIVATE.NAME].Value);
            Assert.AreEqual("private03", dgvPrivate.Rows[2].Cells[COL.PRIVATE.NAME].Value);
            Assert.AreEqual("private04", dgvPrivate.Rows[3].Cells[COL.PRIVATE.NAME].Value);
            Assert.AreEqual("private05", dgvPrivate.Rows[4].Cells[COL.PRIVATE.NAME].Value);
            Assert.AreEqual("private06", dgvPrivate.Rows[5].Cells[COL.PRIVATE.NAME].Value);
            Assert.AreEqual("private07", dgvPrivate.Rows[6].Cells[COL.PRIVATE.NAME].Value);
            Assert.AreEqual("private08", dgvPrivate.Rows[7].Cells[COL.PRIVATE.NAME].Value);
        }

        /// <summary>
        /// 金額のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithCost()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual( 10000, dgvPrivate.Rows[0].Cells[COL.PRIVATE.COST].Value);
            Assert.AreEqual( 20000, dgvPrivate.Rows[1].Cells[COL.PRIVATE.COST].Value);
            Assert.AreEqual( 30000, dgvPrivate.Rows[2].Cells[COL.PRIVATE.COST].Value);
            Assert.AreEqual(-40000, dgvPrivate.Rows[3].Cells[COL.PRIVATE.COST].Value);
            Assert.AreEqual( 50000, dgvPrivate.Rows[4].Cells[COL.PRIVATE.COST].Value);
            Assert.AreEqual( 60000, dgvPrivate.Rows[5].Cells[COL.PRIVATE.COST].Value);
            Assert.AreEqual( 70000, dgvPrivate.Rows[6].Cells[COL.PRIVATE.COST].Value);
            Assert.AreEqual(-80000, dgvPrivate.Rows[7].Cells[COL.PRIVATE.COST].Value);
        }

        /// <summary>
        /// 収支のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithBalance()
        {
            ShowFormMain(DB_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual( 10000, dgvPrivate.Rows[0].Cells[COL.PRIVATE.BLNC].Value);
            Assert.AreEqual( 30000, dgvPrivate.Rows[1].Cells[COL.PRIVATE.BLNC].Value);
            Assert.AreEqual( 60000, dgvPrivate.Rows[2].Cells[COL.PRIVATE.BLNC].Value);
            Assert.AreEqual( 20000, dgvPrivate.Rows[3].Cells[COL.PRIVATE.BLNC].Value);
            Assert.AreEqual( 70000, dgvPrivate.Rows[4].Cells[COL.PRIVATE.BLNC].Value);
            Assert.AreEqual(130000, dgvPrivate.Rows[5].Cells[COL.PRIVATE.BLNC].Value);
            Assert.AreEqual(200000, dgvPrivate.Rows[6].Cells[COL.PRIVATE.BLNC].Value);
            Assert.AreEqual(120000, dgvPrivate.Rows[7].Cells[COL.PRIVATE.BLNC].Value);
        }
    }
}
