namespace Abook
{
    using System;
    using System.Drawing;
    using NUnit.Framework;

    [TestFixture]
    public class AbTestGraphData
    {
        private AbGraphData abGraphData;

        [SetUp]
        public void SetUp()
        {
            abGraphData = new AbGraphData(Brushes.Black);
        }

        [Test]
        public void AddPoint1Time()
        {
            abGraphData.AddPoint(0);

            Assert.AreEqual(  0, abGraphData.Points[0].X);
            Assert.AreEqual(218, abGraphData.Points[0].Y);
        }

        [Test]
        public void AddPoint2Times()
        {
            abGraphData.AddPoint(0);
            abGraphData.AddPoint(2500);

            Assert.AreEqual( 26, abGraphData.Points[1].X);
            Assert.AreEqual(181, abGraphData.Points[1].Y);
        }

        [Test]
        public void AddPoint3Times()
        {
            abGraphData.AddPoint(0);
            abGraphData.AddPoint(2500);
            abGraphData.AddPoint(5000);

            Assert.AreEqual( 53, abGraphData.Points[2].X);
            Assert.AreEqual(145, abGraphData.Points[2].Y);
        }

        [Test]
        public void AddPoint4Times()
        {
            abGraphData.AddPoint(0);
            abGraphData.AddPoint(2500);
            abGraphData.AddPoint(5000);
            abGraphData.AddPoint(7500);

            Assert.AreEqual( 80, abGraphData.Points[3].X);
            Assert.AreEqual(108, abGraphData.Points[3].Y);
        }

        [Test]
        public void AddPoint5Times()
        {
            abGraphData.AddPoint(0);
            abGraphData.AddPoint(2500);
            abGraphData.AddPoint(5000);
            abGraphData.AddPoint(7500);
            abGraphData.AddPoint(10000);

            Assert.AreEqual(107, abGraphData.Points[4].X);
            Assert.AreEqual( 72, abGraphData.Points[4].Y);
        }
    }
}
