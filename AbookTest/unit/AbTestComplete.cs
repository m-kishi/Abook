// ------------------------------------------------------------
// © 2010 Masaaki Kishi
// ------------------------------------------------------------
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
        /// <summary>引数:支出情報リスト</summary>
        private List<AbExpense> argExpenses;
        /// <summary>対象:自動補完</summary>
        private AbComplete abComplete;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argExpenses = GenerateExpenses();
            abComplete = new AbComplete(argExpenses);
        }

        /// <summary>
        /// 支出情報リスト生成
        /// </summary>
        /// <returns>支出情報リスト</returns>
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

            expenses.Add(new AbExpense("2017-02-01", "name0", TYPE.FOOD, "0"));
            expenses.Add(new AbExpense("2017-02-01", "name0", TYPE.OTFD, "100"));
            expenses.Add(new AbExpense("2017-02-01", "name0", TYPE.GOOD, "1000"));
            expenses.Add(new AbExpense("2017-02-01", "name0", TYPE.FRND, "10000"));
            expenses.Add(new AbExpense("2017-02-01", "name0", TYPE.TRFC, "100000"));
            expenses.Add(new AbExpense("2017-02-01", "name0", TYPE.PLAY, "1000000"));

            expenses.Add(new AbExpense("2017-03-01", "name6", TYPE.FOOD,  "100"));
            expenses.Add(new AbExpense("2017-03-02", "name7", TYPE.FOOD,  "100"));
            expenses.Add(new AbExpense("2017-03-02", "name7", TYPE.FOOD,  "200"));
            expenses.Add(new AbExpense("2017-03-03", "name8", TYPE.FOOD,  "100"));
            expenses.Add(new AbExpense("2017-03-03", "name8", TYPE.FOOD,  "200"));
            expenses.Add(new AbExpense("2017-03-03", "name8", TYPE.FOOD,  "300"));
            expenses.Add(new AbExpense("2017-03-04", "name9", TYPE.FOOD,  "100"));
            expenses.Add(new AbExpense("2017-03-04", "name9", TYPE.FOOD,  "200"));
            expenses.Add(new AbExpense("2017-03-04", "name9", TYPE.FOOD,  "300"));
            expenses.Add(new AbExpense("2017-03-04", "name9", TYPE.FOOD,  "400"));
            expenses.Add(new AbExpense("2017-03-05", "nameA", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-05", "nameA", TYPE.OTFD, "2000"));
            expenses.Add(new AbExpense("2017-03-06", "nameB", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-06", "nameB", TYPE.FOOD, "2000"));
            expenses.Add(new AbExpense("2017-03-06", "nameB", TYPE.OTFD, "3000"));
            expenses.Add(new AbExpense("2017-03-06", "nameB", TYPE.OTFD, "4000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.FOOD, "2000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.FOOD, "3000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.OTFD, "4000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.OTFD, "5000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.OTFD, "6000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.GOOD, "7000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.GOOD, "8000"));
            expenses.Add(new AbExpense("2017-03-07", "nameC", TYPE.GOOD, "9000"));
            expenses.Add(new AbExpense("2017-03-08", "nameD", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-08", "nameD", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-08", "nameD", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-09", "nameE", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-09", "nameE", TYPE.FOOD, "2000"));
            expenses.Add(new AbExpense("2017-03-09", "nameE", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-09", "nameE", TYPE.FOOD, "2000"));
            expenses.Add(new AbExpense("2017-03-09", "nameE", TYPE.FOOD, "1000"));
            expenses.Add(new AbExpense("2017-03-09", "nameE", TYPE.FOOD, "2000"));
            expenses.Add(new AbExpense("2017-03-31", "nameX", TYPE.FOOD,    "0"));
            
            return expenses;
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報リストがNULL
        /// </summary>
        [Test]
        public void AbCompleteWithNullExpenses()
        {
            argExpenses = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbComplete(argExpenses)
            );
            Assert.AreEqual(EX.EXPENSES_NULL, ex.Message);
        }

        /// <summary>
        /// 種別取得
        /// 引数:名称がNULL
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
        /// 支出情報が空リスト
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

        /// <summary>
        /// 金額取得
        /// 引数:名称がNULL
        /// </summary>
        [Test]
        public void GetCostWithNullName()
        {
            Assert.AreEqual(string.Empty, abComplete.GetCost(null, TYPE.FOOD));
        }

        /// <summary>
        /// 金額取得
        /// 引数:名称が空文字列
        /// </summary>
        [Test]
        public void GetCostWithEmptyName()
        {
            Assert.AreEqual(string.Empty, abComplete.GetCost(string.Empty, TYPE.FOOD));
        }

        /// <summary>
        /// 金額取得
        /// 引数:種別がNULL
        /// </summary>
        [Test]
        public void GetCostWithNullType()
        {
            Assert.AreEqual(string.Empty, abComplete.GetCost("name1", null));
        }

        /// <summary>
        /// 金額取得
        /// 引数:種別が空文字列
        /// </summary>
        [Test]
        public void GetCostWithEmptyType()
        {
            Assert.AreEqual(string.Empty, abComplete.GetCost("name1", string.Empty));
        }

        /// <summary>
        /// 金額取得
        /// 支出情報が空リスト
        /// </summary>
        [Test]
        public void GetCostWithEmptyExpenses()
        {
            argExpenses = new List<AbExpense>();
            abComplete = new AbComplete(argExpenses);

            Assert.AreEqual(string.Empty, abComplete.GetCost("name1", TYPE.FOOD));
            Assert.AreEqual(string.Empty, abComplete.GetCost("name2", TYPE.OTFD));
            Assert.AreEqual(string.Empty, abComplete.GetCost("name3", TYPE.GOOD));
            Assert.AreEqual(string.Empty, abComplete.GetCost("name4", TYPE.FOOD));
            Assert.AreEqual(string.Empty, abComplete.GetCost("name5", TYPE.PLAY));
            Assert.AreEqual(string.Empty, abComplete.GetCost("not match", TYPE.FOOD));
        }

        /// <summary>
        /// 金額取得
        /// 金額のカンマ編集
        /// </summary>
        [TestCase("name0", TYPE.FOOD,         "0")]
        [TestCase("name0", TYPE.OTFD,       "100")]
        [TestCase("name0", TYPE.GOOD,     "1,000")]
        [TestCase("name0", TYPE.FRND,    "10,000")]
        [TestCase("name0", TYPE.TRFC,   "100,000")]
        [TestCase("name0", TYPE.PLAY, "1,000,000")]
        public void GetCostFormatedComma(string name, string type, string expected)
        {
            Assert.AreEqual(expected, abComplete.GetCost(name, type));
        }

        /// <summary>
        /// 金額取得
        /// 複数パターンのテスト
        /// </summary>
        [TestCase("name6", TYPE.FOOD, "100")]
        [TestCase("name7", TYPE.FOOD, "200/100")]
        [TestCase("name8", TYPE.FOOD, "300/200/100")]
        [TestCase("name9", TYPE.FOOD, "400/300/200")]
        [TestCase("nameA", TYPE.FOOD, "1,000")]
        [TestCase("nameB", TYPE.OTFD, "4,000/3,000")]
        [TestCase("nameC", TYPE.GOOD, "9,000/8,000/7,000")]
        [TestCase("nameD", TYPE.FOOD, "1,000")]
        [TestCase("nameE", TYPE.FOOD, "2,000/1,000")]
        [TestCase("nameX", TYPE.OTFD, "")]
        [TestCase("nameZ", TYPE.FOOD, "")]
        public void GetCostWithName(string name, string type, string expected)
        {
            Assert.AreEqual(expected, abComplete.GetCost(name, type));
        }
    }
}
