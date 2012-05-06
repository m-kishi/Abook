namespace AbookTest
{
    using Abook;
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;
    using EX   = Abook.AbException.EX;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 自動補完テスト
    /// </summary>
    [TestFixture]
    public class AbTestComplete
    {
        /// <summary>引数:支出レコードリスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>対象:自動補完</summary>
        private AbComplete abComplete;

        [SetUp]
        public void SetUp()
        {
            argExpenses = GenerateExpenses();
            abComplete = new AbComplete(argExpenses);
        }

        /// <summary>
        /// 支出レコードリスト生成
        /// </summary>
        /// <returns>支出レコードリスト</returns>
        private List<AbExpense> GenerateExpenses()
        {
            var expenses = new List<AbExpense>();
            expenses.Add(new AbExpense("2012-04-01", "name1", TYPE.FOOD, "0"));
            expenses.Add(new AbExpense("2012-04-01", "name2", TYPE.FOOD, "0"));
            expenses.Add(new AbExpense("2012-04-02", "name2", TYPE.OTFD, "0"));
            expenses.Add(new AbExpense("2012-04-03", "name2", TYPE.OTFD, "0"));
            expenses.Add(new AbExpense("2012-04-05", "name3", TYPE.GOOD, "0"));
            expenses.Add(new AbExpense("2012-04-08", "name3", TYPE.GOOD, "0"));
            expenses.Add(new AbExpense("2012-04-10", "name3", TYPE.FRND, "0"));
            expenses.Add(new AbExpense("2012-04-11", "name3", TYPE.FRND, "0"));
            expenses.Add(new AbExpense("2012-04-11", "name4", TYPE.FOOD, "0"));
            expenses.Add(new AbExpense("2012-04-12", "name4", TYPE.FOOD, "0"));
            expenses.Add(new AbExpense("2012-04-23", "name5", TYPE.OTFD, "0"));
            expenses.Add(new AbExpense("2012-04-23", "name5", TYPE.PLAY, "0"));
            expenses.Add(new AbExpense("2012-04-30", "name5", TYPE.PLAY, "0"));
            return expenses;
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出レコードリストが NULL
        /// </summary>
        [Test]
        public void AbCompleteWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                { new AbComplete(argExpenses); }
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// 種別取得
        /// 引数:名称が NULL
        /// </summary>
        [Test]
        public void GetTypeWithNullName()
        {
            Assert.AreEqual(string.Empty, abComplete.GetType(null));
        }

        /// <summary>
        /// 種別取得
        /// 引数:名称が空文字列
        /// </summary>
        [Test]
        public void GetTypeWithEmptyName()
        {
            Assert.AreEqual(string.Empty, abComplete.GetType(string.Empty));
        }

        /// <summary>
        /// 種別取得
        /// 支出レコードが空リスト
        /// </summary>
        [Test]
        public void GetTypeWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abComplete = new AbComplete(argExpenses);

            Assert.AreEqual(string.Empty, abComplete.GetType("name1"));
            Assert.AreEqual(string.Empty, abComplete.GetType("name2"));
            Assert.AreEqual(string.Empty, abComplete.GetType("name3"));
            Assert.AreEqual(string.Empty, abComplete.GetType("name4"));
            Assert.AreEqual(string.Empty, abComplete.GetType("name5"));
            Assert.AreEqual(string.Empty, abComplete.GetType("not match"));
        }

        /// <summary>
        /// 種別取得
        /// 複数パターンのテスト
        /// </summary>
        [Test]
        public void GetTypeWithName()
        {
            Assert.AreEqual(TYPE.FOOD, abComplete.GetType("name1"));
            Assert.AreEqual(TYPE.OTFD, abComplete.GetType("name2"));
            Assert.AreEqual(TYPE.GOOD + " " + TYPE.FRND, abComplete.GetType("name3"));
            Assert.AreEqual(TYPE.FOOD, abComplete.GetType("name4"));
            Assert.AreEqual(TYPE.PLAY, abComplete.GetType("name5"));
            Assert.AreEqual(string.Empty, abComplete.GetType("not match"));
        }
    }
}
