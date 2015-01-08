namespace AbookTest
{
    using Abook;
    using System;
    using NUnit.Framework;
    using EX  = Abook.AbException.EX;
    using FMT = Abook.AbConstants.FMT;

    /// <summary>
    /// 支出情報テスト
    /// </summary>
    [TestFixture]
    public class AbTestExpense
    {
        /// <summary>引数:日付</summary>
        private string argDate;
        /// <summary>引数:名称</summary>
        private string argName;
        /// <summary>引数:種別</summary>
        private string argType;
        /// <summary>引数:金額</summary>
        private string argCost;
        /// <summary>対象:支出情報</summary>
        private AbExpense abExpense;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argDate = "2011-03-01";
            argName = "おにぎり";
            argType = "食費";
            argCost = "105";
            abExpense = new AbExpense(argDate, argName, argType, argCost);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:日付のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithDate()
        {
            var expected = DateTime.Parse(argDate);
            Assert.AreEqual(expected, abExpense.Date);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:名称のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithName()
        {
            var expected = argName;
            Assert.AreEqual(expected, abExpense.Name);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:種別のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithType()
        {
            var expected = argType;
            Assert.AreEqual(expected, abExpense.Type);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額のテスト
        /// </summary>
        [Test]
        public void AbExpenseWithCost()
        {
            var expected = decimal.Parse(argCost);
            Assert.AreEqual(expected, abExpense.Cost);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:日付がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullDate()
        {
            argDate = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.DATE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:日付が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyDate()
        {
            argDate = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.DATE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:日付の形式が不正
        /// </summary>
        [Test]
        public void AbExpenseWithInvalidDate()
        {
            argDate = "invalid";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.DATE_FORMAT, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:名称がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullName()
        {
            argName = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.NAME_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:名称が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyName()
        {
            argName = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.NAME_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:種別がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullType()
        {
            argType = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.TYPE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:種別が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyType()
        {
            argType = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.TYPE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:種別が不正
        /// </summary>
        [Test]
        public void AbExpenseWithWrongType()
        {
            argType = "wrong";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.TYPE_WRONG, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額がNULL
        /// </summary>
        [Test]
        public void AbExpenseWithNullCost()
        {
            argCost = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額が空文字列
        /// </summary>
        [Test]
        public void AbExpenseWithEmptyCost()
        {
            argCost = string.Empty;
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額の形式が不正
        /// </summary>
        [Test]
        public void AbExpenseWithInvalidCost()
        {
            argCost = "invalid";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_FORMAT, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額がマイナス
        /// </summary>
        [Test]
        public void AbExpenseWithMinusCost()
        {
            argCost = "-100";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_MINUS, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額がオーバーフロー
        /// </summary>
        [Test]
        public void AbExpenseWithOverflowCost()
        {
            argCost = Convert.ToString(decimal.MaxValue) + "0";
            var ex = Assert.Throws<AbException>(() =>
                new AbExpense(argDate, argName, argType, argCost)
            );
            Assert.AreEqual(EX.COST_OVERFLOW, ex.Message);
        }

        /// <summary>
        /// CSV形式
        /// </summary>
        [Test]
        public void ToCSV()
        {
            var expected = string.Format(FMT.CSV, argDate, argName, argType, argCost);
            Assert.AreEqual(expected, abExpense.ToCSV());
        }

        /// <summary>
        /// SQL形式
        /// </summary>
        [Test]
        public void ToSQL()
        {
            var type = AbUtilities.ToTypeId(argType);
            var expected = string.Format(FMT.SQL, argDate, argName, type, argCost);
            Assert.AreEqual(expected, abExpense.ToSQL());
        }
    }
}
