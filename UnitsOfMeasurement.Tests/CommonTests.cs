using DoenaSoft.UnitsOfMeasurement.ComplexUnits;
using DoenaSoft.UnitsOfMeasurement.SimpleUnits;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        public void GetAllSimpleUnits()
        {
            var result = UnitConverter.GetKnownUnits();

            Assert.IsTrue(result.Count >= 41);
        }

        [TestMethod]
        public void RegisterUniqueSimpleUnit()
        {
            var unit = new CustomWeight(0.0311034768, "oz.tr.");

            UnitConverter.RegisterCustomUnit(unit);

            var result = UnitConverter.ToUnitOfMeasurement("oz.tr.");

            Assert.IsNotNull(result);

            Assert.AreEqual("oz.tr.", result.ToSerializable());
            Assert.IsTrue(result is CustomWeight);
        }

        [TestMethod]
        public void RegisterStandardSimpleUnit()
        {
            var unit = new CustomWeight(1, "kg");

            UnitConverter.RegisterCustomUnit(unit);

            var result = UnitConverter.ToUnitOfMeasurement("kg");

            Assert.IsNotNull(result);

            Assert.AreEqual("kg", result.ToSerializable());
            Assert.IsTrue(result is Kilogram);
        }

        [TestMethod]
        public void RegisterStandardDeviationSimpleUnit()
        {
            var unit = new CustomWeight(1, "kgm");

            UnitConverter.RegisterCustomUnit(unit);

            var result = UnitConverter.ToUnitOfMeasurement("kgm");

            Assert.IsNotNull(result);

            Assert.AreEqual("kg", result.ToSerializable());
            Assert.IsTrue(result is CustomWeight);
        }

        [TestMethod]
        public void SimpleEquality()
        {
            var result1 = new CustomWeight(0.0311034768, "oz.tr.");

            UnitConverter.RegisterCustomUnit(result1);

            var result2 = UnitConverter.ToUnitOfMeasurement("oz.tr.");

            AssertAreEqual(result1, result2);

            var result3a = UnitConverter.ToUnitOfMeasurement("oz");
            var result3b = UnitConverter.ToUnitOfMeasurement("oz");

            AssertAreNotEqual(result1, result3a);

            AssertAreEqual(result3a, result3b);

            var result4 = result1 as ISimpleUnit;

            var result5 = result2 as ISimpleUnit;

            AssertAreEqual(result4, result5);

            var result6a = result3a as ISimpleUnit;
            var result6b = result3b as ISimpleUnit;

            AssertAreNotEqual(result4, result6a);

            AssertAreEqual(result6a, result6b);
        }

        [TestMethod]
        public void RegisterUniqueComplexUnit()
        {
            var unit = new CustomComplexUnit(new CustomWeight(0.0311034768, "oz.tr."), new CustomTime(86400 * 7, "w"), "ozpw");

            UnitConverter.RegisterCustomUnit(unit);

            var result = UnitConverter.ToUnitOfMeasurement("ozpw");

            Assert.IsNotNull(result);

            Assert.AreEqual("oz.tr./w", result.ToSerializable());

            var complexResult = result as ComplexUnit;

            Assert.IsNotNull(complexResult);

            var complexNumeratorResult = complexResult.Numerator;

            Assert.IsNotNull(complexNumeratorResult);

            Assert.AreEqual("oz.tr.", complexNumeratorResult.ToSerializable());
            Assert.IsTrue(complexNumeratorResult is CustomWeight);

            var complexDenominatorResult = complexResult.Denominator;

            Assert.IsNotNull(complexDenominatorResult);

            Assert.AreEqual("w", complexDenominatorResult.ToSerializable());
            Assert.IsTrue(complexDenominatorResult is CustomTime);

            var numeratorResult = UnitConverter.ToUnitOfMeasurement("oz.tr.");

            Assert.IsNotNull(numeratorResult);

            Assert.AreEqual("oz.tr.", numeratorResult.ToSerializable());
            Assert.IsTrue(numeratorResult is CustomWeight);

            var denominatorResult = UnitConverter.ToUnitOfMeasurement("w");

            Assert.IsNotNull(denominatorResult);

            Assert.AreEqual("w", denominatorResult.ToSerializable());
            Assert.IsTrue(denominatorResult is CustomTime);


            result = UnitConverter.ToUnitOfMeasurement("oz.tr./w");

            Assert.IsNotNull(result);

            Assert.AreEqual("oz.tr./w", result.ToSerializable());

            complexResult = result as ComplexUnit;

            Assert.IsNotNull(complexResult);

            complexNumeratorResult = complexResult.Numerator;

            Assert.IsNotNull(complexNumeratorResult);

            Assert.AreEqual("oz.tr.", complexNumeratorResult.ToSerializable());
            Assert.IsTrue(complexNumeratorResult is CustomWeight);

            complexDenominatorResult = complexResult.Denominator;

            Assert.IsNotNull(complexDenominatorResult);

            Assert.AreEqual("w", complexDenominatorResult.ToSerializable());
            Assert.IsTrue(complexDenominatorResult is CustomTime);

            numeratorResult = UnitConverter.ToUnitOfMeasurement("oz.tr.");

            Assert.IsNotNull(numeratorResult);

            Assert.AreEqual("oz.tr.", numeratorResult.ToSerializable());
            Assert.IsTrue(numeratorResult is CustomWeight);

            denominatorResult = UnitConverter.ToUnitOfMeasurement("w");

            Assert.IsNotNull(denominatorResult);

            Assert.AreEqual("w", denominatorResult.ToSerializable());
            Assert.IsTrue(denominatorResult is CustomTime);
        }

        [TestMethod]
        public void RegisterStandardComplexUnit()
        {
            var unit = new CustomComplexUnit(new Kilometer(), new Hour());

            UnitConverter.RegisterCustomUnit(unit);

            var result = UnitConverter.ToUnitOfMeasurement("km/h");

            Assert.IsNotNull(result);

            Assert.AreEqual("km/h", result.ToSerializable());

            Assert.AreEqual(unit, result);
        }

        [TestMethod]
        public void RegisterStandardComplexUnitUnitKey()
        {
            var unit = new CustomComplexUnit(new CustomWeight(907.18474, "stn"), new CustomTime(86400, "d"), "STPD");

            UnitConverter.RegisterCustomUnit(unit);

            var result = UnitConverter.ToUnitOfMeasurement("STPD");

            Assert.IsNotNull(result);

            Assert.AreEqual("stn/d", result.ToSerializable());

            var complexResult = result as ComplexUnit;

            Assert.IsNotNull(complexResult);

            var complexNumeratorResult = complexResult.Numerator;

            Assert.IsNotNull(complexNumeratorResult);

            Assert.AreEqual("stn", complexNumeratorResult.ToSerializable());
            Assert.IsTrue(complexNumeratorResult is CustomWeight);

            var complexDenominatorResult = complexResult.Denominator;

            Assert.IsNotNull(complexDenominatorResult);

            Assert.AreEqual("d", complexDenominatorResult.ToSerializable());
            Assert.IsTrue(complexDenominatorResult is CustomTime);

            var numeratorResult = UnitConverter.ToUnitOfMeasurement("stn");

            Assert.IsNotNull(numeratorResult);

            Assert.AreEqual("stn", numeratorResult.ToSerializable());
            Assert.IsTrue(numeratorResult is ShortTon);

            var denominatorResult = UnitConverter.ToUnitOfMeasurement("d");

            Assert.IsNotNull(denominatorResult);

            Assert.AreEqual("d", denominatorResult.ToSerializable());
            Assert.IsTrue(denominatorResult is Day);


            result = UnitConverter.ToUnitOfMeasurement("stn/d");

            Assert.IsNotNull(result);

            Assert.AreEqual("stn/d", result.ToSerializable());

            complexResult = result as ComplexUnit;

            Assert.IsNotNull(complexResult);

            complexNumeratorResult = complexResult.Numerator;

            Assert.IsNotNull(complexNumeratorResult);

            Assert.AreEqual("stn", complexNumeratorResult.ToSerializable());
            Assert.IsTrue(complexNumeratorResult is ShortTon);

            complexDenominatorResult = complexResult.Denominator;

            Assert.IsNotNull(complexDenominatorResult);

            Assert.AreEqual("d", complexDenominatorResult.ToSerializable());
            Assert.IsTrue(complexDenominatorResult is Day);

            numeratorResult = UnitConverter.ToUnitOfMeasurement("stn");

            Assert.IsNotNull(numeratorResult);

            Assert.AreEqual("stn", numeratorResult.ToSerializable());
            Assert.IsTrue(numeratorResult is ShortTon);

            denominatorResult = UnitConverter.ToUnitOfMeasurement("d");

            Assert.IsNotNull(denominatorResult);

            Assert.AreEqual("d", denominatorResult.ToSerializable());
            Assert.IsTrue(denominatorResult is Day);
        }

        [TestMethod]
        public void ComplexEquality()
        {
            var unit = new CustomComplexUnit(new CustomWeight(0.0311034768, "oz.tr."), new CustomTime(86400 * 7, "w"), "ozpw");

            UnitConverter.RegisterCustomUnit(unit);

            var result1 = UnitConverter.ToUnitOfMeasurement("ozpw");

            var result2 = UnitConverter.ToUnitOfMeasurement("oz.tr./w");

            AssertAreEqual(result1, result2);

            var result3a = UnitConverter.ToUnitOfMeasurement("oz/w");
            var result3b = UnitConverter.ToUnitOfMeasurement("oz/w");

            AssertAreNotEqual(result1, result3a);
            AssertAreNotEqual(result2, result3a);

            AssertAreEqual(result3a, result3b);

            var result4a = UnitConverter.ToUnitOfMeasurement("o/z/w");
            var result4b = UnitConverter.ToUnitOfMeasurement("o/z/w");

            AssertAreNotEqual(result1, result4a);
            AssertAreNotEqual(result2, result4a);
            AssertAreNotEqual(result3a, result4a);

            AssertAreEqual(result4a, result4b);

            var result5 = result1 as IComplexUnit;

            var result6 = result2 as IComplexUnit;

            AssertAreEqual(result5, result6);

            var result7a = result3a as IComplexUnit;
            var result7b = result3b as IComplexUnit;

            AssertAreNotEqual(result5, result7a);
            AssertAreNotEqual(result6, result7a);

            AssertAreEqual(result7a, result7b);

            var result8a = result4a as IComplexUnit;
            var result8b = result4b as IComplexUnit;

            AssertAreNotEqual(result5, result8a);
            AssertAreNotEqual(result6, result8a);
            AssertAreNotEqual(result7a, result8a);

            AssertAreEqual(result8a, result8b);
        }

        [TestMethod]
        public void UndefinedComplex()
        {
            var result = UnitConverter.ToUnitOfMeasurement("/h") as IComplexUnit;

            Assert.IsNotNull(result);

            AssertAreEqual(result.Numerator, new UndefinedUnitOfMeasurement());
            AssertAreEqual(result.Denominator, new Hour());

            var result2 = UnitConverter.ToUnitOfMeasurement("m/") as IComplexUnit;

            Assert.IsNotNull(result2);

            AssertAreEqual(result2.Numerator, new Meter());
            AssertAreEqual(result2.Denominator, new UndefinedUnitOfMeasurement());

            var result3 = UnitConverter.ToUnitOfMeasurement("m//d") as IComplexUnit;

            Assert.IsNotNull(result3);

            AssertAreEqual(result3.Numerator, new Meter());
            AssertAreEqual(result3.Denominator, new UnknownComplexUnitOfMeasurement("/d"));

            var result4 = UnitConverter.ToUnitOfMeasurement("m/s²") as IComplexUnit;

            Assert.IsNotNull(result4);

            AssertAreEqual(result4.Numerator, new Meter());
            AssertAreEqual(result4.Denominator, new UnknownSimpleUnitOfMeasurement("s²"));

            var result5 = UnitConverter.ToUnitOfMeasurement("m/s/kg/°C") as IComplexUnit;

            Assert.IsNotNull(result5);

            AssertAreEqual(result5.Numerator, new Meter());

            var result5d = UnitConverter.ToUnitOfMeasurement("s/kg/°C") as IComplexUnit;

            AssertAreEqual(result5.Denominator, result5d);

            AssertAreEqual(result5d.Numerator, new Second());
            AssertAreEqual(result5d.Denominator, new ComplexUnit<Kilogram, Celsius>());
        }

        private static void AssertAreEqual(UnitOfMeasurement left, UnitOfMeasurement right)
        {
            Assert.IsTrue(left.Equals(right));
            Assert.IsTrue(right.Equals(left));
        }

        private static void AssertAreEqual(IUnitOfMeasurement left, IUnitOfMeasurement right)
        {
            Assert.IsTrue(left.Equals(right));
            Assert.IsTrue(right.Equals(left));
        }

        private static void AssertAreNotEqual(UnitOfMeasurement left, UnitOfMeasurement right)
        {
            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(right.Equals(left));
        }

        private static void AssertAreNotEqual(IUnitOfMeasurement left, IUnitOfMeasurement right)
        {
            Assert.IsFalse(left.Equals(right));
            Assert.IsFalse(right.Equals(left));
        }
    }
}
