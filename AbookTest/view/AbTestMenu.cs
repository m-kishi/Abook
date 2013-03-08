namespace AbookTest
{
    using Abook;
    using System;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;

    /// <summary>
    /// メニューテスト
    /// </summary>
    [TestFixture]
    public class AbTestMenu : AbTestFormBase
    {
        /// <summary>DB ファイル</summary>
        private const string DB = "AbTestMenu.db";

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            if (System.IO.File.Exists(DB)) System.IO.File.Delete(DB);
        }

        /// <summary>
        /// 終了メニュークリック
        /// </summary>
        [Test]
        public void MenuExitClick()
        {
            ShowFormMain(DB);

            TsMenuExit().Click();

            Assert.IsTrue(this.form.IsDisposed);
        }

        /// <summary>
        /// バージョン情報メニュークリック
        /// </summary>
        [Test]
        public void MenuVersionClick()
        {
            //バージョン情報フォームの表示テスト
            ModalFormHandler = (name, hWnd, form) =>
            {
                //フォーム名テスト
                Assert.AreEqual(name, "AbFormVersion");

                //テスト環境でアセンブリ情報の取得は不可
                Assert.IsNull(System.Reflection.Assembly.GetEntryAssembly());

                // OK ボタンクリック
                (new ButtonTester("BtnOK", form)).Click();
            };

            ShowFormMain(DB);

            TsMenuVersion().Click();
        }
    }
}
