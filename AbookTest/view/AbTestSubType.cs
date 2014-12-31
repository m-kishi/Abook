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
    /// 種別明細サブフォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestSubType : NUnitFormTest
    {
        /// <summary>CSVファイル</summary>
        private const string CSV_EMPTY = "AbTestSubTypeEmpty.db";
        /// <summary>CSVファイル</summary>
        private const string CSV_EXIST = "AbTestSubTypeExist.db";

        /// <summary>対象:種別明細サブ</summary>
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
                //すでに閉じられている
            }
            base.TearDown();
        }

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(CSV_EXIST, false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine(ToCSV("2014-02-26", "name01", TYPE.FOOD, "1000"));
                sw.WriteLine(ToCSV("2014-02-27", "name02", TYPE.OTFD, "1100"));
                sw.WriteLine(ToCSV("2014-02-28", "name03", TYPE.GOOD, "1200"));
                sw.WriteLine(ToCSV("2014-03-01", "name04", TYPE.FOOD, "1300"));
                sw.WriteLine(ToCSV("2014-03-02", "name05", TYPE.OTFD, "1400"));
                sw.WriteLine(ToCSV("2014-03-03", "name06", TYPE.GOOD, "1500"));
                sw.WriteLine(ToCSV("2014-03-28", "name07", TYPE.FOOD, "1600"));
                sw.WriteLine(ToCSV("2014-03-29", "name08", TYPE.OTFD, "1700"));
                sw.WriteLine(ToCSV("2014-03-30", "name09", TYPE.GOOD, "1800"));
                sw.WriteLine(ToCSV("2014-03-31", "name10", TYPE.FOOD, "1900"));
                sw.WriteLine(ToCSV("2014-04-01", "name11", TYPE.FOOD, "2000"));
                sw.WriteLine(ToCSV("2014-04-02", "name12", TYPE.OTFD, "2100"));
                sw.WriteLine(ToCSV("2014-04-03", "name13", TYPE.GOOD, "2200"));
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (System.IO.File.Exists(CSV_EMPTY)) System.IO.File.Delete(CSV_EMPTY);
            if (System.IO.File.Exists(CSV_EXIST)) System.IO.File.Delete(CSV_EXIST);
        }

        /// <summary>
        /// 支出情報CSV生成
        /// (AbTestFormBaseと重複:Formが増えるならDRY検討)
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="name">名前</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        /// <returns>支出情報CSV</returns>
        protected string ToCSV(string date, string name, string type, string cost)
        {
            const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\"";
            return string.Format(TEMPLATE, date, name, type, cost);
        }

        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="csv">CSVファイル</param>
        protected void ShowSubType(string csv)
        {
            var parent = new AbFormMain(csv);
            var current = new DateTime(2014, 3, 1);

            form = new AbSubType(parent, TYPE.FOOD, current);
            form.Show();
        }

        /// <summary>
        /// 種別明細サブフォーム取得
        /// </summary>
        /// <returns>種別明細サブフォームフォーム</returns>
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
            ShowSubType(CSV_EMPTY);
            Assert.IsTrue(CtAbSubType().Visible);
        }

        /// <summary>
        /// タイトルテスト
        /// </summary>
        [Test]
        public void LoadWithTypeName()
        {
            ShowSubType(CSV_EMPTY);
            Assert.AreEqual(TYPE.FOOD, form.Text);
        }

        /// <summary>
        /// レコード数のテスト
        /// </summary>
        [Test]
        public void DgvExpenseWithCount()
        {
            ShowSubType(CSV_EXIST);

            Assert.AreEqual(3, CtDgvExpense().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (データなし)
        /// </summary>
        [Test]
        public void DgvExpenseWithCountWithEmptyData()
        {
            ShowSubType(CSV_EMPTY);

            Assert.AreEqual(0, CtDgvExpense().Rows.Count);
        }

        /// <summary>
        /// レコード数のテスト
        /// (日付範囲外)
        /// </summary>
        [Test]
        public void DgvExpenseWithCountWithOutOfDate()
        {
            var parent = new AbFormMain(CSV_EXIST);
            var current = new DateTime(2014, 5, 1);

            form = new AbSubType(parent, TYPE.FOOD, current);
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
            var parent = new AbFormMain(CSV_EXIST);
            var current = new DateTime(2014, 3, 1);

            form = new AbSubType(parent, TYPE.HOUS, current);
            form.Show();

            Assert.AreEqual(0, CtDgvExpense().Rows.Count);
        }

        /// <summary>
        /// 日付のテスト
        /// </summary>
        [Test]
        public void DgvExpenseWithDate()
        {
            ShowSubType(CSV_EXIST);

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
            ShowSubType(CSV_EXIST);

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
            ShowSubType(CSV_EXIST);

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
            ShowSubType(CSV_EXIST);

            var dgvExpense = CtDgvExpense();
            Assert.AreEqual(1300, dgvExpense.Rows[0].Cells[COL.COST].Value);
            Assert.AreEqual(1600, dgvExpense.Rows[1].Cells[COL.COST].Value);
            Assert.AreEqual(1900, dgvExpense.Rows[2].Cells[COL.COST].Value);
        }
    }
}
