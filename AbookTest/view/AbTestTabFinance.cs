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
    using COL  = Abook.AbConstants.COL.FINANCE;
    using DGV  = Abook.AbConstants.DGV;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 投資タブテスト
    /// </summary>
    [TestFixture]
    public class AbTestTabFinance : AbTestFormBase
    {
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EXIST = "AbTestTabFinanceExist.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EMPTY = "AbTestTabFinanceEmpty.db";
        /// <summary>タブインデックス</summary>
        private const int TAB_IDX = 5;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_FILE_EXIST, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2024-01-10", "finance01", TYPE.FNCE, "100000"));
                sw.WriteLine(TT.ToDBFileFormat("2024-01-20", "finance02", TYPE.FNCE, "100001"));
                sw.WriteLine(TT.ToDBFileFormat("2024-01-31", "dummy    ", TYPE.FOOD, "999999"));
                sw.WriteLine(TT.ToDBFileFormat("2024-02-20", "finance03", TYPE.FNCE, "100002"));
                sw.WriteLine(TT.ToDBFileFormat("2024-03-20", "finance04", TYPE.FNCE, "100003"));
                sw.WriteLine(TT.ToDBFileFormat("2024-04-20", "finance05", TYPE.FNCE, "100004"));
                sw.WriteLine(TT.ToDBFileFormat("2024-05-20", "finance06", TYPE.FNCE, "100005"));
                sw.WriteLine(TT.ToDBFileFormat("2024-06-20", "finance07", TYPE.FNCE, "100006"));
                sw.WriteLine(TT.ToDBFileFormat("2024-07-20", "finance08", TYPE.FNCE, "100007"));
                sw.WriteLine(TT.ToDBFileFormat("2024-08-20", "finance09", TYPE.FNCE, "100008"));
                sw.WriteLine(TT.ToDBFileFormat("2024-09-20", "finance10", TYPE.FNCE, "100009"));
                sw.WriteLine(TT.ToDBFileFormat("2024-10-20", "finance11", TYPE.FNCE, "100010"));
                sw.WriteLine(TT.ToDBFileFormat("2024-11-20", "finance12", TYPE.FNCE, "100011"));
                sw.WriteLine(TT.ToDBFileFormat("2024-12-20", "finance13", TYPE.FNCE, "100012", "note12"));
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
        public void DgvFinanceWithCount()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);
            Assert.AreEqual(13, CtDgvFinance().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (データなし)
        /// </summary>
        [Test]
        public void DgvFinanceWithCountWithEmptyData()
        {
            ShowFormMain(DB_FILE_EMPTY, TAB_IDX);
            Assert.AreEqual(0, CtDgvFinance().Rows.Count);
        }

        /// <summary>
        /// DataGridView
        /// セル選択位置のテスト
        /// </summary>
        [Test]
        public void DgvFinanceWithSelection()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            var row = dgvFinance.SelectedRows[0];
            var cell = dgvFinance.Rows[dgvFinance.Rows.Count - 1].Cells[COL.TTAL];

            Assert.True(row.Selected);
            Assert.True(cell.Selected);
            Assert.AreEqual(12, row.Index);
            Assert.AreEqual(1, dgvFinance.SelectedRows.Count);
        }

        /// <summary>
        /// DataGridView
        /// スクロールバーのテスト
        /// </summary>
        [Ignore]
        public void DgvFinanceWithScrollBar()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            var row = dgvFinance.SelectedRows[0];

            // テストデータではスクロールが発生しないので手動確認することにして無視
            Assert.AreEqual(dgvFinance.FirstDisplayedCell.RowIndex, row.Index - 9);
        }

        /// <summary>
        /// 日付のテスト
        /// </summary>
        [Test]
        public void DgvFinanceWithDate()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            Assert.AreEqual("2024-01-10", dgvFinance.Rows[ 0].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-01-20", dgvFinance.Rows[ 1].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-02-20", dgvFinance.Rows[ 2].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-03-20", dgvFinance.Rows[ 3].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-04-20", dgvFinance.Rows[ 4].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-05-20", dgvFinance.Rows[ 5].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-06-20", dgvFinance.Rows[ 6].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-07-20", dgvFinance.Rows[ 7].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-08-20", dgvFinance.Rows[ 8].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-09-20", dgvFinance.Rows[ 9].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-10-20", dgvFinance.Rows[10].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-11-20", dgvFinance.Rows[11].Cells[COL.DATE].Value);
            Assert.AreEqual("2024-12-20", dgvFinance.Rows[12].Cells[COL.DATE].Value);
        }

        /// <summary>
        /// 名称のテスト
        /// </summary>
        [Test]
        public void DgvFinanceWithName()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            Assert.AreEqual("finance01", dgvFinance.Rows[ 0].Cells[COL.NAME].Value);
            Assert.AreEqual("finance02", dgvFinance.Rows[ 1].Cells[COL.NAME].Value);
            Assert.AreEqual("finance03", dgvFinance.Rows[ 2].Cells[COL.NAME].Value);
            Assert.AreEqual("finance04", dgvFinance.Rows[ 3].Cells[COL.NAME].Value);
            Assert.AreEqual("finance05", dgvFinance.Rows[ 4].Cells[COL.NAME].Value);
            Assert.AreEqual("finance06", dgvFinance.Rows[ 5].Cells[COL.NAME].Value);
            Assert.AreEqual("finance07", dgvFinance.Rows[ 6].Cells[COL.NAME].Value);
            Assert.AreEqual("finance08", dgvFinance.Rows[ 7].Cells[COL.NAME].Value);
            Assert.AreEqual("finance09", dgvFinance.Rows[ 8].Cells[COL.NAME].Value);
            Assert.AreEqual("finance10", dgvFinance.Rows[ 9].Cells[COL.NAME].Value);
            Assert.AreEqual("finance11", dgvFinance.Rows[10].Cells[COL.NAME].Value);
            Assert.AreEqual("finance12", dgvFinance.Rows[11].Cells[COL.NAME].Value);
            Assert.AreEqual("finance13", dgvFinance.Rows[12].Cells[COL.NAME].Value);
        }

        /// <summary>
        /// 金額のテスト
        /// </summary>
        [Test]
        public void DgvFinanceWithCost()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            Assert.AreEqual(100000, dgvFinance.Rows[ 0].Cells[COL.COST].Value);
            Assert.AreEqual(100001, dgvFinance.Rows[ 1].Cells[COL.COST].Value);
            Assert.AreEqual(100002, dgvFinance.Rows[ 2].Cells[COL.COST].Value);
            Assert.AreEqual(100003, dgvFinance.Rows[ 3].Cells[COL.COST].Value);
            Assert.AreEqual(100004, dgvFinance.Rows[ 4].Cells[COL.COST].Value);
            Assert.AreEqual(100005, dgvFinance.Rows[ 5].Cells[COL.COST].Value);
            Assert.AreEqual(100006, dgvFinance.Rows[ 6].Cells[COL.COST].Value);
            Assert.AreEqual(100007, dgvFinance.Rows[ 7].Cells[COL.COST].Value);
            Assert.AreEqual(100008, dgvFinance.Rows[ 8].Cells[COL.COST].Value);
            Assert.AreEqual(100009, dgvFinance.Rows[ 9].Cells[COL.COST].Value);
            Assert.AreEqual(100010, dgvFinance.Rows[10].Cells[COL.COST].Value);
            Assert.AreEqual(100011, dgvFinance.Rows[11].Cells[COL.COST].Value);
            Assert.AreEqual(100012, dgvFinance.Rows[12].Cells[COL.COST].Value);
        }

        /// <summary>
        /// 備考のテスト
        /// </summary>
        [Test]
        public void DgvFinanceWithNote()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            Assert.AreEqual("", dgvFinance.Rows[ 0].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 1].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 2].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 3].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 4].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 5].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 6].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 7].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 8].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[ 9].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[10].Cells[COL.NOTE].Value);
            Assert.AreEqual("", dgvFinance.Rows[11].Cells[COL.NOTE].Value);
            Assert.AreEqual("note12", dgvFinance.Rows[12].Cells[COL.NOTE].Value);
        }

        /// <summary>
        /// ツールチップのテスト
        /// </summary>
        [Test]
        public void DgvFinanceWithToolTip()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            Assert.AreEqual("", dgvFinance.Rows[ 0].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 1].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 2].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 3].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 4].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 5].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 6].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 7].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 8].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[ 9].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[10].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("", dgvFinance.Rows[11].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual("note12", dgvFinance.Rows[12].Cells[COL.NAME].ToolTipText);
        }

        /// <summary>
        /// 備考の背景色のテスト
        /// </summary>
        [Test]
        public void DgvFinanceWithNoteBackgroundColor()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 0].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 1].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 2].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 3].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 4].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 5].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 6].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 7].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 8].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[ 9].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[10].DefaultCellStyle.BackColor);
            Assert.AreEqual(Color.Empty, dgvFinance.Rows[11].DefaultCellStyle.BackColor);
            Assert.AreEqual(DGV.NOTE_BG_COLOR, dgvFinance.Rows[12].DefaultCellStyle.BackColor);
        }

        /// <summary>
        /// 収支のテスト
        /// </summary>
        [Test]
        public void DgvFinanceWithBalance()
        {
            ShowFormMain(DB_FILE_EXIST, TAB_IDX);

            var dgvFinance = CtDgvFinance();
            Assert.AreEqual( 100000, dgvFinance.Rows[ 0].Cells[COL.TTAL].Value);
            Assert.AreEqual( 200001, dgvFinance.Rows[ 1].Cells[COL.TTAL].Value);
            Assert.AreEqual( 300003, dgvFinance.Rows[ 2].Cells[COL.TTAL].Value);
            Assert.AreEqual( 400006, dgvFinance.Rows[ 3].Cells[COL.TTAL].Value);
            Assert.AreEqual( 500010, dgvFinance.Rows[ 4].Cells[COL.TTAL].Value);
            Assert.AreEqual( 600015, dgvFinance.Rows[ 5].Cells[COL.TTAL].Value);
            Assert.AreEqual( 700021, dgvFinance.Rows[ 6].Cells[COL.TTAL].Value);
            Assert.AreEqual( 800028, dgvFinance.Rows[ 7].Cells[COL.TTAL].Value);
            Assert.AreEqual( 900036, dgvFinance.Rows[ 8].Cells[COL.TTAL].Value);
            Assert.AreEqual(1000045, dgvFinance.Rows[ 9].Cells[COL.TTAL].Value);
            Assert.AreEqual(1100055, dgvFinance.Rows[10].Cells[COL.TTAL].Value);
            Assert.AreEqual(1200066, dgvFinance.Rows[11].Cells[COL.TTAL].Value);
            Assert.AreEqual(1300078, dgvFinance.Rows[12].Cells[COL.TTAL].Value);
        }
    }
}
