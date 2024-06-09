// ------------------------------------------------------------
// © 2010 https://github.com/m-kishi
// ------------------------------------------------------------
namespace AbookTest
{
    using Abook;
    using System;
    using NUnit.Framework;
    using EX   = Abook.AbException.EX;
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 投資情報テスト
    /// </summary>
    [TestFixture]
    public class AbTestFinance
    {
        /// <summary>引数:累計</summary>
        private decimal argTotal;
        /// <summary>引数:支出情報</summary>
        private AbExpense argExpense;
        /// <summary>対象:投資情報</summary>
        private AbFinance abFinance;

        /// <summary>
        /// SetUp
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            argTotal = 300;
            argExpense = new AbExpense("2024-06-01", "NISA", TYPE.FNCE, "50000", "備考");
            abFinance  = new AbFinance(argExpense, argTotal);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:日付のテスト
        /// </summary>
        [Test]
        public void AbFinanceWithDate()
        {
            var expected = DateTime.Parse("2024-06-01");
            Assert.AreEqual(expected, abFinance.Date);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:名称のテスト
        /// </summary>
        [Test]
        public void AbFinanceWithName()
        {
            Assert.AreEqual("NISA", abFinance.Name);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額のテスト
        /// </summary>
        [Test]
        public void AbFinanceWithCostWithPrvI()
        {
            Assert.AreEqual(50000, abFinance.Cost);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:累計のテスト
        /// </summary>
        [Test]
        public void AbFinanceWithBalance()
        {
            Assert.AreEqual(50300, abFinance.Ttal);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報がNULL
        /// </summary>
        [Test]
        public void AbFinanceWithNullExpense()
        {
            argExpense = null;
            var ex = Assert.Throws<AbException>(() =>
                new AbFinance(argExpense, argTotal)
            );
            Assert.AreEqual(EX.EXPENSE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:支出情報の種別が不正
        /// </summary>
        [Test]
        public void AbFinanceWithInvalidType()
        {
            argExpense = new AbExpense("2024-06-01", "NISA", TYPE.FOOD, "100");
            var ex = Assert.Throws<AbException>(() =>
                new AbFinance(argExpense, argTotal)
            );
            Assert.AreEqual(EX.TYPE_FINANCE_ERR, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:備考のテスト
        /// </summary>
        [Test]
        public void AbFinanceWithNote()
        {
            Assert.AreEqual("備考", abFinance.Note);
        }
    }
}
