namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using TT  = AbTestTool;
    using EX  = Abook.AbException.EX;
    using CSV = Abook.AbConstants.CSV;

    /// <summary>
    /// アップロードサブフォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestSubUpload : NUnitFormTest
    {
        /// <summary>CSVファイル</summary>
        private const string CSV_FILE = "AbTestSubUpload.db";
        /// <summary>メール</summary>
        private const string MAIL = AbWebServer.MAIL;
        /// <summary>パスワード</summary>
        private const string PASS = AbWebServer.PASS;
        /// <summary>ログインURL</summary>
        private const string URL_LOGIN = AbWebServer.URL_LOGIN;
        /// <summary>アップロードURL</summary>
        private const string URL_UPLOAD = AbWebServer.URL_UPLOAD;

        /// <summary>対象:種別明細サブ</summary>
        protected AbSubUpload form;

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
                CtAbSubUpload().Close();
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
            AbWebServer.Start();
            using (StreamWriter sw = new StreamWriter(CSV_FILE, false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine(TT.ToCSV("2014-11-01", "name1", "食費", "100"));
                sw.WriteLine(TT.ToCSV("2014-11-02", "name2", "雑貨", "200"));
                sw.WriteLine(TT.ToCSV("2014-11-03", "name3", "家賃", "300"));
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
        /// フォーム表示
        /// </summary>
        /// <param name="csv">CSVファイル</param>
        /// <param name="login">ログインURL</param>
        /// <param name="upload">アップロードURL</param>
        private void ShowSubUpload(string csv, string login, string upload)
        {
            form = new AbSubUpload(csv, login, upload);
            Assert.AreEqual("アップロード", form.Text);

            form.Show();
        }

        #region "Tester取得メソッド"

        /// <summary>
        /// アップロードサブフォーム取得
        /// </summary>
        /// <returns>アップロードサブフォーム</returns>
        private AbSubUpload CtAbSubUpload()
        {
            var finder = new FormFinder();
            return (AbSubUpload)finder.Find(typeof(AbSubUpload).Name);
        }

        /// <summary>
        /// メール入力欄取得
        /// </summary>
        /// <returns>メール入力欄</returns>
        private TextBoxTester TsTxtMail()
        {
            return (new TextBoxTester("TxtMail", form));
        }

        /// <summary>
        /// パスワード入力欄取得
        /// </summary>
        /// <returns>パスワード入力欄</returns>
        private TextBoxTester TsTxtPass()
        {
            return (new TextBoxTester("TxtPass", form));
        }

        /// <summary>
        /// アップロードボタン取得
        /// </summary>
        /// <returns>アップロードボタン</returns>
        private ButtonTester TsBtnUpload()
        {
            return (new ButtonTester("BtnUpload", form));
        }

        /// <summary>
        /// キャンセルボタン取得
        /// </summary>
        /// <returns>キャンセルボタン取得</returns>
        private ButtonTester TsBtnCancel()
        {
            return (new ButtonTester("BtnCancel", form));
        }

        #endregion

        #region "Control取得メソッド"

        /// <summary>
        /// コントロール取得
        /// </summary>
        /// <typeparam name="T">型パラメタ</typeparam>
        /// <param name="name">コントロール名</param>
        /// <returns>コントロール</returns>
        private T CtControl<T>(string name)
        {
            return (new Finder<T>(name, form).Find());
        }

        /// <summary>
        /// メールラベル取得
        /// </summary>
        /// <returns>メールラベル</returns>
        private Label CtLblMail()
        {
            return CtControl<Label>("LblMail");
        }

        /// <summary>
        /// パスワードラベル取得
        /// </summary>
        /// <returns>パスワードラベル</returns>
        private Label CtLblPass()
        {
            return CtControl<Label>("LblPass");
        }

        /// <summary>
        /// メール入力欄取得
        /// </summary>
        /// <returns>メール入力欄</returns>
        private TextBox CtTxtMail()
        {
            return CtControl<TextBox>("TxtMail");
        }

        /// <summary>
        /// パスワード入力欄取得
        /// </summary>
        /// <returns>パスワード入力欄</returns>
        private TextBox CtTxtPass()
        {
            return CtControl<TextBox>("TxtPass");
        }

        /// <summary>
        /// アップロードボタン取得
        /// </summary>
        /// <returns>アップロードボタン</returns>
        private Button CtBtnUpload()
        {
            return CtControl<Button>("BtnUpload");
        }

        /// <summary>
        /// キャンセルボタン取得
        /// </summary>
        /// <returns>キャンセルボタン</returns>
        private Button CtBtnCancel()
        {
            return CtControl<Button>("BtnCancel");
        }

        /// <summary>
        /// プログレスバー取得
        /// </summary>
        /// <returns>プログレスバー</returns>
        private PictureBox CtPboxProgress()
        {
            return CtControl<PictureBox>("PboxProgress");
        }

        #endregion

        /// <summary>
        /// コントロールの表示・非表示、有効・無効のテスト
        /// </summary>
        /// <param name="enabled">true:認証情報入力表示 false:プログレスバー表示</param>
        private void CtrlEnabled(bool enabled)
        {
            Assert.AreEqual(enabled, CtLblMail().Visible);
            Assert.AreEqual(enabled, CtTxtMail().Visible);
            Assert.AreEqual(enabled, CtLblPass().Visible);
            Assert.AreEqual(enabled, CtTxtPass().Visible);
            Assert.AreEqual(enabled, CtBtnUpload().Enabled);
            Assert.AreEqual(enabled, CtBtnCancel().Enabled);
            Assert.AreEqual(!enabled, CtPboxProgress().Visible);
        }

        /// <summary>
        /// アップロード
        /// メール未入力のエラー
        /// </summary>
        [Test]
        public void UploadWithEmptyMail()
        {
            ShowSubUpload(CSV_FILE, URL_LOGIN, URL_UPLOAD);

            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                Assert.IsTrue(tsMessageBox.Text.Contains(EX.MAIL_NULL));

                //OKボタンクリック
                tsMessageBox.ClickOk();
            };

            CtrlEnabled(true);

            TsTxtMail().Enter("");
            TsTxtPass().Enter(PASS);
            TsBtnUpload().Click();
        }

        /// <summary>
        /// アップロード
        /// パスワード未入力のエラー
        /// </summary>
        [Test]
        public void UploadWithEmptyPass()
        {
            ShowSubUpload(CSV_FILE, URL_LOGIN, URL_UPLOAD);

            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                Assert.IsTrue(tsMessageBox.Text.Contains(EX.PASS_NULL));

                //OKボタンクリック
                tsMessageBox.ClickOk();
            };

            CtrlEnabled(true);

            TsTxtMail().Enter(MAIL);
            TsTxtPass().Enter("");
            TsBtnUpload().Click();
        }

        /// <summary>
        /// アップロード
        /// ログインURL不正のエラー
        /// </summary>
        [Test]
        public void UploadWithLoginUrlNotAvailable()
        {
            var login = "http://localhost:9990/";
            ShowSubUpload(CSV_FILE, login, URL_UPLOAD);

            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                Assert.IsTrue(tsMessageBox.Text.Contains("リモート サーバーに接続できません。"));

                //OKボタンクリック
                tsMessageBox.ClickOk();

                CtrlEnabled(true);
            };

            CtrlEnabled(true);

            TsTxtMail().Enter(MAIL);
            TsTxtPass().Enter(PASS);
            TsBtnUpload().Click();

            Application.DoEvents();
            CtrlEnabled(false);

            //処理完了まで待機(2秒程)
            Thread.Sleep(2 * 1000);
            Application.DoEvents();
        }

        /// <summary>
        /// アップロード
        /// ログイン失敗のエラー
        /// </summary>
        [Test]
        public void UploadWithLoginFailure()
        {
            var login = AbWebServer.URL_LOGIN_FAILED;
            ShowSubUpload(CSV_FILE, login, URL_UPLOAD);

            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                Assert.IsTrue(tsMessageBox.Text.Contains("404"));

                //OKボタンクリック
                tsMessageBox.ClickOk();

                CtrlEnabled(true);
            };

            CtrlEnabled(true);

            TsTxtMail().Enter(MAIL);
            TsTxtPass().Enter(PASS);
            TsBtnUpload().Click();

            Application.DoEvents();
            CtrlEnabled(false);

            //処理完了まで待機(2秒程)
            Thread.Sleep(2 * 1000);
            Application.DoEvents();
        }

        /// <summary>
        /// アップロード
        /// アップロードURL不正のエラー
        /// </summary>
        [Test]
        public void UploadWithUploadUrlNotAvailable()
        {
            var upload = "http://localhost:9990/";
            ShowSubUpload(CSV_FILE, URL_LOGIN, upload);

            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                Assert.IsTrue(tsMessageBox.Text.Contains("リモート サーバーに接続できません。"));

                //OKボタンクリック
                tsMessageBox.ClickOk();

                CtrlEnabled(true);
            };

            CtrlEnabled(true);

            TsTxtMail().Enter(MAIL);
            TsTxtPass().Enter(PASS);
            TsBtnUpload().Click();

            Application.DoEvents();
            CtrlEnabled(false);

            //処理完了まで待機(2秒程)
            Thread.Sleep(2 * 1000);
            Application.DoEvents();
        }

        /// <summary>
        /// アップロード
        /// アクセストークン無効のエラー
        /// </summary>
        [Test]
        public void UploadWithInvalidAccessToken()
        {
            var login = AbWebServer.URL_LOGIN_INVALID_ACCESS_TOKEN;
            ShowSubUpload(CSV_FILE, login, URL_UPLOAD);

            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                Assert.IsTrue(tsMessageBox.Text.Contains("500"));

                //OKボタンクリック
                tsMessageBox.ClickOk();

                CtrlEnabled(true);
            };

            CtrlEnabled(true);

            TsTxtMail().Enter(MAIL);
            TsTxtPass().Enter(PASS);
            TsBtnUpload().Click();

            Application.DoEvents();
            CtrlEnabled(false);

            //処理完了まで待機(2秒程)
            Thread.Sleep(2 * 1000);
            Application.DoEvents();
        }

        /// <summary>
        /// アップロード
        /// アップロード成功
        /// </summary>
        [Test]
        public void UploadWithUploadSuccess()
        {
            ShowSubUpload(CSV_FILE, URL_LOGIN, URL_UPLOAD);

            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "アップロード";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                Assert.AreEqual("成功しました。", tsMessageBox.Text);

                //OKボタンクリック
                tsMessageBox.ClickOk();
            };

            CtrlEnabled(true);

            TsTxtMail().Enter(MAIL);
            TsTxtPass().Enter(PASS);
            TsBtnUpload().Click();

            Application.DoEvents();
            CtrlEnabled(false);

            //処理完了まで待機(2秒程)
            Thread.Sleep(2 * 1000);
            Application.DoEvents();
        }

        /// <summary>
        /// アップロード
        /// アップロード失敗
        /// </summary>
        [Test]
        public void UploadWithUploadFailure()
        {
            var upload = AbWebServer.URL_UPLOAD_FAILED;
            ShowSubUpload(CSV_FILE, URL_LOGIN, upload);

            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                Assert.IsTrue(tsMessageBox.Text.Contains("500"));

                //OKボタンクリック
                tsMessageBox.ClickOk();

                CtrlEnabled(true);
            };

            CtrlEnabled(true);

            TsTxtMail().Enter(MAIL);
            TsTxtPass().Enter(PASS);
            TsBtnUpload().Click();

            Application.DoEvents();
            CtrlEnabled(false);

            //処理完了まで待機(2秒程)
            Thread.Sleep(2 * 1000);
            Application.DoEvents();
        }

        /// <summary>
        /// アップロード
        /// キャンセル
        /// </summary>
        [Test]
        public void UploadWithCancel()
        {
            ShowSubUpload(CSV_FILE, URL_LOGIN, URL_UPLOAD);

            CtrlEnabled(true);

            TsBtnCancel().Click();

            Assert.IsTrue(form.IsDisposed);
        }
    }
}
