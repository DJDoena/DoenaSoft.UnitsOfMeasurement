using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using SimpleUnits.WizardCurrencies;
    using Values;

    [TestClass]
    public class WizardMoneyTests
    {
        [TestMethod]
        public void WizardMoney()
        {
            //‘The gold ones are Galleons,’ he explained.
            //‘Seventeen silver Sickles to a Galleon and twenty-nine Knuts to a Sickle, it’s easy enough.
            //J.K.Rowling: Harry Potter and the Philosopher's Stone

            var galleon = new Value<GoldGalleon>(1m);

            var sickle = ValueConverter.Convert<SilverSickle>(galleon);

            Assert.AreEqual(17m, sickle.Scalar);

            var knut = ValueConverter.Convert<BronzeKnut>(galleon);

            Assert.AreEqual(493m, knut.Scalar);

            knut = ValueConverter.Convert<BronzeKnut>(sickle);

            Assert.AreEqual(493m, knut.Scalar);
        }

        [TestMethod]
        public void TrolleyLady()
        {
            //Not wanting to miss anything,
            //he got some of everything and paid the woman eleven silver Sickles and seven bronze knuts.
            //J.K.Rowling: Harry Potter and the Philosopher's Stone

            var sickle = new Value<SilverSickle>(11m);

            sickle = sickle.Add(new Value<BronzeKnut>(7m));

            var knut = ValueConverter.Convert<BronzeKnut>(sickle).Round(10);

            Assert.AreEqual(11m * 29m + 7m, knut.Scalar);

            knut = new Value<BronzeKnut>(7m);

            knut = knut.Add(new Value<SilverSickle>(11m));

            Assert.AreEqual(11m * 29m + 7m, knut.Scalar);
        }
    }
}