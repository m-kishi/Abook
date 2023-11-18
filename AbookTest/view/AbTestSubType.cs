// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT   = AbTestTool;
    using DB   = Abook.AbConstants.DB;
    using COL  = Abook.AbConstants.COL.EXPENSE;
    using DGV  = Abook.AbConstants.DGV;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 種別サブフォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestSubType : NUnitFormTest
    {
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EMPTY = "AbTestSubTypeEmpty.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EXIST = "AbTestSubTypeExist.db";
        /// <summary>対象:種別サブフォーム</summary>
        protected AbSubType form;

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
                CtAbSubType().Close();
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
            using (StreamWriter sw = new StreamWriter(DB_FILE_EXIST, false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine(TT.ToDBFileFormat("2014-02-26", "name01", TYPE.FOOD, "1000"));
                sw.WriteLine(TT.ToDBFileFormat("2014-02-27", "name02", TYPE.OTFD, "1100"));
                sw.WriteLine(TT.ToDBFileFormat("2014-02-28", "name03", TYPE.GOOD, "1200"));
                sw.WriteLine(TT.ToDBFileFormat("2014-03-01", "name04", TYPE.FOOD, "1300"));
                sw.WriteLine(TT.ToDBFileFormat("2014-03-02", "name05", TYPE.OTFD, "1400"));
                sw.WriteLine(TT.ToDBFileFormat("2014-03-03", "name06", TYPE.GOOD, "1500"));
                sw.WriteLine(TT.ToDBFileFormat("2014-03-28", "name07", TYPE.FOOD, "1600"));
                sw.WriteLine(TT.ToDBFileFormat("2014-03-29", "name08", TYPE.OTFD, "1700"));
                sw.WriteLine(TT.ToDBFileFormat("2014-03-30", "name09", TYPE.GOOD, "1800"));
                sw.WriteLine(TT.ToDBFileFormat("2014-03-31", "name10", TYPE.FOOD, "1900"));
                sw.WriteLine(TT.ToDBFileFormat("2014-04-01", "name11", TYPE.FOOD, "2000"));
                sw.WriteLine(TT.ToDBFileFormat("2014-04-02", "name12", TYPE.OTFD, "2100"));
                sw.WriteLine(TT.ToDBFileFormat("2014-04-03", "name13", TYPE.GOOD, "2200"));
                sw.WriteLine(TT.ToDBFileFormat("2020-12-07", "name14", TYPE.FOOD, "2300", "note14"));
                sw.Close();
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (File.Exists(DB_FILE_EMPTY)) File.Delete(DB_FILE_EMPTY);
            if (File.Exists(DB_FILE_EXIST)) File.Delete(DB_FILE_EXIST);
        }

        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="dbFile">DBファイル</param>
        protected void ShowSubType(string dbFile)
        {
            var current = new DateTime(2014, 3, 1);
            var expenses = AbDBManager.Load(dbFile);

            form = new AbSubType(TYPE.FOOD, current, expenses);
            form.Show();
        }

        /// <summary>
        /// 種別サブフォーム取得
        /// </summary>
        /// <returns>種別サブフォーム</returns>
        protected Form CtAbSubType()
        {
            var finder = new FormFinder();
            return finder.Find(typeof(AbSubType).Name);
        }

        /// <summary>
        /// 支出ビュー取得
        /// </summary>
        /// <returns>支出ビュー</returns>
        protected DataGridView CtDgvExpense()
        {
            return (new Finder<DataGridView>("DgvExpense", form).Find());
        }

        /// <summary>
        /// Loadテスト
        /// </summary>
        [Test]
        public void Load()
        {
            ShowSubType(DB_FILE_EMPTY);
            Assert.IsTrue(CtAbSubType().Visible);
        }

        /// <summary>
        /// タイトルテスト
        /// </summary>
        [Test]
        public void LoadWithTypeName()
        {
            ShowSubType(DB_FILE_EMPTY);
            Assert.AreEqual(TYPE.FOOD, form.Text);
        }

        /// <summary>
        /// レコード数のテスト
        /// </summary>
        [Test]
        public void DgvExpenseWithCount()
        {
            ShowSubType(DB_FILE_EXIST);
            Assert.AreEqual(3, CtDgvExpense().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (データなし)
        /// </summary>
        [Test]
        public void DgvExpenseWithCountWithEmptyData()
        {
            ShowSubType(DB_FILE_EMPTY);
            Assert.AreEqual(0, CtDgvExpense().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (日付範囲外)
        /// </summary>
        [Test]
        public void DgvExpenseWithCountWithOutOfDate()
        {
            var current = new DateTime(2014, 5, 1);
            var expenses = AbDBManager.Load(DB_FILE_EXIST);

            form = new AbSubType(TYPE.FOOD, current, expenses);
            form.Show();

            Assert.AreEqual(0, CtDgvExpense().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (種別なし)
        /// </summary>
        [Test]
        public void DgvExpenseWithCountWithEmptyType()
        {
            var current = new DateTime(2014, 3, 1);
            var expenses = AbDBManager.Load(DB_FILE_EXIST);

            form = new AbSubType(TYPE.HOUS, current, expenses);
            form.Show();

            Assert.AreEqual(0, CtDgvExpense().Rows.Count);
        }

        /// <summary>
        /// 日付のテスト
        /// </summary>
        [Test]
        public void DgvExpenseWithDate()
        {
            ShowSubType(DB_FILE_EXIST);

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual("2014-03-01", dgvExpense.Rows[0].Cells[COL.DATE].Value);
            Assert.AreEqual("2014-03-28", dgvExpense.Rows[1].Cells[COL.DATE].Value);
            Assert.AreEqual("2014-03-31", dgvExpense.Rows[2].Cells[COL.DATE].Value);
        }

        /// <summary>
        /// 名称のテスト
        /// </summary>
        [Test]
        public void DgvExpenseWithName()
        {
            ShowSubType(DB_FILE_EXIST);

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual("name04", dgvExpense.Rows[0].Cells[COL.NAME].Value);
            Assert.AreEqual("name07", dgvExpense.Rows[1].Cells[COL.NAME].Value);
            Assert.AreEqual("name10", dgvExpense.Rows[2].Cells[COL.NAME].Value);
        }

        /// <summary>
        /// 種別のテスト
        /// </summary>
        [Test]
        public void DgvExpenseWithType()
        {
            ShowSubType(DB_FILE_EXIST);

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(TYPE.FOOD, dgvExpense.Rows[0].Cells[COL.TYPE].Value);
            Assert.AreEqual(TYPE.FOOD, dgvExpense.Rows[1].Cells[COL.TYPE].Value);
            Assert.AreEqual(TYPE.FOOD, dgvExpense.Rows[2].Cells[COL.TYPE].Value);
        }

        /// <summary>
        /// 金額のテスト
        /// </summary>
        [Test]
        public void DgvExpenseWithCost()
        {
            ShowSubType(DB_FILE_EXIST);

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(1300, dgvExpense.Rows[0].Cells[COL.COST].Value);
            Assert.AreEqual(1600, dgvExpense.Rows[1].Cells[COL.COST].Value);
            Assert.AreEqual(1900, dgvExpense.Rows[2].Cells[COL.COST].Value);
        }

        /// <summary>
        /// 備考のテスト
        /// 備考: あり
        /// </summary>
        [Test]
        public void DgvExpenseWithNote()
        {
            var current = new DateTime(2020, 12, 1);
            var expenses = AbDBManager.Load(DB_FILE_EXIST);

            form = new AbSubType(TYPE.FOOD, current, expenses);
            form.Show();

            Assert.AreEqual("note14", CtDgvExpense().Rows[0].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual(DGV.NOTE_BG_COLOR, CtDgvExpense().Rows[0].DefaultCellStyle.BackColor);
        }

        /// <summary>
        /// 備考のテスト
        /// 備考: なし
        /// </summary>
        [Test]
        public void DgvExpenseWithNoteWithEmpty()
        {
            ShowSubType(DB_FILE_EXIST);

            Assert.AreEqual("", CtDgvExpense().Rows[0].Cells[COL.NAME].ToolTipText);
            Assert.AreEqual(Color.Empty, CtDgvExpense().Rows[0].DefaultCellStyle.BackColor);
        }
    }
}
