// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
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
        /// <summary>引数:投資</summary>
        private decimal argFinance;
        /// <summary>対象:収支情報</summary>
        private AbBalance abBalance;
        /// <summary>対象:収支情報</summary>
        private AbBalance abBalance2;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argYear    = 2010;
            argEarn    = 2553635;
            argExpense = 1060641;
            argSpecial =   92490;
            argBalance = 1400504;
            argFinance = 3600000;
            abBalance = new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance);
            abBalance2 = new AbBalance(argYear, argFinance);
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
        /// 引数:投資のテスト
        /// </summary>
        [Test]
        public void AbBalanceWithFinance()
        {
            Assert.AreEqual(0, abBalance.Finance);
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
                new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance)
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
                new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance)
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
                new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance)
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
                new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance)
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
                new AbBalance(argYear, argEarn, argExpense, argSpecial, argBalance)
            );
            Assert.AreEqual(EX.BALANCE_INCORRECT, ex.Message);
        }

        /// <summary>
        /// コンストラクタ2
        /// 引数:年度のテスト
        /// </summary>
        [Test]
        public void AbBalance2WithYear()
        {
            var expected = argYear;
            Assert.AreEqual(expected, abBalance2.Year);
        }

        /// <summary>
        /// コンストラクタ2
        /// 収入のテスト
        /// </summary>
        [Test]
        public void AbBalance2WithEarn()
        {
            Assert.AreEqual(0, abBalance2.Earn);
        }

        /// <summary>
        /// コンストラクタ2
        /// 支出のテスト
        /// </summary>
        [Test]
        public void AbBalance2WithExpense()
        {
            Assert.AreEqual(0, abBalance2.Expense);
        }

        /// <summary>
        /// コンストラクタ2
        /// 特出のテスト
        /// </summary>
        [Test]
        public void AbBalance2WithSpecial()
        {
            Assert.AreEqual(0, abBalance2.Special);
        }

        /// <summary>
        /// コンストラクタ2
        /// 収支のテスト
        /// </summary>
        [Test]
        public void AbBalance2WithBalance()
        {
            Assert.AreEqual(0, abBalance2.Balance);
        }

        /// <summary>
        /// コンストラクタ2
        /// 引数:投資のテスト
        /// </summary>
        [Test]
        public void AbBalance2WithFinance()
        {
            var expected = argFinance;
            Assert.AreEqual(expected, abBalance2.Finance);
        }

        /// <summary>
        /// 投資設定のテスト
        /// </summary>
        [Test]
        public void SetFinance()
        {
            abBalance.SetFinance(argFinance);
            Assert.AreEqual(argFinance, abBalance.Finance);
        }

        /// <summary>
        /// 投資設定のテスト
        /// 引数:投資がマイナス
        /// </summary>
        [Test]
        public void SetFinanceWithMinusFinance()
        {
            argFinance = -argFinance;
            var ex = Assert.Throws<AbException>(() =>
                abBalance.SetFinance(argFinance)
            );
            Assert.AreEqual(EX.FINANCE_MINUS, ex.Message);
        }
    }
}
