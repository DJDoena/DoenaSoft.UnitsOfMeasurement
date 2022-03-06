using DoenaSoft.UnitsOfMeasurement.ComplexUnits;
using DoenaSoft.UnitsOfMeasurement.SimpleUnits;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    [TestClass]
    public class TimeTestsGenerics
    {
        [TestMethod]
        public void SimpleConversion()
        {
            Value source = new Value<Hour>(1);
            Value target = ValueConverter.Convert<Second>(source);

            Assert.AreEqual(3600, target.Scalar);
            Assert.AreEqual(typeof(Second), target.Unit.GetType());

            source = new Value<Hour>(1);
            target = ValueConverter.Convert<Minute>(source);

            Assert.AreEqual(60, target.Scalar);
            Assert.AreEqual(typeof(Minute), target.Unit.GetType());
        }

        [TestMethod]
        public void ComplexConversion()
        {
            Value source = new Value<ComplexUnit<Liter, Hour>>(60);
            Value target = ValueConverter.Convert<ComplexUnit<Liter, Minute>>(source);

            Assert.AreEqual(1, target.Scalar);
            Assert.AreEqual(typeof(ComplexUnit<Liter, Minute>), target.Unit.GetType());

            source = new Value(60, UnitConverter.ToUnitOfMeasurement("l/h"));
            target = ValueConverter.Convert<ComplexUnit<Liter, Minute>>(source);

            Assert.AreEqual(1, target.Scalar);
            Assert.AreEqual(typeof(ComplexUnit<Liter, Minute>), target.Unit.GetType());
        }
    }
}