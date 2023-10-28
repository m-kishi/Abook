// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT  = AbTestTool;
    using EX  = Abook.AbException.EX;
    using CSV = Abook.AbConstants.CSV;

    /// <summary>
    /// メニューテスト
    /// </summary>
    [TestFixture]
    public class AbTestMenu : AbTestFormBase
    {
        /// <summary>CSVファイル</summary>
        private const string CSV_FILE = "AbTestMenu.db";

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            using (var sw = new StreamWriter(CSV_FILE, false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine(TT.ToCSV("2014-11-01", "おにぎり", "食費", "108"));
                sw.Close();
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (File.Exists(CSV_FILE)) File.Delete(CSV_FILE);
        }

        /// <summary>
        /// 終了メニュークリック
        /// </summary>
        [Test]
        public void MenuExitClick()
        {
            ShowFormMain(CSV_FILE);

            TsMenuExit().Click();

            Assert.IsTrue(form.IsDisposed);
        }

        /// <summary>
        /// バージョン情報メニュークリック
        /// </summary>
        [Test]
        public void MenuVersionClick()
        {
            // バージョン情報フォームの表示テスト
            ModalFormHandler = (name, hWnd, form) =>
            {
                // フォーム名テスト
                Assert.AreEqual(name, "AbFormVersion");

                // テスト環境でアセンブリ情報の取得は不可
                Assert.IsNull(System.Reflection.Assembly.GetEntryAssembly());

                // OKボタンクリック
                (new ButtonTester("BtnOK", form)).Click();
            };

            ShowFormMain(CSV_FILE);

            TsMenuVersion().Click();
        }

        /// <summary>
        /// 光熱費メニュークリック
        /// </summary>
        [Test]
        public void MenuEnergyClick()
        {
            // 光熱費サブフォームが表示される
            ModalFormHandler = (name, hWnd, form) =>
            {
                // フォーム名テスト
                Assert.AreEqual(name, "AbSubEnergy");

                // 閉じる
                form.Close();
            };

            ShowFormMain(CSV_FILE);

            TsMenuEnergy().Click();
        }
    }
}
