namespace Abook
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// 特別支出テスト
    /// </summary>
    [TestFixture]
    public class AbTestSpecial
    {
        private int argYear;
        private int argEarn;
        private int argExpense;
        private int argSpecial;
        private int argBalance;

        private AbSpecial abSpecial;

        [SetUp]
        public void SetUp()
        {
            argYear    = 2010;
            argEarn    = 2553635;
            argExpense = 1060641;
            argSpecial =   92490;
            argBalance = 1400504;

            abSpecial = new AbSpecial(argYear, argEarn, argExpense, argSpecial, argBalance);
        }

        [Test]
        public void AbSpecialWithMinusYear()
        {
            argYear = -argYear;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbSpecial(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
        }

        [Test]
        public void AbSpecialWithMinusEarn()
        {
            argEarn = -argEarn;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbSpecial(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
        }

        [Test]
        public void AbSpecialWithMinusExpense()
        {
            argExpense = -argExpense;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbSpecial(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
        }

        [Test]
        public void AbSpecialWithMinusSpecial()
        {
            argSpecial = -argSpecial;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbSpecial(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
        }

        [Test]
        public void AbSpecialWithNotMuchBalance()
        {
            argBalance = 0;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbSpecial(argYear, argEarn, argExpense, argSpecial, argBalance); }
            );
        }

        [Test]
        public void AbSpecialWithValidArgs()
        {
            Assert.AreEqual(argYear   , abSpecial.Year   );
            Assert.AreEqual(argEarn   , abSpecial.Earn   );
            Assert.AreEqual(argExpense, abSpecial.Expense);
            Assert.AreEqual(argSpecial, abSpecial.Special);
            Assert.AreEqual(argBalance, abSpecial.Balance);
        }
    }
}
