using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using FractionUnits;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using Values;

    [TestClass]
    public class TimeTestsGenerics
    {
        [TestMethod]
        public void SimpleConversion()
        {
            Value source = new Value<Hour>(1m);
            Value target = ValueConverter.Convert<Second>(source);

            Assert.AreEqual(3600, target.Scalar);
            Assert.AreEqual(typeof(Second), target.Unit.GetType());

            source = new Value<Hour>(1m);
            target = ValueConverter.Convert<Minute>(source);

            Assert.AreEqual(60, target.Scalar);
            Assert.AreEqual(typeof(Minute), target.Unit.GetType());
        }

        [TestMethod]
        public void FractionConversion()
        {
            Value source = new Value<FractionUnit<Liter, Hour>>(60m);
            Value target = ValueConverter.Convert<FractionUnit<Liter, Minute>>(source);

            Assert.AreEqual(1m, target.Scalar);
            Assert.AreEqual(typeof(FractionUnit<Liter, Minute>), target.Unit.GetType());

            source = new Value(60m, UnitConverter.ToUnitOfMeasurement("l/h"));
            target = ValueConverter.Convert<FractionUnit<Liter, Minute>>(source);

            Assert.AreEqual(1, target.Scalar);
            Assert.AreEqual(typeof(FractionUnit<Liter, Minute>), target.Unit.GetType());
        }
    }
}