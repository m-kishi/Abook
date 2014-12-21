namespace AbookTest
{
    using Abook;
    using System;
    using System.IO;
    using System.Threading;
    using System.Windows.Forms;
    using NUnit.Framework;
    using NUnit.Extensions.Forms;
    using CSV = Abook.AbConstants.CSV;

    /// <summary>
    /// アップロードサブフォームテスト
    /// </summary>
    [TestFixture]
    public class AbTestSubUpload : NUnitFormTest
    {
        /// <summary>リクエストURL</summary>
        private const string VALID_URL   = "http://localhost:9999/";
        /// <summary>リクエストURL</summary>
        private const string INVALID_URL = "http://localhost:9000/";
        /// <summary>DBファイル</summary>
        private const string DB_FILE = "AbTestSubUpload.db";
        /// <summary>UPDファイル</summary>
        private const string UPD_FILE = "AbTestSubUpload.sql";

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
            using (StreamWriter sw = new StreamWriter(DB_FILE, false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine(ToCSV("2014-11-01", "name1", "食費", "100"));
                sw.WriteLine(ToCSV("2014-11-02", "name2", "雑貨", "200"));
                sw.WriteLine(ToCSV("2014-11-03", "name3", "家賃", "300"));
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
            if (System.IO.File.Exists(DB_FILE )) System.IO.File.Delete(DB_FILE );
            if (System.IO.File.Exists(UPD_FILE)) System.IO.File.Delete(UPD_FILE);
        }

        /// <summary>
        /// 支出情報CSV生成
        /// (AbTestFormBase、AbTestSubTypeと重複:これ以上増えるならDRY検討)
        /// </summary>
        /// <param name="date">日付</param>
        /// <param name="name">名前</param>
        /// <param name="type">種別</param>
        /// <param name="cost">金額</param>
        /// <returns>支出情報CSV</returns>
        protected string ToCSV(string date, string name, string type, string cost)
        {
            const string TEMPLATE = "\"{0}\",\"{1}\",\"{2}\",\"{3}\"";
            return string.Format(TEMPLATE, date, name, type, cost);
        }

        /// <summary>
        /// フォーム表示
        /// </summary>
        /// <param name="db">DBファイル</param>
        /// <param name="url">リクエストURL</param>
        protected void ShowSubUpload(string db, string url)
        {
            form = new AbSubUpload(db, UPD_FILE, url);
            Assert.AreEqual("アップロード", form.Text);

            //フォームのShownイベント起動のために必要
            form.Show();
            Application.DoEvents();
        }

        /// <summary>
        /// アップロードサブフォーム取得
        /// </summary>
        /// <returns>アップロードサブフォーム</returns>
        protected AbSubUpload CtAbSubUpload()
        {
            var finder = new FormFinder();
            return (AbSubUpload)finder.Find(typeof(AbSubUpload).Name);
        }

        /// <summary>
        /// アップロード成功のテスト
        /// </summary>
        [Test]
        public void UploadWithSuccess()
        {
            ShowSubUpload(DB_FILE, VALID_URL);

            //処理完了まで待機
            while (form.IsRunning)
            {
                Thread.Sleep(1 * 1000);
                Application.DoEvents();
            }
            Assert.IsTrue(form.IsDisposed);
            Assert.AreEqual(DialogResult.OK, form.DialogResult);
        }

        /// <summary>
        /// アップロード失敗のテスト
        /// </summary>
        [Test]
        public void UploadWithFailure()
        {
            //ダイアログの表示テスト
            DialogBoxHandler = (name, hWnd) =>
            {
                var tsMessageBox = new MessageBoxTester(hWnd);

                //タイトル
                var title = "エラー";
                Assert.AreEqual(title, tsMessageBox.Title);

                //テキスト
                var text = "サーバへのアップロードに失敗しました。:\r\nリモート サーバーに接続できません。";
                Assert.AreEqual(text, tsMessageBox.Text);

                //OKボタンクリック
                tsMessageBox.ClickOk();
            };

            ShowSubUpload(DB_FILE, INVALID_URL);

            //処理完了まで待機
            while (form.IsRunning)
            {
                Thread.Sleep(1 * 1000);
                Application.DoEvents();
            }
            Assert.IsTrue(form.IsDisposed);
            Assert.AreEqual(DialogResult.Abort, form.DialogResult);
        }

        /// <summary>
        /// キャンセルのテスト
        /// </summary>
        [Test]
        public void Cancel()
        {
            ShowSubUpload(DB_FILE, VALID_URL);

            //処理が一瞬で終わる場合はキャンセルが間に合わない
            if (!form.IsDisposed)
            {
                var ctBtnCancel = (new Finder<Button>("BtnCancel", form).Find());
                Assert.IsTrue(ctBtnCancel.Enabled);
                ButtonTester tsBtnCancel = new ButtonTester("BtnCancel", form);
                tsBtnCancel.Click();
                Assert.IsFalse(ctBtnCancel.Enabled);
            }

            //処理完了まで待機
            while (form.IsRunning)
            {
                Thread.Sleep(1 * 1000);
                Application.DoEvents();
            }

            //キャンセルは間に合わずOKが返る
            Assert.IsTrue(form.IsDisposed);
            Assert.AreEqual(DialogResult.OK, form.DialogResult);
        }
    }
}
