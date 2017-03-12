// ------------------------------------------------------------
// Copyright (C) 2010-2017 Masaaki Kishi. All rights reserved.
// Author: Masaaki Kishi <m.kishi.5@gmail.com>
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using NUnit.Framework;
    using TT  = AbTestTool;
    using EX  = Abook.AbException.EX;
    using CSV = Abook.AbConstants.CSV;
    using UPD = Abook.AbConstants.UPD;

    /// <summary>
    /// アップロードテスト
    /// </summary>
    [TestFixture]
    public class AbTestUploaders
    {
        /// <summary>引数:ファイル</summary>
        private string argFile;
        /// <summary>引数:メール</summary>
        private string argMail;
        /// <summary>引数:パスワード</summary>
        private string argPass;
        /// <summary>引数:ログインURL</summary>
        private string argLogin;
        /// <summary>引数:アップロードURL</summary>
        private string argUpload;

        /// <summary>DBファイル名</summary>
        private const string DB_FILE = "AbTestUploaders.db";
        /// <summary>DBファイル名(0件数)</summary>
        private const string EMPTY_FILE = "AbTestUploadersEmpty.db";

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            AbWebServer.Start();
            if (!File.Exists(DB_FILE)) File.Create(DB_FILE).Close();
            if (!File.Exists(EMPTY_FILE)) File.Create(EMPTY_FILE).Close();
            using (StreamWriter sw = new StreamWriter(DB_FILE, false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine(TT.ToCSV("2015-09-05", "おにぎり", "食費", "108"));
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
            if (File.Exists(DB_FILE)) File.Delete(DB_FILE);
            if (File.Exists(EMPTY_FILE)) File.Delete(EMPTY_FILE);
        }

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argFile = DB_FILE;
            argMail = AbWebServer.MAIL;
            argPass = AbWebServer.PASS;
            argLogin = AbWebServer.URL_LOGIN;
            argUpload = AbWebServer.URL_UPLOAD;
        }

        /// <summary>
        /// アップロード
        /// 引数:ファイルがNULL
        /// </summary>
        [Test]
        public void SendUploadRequestWithNullFile()
        {
            argFile = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.DB_DOES_NOT_EXIST, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:ファイルが空文字列
        /// </summary>
        [Test]
        public void SendUploadRequestWithEmptyFile()
        {
            argFile = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.DB_DOES_NOT_EXIST, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:ファイルが存在しない
        /// </summary>
        [Test]
        public void SendUploadRequestWithFileDoesNotExist()
        {
            argFile = "does_not_exist.db";
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.DB_DOES_NOT_EXIST, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:ファイルの件数0
        /// </summary>
        [Test]
        public void SendUploadRequestWithUpdateRecordNothing()
        {
            argFile = EMPTY_FILE;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.UPD_RECORD_NOTHING, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:メールがNULL
        /// </summary>
        [Test]
        public void SendUploadRequestWithNullMail()
        {
            argMail = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.MAIL_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:メールが空文字列
        /// </summary>
        [Test]
        public void SendUploadRequestWithEmptyMail()
        {
            argMail = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.MAIL_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:パスワードがNULL
        /// </summary>
        [Test]
        public void SendUploadRequestWithNullPass()
        {
            argPass = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.PASS_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:パスワードが空文字列
        /// </summary>
        [Test]
        public void SendUploadRequestWithEmptyPass()
        {
            argPass = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.PASS_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:ログインURLがNULL
        /// </summary>
        [Test]
        public void SendUploadRequestWithNullLogin()
        {
            argLogin = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.LOGIN_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:ログインURLが空文字列
        /// </summary>
        [Test]
        public void SendUploadRequestWithEmptyLogin()
        {
            argLogin = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.LOGIN_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:アップロードURLがNULL
        /// </summary>
        [Test]
        public void SendUploadRequestWithNullUpload()
        {
            argUpload = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.UPLOAD_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:アップロードURLが空文字列
        /// </summary>
        [Test]
        public void SendUploadRequestWithEmptyUpload()
        {
            argUpload = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual(EX.UPLOAD_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// サーバへの接続失敗
        /// </summary>
        [Test]
        public void SendUploadRequestWithConnectionError()
        {
            argLogin = "http://localhost:9000/connection-error";
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.IsTrue(ex.Message.Contains(EX.UPD_REQ_FAILED));
        }

        /// <summary>
        /// アップロード
        /// ログイン失敗(認証エラー)
        /// </summary>
        [Test]
        public void SendUploadRequestWithInvalidLoginAccount()
        {
            argMail = "dummy@example.com";
            argPass = "invalid_passwords";
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.IsTrue(ex.Message.Contains("404"));
            Assert.IsTrue(ex.Message.Contains(EX.UPD_REQ_FAILED));
        }

        /// <summary>
        /// アップロード
        /// ログイン失敗(サーバエラー)
        /// </summary>
        [Test]
        public void SendUploadRequestWithLoginServerError()
        {
            argLogin = AbWebServer.URL_LOGIN_FAILED;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.IsTrue(ex.Message.Contains("404"));
            Assert.IsTrue(ex.Message.Contains(EX.UPD_REQ_FAILED));
        }

        /// <summary>
        /// アップロード
        /// アクセストークンエラー
        /// </summary>
        [Test]
        public void SendUploadRequestWithInvalidAccessToken()
        {
            argLogin = AbWebServer.URL_LOGIN_INVALID_ACCESS_TOKEN;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.IsTrue(ex.Message.Contains("500"));
            Assert.IsTrue(ex.Message.Contains(EX.UPD_REQ_FAILED));
        }

        /// <summary>
        /// アップロード
        /// アップロード成功
        /// </summary>
        [Test]
        public void SendUploadRequest()
        {
            string result = "";
            Assert.DoesNotThrow(() =>
                result = AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.AreEqual("", result);
        }

        /// <summary>
        /// アップロード
        /// アップロード失敗(サーバエラー)
        /// </summary>
        [Test]
        public void SendUploadRequestWithUploadFailed()
        {
            argLogin = AbWebServer.URL_UPLOAD_FAILED;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argFile, argMail, argPass, argLogin, argUpload)
            );
            Assert.IsTrue(ex.Message.Contains("500"));
            Assert.IsTrue(ex.Message.Contains(EX.UPD_REQ_FAILED));
        }
    }
}
