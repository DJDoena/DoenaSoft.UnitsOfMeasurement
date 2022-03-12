using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using SimpleUnits.Weights;
    using Values;

    [TestClass]
    public class TestUnitTests
    {
        [TestMethod]
        public void TestWeightToKilogram()
        {
            var tw = new Value<TestWeightUnit>(1m);

            Assert.AreEqual(new Value<Kilogram>(42m), tw);
        }

        [TestMethod]
        public void FakeWeight()
        {
            var tw = new Value<TestFakeWeightUnit>(1m);

            Assert.IsFalse(new Value<Kilogram>(42m).Equals(tw));
        }

        [TestMethod]
        public void FakeWeightUnit()
        {
            var tw = new TestFakeWeightUnit();

            Assert.IsFalse((new Kilogram()).Equals(tw));
        }
    }
}