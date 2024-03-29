﻿// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using EX  = Abook.AbException.EX;
    using DB  = Abook.AbConstants.DB;
    using COL = Abook.AbConstants.COL.EXPENSE;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// DBファイル管理テスト
    /// </summary>
    [TestFixture]
    public class AbTestDBManager
    {
        /// <summary>引数:エラー行参照</summary>
        private int argLine;
        /// <summary>引数:読み込みファイル名</summary>
        private string argInFile;
        /// <summary>引数:書き出しファイル名</summary>
        private string argOutFile;
        /// <summary>引数:DataGridView</summary>
        private DataGridView argDgv;
        /// <summary>引数:支出情報リスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>期待値:支出情報リスト</summary>
        private List<AbExpense> expected;

        /// <summary>
        /// TestFixtureSetUp
        /// </summary>
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            // DBファイルのフィールド数が少ない
            using (StreamWriter sw = new StreamWriter("LessFields.db", false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine("\"column1\",\"column2\",\"column3\"");
                sw.Close();
            }

            // DBファイルのフィールド数が多い
            using (StreamWriter sw = new StreamWriter("MoreFields.db", false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine("\"column1\",\"column2\",\"column3\",\"column4\",\"column5\",\"column6\"");
                sw.Close();
            }

            // 日付が不正
            using (StreamWriter sw = new StreamWriter("InvalidDateFormat.db", false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine("\"2011-02-31\",\"name\",\"type\",\"1000\"");
                sw.Close();
            }

            // データなし
            File.Create("NoData.db").Close();

            // テストデータ
            using (StreamWriter sw = new StreamWriter("InData.db", false, DB.ENCODING))
            {
                sw.NewLine = DB.LF;
                sw.WriteLine("\"2009-04-01\",\"name1\",\"食費\",\"100\",\"\"");
                sw.WriteLine("\"2009-04-01\",\"name2\",\"食費\",\"200\",\"\"");
                sw.WriteLine("\"2009-04-02\",\"name3\",\"食費\",\"300\",\"備考\"");
                sw.Close();
            }
        }

        /// <summary>
        /// TestFixtureTearDown
        /// </summary>
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            File.Delete("NoData.db");
            File.Delete("InData.db");
            File.Delete("OutData.db");
            File.Delete("NotExist.db");
            File.Delete("LessFields.db");
            File.Delete("MoreFields.db");
            File.Delete("InvalidDateFormat.db");
        }

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argInFile = "InData.db";
            argOutFile = "OutData.db";

            argExpenses = AbDBManager.Load(argInFile);

            argDgv = new DataGridView();
            argDgv.Columns.Add(COL.DATE, "日付");
            argDgv.Columns.Add(COL.NAME, "名称");
            argDgv.Columns.Add(COL.TYPE, "種別");
            argDgv.Columns.Add(COL.COST, "金額");
            argDgv.Columns.Add(COL.NOTE, "備考");
            argDgv.AllowUserToAddRows = false;

            argDgv.Rows.Clear();
            argDgv.Rows.Add(argExpenses.Count);
            for (int i = 0; i < argExpenses.Count; i++)
            {
                var exp = argExpenses[i];
                argDgv.Rows[i].Cells[COL.DATE].Value = exp.Date.ToString(FMT.DATE);
                argDgv.Rows[i].Cells[COL.NAME].Value = exp.Name;
                argDgv.Rows[i].Cells[COL.TYPE].Value = exp.Type;
                argDgv.Rows[i].Cells[COL.COST].Value = exp.Cost;
                argDgv.Rows[i].Cells[COL.NOTE].Value = exp.Note;
            }

            expected = new List<AbExpense>()
            {
                new AbExpense("2009-04-01", "name1", "食費", "100"),
                new AbExpense("2009-04-01", "name2", "食費", "200", ""),
                new AbExpense("2009-04-02", "name3", "食費", "300", "備考")
            };
        }

        /// <summary>
        /// DBファイル読み込み
        /// 引数:DBファイルがNULL
        /// </summary>
        [Test]
        public void LoadWithNullDBFile()
        {
            argInFile = null;
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Load(argInFile)
            );
            Assert.AreEqual(EX.DB_FILE_NULL, ex.Message);
        }

        /// <summary>
        /// DBファイル読み込み
        /// 引数:DBファイルが空文字列
        /// </summary>
        [Test]
        public void LoadWithEmptyDBFile()
        {
            argInFile = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Load(argInFile)
            );
            Assert.AreEqual(EX.DB_FILE_NULL, ex.Message);
        }

        /// <summary>
        /// DBファイル読み込み
        /// 引数:DBファイルが存在しない
        /// </summary>
        [Test]
        public void LoadWithNotExistDBFile()
        {
            argInFile = "NotExist.db";
            var expenses = AbDBManager.Load(argInFile);

            CollectionAssert.IsEmpty(expenses);
            Assert.IsTrue(File.Exists(argInFile));
        }

        /// <summary>
        /// DBファイル読み込み
        /// DBファイルのフィールド数が少ない
        /// </summary>
        [Test]
        public void LoadWithLessFields()
        {
            argInFile = "LessFields.db";
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Load(argInFile)
            );
            Assert.AreEqual(string.Format(EX.DB_FILE_LOAD, 1, EX.DB_FILE_FIELD_LESS), ex.Message);
        }

        /// <summary>
        /// DBファイル読み込み
        /// DBファイルのフィールド数が多い
        /// </summary>
        [Test]
        public void LoadWithMoreFields()
        {
            argInFile = "MoreFields.db";
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Load(argInFile)
            );
            Assert.AreEqual(string.Format(EX.DB_FILE_LOAD, 1, EX.DB_FILE_FIELD_MORE), ex.Message);
        }

        /// <summary>
        /// DBファイル読み込み
        /// 読み込むデータが不正
        /// </summary>
        [Test]
        public void LoadWithInvalidDateFormat()
        {
            argInFile = "InvalidDateFormat.db";
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Load(argInFile)
            );
            Assert.AreEqual(string.Format(EX.DB_FILE_LOAD, 1, EX.DATE_FORMAT), ex.Message);
        }

        /// <summary>
        /// DBファイル読み込み
        /// 空ファイルから読み込み
        /// </summary>
        [Test]
        public void LoadWithNoDataDBFile()
        {
            argInFile = "NoData.db";
            var expenses = AbDBManager.Load(argInFile);
            CollectionAssert.IsEmpty(expenses);
        }

        /// <summary>
        /// DataGridViewから読み込み
        /// 引数:DataGridViewがNULL
        /// </summary>
        [Test]
        public void LoadWithNullDgv()
        {
            argDgv = null;
            var expenses = AbDBManager.Load(argDgv, out argLine);
            Assert.AreEqual(0, argLine);
            CollectionAssert.IsEmpty(expenses);
        }

        /// <summary>
        /// DataGridViewから読み込み
        /// 引数:DataGridViewが空
        /// </summary>
        [Test]
        public void LoadWithEmptyDgv()
        {
            argDgv.Rows.Clear();
            var expenses = AbDBManager.Load(argDgv, out argLine);
            Assert.AreEqual(0, argLine);
            CollectionAssert.IsEmpty(expenses);
        }

        /// <summary>
        /// DataGridViewから読み込み
        /// 引数:DataGridViewのデータが不正
        /// </summary>
        [Test]
        public void LoadWithInvalidDateFormatDgv()
        {
            argDgv.Rows.Add(1);
            var row = argDgv.Rows[argDgv.Rows.Count - 1];
            row.Cells[COL.DATE].Value = "2011-02-31";
            row.Cells[COL.NAME].Value = "name";
            row.Cells[COL.TYPE].Value = "食費";
            row.Cells[COL.COST].Value = "1000";

            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Load(argDgv, out argLine)
            );
            Assert.AreEqual(argDgv.Rows.Count, argLine);
            Assert.AreEqual(string.Format(EX.DB_FILE_LOAD, argLine, EX.DATE_FORMAT), ex.Message);
        }

        /// <summary>
        /// DBファイル読み込み
        /// 読み込み件数のチェック
        /// </summary>
        [Test]
        public void LoadWithCountFromDBFile()
        {
            var expenses = AbDBManager.Load(argInFile);
            Assert.AreEqual(3, expenses.Count);
        }

        /// <summary>
        /// DBファイル読み込み
        /// 読み込み件数のチェック
        /// </summary>
        [Test]
        public void LoadWithCountFromDgv()
        {
            var expenses = AbDBManager.Load(argDgv, out argLine);
            Assert.AreEqual(3, expenses.Count);
        }

        /// <summary>
        /// DBファイル読み込み
        /// </summary>
        [Test]
        public void LoadFromDBFile()
        {
            var expenses = AbDBManager.Load(argInFile);
            Assert.AreEqual(expected.Count, expenses.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Date, expenses[i].Date);
                Assert.AreEqual(expected[i].Name, expenses[i].Name);
                Assert.AreEqual(expected[i].Type, expenses[i].Type);
                Assert.AreEqual(expected[i].Cost, expenses[i].Cost);
                Assert.AreEqual(expected[i].Note, expenses[i].Note);
            }
        }

        /// <summary>
        /// DataGridViewから読み込み
        /// </summary>
        [Test]
        public void LoadFromDgv()
        {
            var expenses = AbDBManager.Load(argDgv, out argLine);
            Assert.AreEqual(expected.Count, expenses.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Date, expenses[i].Date);
                Assert.AreEqual(expected[i].Name, expenses[i].Name);
                Assert.AreEqual(expected[i].Type, expenses[i].Type);
                Assert.AreEqual(expected[i].Cost, expenses[i].Cost);
                Assert.AreEqual(expected[i].Note, expenses[i].Note);
            }
        }

        /// <summary>
        /// DBファイル書き出し
        /// 引数:DBファイルがNULL
        /// </summary>
        [Test]
        public void StoreWithNullDBFile()
        {
            argOutFile = null;
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Store(argOutFile, argExpenses)
            );
            Assert.AreEqual(EX.DB_FILE_NULL, ex.Message);
        }

        /// <summary>
        /// DBファイル書き出し
        /// 引数:DBファイルが空文字列
        /// </summary>
        [Test]
        public void StoreWithEmptyDBFile()
        {
            argOutFile = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Store(argOutFile, argExpenses)
            );
            Assert.AreEqual(EX.DB_FILE_NULL, ex.Message);
        }

        /// <summary>
        /// DBファイル書き出し
        /// 引数:支出情報リストがNULL
        /// </summary>
        [Test]
        public void StoreWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Store(argOutFile, argExpenses)
            );
            Assert.AreEqual(EX.DB_FILE_RECORD_NOTHING, ex.Message);
        }

        /// <summary>
        /// DBファイル書き出し
        /// 引数:支出情報リストが空リスト
        /// </summary>
        [Test]
        public void StoreWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            var ex = Assert.Throws<AbException>(() =>
                AbDBManager.Store(argOutFile, argExpenses)
            );
            Assert.AreEqual(EX.DB_FILE_RECORD_NOTHING, ex.Message);
        }

        /// <summary>
        /// DBファイル書き出し
        /// </summary>
        [Test]
        public void Store()
        {
            AbDBManager.Store(argOutFile, argExpenses);

            Assert.IsTrue(File.Exists(argOutFile));
            FileAssert.AreEqual("InData.db", argOutFile);
        }
    }
}
