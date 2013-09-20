namespace AbookTest
{
    using Abook;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;
    using EX  = Abook.AbException.EX;
    using COL = Abook.AbConstants.COL;
    using CSV = Abook.AbConstants.CSV;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// DB ファイル管理テスト
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
        /// <summary>引数:支出リスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>期待値:支出リスト</summary>
        private List<AbExpense> expected;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //CSVのフィールド数が少ない
            using (StreamWriter sw = new StreamWriter("LessCSVFields.db", false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine("\"column1\",\"column2\",\"column3\"");
                sw.Close();
            }

            //CSVのフィールド数が多い
            using (StreamWriter sw = new StreamWriter("MoreCSVFields.db", false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine("\"column1\",\"column2\",\"column3\",\"column4\",\"column5\"");
                sw.Close();
            }

            //日付が不正
            using (StreamWriter sw = new StreamWriter("InvalidDateFormat.db", false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine("\"2011-02-31\",\"name\",\"type\",\"1000\"");
                sw.Close();
            }

            //データなし
            File.Create("NoData.db").Close();

            //テストデータ
            using (StreamWriter sw = new StreamWriter("InData.db", false, CSV.ENCODING))
            {
                sw.NewLine = CSV.LF;
                sw.WriteLine("\"2009-04-01\",\"name1\",\"食費\",\"100\"");
                sw.WriteLine("\"2009-04-01\",\"name2\",\"食費\",\"200\"");
                sw.WriteLine("\"2009-04-02\",\"name3\",\"食費\",\"300\"");
                sw.Close();
            }
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            File.Delete("NoData.db");
            File.Delete("InData.db");
            File.Delete("OutData.db");
            File.Delete("NotExist.db");
            File.Delete("LessCSVFields.db");
            File.Delete("MoreCSVFields.db");
            File.Delete("InvalidDateFormat.db");
        }

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
            }

            expected = new List<AbExpense>()
            {
                new AbExpense("2009-04-01", "name1", "食費", "100"),
                new AbExpense("2009-04-01", "name2", "食費", "200"),
                new AbExpense("2009-04-02", "name3", "食費", "300")
            };
        }

        /// <summary>
        /// DB ファイル読み込み
        /// 引数:ファイル名が NULL
        /// </summary>
        [Test]
        public void LoadWithNullFile()
        {
            argInFile = null;
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Load(argInFile); }
            );
            Assert.AreEqual(EX.DB_NULL, ex.Message);
        }

        /// <summary>
        /// DB ファイル読み込み
        /// 引数:ファイル名が空文字列
        /// </summary>
        [Test]
        public void LoadWithEmptyFile()
        {
            argInFile = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Load(argInFile); }
            );
            Assert.AreEqual(EX.DB_NULL, ex.Message);
        }

        /// <summary>
        /// DB ファイル読み込み
        /// 引数:ファイル名が存在しない
        /// </summary>
        [Test]
        public void LoadWithNotExistFile()
        {
            argInFile = "NotExist.db";
            var expenses = AbDBManager.Load(argInFile);

            CollectionAssert.IsEmpty(expenses);
            Assert.IsTrue(File.Exists(argInFile));
        }

        /// <summary>
        /// DB ファイル読み込み
        /// CSV のフィールド数が少ない
        /// </summary>
        [Test]
        public void LoadWithLessCSVFields()
        {
            argInFile = "LessCSVFields.db";
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Load(argInFile); }
            );
            Assert.AreEqual(string.Format(EX.DB_LOAD, 1, EX.DB_FIELD_LESS), ex.Message);
        }

        /// <summary>
        /// DB ファイル読み込み
        /// CSV のフィールド数が多い
        /// </summary>
        [Test]
        public void LoadWithMoreCSVFields()
        {
            argInFile = "MoreCSVFields.db";
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Load(argInFile); }
            );
            Assert.AreEqual(string.Format(EX.DB_LOAD, 1, EX.DB_FIELD_MORE), ex.Message);
        }

        /// <summary>
        /// DB ファイル読み込み
        /// 読み込むデータが不正
        /// </summary>
        [Test]
        public void LoadWithInvalidDateFormat()
        {
            argInFile = "InvalidDateFormat.db";
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Load(argInFile); }
            );
            Assert.AreEqual(string.Format(EX.DB_LOAD, 1, EX.DATE_FORMAT), ex.Message);
        }

        /// <summary>
        /// DB ファイル読み込み
        /// 空ファイルから読み込み
        /// </summary>
        [Test]
        public void LoadWithNoDataFile()
        {
            argInFile = "NoData.db";
            var expenses = AbDBManager.Load(argInFile);
            CollectionAssert.IsEmpty(expenses);
        }

        /// <summary>
        /// DataGridView から読み込み
        /// 引数:DataGridView が NULL
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
        /// DataGridView から読み込み
        /// 引数:DataGridView が空
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
        /// DataGridView から読み込み
        /// 引数:DataGridView のデータが不正
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
                { AbDBManager.Load(argDgv, out argLine); }
            );
            Assert.AreEqual(argDgv.Rows.Count, argLine);
            Assert.AreEqual(string.Format(EX.DB_STORE, argLine, EX.DATE_FORMAT), ex.Message);
        }

        /// <summary>
        /// DB ファイル読み込み
        /// 読み込み件数のチェック
        /// </summary>
        [Test]
        public void LoadWithCountFromFile()
        {
            var expenses = AbDBManager.Load(argInFile);
            Assert.AreEqual(3, expenses.Count);
        }

        /// <summary>
        /// DB ファイル読み込み
        /// 読み込み件数のチェック
        /// </summary>
        [Test]
        public void LoadWithCountFromDgv()
        {
            var expenses = AbDBManager.Load(argDgv, out argLine);
            Assert.AreEqual(3, expenses.Count);
        }

        /// <summary>
        /// DB ファイル読み込み
        /// </summary>
        [Test]
        public void LoadFromFile()
        {
            var expenses = AbDBManager.Load(argInFile);
            Assert.AreEqual(expected.Count, expenses.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Date, expenses[i].Date);
                Assert.AreEqual(expected[i].Name, expenses[i].Name);
                Assert.AreEqual(expected[i].Type, expenses[i].Type);
                Assert.AreEqual(expected[i].Cost, expenses[i].Cost);
            }
        }

        /// <summary>
        /// DataGridView から読み込み
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
            }
        }

        /// <summary>
        /// DB ファイル書き出し
        /// 引数:ファイル名が NULL
        /// </summary>
        [Test]
        public void StoreWithNullFile()
        {
            argOutFile = null;
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Store(argOutFile, argExpenses); }
            );
            Assert.AreEqual(EX.DB_NULL, ex.Message);
        }

        /// <summary>
        /// DB ファイル書き出し
        /// 引数:ファイル名が空文字列
        /// </summary>
        [Test]
        public void StoreWithEmptyFile()
        {
            argOutFile = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Store(argOutFile, argExpenses); }
            );
            Assert.AreEqual(EX.DB_NULL, ex.Message);
        }

        /// <summary>
        /// DB ファイル書き出し
        /// 引数:支出情報リストが NULL
        /// </summary>
        [Test]
        public void StoreWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Store(argOutFile, argExpenses); }
            );
            Assert.AreEqual(EX.DB_RECORD_NOTHING, ex.Message);
        }

        /// <summary>
        /// DB ファイル書き出し
        /// 引数:支出情報リストが空リスト
        /// </summary>
        [Test]
        public void StoreWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            var ex = Assert.Throws<AbException>(() =>
                { AbDBManager.Store(argOutFile, argExpenses); }
            );
            Assert.AreEqual(EX.DB_RECORD_NOTHING, ex.Message);
        }

        /// <summary>
        /// DB ファイル書き出し
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
