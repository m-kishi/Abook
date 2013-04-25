namespace AbookTest
{
    using Abook;
    using System;
    using NUnit.Framework;
    using EX   = Abook.AbException.EX;
    using FMT  = Abook.AbConstants.FMT;
    using TYPE = Abook.AbConstants.TYPE;

    /// <summary>
    /// 秘密収支情報テスト
    /// </summary>
    [TestFixture]
    public class AbTestPrivate
    {
        /// <summary>引数:収支</summary>
        private decimal argBalance;
        /// <summary>引数:支出情報</summary>
        private AbExpense argExpense;
        /// <summary>対象:秘密収支情報</summary>
        private AbPrivate abPrivate;

        [SetUp]
        public void SetUp()
        {
            argBalance = 300;
            argExpense = new AbExpense("2012-04-01", "小遣い", TYPE.PRVI, "5000");
            abPrivate  = new AbPrivate(argExpense, argBalance);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:年月のテスト
        /// </summary>
        [Test]
        public void AbPrivateWithDate()
        {
            var date = argExpense.Date.ToString(FMT.YEAR_MONTH);
            Assert.AreEqual(date, abPrivate.Date);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:名称のテスト
        /// </summary>
        [Test]
        public void AbPrivateWithName()
        {
            Assert.AreEqual("小遣い", abPrivate.Name);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額(秘密入)のテスト
        /// </summary>
        [Test]
        public void AbPrivateWithCostWithPrvI()
        {
            argExpense = new AbExpense("2012-04-01", "小遣い", TYPE.PRVI, "5000");
            abPrivate  = new AbPrivate(argExpense, argBalance);

            Assert.AreEqual(5000, abPrivate.Cost);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:金額(秘密出)のテスト
        /// </summary>
        [Test]
        public void AbPrivateWithCostWithPrvO()
        {
            argExpense = new AbExpense("2012-04-01", "小遣い", TYPE.PRVO, "5000");
            abPrivate  = new AbPrivate(argExpense, argBalance);

            Assert.AreEqual(-5000, abPrivate.Cost);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:収支のテスト
        /// </summary>
        [Test]
        public void AbPrivateWithBalance()
        {
            Assert.AreEqual(5300, abPrivate.Blnc);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:収支レコードが NULL
        /// </summary>
        [Test]
        public void AbPrivateWithNullExpense()
        {
            argExpense = null;
            var ex = Assert.Throws<AbException>(() =>
                { new AbPrivate(argExpense, argBalance); }
            );
            Assert.AreEqual(EX.EXPENSE_NULL, ex.Message);
        }

        /// <summary>
        /// コンストラクタ
        /// 引数:収支レコードの種別が不正
        ///      "秘密入"でも"秘密出"でもない
        /// </summary>
        [Test]
        public void AbPrivateWithInvalidType()
        {
            argExpense = new AbExpense("2012-04-01", "小遣い", TYPE.FOOD, "100");
            var ex = Assert.Throws<AbException>(() =>
                { new AbPrivate(argExpense, argBalance); }
            );
            Assert.AreEqual(EX.TYPE_PRIVATE_ERR, ex.Message);
        }
    }
}
