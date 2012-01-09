namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// 特別支出管理テスト
    /// </summary>
    [TestFixture]
    public class AbTestSpecialManager
    {
        private List<AbExpense> argExpenses;
        private AbSpecialManager abSpecialManager;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argExpenses = GenerateExpenses();
            abSpecialManager = new AbSpecialManager(argExpenses);
        }

        /// <summary>
        /// 支出リスト生成
        /// </summary>
        /// <returns>支出リスト</returns>
        private List<AbExpense> GenerateExpenses()
        {
            var expenses = new List<AbExpense>();
            expenses.Add(new AbExpense("2011-04-01", "name1", "食費"  , "90000"));
            expenses.Add(new AbExpense("2011-04-30", "name2", "収入"  , "100000"));
            expenses.Add(new AbExpense("2011-05-01", "name3", "特出"  , "60000"));
            expenses.Add(new AbExpense("2011-05-02", "name4", "外食費", "80000"));
            expenses.Add(new AbExpense("2011-05-31", "name5", "収入"  , "200000"));
            expenses.Add(new AbExpense("2011-08-01", "name6", "特出"  , "30000"));
            expenses.Add(new AbExpense("2011-08-03", "name7", "雑貨"  , "70000"));
            expenses.Add(new AbExpense("2011-08-31", "name8", "収入"  , "300000"));
            expenses.Add(new AbExpense("2011-11-10", "name9", "交通費", "60000"));
            expenses.Add(new AbExpense("2011-11-11", "name1", "交際費", "50000"));
            expenses.Add(new AbExpense("2011-11-30", "name2", "収入"  , "400000"));
            expenses.Add(new AbExpense("2011-12-12", "name3", "遊行費", "40000"));
            expenses.Add(new AbExpense("2012-01-01", "name4", "家賃"  , "30000"));
            expenses.Add(new AbExpense("2012-01-01", "name5", "特出"  , "40000"));
            expenses.Add(new AbExpense("2012-02-28", "name6", "収入"  , "500000"));
            expenses.Add(new AbExpense("2012-04-01", "name7", "光熱費", "20000"));
            expenses.Add(new AbExpense("2012-04-02", "name8", "収入"  , "100000"));
            expenses.Add(new AbExpense("2012-04-03", "name9", "特出"  , "50000"));
            expenses.Add(new AbExpense("2012-05-03", "name1", "通信費", "10000"));
            expenses.Add(new AbExpense("2012-05-04", "name2", "収入"  , "200000"));
            expenses.Add(new AbExpense("2012-06-05", "name3", "医療費", "90000"));
            expenses.Add(new AbExpense("2012-06-06", "name4", "収入"  , "300000"));
            expenses.Add(new AbExpense("2013-03-07", "name5", "保険料", "80000"));
            expenses.Add(new AbExpense("2013-03-08", "name6", "その他", "70000"));
            expenses.Add(new AbExpense("2013-03-09", "name7", "特出"  , "60000"));
            expenses.Add(new AbExpense("2013-03-31", "name8", "収入"  , "400000"));
            return expenses;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Test]
        public void NewWithEnumeratorsCount()
        {
            Assert.AreEqual(3, abSpecialManager.GetEnumerator().Count());
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Test]
        public void NewWithFirst()
        {
            var first = abSpecialManager.GetEnumerator().ElementAt(0);
            Assert.AreEqual(first.Year, 2011);
            Assert.AreEqual(first.Earn, 1500000);
            Assert.AreEqual(first.Expense, 420000);
            Assert.AreEqual(first.Special, 130000);
            Assert.AreEqual(first.Balance, 950000);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Test]
        public void NewWithSecond()
        {
            var second = abSpecialManager.GetEnumerator().ElementAt(1);
            Assert.AreEqual(second.Year, 2012);
            Assert.AreEqual(second.Earn, 1000000);
            Assert.AreEqual(second.Expense, 270000);
            Assert.AreEqual(second.Special, 110000);
            Assert.AreEqual(second.Balance, 620000);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        [Test]
        public void NewWithTotal()
        {
            var total = abSpecialManager.GetEnumerator().ElementAt(2);
            Assert.AreEqual(total.Year, 9999);
            Assert.AreEqual(total.Earn, 2500000);
            Assert.AreEqual(total.Expense, 690000);
            Assert.AreEqual(total.Special, 240000);
            Assert.AreEqual(total.Balance, 1570000);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出リストが NULL
        /// </summary>
        [Test]
        public void NewWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<ArgumentException>(
                () => { new AbSpecialManager(argExpenses); }
            );
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出リストが空
        /// </summary>
        [Test]
        public void NewWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abSpecialManager = new AbSpecialManager(argExpenses);

            Assert.AreEqual(0, abSpecialManager.GetEnumerator().Count());
        }
    }
}
