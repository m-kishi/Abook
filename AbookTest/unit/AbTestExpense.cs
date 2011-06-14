namespace Abook
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AbTestExpense
    {
        private string argDate;
        private string argName;
        private string argType;
        private string argPrice;

        private AbExpense abExpense;

        [SetUp]
        public void SetUp()
        {
            argDate  = "2011/03/01";
            argName  = "おにぎり";
            argType  = "食費";
            argPrice = "105";

            abExpense = new AbExpense(argDate, argName, argType, argPrice);
        }

        [Test]
        public void AbExpenseWithNullDate()
        {
            argDate = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithEmptyDate()
        {
            argDate = string.Empty;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithInvalidDate()
        {
            argDate = "invalid";
            Assert.Throws(
                typeof(FormatException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithNullName()
        {
            argName = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithEmptyName()
        {
            argName = string.Empty;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithNullType()
        {
            argType = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithEmptyType()
        {
            argType = string.Empty;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithNullPrice()
        {
            argPrice = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithEmptyPrice()
        {
            argPrice = string.Empty;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithInvalidPrice()
        {
            argPrice = "invalid";
            Assert.Throws(
                typeof(FormatException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithOverflowPrice()
        {
            argPrice = "999999999999999";
            Assert.Throws(
                typeof(OverflowException),
                () => { new AbExpense(argDate, argName, argType, argPrice); }
            );
        }

        [Test]
        public void AbExpenseWithValidArgs()
        {
            Assert.AreEqual(new DateTime(2011, 3, 1), abExpense.Date);
            Assert.AreEqual("おにぎり", abExpense.Name);
            Assert.AreEqual("食費", abExpense.Type);
            Assert.AreEqual(105, abExpense.Price);
        }

        [Test]
        public void ToCSVFormat()
        {
            Assert.AreEqual("2011/03/01,おにぎり,食費,105", abExpense.ToCSVFormat());
        }
    }
}
