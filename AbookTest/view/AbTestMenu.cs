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
    public class AbTestMenu : NUnitFormTest
    {
        /// <summary>引数:DB ファイル</summary>
        private string argDB = "AbTestMenu.db";
        /// <summary>対象:メイン画面フォーム</summary>
        private AbFormMain abFormMain;

        /// <summary>
        /// Setup
        /// </summary>
        public override void Setup()
        {
            base.Setup();
            abFormMain = new AbFormMain(argDB);
            abFormMain.Show();
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
            finally
            {
                if (System.IO.File.Exists(argDB))
                {
                    System.IO.File.Delete(argDB);
                }
            }
            base.TearDown();
        }

        /// <summary>
        /// 終了メニュークリック
        /// </summary>
        [Test]
        public void MenuExitClick()
        {
            var menuExit = new ToolStripMenuItemTester("MenuExit", abFormMain);
            menuExit.Click();

            Assert.IsTrue(abFormMain.IsDisposed);
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
                Assert.AreEqual(name, "AbFormVersion");

                //アセンブリ情報の取得は不可
                var assembly = System.Reflection.Assembly.GetEntryAssembly();
                Assert.IsNull(assembly);

                var btnOK = new ButtonTester("BtnOK", form);
                btnOK.Click();
            };
            var menuVersion = new ToolStripMenuItemTester("MenuVersion", abFormMain);
            menuVersion.Click();
        }
    }
}
