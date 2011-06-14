namespace Abook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class AbTestSummary
    {
        private DateTime argDtNow;
        private List<AbExpense> argAbExpenses;

        private AbSummary abSummary;
        private List<AbSummary> abSummaries;

        [SetUp]
        public void SetUp()
        {
            argDtNow = new DateTime(2011, 3, 15);
            argAbExpenses = AbDBManager.LoadFromFile("In_AbSummaryTest.db");

            abSummary = new AbSummary(argDtNow, argAbExpenses);
            abSummaries = AbSummary.GetSummaries(argAbExpenses);
        }

        [Test]
        public void AbSummaryWithNullExpenses()
        {
            argAbExpenses = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { new AbSummary(argDtNow, argAbExpenses); }
            );
        }

        [Test]
        public void GetPriceByTypeWithNullType()
        {
            Assert.AreEqual(0, abSummary.GetPriceByType(null));
        }

        [Test]
        public void GetPriceByTypeWithEmptyType()
        {
            Assert.AreEqual(0, abSummary.GetPriceByType(string.Empty));
        }

        [Test]
        public void GetPriceByTypeWithEmptyExpenses()
        {
            argAbExpenses = new List<AbExpense>();
            abSummary = new AbSummary(argDtNow, argAbExpenses);

            Assert.AreEqual(0, abSummary.GetPriceByType("食費"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("外食費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("雑貨"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("交際費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("交通費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("遊行費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("家賃"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("光熱費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("通信費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("医療費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("保険料"));
            Assert.AreEqual(0, abSummary.GetPriceByType("その他"));
            Assert.AreEqual(0, abSummary.GetPriceByType("合計"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("収入"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("残金"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("not match"));
        }

        [Test]
        public void GetPriceByTypeWithOutOfHead()
        {
            argDtNow = new DateTime(2011, 1, 31);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 1, 1) <= exp.Date && exp.Date <= new DateTime(2011, 1, 31)
                )
            );

            Assert.AreEqual(0, abSummary.GetPriceByType("食費"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("外食費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("雑貨"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("交際費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("交通費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("遊行費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("家賃"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("光熱費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("通信費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("医療費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("保険料"));
            Assert.AreEqual(0, abSummary.GetPriceByType("その他"));
            Assert.AreEqual(0, abSummary.GetPriceByType("合計"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("収入"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("残金"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("not match"));
        }

        [Test]
        public void GetPriceByTypeWithInHead()
        {
            argDtNow = new DateTime(2011, 2, 20);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 2, 1) <= exp.Date && exp.Date <= new DateTime(2011, 2, 28)
                )
            );

            Assert.AreEqual(  7304, abSummary.GetPriceByType("食費"  ));
            Assert.AreEqual(  6684, abSummary.GetPriceByType("外食費"));
            Assert.AreEqual(   598, abSummary.GetPriceByType("雑貨"  ));
            Assert.AreEqual(  3000, abSummary.GetPriceByType("交際費"));
            Assert.AreEqual(  2500, abSummary.GetPriceByType("交通費"));
            Assert.AreEqual(     0, abSummary.GetPriceByType("遊行費"));
            Assert.AreEqual( 45500, abSummary.GetPriceByType("家賃"  ));
            Assert.AreEqual(  9130, abSummary.GetPriceByType("光熱費"));
            Assert.AreEqual(  1304, abSummary.GetPriceByType("通信費"));
            Assert.AreEqual(  4580, abSummary.GetPriceByType("医療費"));
            Assert.AreEqual(  2760, abSummary.GetPriceByType("保険料"));
            Assert.AreEqual(   630, abSummary.GetPriceByType("その他"));
            Assert.AreEqual( 83990, abSummary.GetPriceByType("合計"  ));
            Assert.AreEqual(160059, abSummary.GetPriceByType("収入"  ));
            Assert.AreEqual( 76069, abSummary.GetPriceByType("残金"  ));
            Assert.AreEqual(     0, abSummary.GetPriceByType("not match"));
        }

        [Test]
        public void GetPriceByTypeWithInMiddle()
        {
            argDtNow = new DateTime(2011, 3, 31);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 3, 1) <= exp.Date && exp.Date <= new DateTime(2011, 3, 31)
                )
            );

            Assert.AreEqual(  6527, abSummary.GetPriceByType("食費"  ));
            Assert.AreEqual(  7904, abSummary.GetPriceByType("外食費"));
            Assert.AreEqual(  2930, abSummary.GetPriceByType("雑貨"  ));
            Assert.AreEqual(  5900, abSummary.GetPriceByType("交際費"));
            Assert.AreEqual(   930, abSummary.GetPriceByType("交通費"));
            Assert.AreEqual(  2000, abSummary.GetPriceByType("遊行費"));
            Assert.AreEqual( 45500, abSummary.GetPriceByType("家賃"  ));
            Assert.AreEqual(  8447, abSummary.GetPriceByType("光熱費"));
            Assert.AreEqual(  1304, abSummary.GetPriceByType("通信費"));
            Assert.AreEqual(  2330, abSummary.GetPriceByType("医療費"));
            Assert.AreEqual(  9760, abSummary.GetPriceByType("保険料"));
            Assert.AreEqual(   525, abSummary.GetPriceByType("その他"));
            Assert.AreEqual( 94057, abSummary.GetPriceByType("合計"  ));
            Assert.AreEqual(160059, abSummary.GetPriceByType("収入"  ));
            Assert.AreEqual( 66002, abSummary.GetPriceByType("残金"  ));
            Assert.AreEqual(     0, abSummary.GetPriceByType("not match"));
        }

        [Test]
        public void GetPriceByTypeWithInTail()
        {
            argDtNow = new DateTime(2011, 4, 1);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 4, 1) <= exp.Date && exp.Date <= new DateTime(2011, 4, 30)
                )
            );

            Assert.AreEqual(  6390, abSummary.GetPriceByType("食費"  ));
            Assert.AreEqual(  6730, abSummary.GetPriceByType("外食費"));
            Assert.AreEqual(  2171, abSummary.GetPriceByType("雑貨"  ));
            Assert.AreEqual(  4514, abSummary.GetPriceByType("交際費"));
            Assert.AreEqual(  7940, abSummary.GetPriceByType("交通費"));
            Assert.AreEqual(   649, abSummary.GetPriceByType("遊行費"));
            Assert.AreEqual( 45500, abSummary.GetPriceByType("家賃"  ));
            Assert.AreEqual(  8468, abSummary.GetPriceByType("光熱費"));
            Assert.AreEqual(  1303, abSummary.GetPriceByType("通信費"));
            Assert.AreEqual(     0, abSummary.GetPriceByType("医療費"));
            Assert.AreEqual(  2760, abSummary.GetPriceByType("保険料"));
            Assert.AreEqual( 15435, abSummary.GetPriceByType("その他"));
            Assert.AreEqual(101860, abSummary.GetPriceByType("合計"  ));
            Assert.AreEqual(159889, abSummary.GetPriceByType("収入"  ));
            Assert.AreEqual( 58029, abSummary.GetPriceByType("残金"  ));
            Assert.AreEqual(     0, abSummary.GetPriceByType("not match"));
        }

        [Test]
        public void GetPriceByTypeWithOutOfTail()
        {
            argDtNow = new DateTime(2011, 5, 1);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 5, 1) <= exp.Date && exp.Date <= new DateTime(2011, 5, 31)
                )
            );

            Assert.AreEqual(0, abSummary.GetPriceByType("食費"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("外食費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("雑貨"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("交際費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("交通費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("遊行費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("家賃"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("光熱費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("通信費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("医療費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("保険料"));
            Assert.AreEqual(0, abSummary.GetPriceByType("その他"));
            Assert.AreEqual(0, abSummary.GetPriceByType("合計"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("収入"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("残金"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("not match"));
        }

        [Test]
        public void GetPriceByNameWithNullName()
        {
            Assert.AreEqual(0, abSummary.GetPriceByName(null));
        }

        [Test]
        public void GetPriceByNameWithEmptyName()
        {
            Assert.AreEqual(0, abSummary.GetPriceByName(string.Empty));
        }

        [Test]
        public void GetPriceByNameWithEmptyExpenses()
        {
            argAbExpenses = new List<AbExpense>();
            abSummary = new AbSummary(argDtNow, argAbExpenses);

            Assert.AreEqual(0, abSummary.GetPriceByName("うどん"));
            Assert.AreEqual(0, abSummary.GetPriceByName("電気代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("ガス代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("水道代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("not match"));
        }

        [Test]
        public void GetPriceByNameWithOutOfHead()
        {
            argDtNow = new DateTime(2011, 1, 31);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 1, 1) <= exp.Date && exp.Date <= new DateTime(2011, 1, 31)
                )
            );

            Assert.AreEqual(0, abSummary.GetPriceByName("うどん"));
            Assert.AreEqual(0, abSummary.GetPriceByName("電気代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("ガス代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("水道代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("not match"));
        }

        [Test]
        public void GetPriceByNameWithInHead()
        {
            argDtNow = new DateTime(2011, 2, 20);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 2, 1) <= exp.Date && exp.Date <= new DateTime(2011, 2, 28)
                )
            );

            Assert.AreEqual(1570, abSummary.GetPriceByName("うどん"));
            Assert.AreEqual(1783, abSummary.GetPriceByName("電気代"));
            Assert.AreEqual(5596, abSummary.GetPriceByName("ガス代"));
            Assert.AreEqual(1751, abSummary.GetPriceByName("水道代"));
            Assert.AreEqual(   0, abSummary.GetPriceByName("not match"));
        }

        [Test]
        public void GetPriceByNameWithInMiddle()
        {
            argDtNow = new DateTime(2011, 3, 31);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 3, 1) <= exp.Date && exp.Date <= new DateTime(2011, 3, 31)
                )
            );

            Assert.AreEqual(2760, abSummary.GetPriceByName("うどん"));
            Assert.AreEqual(1357, abSummary.GetPriceByName("電気代"));
            Assert.AreEqual(5339, abSummary.GetPriceByName("ガス代"));
            Assert.AreEqual(1751, abSummary.GetPriceByName("水道代"));
            Assert.AreEqual(   0, abSummary.GetPriceByName("not match"));
        }

        [Test]
        public void GetPriceByNameWithInTail()
        {
            argDtNow = new DateTime(2011, 4, 1);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 4, 1) <= exp.Date && exp.Date <= new DateTime(2011, 4, 30)
                )
            );

            Assert.AreEqual(2349, abSummary.GetPriceByName("うどん"));
            Assert.AreEqual(1426, abSummary.GetPriceByName("電気代"));
            Assert.AreEqual(5339, abSummary.GetPriceByName("ガス代"));
            Assert.AreEqual(1703, abSummary.GetPriceByName("水道代"));
            Assert.AreEqual(   0, abSummary.GetPriceByName("not match"));
        }

        [Test]
        public void GetPriceByNameWithOutOfTail()
        {
            argDtNow = new DateTime(2011, 5, 1);
            abSummary = new AbSummary(
                argDtNow,
                argAbExpenses.Where(exp =>
                    new DateTime(2011, 5, 1) <= exp.Date && exp.Date <= new DateTime(2011, 5, 31)
                )
            );

            Assert.AreEqual(0, abSummary.GetPriceByName("うどん"));
            Assert.AreEqual(0, abSummary.GetPriceByName("電気代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("ガス代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("水道代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("not match"));
        }

        [Test]
        public void GetSummariesWithNullExpenses()
        {
            argAbExpenses = null;
            Assert.Throws(
                typeof(ArgumentException),
                () => { AbSummary.GetSummaries(argAbExpenses); }
            );
        }

        [Test]
        public void GetSummariesWithEmptyExpenses()
        {
            argAbExpenses = new List<AbExpense>();
            CollectionAssert.IsEmpty(AbSummary.GetSummaries(argAbExpenses));
        }

        [Test]
        public void GetSummariesWithInDate()
        {
            var sums = abSummaries.Where(sum => sum.Predicate(argDtNow));
            abSummary = (sums.Count() > 0) ? sums.First() : new AbSummary(argDtNow, new List<AbExpense>());

            Assert.AreEqual(1, sums.Count());

            Assert.AreEqual(  6527, abSummary.GetPriceByType("食費"  ));
            Assert.AreEqual(  7904, abSummary.GetPriceByType("外食費"));
            Assert.AreEqual(  2930, abSummary.GetPriceByType("雑貨"  ));
            Assert.AreEqual(  5900, abSummary.GetPriceByType("交際費"));
            Assert.AreEqual(   930, abSummary.GetPriceByType("交通費"));
            Assert.AreEqual(  2000, abSummary.GetPriceByType("遊行費"));
            Assert.AreEqual( 45500, abSummary.GetPriceByType("家賃"  ));
            Assert.AreEqual(  8447, abSummary.GetPriceByType("光熱費"));
            Assert.AreEqual(  1304, abSummary.GetPriceByType("通信費"));
            Assert.AreEqual(  2330, abSummary.GetPriceByType("医療費"));
            Assert.AreEqual(  9760, abSummary.GetPriceByType("保険料"));
            Assert.AreEqual(   525, abSummary.GetPriceByType("その他"));
            Assert.AreEqual( 94057, abSummary.GetPriceByType("合計"  ));
            Assert.AreEqual(160059, abSummary.GetPriceByType("収入"  ));
            Assert.AreEqual( 66002, abSummary.GetPriceByType("残金"  ));
            Assert.AreEqual(     0, abSummary.GetPriceByType("not match"));

            Assert.AreEqual(2760, abSummary.GetPriceByName("うどん"));
            Assert.AreEqual(1357, abSummary.GetPriceByName("電気代"));
            Assert.AreEqual(5339, abSummary.GetPriceByName("ガス代"));
            Assert.AreEqual(1751, abSummary.GetPriceByName("水道代"));
            Assert.AreEqual(   0, abSummary.GetPriceByName("not match"));
        }

        [Test]
        public void GetSummariesWithOutOfDate()
        {
            argDtNow = new DateTime(2011, 11, 11);
            abSummaries = AbSummary.GetSummaries(argAbExpenses);

            var sums = abSummaries.Where(sum => sum.Predicate(argDtNow));
            abSummary = (sums.Count() > 0) ? sums.First() : new AbSummary(argDtNow, new List<AbExpense>());

            Assert.AreEqual(0, sums.Count());

            Assert.AreEqual(0, abSummary.GetPriceByType("食費"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("外食費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("雑貨"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("交際費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("交通費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("遊行費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("家賃"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("光熱費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("通信費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("医療費"));
            Assert.AreEqual(0, abSummary.GetPriceByType("保険料"));
            Assert.AreEqual(0, abSummary.GetPriceByType("その他"));
            Assert.AreEqual(0, abSummary.GetPriceByType("合計"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("収入"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("残金"  ));
            Assert.AreEqual(0, abSummary.GetPriceByType("not match"));

            Assert.AreEqual(0, abSummary.GetPriceByName("うどん"));
            Assert.AreEqual(0, abSummary.GetPriceByName("電気代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("ガス代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("水道代"));
            Assert.AreEqual(0, abSummary.GetPriceByName("not match"));
        }
    }
}
