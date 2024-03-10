// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using EX   = Abook.AbException.EX;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 収支情報管理テスト
    /// </summary>
    [TestFixture]
    public class AbTestBalanceManager
    {
        /// <summary>引数:支出情報リスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>対象:収支情報管理</summary>
        private AbBalanceManager abBalanceManager;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argExpenses = GenerateExpenses();
            abBalanceManager = new AbBalanceManager(argExpenses);
        }

        /// <summary>
        /// 支出情報リスト生成
        /// </summary>
        /// <returns>支出情報リスト</returns>
        private List<AbExpense> GenerateExpenses()
        {
            var expenses = new List<AbExpense>();
            expenses.Add(new AbExpense("2011-04-01", "nameY", TYPE.PRVI,  "10000"));
            expenses.Add(new AbExpense("2011-04-01", "name1", TYPE.FOOD,  "90000"));
            expenses.Add(new AbExpense("2011-04-30", "name2", TYPE.EARN, "100000"));
            expenses.Add(new AbExpense("2011-05-01", "name3", TYPE.SPCL,  "60000"));
            expenses.Add(new AbExpense("2011-05-02", "name4", TYPE.OTFD,  "80000"));
            expenses.Add(new AbExpense("2011-05-31", "name5", TYPE.EARN, "200000"));
            expenses.Add(new AbExpense("2011-08-01", "name6", TYPE.SPCL,  "30000"));
            expenses.Add(new AbExpense("2011-08-03", "name7", TYPE.GOOD,  "70000"));
            expenses.Add(new AbExpense("2011-08-31", "name8", TYPE.EARN, "300000"));
            expenses.Add(new AbExpense("2011-08-31", "nameX", TYPE.BNUS, "150000"));
            expenses.Add(new AbExpense("2011-11-10", "name9", TYPE.TRFC,  "60000"));
            expenses.Add(new AbExpense("2011-11-11", "name1", TYPE.FRND,  "50000"));
            expenses.Add(new AbExpense("2011-11-30", "name2", TYPE.EARN, "400000"));
            expenses.Add(new AbExpense("2011-12-12", "name3", TYPE.PLAY,  "40000"));
            expenses.Add(new AbExpense("2011-12-31", "nameY", TYPE.PRVI,  "10000"));
            expenses.Add(new AbExpense("2012-01-01", "name4", TYPE.HOUS,  "30000"));
            expenses.Add(new AbExpense("2012-01-01", "name5", TYPE.SPCL,  "40000"));
            expenses.Add(new AbExpense("2012-02-28", "name6", TYPE.EARN, "500000"));
            expenses.Add(new AbExpense("2012-02-28", "nameX", TYPE.BNUS,  "70000"));
            expenses.Add(new AbExpense("2012-04-01", "name7", TYPE.ENGY,  "20000"));
            expenses.Add(new AbExpense("2012-04-02", "name8", TYPE.EARN, "100000"));
            expenses.Add(new AbExpense("2012-04-03", "name9", TYPE.SPCL,  "50000"));
            expenses.Add(new AbExpense("2012-05-03", "name1", TYPE.CNCT,  "10000"));
            expenses.Add(new AbExpense("2012-05-04", "name2", TYPE.EARN, "200000"));
            expenses.Add(new AbExpense("2012-06-05", "name3", TYPE.MEDI,  "90000"));
            expenses.Add(new AbExpense("2012-06-06", "name4", TYPE.EARN, "300000"));
            expenses.Add(new AbExpense("2013-03-07", "name5", TYPE.INSU,  "80000"));
            expenses.Add(new AbExpense("2013-03-08", "name6", TYPE.OTHR,  "70000"));
            expenses.Add(new AbExpense("2013-03-09", "name7", TYPE.SPCL,  "60000"));
            expenses.Add(new AbExpense("2013-03-31", "name8", TYPE.EARN, "400000"));
            expenses.Add(new AbExpense("2013-03-31", "nameX", TYPE.BNUS, "250000"));
            expenses.Add(new AbExpense("2013-03-31", "nameY", TYPE.PRVO,   "5000"));
            expenses.Add(new AbExpense("2012-12-31", "nameZ", TYPE.FNCE, "1000000"));
            expenses.Add(new AbExpense("2013-03-31", "nameZ", TYPE.FNCE, "2000000"));
            return expenses;
        }

        /// <summary>
        /// コンストラクタ
        /// 年度数のテスト
        /// </summary>
        [Test]
        public void AbBalanceManagerWithBalancesCount()
        {
            Assert.AreEqual(4, abBalanceManager.Balances().Count());
        }

        /// <summary>
        /// コンストラクタ
        /// 2011年度のテスト
        /// </summary>
        [Test]
        public void AbBalanceManagerWith_2011_Year()
        {
            var balance = abBalanceManager.Balances().ElementAt(0);
            Assert.AreEqual(2011, balance.Year);
            Assert.AreEqual(1720000, balance.Earn);
            Assert.AreEqual( 420000, balance.Expense);
            Assert.AreEqual( 130000, balance.Special);
            Assert.AreEqual(1170000, balance.Balance);
            Assert.AreEqual(      0, balance.Finance);
        }

        /// <summary>
        /// コンストラクタ
        /// 2012年度のテスト
        /// </summary>
        [Test]
        public void AbBalanceManagerWith_2012_Year()
        {
            var balance = abBalanceManager.Balances().ElementAt(1);
            Assert.AreEqual(2012, balance.Year);
            Assert.AreEqual(1250000, balance.Earn);
            Assert.AreEqual( 270000, balance.Expense);
            Assert.AreEqual( 110000, balance.Special);
            Assert.AreEqual( 870000, balance.Balance);
            Assert.AreEqual(1000000, balance.Finance);
        }

        /// <summary>
        /// コンストラクタ
        /// 2013年度のテスト
        /// </summary>
        [Test]
        public void AbBalanceManagerWith_2013_Year()
        {
            var balance = abBalanceManager.Balances().ElementAt(2);
            Assert.AreEqual(2013, balance.Year);
            Assert.AreEqual(      0, balance.Earn);
            Assert.AreEqual(      0, balance.Expense);
            Assert.AreEqual(      0, balance.Special);
            Assert.AreEqual(      0, balance.Balance);
            Assert.AreEqual(2000000, balance.Finance);
        }

        /// <summary>
        /// コンストラクタ
        /// 年度合計のテスト
        /// </summary>
        [Test]
        public void AbBalanceManagerWithTotalYear()
        {
            var balance = abBalanceManager.Balances().ElementAt(3);
            Assert.AreEqual(9999, balance.Year);
            Assert.AreEqual(2970000, balance.Earn);
            Assert.AreEqual( 690000, balance.Expense);
            Assert.AreEqual( 240000, balance.Special);
            Assert.AreEqual(2040000, balance.Balance);
            Assert.AreEqual(3000000, balance.Finance);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報リストがNULL
        /// </summary>
        [Test]
        public void AbBalanceManagerWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbBalanceManager(argExpenses)
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報リストが空
        /// </summary>
        [Test]
        public void AbBalanceManagerWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abBalanceManager = new AbBalanceManager(argExpenses);

            Assert.AreEqual(0, abBalanceManager.Balances().Count());
        }
    }
}
