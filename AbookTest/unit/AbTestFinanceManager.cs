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
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 投資情報管理テスト
    /// </summary>
    public class AbTestFinanceManager
    {
        /// <summary>引数:支出情報リスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>対象:投資情報管理</summary>
        private AbFinanceManager abFinanceManager;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argExpenses = GenerateExpenses();
            abFinanceManager = new AbFinanceManager(argExpenses);
        }

        /// <summary>
        /// 支出情報リスト生成
        /// </summary>
        /// <returns>支出情報リスト</returns>
        private List<AbExpense> GenerateExpenses()
        {
            var expenses = new List<AbExpense>();
            expenses.Add(new AbExpense("2024-01-10", "name1", TYPE.FNCE, "10000", "note1"));
            expenses.Add(new AbExpense("2024-01-31", "name0", TYPE.FOOD, "20000"));
            expenses.Add(new AbExpense("2024-02-20", "name2", TYPE.FNCE, "30000", "note2"));
            expenses.Add(new AbExpense("2024-03-31", "name0", TYPE.FOOD, "40000"));
            expenses.Add(new AbExpense("2024-04-20", "name3", TYPE.FNCE, "50000", "note3"));
            expenses.Add(new AbExpense("2024-05-20", "name4", TYPE.FNCE, "60000"));
            expenses.Add(new AbExpense("2024-06-20", "name5", TYPE.FNCE, "70000"));
            expenses.Add(new AbExpense("2024-07-20", "name6", TYPE.FNCE, "80000"));
            expenses.Add(new AbExpense("2024-08-20", "name7", TYPE.FNCE, "90000"));
            expenses.Add(new AbExpense("2024-09-20", "name8", TYPE.FNCE, "11000"));
            expenses.Add(new AbExpense("2024-10-31", "name9", TYPE.FNCE, "22000"));
            return expenses;
        }

        /// <summary>
        /// コンストラクタ
        /// 要素数のテスト
        /// </summary>
        [Test]
        public void AbFinanceManagerWithFinancesCount()
        {
            Assert.AreEqual(9, abFinanceManager.Finances().Count());
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="idx"  >行  </param>
        /// <param name="date" >日付</param>
        /// <param name="name" >名称</param>
        /// <param name="cost" >金額</param>
        /// <param name="total">累計</param>
        /// <param name="note" >備考</param>
        [TestCase(0, "2024-01-10", "name1", 10000,  10000, "note1")]
        [TestCase(1, "2024-02-20", "name2", 30000,  40000, "note2")]
        [TestCase(2, "2024-04-20", "name3", 50000,  90000, "note3")]
        [TestCase(3, "2024-05-20", "name4", 60000, 150000, "")]
        [TestCase(4, "2024-06-20", "name5", 70000, 220000, "")]
        [TestCase(5, "2024-07-20", "name6", 80000, 300000, "")]
        [TestCase(6, "2024-08-20", "name7", 90000, 390000, "")]
        [TestCase(7, "2024-09-20", "name8", 11000, 401000, "")]
        [TestCase(8, "2024-10-31", "name9", 22000, 423000, "")]
        public void AbFinanceManager(int idx, string date, string name, decimal cost, decimal total, string note)
        {
            var fnc = abFinanceManager.Finances().ElementAt(idx);
            Assert.AreEqual(date , fnc.Date.ToString(FMT.DATE));
            Assert.AreEqual(name , fnc.Name);
            Assert.AreEqual(cost , fnc.Cost);
            Assert.AreEqual(total, fnc.Ttal);
            Assert.AreEqual(note , fnc.Note);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報リストがNULL
        /// </summary>
        [Test]
        public void AbFinanceManagerWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbFinanceManager(argExpenses)
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報リストが空
        /// </summary>
        [Test]
        public void AbFinanceManagerWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abFinanceManager = new AbFinanceManager(argExpenses);

            Assert.AreEqual(0, abFinanceManager.Finances().Count());
        }
    }
}
