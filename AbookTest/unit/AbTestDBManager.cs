namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using NUnit.Framework;

    [TestFixture]
    public class AbTestDBManager
    {
        private string argInFile;
        private string argOutFile;
        private DataGridView argDgv;

        [SetUp]
        public void SetUp()
        {
            argInFile = "In_AnyData.db";
            argOutFile = "Out_AnyData.db";

            argDgv = (new AbFormMain()).DataGridView;
            argDgv.Rows.Clear();
            argDgv.Rows.Add(5);
            argDgv.Rows[0].Cells["colDate" ].Value = "2011/05/01";
            argDgv.Rows[0].Cells["colName" ].Value = "おにぎり";
            argDgv.Rows[0].Cells["colType" ].Value = "食費";
            argDgv.Rows[0].Cells["colPrice"].Value = "105";
            argDgv.Rows[1].Cells["colDate" ].Value = "2011/05/02";
            argDgv.Rows[1].Cells["colName" ].Value = "お茶";
            argDgv.Rows[1].Cells["colType" ].Value = "食費";
            argDgv.Rows[1].Cells["colPrice"].Value = "84";
            argDgv.Rows[2].Cells["colDate" ].Value = "2011/05/03";
            argDgv.Rows[2].Cells["colName" ].Value = "うどん";
            argDgv.Rows[2].Cells["colType" ].Value = "外食費";
            argDgv.Rows[2].Cells["colPrice"].Value = "300";
            argDgv.Rows[3].Cells["colDate" ].Value = "2011/05/04";
            argDgv.Rows[3].Cells["colName" ].Value = "病院";
            argDgv.Rows[3].Cells["colType" ].Value = "医療費";
            argDgv.Rows[3].Cells["colPrice"].Value = "2000";
            argDgv.Rows[4].Cells["colDate" ].Value = "2011/05/05";
            argDgv.Rows[4].Cells["colName" ].Value = "家賃";
            argDgv.Rows[4].Cells["colType" ].Value = "家賃";
            argDgv.Rows[4].Cells["colPrice"].Value = "45500";

            if (File.Exists("NotExist.db"   )) { File.Delete("NotExist.db"   ); }
            if (File.Exists("Out_NoData.db" )) { File.Delete("Out_NoData.db" ); }
            if (File.Exists("Out_AnyData.db")) { File.Delete("Out_AnyData.db"); }
        }

        [Test]
        public void LoadFromFileWithNull()
        {
            argInFile = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { AbDBManager.LoadFromFile(argInFile); }
            );
        }

        [Test]
        public void LoadFromFileWithEmpty()
        {
            argInFile = string.Empty;
            Assert.Throws(
                typeof(ArgumentException),
                () => { AbDBManager.LoadFromFile(argInFile); }
            );
        }

        [Test]
        public void LoadFromFileWithNotExist()
        {
            argInFile = "NotExist.db";
            CollectionAssert.IsEmpty(AbDBManager.LoadFromFile(argInFile));
        }

        [Test]
        public void LoadFromFileWithInvalidFormat()
        {
            argInFile = "In_InvalidFormat.db";
            Assert.Throws(
                typeof(Exception),
                () => { AbDBManager.LoadFromFile(argInFile); }
            );
        }

        [Test]
        public void LoadFromFileWithNoData()
        {
            argInFile = "In_NoData.db";
            CollectionAssert.IsEmpty(AbDBManager.LoadFromFile(argInFile));
        }

        [Test]
        public void LoadFromFileWithAnyData()
        {
            var expected = new List<AbExpense>()
            {
                new AbExpense("2009/02/28", "おにぎり", "食費"  ,  "100"),
                new AbExpense("2010/03/31", "ラーメン", "外食費",  "800"),
                new AbExpense("2011/04/01", "飲み会"  , "遊行費", "3000"),
                new AbExpense("2012/05/31", "ガス代"  , "光熱費", "5000"),
                new AbExpense("2013/06/01", "高速バス", "交通費", "7800")
            };

            var actual = AbDBManager.LoadFromFile(argInFile);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Date , actual[i].Date);
                Assert.AreEqual(expected[i].Name , actual[i].Name);
                Assert.AreEqual(expected[i].Type , actual[i].Type);
                Assert.AreEqual(expected[i].Price, actual[i].Price);
            }
        }

        [Test]
        public void StoreToFileWithNullFile()
        {
            argOutFile = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { AbDBManager.StoreToFile(argOutFile, argDgv); }
            );
        }

        [Test]
        public void StoreToFileWithEmptyFile()
        {
            argOutFile = string.Empty;
            Assert.Throws(
                typeof(ArgumentException),
                () => { AbDBManager.StoreToFile(argOutFile, argDgv); }
            );
        }

        [Test]
        public void StoreToFileWithNoData()
        {
            argDgv.Rows.Clear();
            Assert.Throws(
                typeof(ArgumentException),
                () => { AbDBManager.StoreToFile(argOutFile, argDgv); }
            );
        }

        [Test]
        public void StoreToFileWithAnyData()
        {
            argOutFile = "Out_AnyData.db";
            var expected = new List<AbExpense>()
            {
                new AbExpense("2011/05/01", "おにぎり", "食費"  ,   "105"),
                new AbExpense("2011/05/02", "お茶"    , "食費"  ,    "84"),
                new AbExpense("2011/05/03", "うどん"  , "外食費",   "300"),
                new AbExpense("2011/05/04", "病院"    , "医療費",  "2000"),
                new AbExpense("2011/05/05", "家賃"    , "家賃"  , "45500")
            };

            var actual = AbDBManager.StoreToFile(argOutFile, argDgv);

            Assert.IsTrue(File.Exists(argOutFile));
            FileAssert.AreEqual("Actual_AnyData.db", argOutFile);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Date , actual[i].Date);
                Assert.AreEqual(expected[i].Name , actual[i].Name);
                Assert.AreEqual(expected[i].Type , actual[i].Type);
                Assert.AreEqual(expected[i].Price, actual[i].Price);
            }
        }
    }
}
