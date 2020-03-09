// ------------------------------------------------------------
// © 2010 Masaaki Kishi
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
            AbWebServer.Start();
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
            AbWebServer.Finish();
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
            //バージョン情報フォームの表示テスト
            ModalFormHandler = (name, hWnd, form) =>
            {
                //フォーム名テスト
                Assert.AreEqual(name, "AbFormVersion");

                //テスト環境でアセンブリ情報の取得は不可
                Assert.IsNull(System.Reflection.Assembly.GetEntryAssembly());

                //OKボタンクリック
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
            //光熱費サブフォームが表示される
            ModalFormHandler = (name, hWnd, form) =>
            {
                //フォーム名テスト
                Assert.AreEqual(name, "AbSubEnergy");

                // 閉じる
                form.Close();
            };

            ShowFormMain(CSV_FILE);

            TsMenuEnergy().Click();
        }

        /// <summary>
        /// アップロードメニュークリック
        /// </summary>
        [Test]
        public void MenuUploadClickWithShowSubUpload()
        {
            //アップロードサブフォームが表示される
            ModalFormHandler = (name, hWnd, form) =>
            {
                //フォーム名テスト
                Assert.AreEqual("AbSubUpload", name);

                //キャンセルボタンクリック
                (new ButtonTester("BtnCancel", form)).Click();
            };

            ShowFormMain(CSV_FILE);

            TsMenuUpload().Click();
        }

        /// <summary>
        /// アップロードメニュークリック
        /// アップロード成功
        /// </summary>
        [Test]
        public void MenuUploadClickWithUploadSuccess()
        {
            //アップロードサブフォームが表示される
            ModalFormHandler = (name, hWnd, form) =>
            {
                //アップロード成功ダイアログ
                DialogBoxHandler = (name2, hWnd2) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd2);

                    //タイトル
                    var title = "アップロード";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    //テキスト
                    var text = "成功しました。";
                    Assert.AreEqual(text, tsMessageBox.Text);

                    //OKボタンクリック
                    tsMessageBox.ClickOk();
                };

                Application.DoEvents();

                //フォーム名テスト
                Assert.AreEqual("AbSubUpload", name);

                // メールを入力
                (new TextBoxTester("TxtMail", form)).Enter(AbWebServer.MAIL);

                // パスワードを入力
                (new TextBoxTester("TxtPass", form)).Enter(AbWebServer.PASS);

                //アップロードボタンクリック
                (new ButtonTester("BtnUpload", form)).Click();

            };

            ShowFormMain(CSV_FILE, AbWebServer.URL_LOGIN, AbWebServer.URL_UPLOAD);

            TsMenuUpload().Click();
        }

        /// <summary>
        /// アップロードメニュークリック
        /// アップロード失敗
        /// </summary>
        [Test]
        public void MenuUploadClickWithUploadFailure()
        {
            //アップロードサブフォームが表示される
            ModalFormHandler = (name, hWnd, form) =>
            {
                //アップロード失敗ダイアログ
                DialogBoxHandler = (name2, hWnd2) =>
                {
                    var tsMessageBox = new MessageBoxTester(hWnd2);

                    //タイトル
                    var title = "エラー";
                    Assert.AreEqual(title, tsMessageBox.Title);

                    //テキスト
                    Assert.IsTrue(tsMessageBox.Text.Contains(EX.UPD_REQ_FAILED));

                    //OKボタンクリック
                    tsMessageBox.ClickOk();

                    //アップロードサブフォームのキャンセルボタンをクリック
                    (new ButtonTester("BtnCancel", form)).Click();
                };

                Application.DoEvents();

                //フォーム名テスト
                Assert.AreEqual("AbSubUpload", name);

                // メールを入力
                (new TextBoxTester("TxtMail", form)).Enter(AbWebServer.MAIL);

                // パスワードを入力
                (new TextBoxTester("TxtPass", form)).Enter(AbWebServer.PASS);

                //アップロードボタンクリック
                (new ButtonTester("BtnUpload", form)).Click();

            };

            ShowFormMain(CSV_FILE, AbWebServer.URL_LOGIN_INVALID_ACCESS_TOKEN, AbWebServer.URL_UPLOAD);

            TsMenuUpload().Click();
        }
    }
}
