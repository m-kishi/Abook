// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT  = AbTestTool;
    using EX  = Abook.AbException.EX;
    using CSV = Abook.AbConstants.CSV;

    /// <summary>
    /// メイン画面フォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestFormMain : AbTestFormBase
    {
        /// <summary>CSVファイル</summary>
        private const string CSV_EMPTY = "AbTestFormMainEmpty.db";
        /// <summary>CSVファイル</summary>
        private const string CSV_INVALID = "AbTestFormMainInvalid.db";

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(CSV_INVALID, false, CSV.ENCODING))
            {
                sw.WriteLine(TT.ToCSV("2012-01-01", "name1", "食費", "10000"));
                sw.WriteLine(TT.ToCSV("2012-02-30", "name2", "食費", "20000"));
                sw.WriteLine(TT.ToCSV("2012-03-05", "name3", "食費", "30000"));
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (File.Exists(CSV_EMPTY  )) File.Delete(CSV_EMPTY);
            if (File.Exists(CSV_INVALID)) File.Delete(CSV_INVALID);
        }

        /// <summary>
        /// Loadテスト
        /// </summary>
        [Test]
        public void Load()
        {
            ShowFormMain(CSV_EMPTY);
            Assert.IsTrue(CtAbFormMain().Visible);
        }

        /// <summary>
        /// Loadテスト
        /// 日付の形式が不正
        /// </summary>
        [Test]
        public void LoadWithInvalidDB()
        {
            // ダイアログの表示テスト
            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                // タイトルテスト
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                // テキストテスト
                var text = string.Format(EX.CSV_LOAD, 2, EX.DATE_FORMAT);
                Assert.AreEqual(text, tsMessageBox.Text);

                // OKボタンクリック
                tsMessageBox.ClickOk();
            };
            ShowFormMain(CSV_INVALID);
        }
    }
}
