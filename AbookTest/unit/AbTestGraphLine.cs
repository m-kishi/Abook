namespace Abook
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AbTestGraphLine
    {
        [Test]
        public void AbGraphLineWithSomeValue()
        {
            AbGraphLine abGraphLinePlus;
            AbGraphLine abGraphLineMinus;

            for (int value = 0; value <= 12500; value += 2500)
            {
                abGraphLinePlus = new AbGraphLine(value);
                abGraphLineMinus = new AbGraphLine(-value);

                switch (value / 2500)
                {
                    case 0:
                        Assert.AreEqual("(0,218)-(349,218)", abGraphLinePlus.ToString());
                        Assert.AreEqual("(0,218)-(349,218)", abGraphLineMinus.ToString());
                        break;

                    case 1:
                        Assert.AreEqual("(0,181)-(349,181)", abGraphLinePlus.ToString());
                        Assert.AreEqual("(0,254)-(349,254)", abGraphLineMinus.ToString());
                        break;

                    case 2:
                        Assert.AreEqual("(0,145)-(349,145)", abGraphLinePlus.ToString());
                        Assert.AreEqual("(0,290)-(349,290)", abGraphLineMinus.ToString());
                        break;

                    case 3:
                        Assert.AreEqual("(0,108)-(349,108)", abGraphLinePlus.ToString());
                        Assert.AreEqual("(0,327)-(349,327)", abGraphLineMinus.ToString());
                        break;

                    case 4:
                        Assert.AreEqual("(0,72)-(349,72)"  , abGraphLinePlus.ToString());
                        Assert.AreEqual("(0,363)-(349,363)", abGraphLineMinus.ToString());
                        break;

                    case 5:
                        Assert.AreEqual("(0,36)-(349,36)"  , abGraphLinePlus.ToString());
                        Assert.AreEqual("(0,399)-(349,399)", abGraphLineMinus.ToString());
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
