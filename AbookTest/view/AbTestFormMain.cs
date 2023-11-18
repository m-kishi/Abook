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
    using TT = AbTestTool;
    using EX = Abook.AbException.EX;
    using DB = Abook.AbConstants.DB;

    /// <summary>
    /// メイン画面フォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestFormMain : AbTestFormBase
    {
        /// <summary>DBファイル</summary>
        private const string DB_FILE_EMPTY = "AbTestFormMainEmpty.db";
        /// <summary>DBファイル</summary>
        private const string DB_FILE_INVALID = "AbTestFormMainInvalid.db";

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_FILE_INVALID, false, DB.ENCODING))
            {
                sw.WriteLine(TT.ToDBFileFormat("2012-01-01", "name1", "食費", "10000"));
                sw.WriteLine(TT.ToDBFileFormat("2012-02-30", "name2", "食費", "20000"));
                sw.WriteLine(TT.ToDBFileFormat("2012-03-05", "name3", "食費", "30000"));
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (File.Exists(DB_FILE_EMPTY  )) File.Delete(DB_FILE_EMPTY);
            if (File.Exists(DB_FILE_INVALID)) File.Delete(DB_FILE_INVALID);
        }

        /// <summary>
        /// Loadテスト
        /// </summary>
        [Test]
        public void Load()
        {
            ShowFormMain(DB_FILE_EMPTY);
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
                var text = string.Format(EX.DB_FILE_LOAD, 2, EX.DATE_FORMAT);
                Assert.AreEqual(text, tsMessageBox.Text);

                // OKボタンクリック
                tsMessageBox.ClickOk();
            };
            ShowFormMain(DB_FILE_INVALID);
        }
    }
}
