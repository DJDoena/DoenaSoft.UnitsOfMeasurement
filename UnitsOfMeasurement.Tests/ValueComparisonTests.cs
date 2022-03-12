using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using FractionUnits;
    using SimpleUnits.Lengths;
    using SimpleUnits.Times;
    using SimpleUnits.Weights;
    using Values;

    [TestClass]
    public class ValueComparisonTests
    {
        [TestMethod]
        public void YardToMeter()
        {
            var yd = new Value<Yard>(1m);

#pragma warning disable CS1718 // Comparison made to same variable
            Assert.IsFalse(yd < yd);
            Assert.IsTrue(yd <= yd);
            Assert.IsFalse(yd != yd);
            Assert.IsFalse(yd > yd);
            Assert.IsTrue(yd >= yd);
            Assert.IsTrue(yd == yd);
#pragma warning restore CS1718 // Comparison made to same variable

            var m = new Value<Meter>(1m);

            Assert.IsTrue(yd < m);
            Assert.IsTrue(yd <= m);
            Assert.IsTrue(yd != m);
            Assert.IsFalse(yd > m);
            Assert.IsFalse(yd >= m);
            Assert.IsFalse(yd == m);

            m = new Value<Meter>(0.9144m);

            Assert.IsFalse(yd < m);
            Assert.IsTrue(yd <= m);
            Assert.IsFalse(yd != m);
            Assert.IsFalse(yd > m);
            Assert.IsTrue(yd >= m);
            Assert.IsTrue(yd == m);

            yd = new Value<Yard>(2m);

            Assert.IsFalse(yd < m);
            Assert.IsFalse(yd <= m);
            Assert.IsTrue(yd != m);
            Assert.IsTrue(yd > m);
            Assert.IsTrue(yd >= m);
            Assert.IsFalse(yd == m);
        }

        [TestMethod]
        public void KmhTomps()
        {
            var kmh = new Value<FractionUnit<Kilometer, Hour>>(30m);

            var mps = new Value<FractionUnit<Meter, Second>>(30m);

            Assert.IsTrue(kmh < mps);
            Assert.IsTrue(kmh <= mps);
            Assert.IsTrue(kmh != mps);
            Assert.IsFalse(kmh > mps);
            Assert.IsFalse(kmh >= mps);
            Assert.IsFalse(kmh == mps);
        }

        [TestMethod]
        public void Inversion()
        {
            var mpkg = new Value<FractionUnit<Meter, Kilogram>>(10m);

            var kgpm = new Value<FractionUnit<Kilogram, Meter>>(0.1m);

            Assert.IsFalse(mpkg < kgpm);
            Assert.IsTrue(mpkg <= kgpm);
            Assert.IsFalse(mpkg != kgpm);
            Assert.IsFalse(mpkg > kgpm);
            Assert.IsTrue(mpkg >= kgpm);
            Assert.IsTrue(mpkg == kgpm);

            kgpm = new Value<FractionUnit<Kilogram, Meter>>(0.09m);

            Assert.IsTrue(mpkg < kgpm);
            Assert.IsTrue(mpkg <= kgpm);
            Assert.IsTrue(mpkg != kgpm);
            Assert.IsFalse(mpkg > kgpm);
            Assert.IsFalse(mpkg >= kgpm);
            Assert.IsFalse(mpkg == kgpm);

            kgpm = new Value<FractionUnit<Kilogram, Meter>>(0.11m);

            Assert.IsFalse(mpkg < kgpm);
            Assert.IsFalse(mpkg <= kgpm);
            Assert.IsTrue(mpkg != kgpm);
            Assert.IsTrue(mpkg > kgpm);
            Assert.IsTrue(mpkg >= kgpm);
            Assert.IsFalse(mpkg == kgpm);
        }
    }
}