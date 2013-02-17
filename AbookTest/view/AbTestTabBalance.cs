namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using COL  = Abook.AbConstants.COL;
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 収支タブテスト
    /// </summary>
    [TestFixture]
    public class AbTestTabBalance : NUnitFormTest
    {
        /// <summary>引数:DB ファイル</summary>
        private string argDB = "AbTestTabBalance.db";
        /// <summary>対象:メイン画面フォーム</summary>
        private AbFormMain abFormMain;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(argDB, false, System.Text.Encoding.UTF8))
            {
                var date = new DateTime(2009, 4, 1);
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 800000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 900000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 200000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 350000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  80000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  50000));

                date = new DateTime(2010, 3, 1);
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 200000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 400000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 300000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 250000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  20000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  30000));

                date = new DateTime(2010, 4, 1);
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 600000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 800000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 200000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 250000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  20000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  40000));

                date = new DateTime(2011, 3, 1);
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 300000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN, 700000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 100000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 450000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  60000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  18000));

                date = new DateTime(2011, 4, 1);
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN,      0));
                sw.WriteLine(GenerateWriteLine(date, TYPE.EARN,      0));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 300000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.FOOD, 900000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  80000));
                sw.WriteLine(GenerateWriteLine(date, TYPE.SPCL,  20000));
            }
        }

        /// <summary>
        /// Setup
        /// </summary>
        public override void Setup()
        {
            base.Setup();
            abFormMain = new AbFormMain(argDB);
            abFormMain.Show();

            var tabSummary = new TabControlTester("TabControl", abFormMain);
            tabSummary.SelectTab(3);
        }

        /// <summary>
        /// TearDown
        /// </summary>
        public override void TearDown()
        {
            try
            {
                var finder = new FormFinder();
                var form = finder.Find(typeof(AbFormMain).Name);
                form.Close();
            }
            catch (NoSuchControlException)
            {
                //すでに閉じられている
            }
            base.TearDown();
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (System.IO.File.Exists(argDB))
            {
                System.IO.File.Delete(argDB);
            }
        }

        /// <summary>GenerateWriteLine メソッド用テンプレ</summary>
        private const string TEMPLATE = "\"{0}\",\"name\",\"{1}\",\"{2}\"";

        /// <summary>
        /// 出力用レコード文字列生成
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        /// <returns>出力用レコード文字列</returns>
        private string GenerateWriteLine(DateTime date, string type, decimal cost)
        {
            return string.Format(TEMPLATE, date.ToString(FMT.DATE), type, cost);
        }

        /// <summary>
        /// DataGridView 取得
        /// </summary>
        /// <returns>DataGridView</returns>
        private DataGridView GetDgvBalance()
        {
            var finder = new Finder<DataGridView>("DgvBalance", abFormMain);
            return finder.Find();
        }

        /// <summary>
        /// レコード数のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithCount()
        {
            var dgvBalance = GetDgvBalance();
            Assert.AreEqual(4, dgvBalance.Rows.Count);
        }

        /// <summary>
        /// データなしのテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithEmptyData()
        {
            abFormMain.Close();
            abFormMain = new AbFormMain("AbTestTabBalanceWithEmptyData.db");
            abFormMain.Show();

            var tabSummary = new TabControlTester("TabControl", abFormMain);
            tabSummary.SelectTab(3);

            var dgvBalance = GetDgvBalance();
            Assert.AreEqual(0, dgvBalance.Rows.Count);
            System.IO.File.Delete("AbTestTabBalanceWithEmptyData.db");
        }

        /// <summary>
        /// 年度のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithYear()
        {
            var dgvBalance = GetDgvBalance();
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
            var dgvBalance = GetDgvBalance();
            Assert.AreEqual(2300000, dgvBalance.Rows[0].Cells[COL.EARN].Value);
            Assert.AreEqual(2400000, dgvBalance.Rows[1].Cells[COL.EARN].Value);
            Assert.AreEqual(      0, dgvBalance.Rows[2].Cells[COL.EARN].Value);
            Assert.AreEqual(4700000, dgvBalance.Rows[3].Cells[COL.EARN].Value);
        }

        /// <summary>
        /// 支出のテスト
        /// </summary>
        [Test]
        public void DgvBalanceWithExpense()
        {
            var dgvBalance = GetDgvBalance();
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
            var dgvBalance = GetDgvBalance();
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
            var dgvBalance = GetDgvBalance();
            Assert.AreEqual( 1020000, dgvBalance.Rows[0].Cells[COL.BALANCE].Value);
            Assert.AreEqual( 1262000, dgvBalance.Rows[1].Cells[COL.BALANCE].Value);
            Assert.AreEqual(-1300000, dgvBalance.Rows[2].Cells[COL.BALANCE].Value);
            Assert.AreEqual(  982000, dgvBalance.Rows[3].Cells[COL.BALANCE].Value);
        }
    }
}
