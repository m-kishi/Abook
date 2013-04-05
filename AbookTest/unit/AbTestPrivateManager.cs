namespace AbookTest
{
    using Abook;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using EX   = Abook.AbException.EX;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 秘密収支情報管理テスト
    /// </summary>
    public class AbTestPrivateManager
    {
        /// <summary>引数:支出情報リスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>対象:秘密収支情報管理</summary>
        private AbPrivateManager abPrivateManager;

        [SetUp]
        public void SetUp()
        {
            argExpenses = GenerateExpenses();
            abPrivateManager = new AbPrivateManager(argExpenses);
        }

        /// <summary>
        /// 支出情報リスト生成
        /// </summary>
        /// <returns>支出情報リスト</returns>
        private List<AbExpense> GenerateExpenses()
        {
            var expenses = new List<AbExpense>();
            expenses.Add(new AbExpense("2011-01-01", "name1", TYPE.PRVI, "10000"));
            expenses.Add(new AbExpense("2011-02-28", "name0", TYPE.FOOD, "11000"));
            expenses.Add(new AbExpense("2011-03-15", "name2", TYPE.PRVO, "10000"));
            expenses.Add(new AbExpense("2011-04-20", "name0", TYPE.FOOD, "22000"));
            expenses.Add(new AbExpense("2011-05-08", "name3", TYPE.PRVI, "15000"));
            expenses.Add(new AbExpense("2011-07-31", "name0", TYPE.FOOD, "33000"));
            expenses.Add(new AbExpense("2011-09-28", "name4", TYPE.PRVI, "30000"));
            expenses.Add(new AbExpense("2011-10-11", "name0", TYPE.FOOD, "44000"));
            expenses.Add(new AbExpense("2011-11-03", "name5", TYPE.PRVO, "25000"));
            expenses.Add(new AbExpense("2011-12-12", "name0", TYPE.FOOD, "55000"));
            expenses.Add(new AbExpense("2011-12-30", "name6", TYPE.PRVI, "20000"));
            return expenses;
        }

        /// <summary>
        /// コンストラクタ
        /// 要素数のテスト
        /// </summary>
        [Test]
        public void AbPrivateManagerWithPrivatesCount()
        {
            Assert.AreEqual(6, abPrivateManager.Privates().Count());
        }

        /// <summary>
        /// コンストラクタ
        /// 1 行目のテスト
        /// </summary>
        [Test]
        public void AbPrivateManagerWith1st()
        {
            var prv = abPrivateManager.Privates().ElementAt(0);
            Assert.AreEqual("2011-01", prv.Date);
            Assert.AreEqual("name1"  , prv.Name);
            Assert.AreEqual(    10000, prv.Cost);
            Assert.AreEqual(    10000, prv.Blnc);
        }

        /// <summary>
        /// コンストラクタ
        /// 2 行目のテスト
        /// </summary>
        [Test]
        public void AbPrivateManagerWith2nd()
        {
            var prv = abPrivateManager.Privates().ElementAt(1);
            Assert.AreEqual("2011-03", prv.Date);
            Assert.AreEqual("name2"  , prv.Name);
            Assert.AreEqual(   -10000, prv.Cost);
            Assert.AreEqual(        0, prv.Blnc);
        }

        /// <summary>
        /// コンストラクタ
        /// 3 行目のテスト
        /// </summary>
        [Test]
        public void AbPrivateManagerWith3rd()
        {
            var prv = abPrivateManager.Privates().ElementAt(2);
            Assert.AreEqual("2011-05", prv.Date);
            Assert.AreEqual("name3"  , prv.Name);
            Assert.AreEqual(    15000, prv.Cost);
            Assert.AreEqual(    15000, prv.Blnc);
        }

        /// <summary>
        /// コンストラクタ
        /// 4 行目のテスト
        /// </summary>
        [Test]
        public void AbPrivateManagerWith4th()
        {
            var prv = abPrivateManager.Privates().ElementAt(3);
            Assert.AreEqual("2011-09", prv.Date);
            Assert.AreEqual("name4"  , prv.Name);
            Assert.AreEqual(    30000, prv.Cost);
            Assert.AreEqual(    45000, prv.Blnc);
        }

        /// <summary>
        /// コンストラクタ
        /// 5 行目のテスト
        /// </summary>
        [Test]
        public void AbPrivateManagerWith5th()
        {
            var prv = abPrivateManager.Privates().ElementAt(4);
            Assert.AreEqual("2011-11", prv.Date);
            Assert.AreEqual("name5"  , prv.Name);
            Assert.AreEqual(   -25000, prv.Cost);
            Assert.AreEqual(    20000, prv.Blnc);
        }

        /// <summary>
        /// コンストラクタ
        /// 6 行目のテスト
        /// </summary>
        [Test]
        public void AbPrivateManagerWith6th()
        {
            var prv = abPrivateManager.Privates().ElementAt(5);
            Assert.AreEqual("2011-12", prv.Date);
            Assert.AreEqual("name6"  , prv.Name);
            Assert.AreEqual(    20000, prv.Cost);
            Assert.AreEqual(    40000, prv.Blnc);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報リストが NULL
        /// </summary>
        [Test]
        public void AbPrivateManagerWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                { new AbPrivateManager(argExpenses); }
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報リストが空
        /// </summary>
        [Test]
        public void AbPrivateManagerWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abPrivateManager = new AbPrivateManager(argExpenses);

            Assert.AreEqual(0, abPrivateManager.Privates().Count());
        }
    }
}
