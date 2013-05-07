namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using EX = Abook.AbException.EX;

    /// <summary>
    /// メイン画面フォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestFormMain : AbTestFormBase
    {
        /// <summary>DB ファイル</summary>
        private const string DB_EMPTY = "AbTestFormMainEmpty.db";
        /// <summary>DB ファイル</summary>
        private const string DB_INVALID = "AbTestFormMainInvalid.db";

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (StreamWriter sw = new StreamWriter(DB_INVALID, false, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(ToCSV("2012-01-01", "name1", "食費", "10000"));
                sw.WriteLine(ToCSV("2012-02-30", "name2", "食費", "20000"));
                sw.WriteLine(ToCSV("2012-03-05", "name3", "食費", "30000"));
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (System.IO.File.Exists(DB_EMPTY  )) System.IO.File.Delete(DB_EMPTY);
            if (System.IO.File.Exists(DB_INVALID)) System.IO.File.Delete(DB_INVALID);
        }

        /// <summary>
        /// Load テスト
        /// </summary>
        [Test]
        public void Load()
        {
            ShowFormMain(DB_EMPTY);
            Assert.IsTrue(CtAbFormMain().Visible);
        }

        /// <summary>
        /// Load テスト
        /// 日付の形式が不正
        /// </summary>
        [Test]
        public void LoadWithInvalidDB()
        {
            //ダイアログの表示テスト
            // Load イベント中でダイアログを表示させている場合、NUnitで検証不可 -> AssertするとNUnitが落ちる？
            // => Assert が成功する場合は落ちないのかも...
            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトルテスト
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキストテスト
                var text = string.Format(EX.DB_LOAD, 2, EX.DATE_FORMAT);
                Assert.AreEqual(text, tsMessageBox.Text);

                // OK ボタンクリック
                tsMessageBox.ClickOk();
            };
            ShowFormMain(DB_INVALID);
        }
    }
}
