namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using DoenaSoft.UnitsOfMeasurement.SimpleUnits.Powers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Values;

    [TestClass]
    public class PowerTests
    {
        [TestMethod]
        public void Standard()
        {
            Value source = new Value<Watt>(1m);
            Value target = ValueConverter.Convert(source, new KiloWatt());

            Assert.AreEqual(0.001m, target.Scalar);
            Assert.AreEqual(typeof(KiloWatt), target.Unit.GetType());

            target = ValueConverter.Convert(source, new MilliWatt());

            Assert.AreEqual(1000m, target.Scalar);
            Assert.AreEqual(typeof(MilliWatt), target.Unit.GetType());

            target = ValueConverter.Convert(source, new MegaWatt());

            Assert.AreEqual(0.000001m, target.Scalar);
            Assert.AreEqual(typeof(MegaWatt), target.Unit.GetType());

            source = new Value(1m, "W");
            target = ValueConverter.Convert(source, new KiloWatt());

            Assert.AreEqual(0.001m, target.Scalar);
            Assert.AreEqual(typeof(KiloWatt), target.Unit.GetType());
        }
    }
}