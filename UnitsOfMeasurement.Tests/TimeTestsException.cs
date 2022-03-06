using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using ComplexUnits;
    using Exceptions;
    using SimpleUnits.Lengths;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using Values;

    [TestClass]
    public class ExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullArgumentTest()
        {
            var _ = ValueConverter.Convert(null, new Second());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullArgumentTest2()
        {
            var _ = ValueConverter.Convert(null, new ComplexUnit<Mile, USLiquidGallon>());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullArgumentTest5()
        {
            var _ = ValueConverter.Convert<Meter>(null);
        }

        [TestMethod]
        [ExpectedException(typeof(UnitConversionException))]
        public void UnitConversionExceptionTest1()
        {
            var _ = new DensityValue(0.5, "m/s");
        }
    }
}