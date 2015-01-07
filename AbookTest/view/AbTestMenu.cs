﻿namespace AbookTest
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
        /// アップロードメニュークリック
        /// 確認ダイアログでOKを選択する
        /// </summary>
        [Test]
        public void MenuUploadClickWithSuccess()
        {
            //確認ダイアログの表示テスト
            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "確認";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                var text = "アップロードします。";
                Assert.AreEqual(text, tsMessageBox.Text);

                //OKボタンクリック
                tsMessageBox.ClickOk();

                //アップロードサブフォームの表示テスト
                ModalFormHandler = (name2, hWnd2, form2) =>
                {
                    //フォーム名テスト
                    Assert.AreEqual(name2, "AbSubUpload");

                    Application.DoEvents();

                    //成功ダイアログの表示テスト
                    DialogBoxHandler = (name3, hWnd3) =>
                    {
                        var tsMessageBox3 = new MessageBoxTester(hWnd3);

                        //タイトル
                        var title3 = "アップロード完了";
                        Assert.AreEqual(title3, tsMessageBox3.Title);

                        //テキスト
                        var text3 = "アップロードに成功しました。";
                        Assert.AreEqual(text3, tsMessageBox3.Text);

                        //OKボタンクリック
                        tsMessageBox3.ClickOk();
                    };
                };
            };

            ShowFormMain(CSV_FILE, "MenuUploadClick.sql", AbWebServer.URL_SUCCESS);

            TsMenuUpload().Click();
        }

        /// <summary>
        /// アップロードメニュークリック
        /// 確認ダイアログでキャンセルを選択する
        /// </summary>
        [Test]
        public void MenuUploadClickWithCancel()
        {
            //確認ダイアログの表示テスト
            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "確認";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                var text = "アップロードします。";
                Assert.AreEqual(text, tsMessageBox.Text);

                //OKボタンクリック
                tsMessageBox.ClickCancel();
            };

            ShowFormMain(CSV_FILE);

            TsMenuUpload().Click();
        }

        /// <summary>
        /// アップロードメニュークリック
        /// アップロードに失敗する
        /// </summary>
        [Test]
        public void MenuUploadClickWithFailure()
        {
            //確認ダイアログの表示テスト
            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "確認";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                var text = "アップロードします。";
                Assert.AreEqual(text, tsMessageBox.Text);

                //OKボタンクリック
                tsMessageBox.ClickOk();

                //アップロードサブフォームの表示テスト
                ModalFormHandler = (name2, hWnd2, form2) =>
                {
                    //フォーム名テスト
                    Assert.AreEqual(name2, "AbSubUpload");

                    Application.DoEvents();

                    //エラーダイアログの表示テスト
                    DialogBoxHandler = (name3, hWnd3) =>
                    {
                        var tsMessageBox3 = new MessageBoxTester(hWnd3);

                        //タイトル
                        var title3 = "エラー";
                        Assert.AreEqual(title3, tsMessageBox3.Title);

                        //テキスト
                        var text3 = EX.UPD_REQ_FAILED;
                        StringAssert.Contains(text3, tsMessageBox3.Text);

                        //失敗ダイアログの表示テスト
                        DialogBoxHandler = (name4, hWnd4) =>
                        {
                            var tsMessageBox4 = new MessageBoxTester(hWnd4);

                            //タイトル
                            var title4 = "アップロード失敗";
                            Assert.AreEqual(title4, tsMessageBox4.Title);

                            //テキスト
                            var text4 = "アップロードに失敗しました。";
                            Assert.AreEqual(text4, tsMessageBox4.Text);

                            //OKボタンクリック
                            tsMessageBox4.ClickOk();
                        };

                        //OKボタンクリック
                        tsMessageBox3.ClickOk();
                    };
                };
            };

            ShowFormMain(CSV_FILE, "MenuUploadClick.sql", AbWebServer.URL_FAILURE);

            TsMenuUpload().Click();
        }
    }
}
