namespace AbookTest
{
    using Abook;
    using System;
    using NUnit.Framework;
    using EX = Abook.AbException.EX;

    /// <summary>
    /// 収支情報テスト
    /// </summary>
    [TestFixture]
    public class AbTestBalance
    {
        /// <summary>引数:年度</summary>
        private int argYear;
        /// <summary>引数:収入</summary>
        private decimal argEarn;
        /// <summary>引数:支出</summary>
        private decimal argExpense;
        /// <summary>引数:特出</summary>
        private decimal argSpecial;
        /// <summary>引数:収支</summary>
        private decimal argBalance;
        /// <summary>対象:収支情報</summary>
        private AbBalance abBalance;

        [SetUp]
        public void SetUp()
        {
            argYear    = 2010;
            argEarn    = 2553635;
            argExpense = 1060641;
            argSpecial =   92490;
            argBalance = 1400504;

            abBalance = new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:年度のテスト
        /// </summary>
        [Test]
        public void AbBalanceWithYear()
        {
            var expected = argYear;
            Assert.AreEqual(expected, abBalance.Year);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:収入のテスト
        /// </summary>
        [Test]
        public void AbBalanceWithEarn()
        {
            var expected = argEarn;
            Assert.AreEqual(expected, abBalance.Earn);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出のテスト
        /// </summary>
        [Test]
        public void AbBalanceWithExpense()
        {
            var expected = argExpense;
            Assert.AreEqual(expected, abBalance.Expense);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:特出のテスト
        /// </summary>
        [Test]
        public void AbBalanceWithSpecial()
        {
            var expected = argSpecial;
            Assert.AreEqual(expected, abBalance.Special);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:収支のテスト
        /// </summary>
        [Test]
        public void AbBalanceWithBalance()
        {
            var expected = argBalance;
            Assert.AreEqual(expected, abBalance.Balance);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:年度がマイナス
        /// </summary>
        [Test]
        public void AbBalanceWithMinusYear()
        {
            argYear = -argYear;
            var ex = Assert.Throws<AbException>(() =>
                { new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
            Assert.AreEqual(EX.YEAR_MINUS, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:収入がマイナス
        /// </summary>
        [Test]
        public void AbBalanceWithMinusEarn()
        {
            argEarn = -argEarn;
            var ex = Assert.Throws<AbException>(() =>
                { new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
            Assert.AreEqual(EX.EARN_MINUS, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出がマイナス
        /// </summary>
        [Test]
        public void AbBalanceWithMinusExpense()
        {
            argExpense = -argExpense;
            var ex = Assert.Throws<AbException>(() =>
                { new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
            Assert.AreEqual(EX.EXPENSE_MINUS, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:特出がマイナス
        /// </summary>
        [Test]
        public void AbBalanceWithMinusSpecial()
        {
            argSpecial = -argSpecial;
            var ex = Assert.Throws<AbException>(() =>
                { new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
            Assert.AreEqual(EX.SPECIAL_MINUS, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:収支が合わない
        /// </summary>
        [Test]
        public void AbBalanceWithBalanceIncorrect()
        {
            argBalance = 0;
            var ex = Assert.Throws<AbException>(() =>
                { new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
            Assert.AreEqual(EX.BALANCE_INCORRECT, ex.Message);
        }
    }
}
