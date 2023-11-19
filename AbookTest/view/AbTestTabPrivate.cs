// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using System.Drawing;
    using System.IO;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT   = AbTestTool;
    using DB   = Abook.AbConstants.DB;
    using COL  = Abook.AbConstants.COL.PRIVATE;
    using DGV  = Abook.AbConstants.DGV;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 秘密タブテスト
    /// </summary>
    [TestFixture]
    public class AbTestTabPrivate : AbTestFormBase
    {
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EXIST = "AbTestTabPrivateExist.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EMPTY = "AbTestTabPrivateEmpty.db";
        /// <summary>タブインデックス</summary>
        private const int TAB_IDX = 4;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_FILE_EXIST, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2009-04-01", "private01", TYPE.PRVI, "10000"));
                sw.WriteLine(TT.ToDBFileFormat("2009-05-01", "private02", TYPE.PRVI, "20000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-06-01", "private03", TYPE.PRVI, "30000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-06-30", "dummy"    , TYPE.FOOD, "35000"));
                sw.WriteLine(TT.ToDBFileFormat("2010-07-01", "private04", TYPE.PRVO, "40000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-08-01", "private05", TYPE.PRVI, "50000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-09-01", "private06", TYPE.PRVI, "60000"));
                sw.WriteLine(TT.ToDBFileFormat("2011-09-30", "dummy"    , TYPE.SPCL, "65000"));
                sw.WriteLine(TT.ToDBFileFormat("2012-10-01", "private07", TYPE.PRVI, "70000"));
                sw.WriteLine(TT.ToDBFileFormat("2012-11-01", "private08", TYPE.PRVO, "80000", "note08"));
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
        public void DgvPrivateWithCount()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);
            Assert.AreEqual(8, CtDgvPrivate().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (データなし)
        /// </summary>
        [Test]
        public void DgvPrivateWithCountWithEmptyData()
        {
            ShowFormMain(DB_FILE_EMPTY, TAB_IDX);
            Assert.AreEqual(0, CtDgvPrivate().Rows.Count);
        }

        /// <summary>
        /// DataGridView
        /// セル選択位置のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithSelection()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            var row = dgvPrivate.SelectedRows[0];
            var cell = dgvPrivate.Rows[dgvPrivate.Rows.Count - 1].Cells[COL.BLNC];

            Assert.True(row.Selected);
            Assert.True(cell.Selected);
            Assert.AreEqual(7, row.Index);
            Assert.AreEqual(1, dgvPrivate.SelectedRows.Count);
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
        /// 年月のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithDate()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual("2009-04", dgvPrivate.Rows[0].Cells[COL.DATE].Value);
            Assert.AreEqual("2009-05", dgvPrivate.Rows[1].Cells[COL.DATE].Value);
            Assert.AreEqual("2010-06", dgvPrivate.Rows[2].Cells[COL.DATE].Value);
            Assert.AreEqual("2010-07", dgvPrivate.Rows[3].Cells[COL.DATE].Value);
            Assert.AreEqual("2011-08", dgvPrivate.Rows[4].Cells[COL.DATE].Value);
            Assert.AreEqual("2011-09", dgvPrivate.Rows[5].Cells[COL.DATE].Value);
            Assert.AreEqual("2012-10", dgvPrivate.Rows[6].Cells[COL.DATE].Value);
            Assert.AreEqual("2012-11", dgvPrivate.Rows[7].Cells[COL.DATE].Value);
        }

        /// <summary>
        /// 名称のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithName()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual("private01", dgvPrivate.Rows[0].Cells[COL.NAME].Value);
            Assert.AreEqual("private02", dgvPrivate.Rows[1].Cells[COL.NAME].Value);
            Assert.AreEqual("private03", dgvPrivate.Rows[2].Cells[COL.NAME].Value);
            Assert.AreEqual("private04", dgvPrivate.Rows[3].Cells[COL.NAME].Value);
            Assert.AreEqual("private05", dgvPrivate.Rows[4].Cells[COL.NAME].Value);
            Assert.AreEqual("private06", dgvPrivate.Rows[5].Cells[COL.NAME].Value);
            Assert.AreEqual("private07", dgvPrivate.Rows[6].Cells[COL.NAME].Value);
            Assert.AreEqual("private08", dgvPrivate.Rows[7].Cells[COL.NAME].Value);
        }

        /// <summary>
        /// 金額のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithCost()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual( 10000, dgvPrivate.Rows[0].Cells[COL.COST].Value);
            Assert.AreEqual( 20000, dgvPrivate.Rows[1].Cells[COL.COST].Value);
            Assert.AreEqual( 30000, dgvPrivate.Rows[2].Cells[COL.COST].Value);
            Assert.AreEqual(-40000, dgvPrivate.Rows[3].Cells[COL.COST].Value);
            Assert.AreEqual( 50000, dgvPrivate.Rows[4].Cells[COL.COST].Value);
            Assert.AreEqual( 60000, dgvPrivate.Rows[5].Cells[COL.COST].Value);
            Assert.AreEqual( 70000, dgvPrivate.Rows[6].Cells[COL.COST].Value);
            Assert.AreEqual(-80000, dgvPrivate.Rows[7].Cells[COL.COST].Value);
        }

        /// <summary>
        /// 備考のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithNote()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual("", dgvPrivate.Rows[0].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvPrivate.Rows[1].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvPrivate.Rows[2].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvPrivate.Rows[3].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvPrivate.Rows[4].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvPrivate.Rows[5].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvPrivate.Rows[6].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("note08", dgvPrivate.Rows[7].Cells[COL.NAME].ToolTipText);
        }

        /// <summary>
        /// 備考の背景色のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithNoteBackgroundColor()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual(Color.Empty, dgvPrivate.Rows[0].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvPrivate.Rows[1].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvPrivate.Rows[2].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvPrivate.Rows[3].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvPrivate.Rows[4].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvPrivate.Rows[5].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvPrivate.Rows[6].DefaultCellStyle.BackColor);
            Assert.AreEqual(DGV.NOTE_BG_COLOR, dgvPrivate.Rows[7].DefaultCellStyle.BackColor);
        }

        /// <summary>
        /// 収支のテスト
        /// </summary>
        [Test]
        public void DgvPrivateWithBalance()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvPrivate = CtDgvPrivate();
            Assert.AreEqual( 10000, dgvPrivate.Rows[0].Cells[COL.BLNC].Value);
            Assert.AreEqual( 30000, dgvPrivate.Rows[1].Cells[COL.BLNC].Value);
            Assert.AreEqual( 60000, dgvPrivate.Rows[2].Cells[COL.BLNC].Value);
            Assert.AreEqual( 20000, dgvPrivate.Rows[3].Cells[COL.BLNC].Value);
            Assert.AreEqual( 70000, dgvPrivate.Rows[4].Cells[COL.BLNC].Value);
            Assert.AreEqual(130000, dgvPrivate.Rows[5].Cells[COL.BLNC].Value);
            Assert.AreEqual(200000, dgvPrivate.Rows[6].Cells[COL.BLNC].Value);
            Assert.AreEqual(120000, dgvPrivate.Rows[7].Cells[COL.BLNC].Value);
        }
    }
}
