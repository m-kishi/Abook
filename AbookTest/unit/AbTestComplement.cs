namespace Abook
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class AbTestComplement
    {
        private AbComplement abComplement;

        [SetUp]
        public void SetUp()
        {
            abComplement = new AbComplement(
                AbDBManager.LoadFromFile("In_AbComplementTest.db")
            );
        }

        [Test]
        public void AbComplementWithNullExpenses()
        {
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbComplement(null); }
            );
        }

        [Test]
        public void GetTypeWithNullName()
        {
            Assert.AreEqual(string.Empty, abComplement.GetType(null));
        }

        [Test]
        public void GetTypeWithEmptyName()
        {
            Assert.AreEqual(string.Empty, abComplement.GetType(string.Empty));
        }

        [Test]
        public void GetTypeWithAbDBManagerNoData()
        {
            abComplement = new AbComplement(
                AbDBManager.LoadFromFile("In_NoData.db")
            );

            Assert.AreEqual(string.Empty, abComplement.GetType("カレー"));
            Assert.AreEqual(string.Empty, abComplement.GetType("うどん"));
            Assert.AreEqual(string.Empty, abComplement.GetType("カツ丼"));
            Assert.AreEqual(string.Empty, abComplement.GetType("電気代"));
            Assert.AreEqual(string.Empty, abComplement.GetType("not match"));
        }

        [Test]
        public void GetTypeSomePattern()
        {
            Assert.AreEqual("食費"       , abComplement.GetType("カレー"));
            Assert.AreEqual("食費 外食費", abComplement.GetType("うどん"));
            Assert.AreEqual("外食費"     , abComplement.GetType("カツ丼"));
            Assert.AreEqual("光熱費"     , abComplement.GetType("電気代"));
            Assert.AreEqual(string.Empty , abComplement.GetType("not match"));
        }
    }
}
