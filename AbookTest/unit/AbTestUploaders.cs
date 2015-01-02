namespace AbookTest
{
    using Abook;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using NUnit.Framework;
    using EX  = Abook.AbException.EX;
    using CSV = Abook.AbConstants.CSV;
    using UPD = Abook.AbConstants.UPD;

    /// <summary>
    /// アップロードテスト
    /// </summary>
    [TestFixture]
    public class AbTestUploaders
    {
        /// <summary>引数:URL</summary>
        private string argUrl;
        /// <summary>引数:ファイル名</summary>
        private string argFile;
        /// <summary>引数:支出情報リスト</summary>
        private List<AbExpense> argExpenses;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            AbWebServer.Start();

            //テストデータ
            using (StreamWriter sw = new StreamWriter("InData.db", false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine("\"2014-11-01\",\"name1\",\"食費\",\"100\"");
                sw.WriteLine("\"2014-11-01\",\"name2\",\"雑貨\",\"200\"");
                sw.WriteLine("\"2014-11-02\",\"name3\",\"家賃\",\"300\"");
                sw.Close();
            }

            //出力されるUPDファイル
            using (StreamWriter sw = new StreamWriter("Expected.sql", false, UPD.ENCODING))
            {
                sw.NewLine = UPD.LF;
                sw.WriteLine("INSERT INTO expenses (date,name,type,cost) VALUES ('2014-11-01','name1','FOOD','100');");
                sw.WriteLine("INSERT INTO expenses (date,name,type,cost) VALUES ('2014-11-01','name2','GOOD','200');");
                sw.WriteLine("INSERT INTO expenses (date,name,type,cost) VALUES ('2014-11-02','name3','HOUS','300');");
                sw.Close();
            }
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            AbWebServer.Finish();
            File.Delete("InData.db");
            File.Delete("Expected.sql");
        }

        [SetUp]
        public void SetUp()
        {
            argFile = UPD.FILE;
            argExpenses = AbDBManager.Load("InData.db");
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(UPD.FILE);
        }

        /// <summary>
        /// UPDファイル書き出し
        /// 引数:ファイル名がNULL
        /// </summary>
        [Test]
        public void PrepareWithNullFile()
        {
            argFile = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.Prepare(argFile, argExpenses)
            );
            Assert.AreEqual(EX.UPD_NULL, ex.Message);
        }

        /// <summary>
        /// UPDファイル書き出し
        /// 引数:ファイル名が空文字列
        /// </summary>
        [Test]
        public void PrepareWithEmptyFile()
        {
            argFile = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.Prepare(argFile, argExpenses)
            );
            Assert.AreEqual(EX.UPD_NULL, ex.Message);
        }

        /// <summary>
        /// UPDファイル書き出し
        /// 引数:支出情報リストがNULL
        /// </summary>
        [Test]
        public void PrepareWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.Prepare(argFile, argExpenses)
            );
            Assert.AreEqual(EX.UPD_RECORD_NOTHING, ex.Message);
        }

        /// <summary>
        /// UPDファイル書き出し
        /// 引数:支出情報リストが空リスト
        /// </summary>
        [Test]
        public void PrepareWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.Prepare(argFile, argExpenses)
            );
            Assert.AreEqual(EX.UPD_RECORD_NOTHING, ex.Message);
        }

        /// <summary>
        /// UPDファイル書き出し
        /// </summary>
        [Test]
        public void Prepare()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            Assert.IsTrue(File.Exists(argFile));
            FileAssert.AreEqual("Expected.sql", argFile);
        }

        /// <summary>
        /// アップロード
        /// 引数:URLがNULL
        /// </summary>
        [Test]
        public void SendUploadRequestWithNullUrl()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            argUrl = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argUrl, argFile)
            );
            Assert.AreEqual(EX.URL_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:URLが空文字列
        /// </summary>
        [Test]
        public void SendUploadRequestWithEmptyUrl()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            argUrl = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argUrl, argFile)
            );
            Assert.AreEqual(EX.URL_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:ファイル名がNULL
        /// </summary>
        [Test]
        public void SendUploadRequestWithNullFile()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            argFile = null;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argUrl, argFile)
            );
            Assert.AreEqual(EX.UPD_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:ファイル名が空文字列
        /// </summary>
        [Test]
        public void SendUploadRequestWithEmptyFile()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            argFile = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argUrl, argFile)
            );
            Assert.AreEqual(EX.UPD_NULL, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// 引数:ファイルが存在しない
        /// </summary>
        [Test]
        public void SendUploadRequestWithFileDoesNotExist()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            argFile = "does_not_exist.sql";
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argUrl, argFile)
            );
            Assert.AreEqual(EX.UPD_DOES_NOT_EXIST, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// サーバへの接続失敗
        /// </summary>
        [Test]
        public void SendUploadRequestWithConnectError()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            argUrl = "http://localhost:9000";
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argUrl, argFile)
            );
            StringAssert.StartsWith(EX.UPD_REQ_FAILED, ex.Message);
        }

        /// <summary>
        /// アップロード
        /// アップロード成功
        /// </summary>
        [Test]
        public void SendUploadRequestWithSuccess()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            argUrl = AbWebServer.URL_SUCCESS;
            var res = AbUploaders.SendUploadRequest(argUrl, argFile);
            Assert.AreEqual("200", res);
            Assert.IsFalse(File.Exists(UPD.FILE));
        }

        /// <summary>
        /// アップロード
        /// アップロード失敗
        /// </summary>
        [Test]
        public void SendUploadRequestWithFailure()
        {
            AbUploaders.Prepare(argFile, argExpenses);

            argUrl = AbWebServer.URL_FAILURE;
            var ex = Assert.Throws<AbException>(() =>
                AbUploaders.SendUploadRequest(argUrl, argFile)
            );
            StringAssert.Contains(EX.UPD_REQ_FAILED, ex.Message);
            Assert.IsFalse(File.Exists(UPD.FILE));
        }
    }
}
