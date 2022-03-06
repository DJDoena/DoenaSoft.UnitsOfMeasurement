using System;
using DoenaSoft.UnitsOfMeasurement.ComplexUnits;
using DoenaSoft.UnitsOfMeasurement.SimpleUnits;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    [TestClass]
    public class UnitTestsForMathConverterGenerics
    {
        [TestMethod]
        public void MilliliterToKilogram()
        {
            var source = new Value<Milliliter>(1000);
            var target = ValueConverter.Convert<Kilogram>(source, new DensityValue<Kilogram, Liter>(0.5));
            Assert.AreEqual(0.5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());

            var source2 = new Value<Milliliter>(1000);
            var density = new DensityValue<Kilogram, Liter>(2);
            var target2 = ValueConverter.Convert<Gram>(source2, density);
            Assert.AreEqual(2000, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());
            var target3 = ValueConverter.Convert<Kilogram>(target2);
            Assert.AreEqual(2, target3.Scalar);
            Assert.AreEqual(typeof(Kilogram), target3.Unit.GetType());
        }

        [TestMethod]
        public void LiterToKilogram()
        {
            var densityOfHelium = new DensityValue(0.1785, "kg/l");

            var source = new Value(5, "dm³");
            var target = ValueConverter.Convert<Kilogram>(source, densityOfHelium);
            Assert.AreEqual(densityOfHelium.Scalar * 5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());

            var source2 = new Value<Liter>(3);
            var target2 = ValueConverter.Convert(source2, new Gram(), densityOfHelium);

            Assert.AreEqual(densityOfHelium.Scalar * 3 * 1000, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());

            var densityNew = new DensityValue<Milligram, Milliliter>(densityOfHelium.Scalar * 1000); // 1 kg/l = 1000 mg/ml
            var target4 = ValueConverter.Convert(source2, new Kilogram(), densityNew);

            Assert.AreEqual(densityOfHelium.Scalar * 3, target4.Scalar);
            Assert.AreEqual(typeof(Kilogram), target4.Unit.GetType());
        }

        [TestMethod]
        public void LiterToKilogram2()
        {
            var densityOfHelium = new DensityValue(0.1785, "kg/l");

            var source = new Value(5, "L");
            var target = ValueConverter.Convert<Kilogram>(source, densityOfHelium);
            Assert.AreEqual(densityOfHelium.Scalar * 5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());

            var source2 = new Value<Liter>(3);
            var densityNew = new DensityValue<Kilogram, Liter>(densityOfHelium.Scalar);
            var target2 = ValueConverter.Convert(source2, new Gram(), densityNew);
            Assert.AreEqual(densityOfHelium.Scalar * 3 * 1000, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToLiter()
        {
            var densityOfHelium = new DensityValue<Density<Kilogram, Liter>>(0.1785);

            // 5 kg Helium / 0.1785 = 28,011 Liter
            var source = new Value(5, UnitConverter.ToUnitOfMeasurement("kg"));
            var target = ValueConverter.Convert<Liter>(source, densityOfHelium);
            Assert.AreEqual(5 / 0.1785, target.Scalar);
            Assert.AreEqual(typeof(Liter), target.Unit.GetType());

            var source2 = new Value<Kilogram>(5);
            var target2 = ValueConverter.Convert(source2, new Liter(), densityOfHelium);
            Assert.AreEqual(5 / 0.1785, target2.Scalar);
            Assert.AreEqual(typeof(Liter), target2.Unit.GetType());

            var source3 = new Value<Kilogram>(5);
            var target3 = ValueConverter.Convert(source3, new Kilogram(), densityOfHelium);
            Assert.AreEqual(5, target3.Scalar);
            Assert.AreEqual(typeof(Kilogram), target3.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToLiter2()
        {
            var densityOfHelium = new DensityValue<Kilogram, Liter>(0.1785);

            // 5 kg Helium / 0.1785 = 28,011 Liter
            var source = new Value(5, UnitConverter.ToUnitOfMeasurement("kg"));
            var target = ValueConverter.Convert<Liter>(source, densityOfHelium);
            Assert.AreEqual(5 / 0.1785, target.Scalar);
            Assert.AreEqual(typeof(Liter), target.Unit.GetType());
        }

        [TestMethod]
        public void CubicCentimeterToGram()
        {
            var densityOfGold = new DensityValue(19.302, "g/cm³");

            var source = new Value(2, UnitConverter.ToUnitOfMeasurement("cm³"));
            var target = ValueConverter.Convert<Gram>(source, densityOfGold);
            Assert.AreEqual(densityOfGold.Scalar * 2, target.Scalar);
            Assert.AreEqual(typeof(Gram), target.Unit.GetType());

            var target2 = ValueConverter.Convert<Kilogram>(source, densityOfGold);
            Assert.AreEqual(densityOfGold.Scalar * 2 / 1000, target2.Scalar);
            Assert.AreEqual(typeof(Kilogram), target2.Unit.GetType());

            var source3 = new Value<Milliliter>(3);
            var densityNew = new DensityValue<Density<Gram, Milliliter>>(densityOfGold.Scalar);
            var target3 = ValueConverter.Convert(source3, new Gram(), densityNew);
            Assert.AreEqual(densityOfGold.Scalar * 3, target3.Scalar);
            Assert.AreEqual(typeof(Gram), target3.Unit.GetType());
        }

        [TestMethod]
        public void VolumeToWeightAndBackAgain()
        {
            var density = new DensityValue<Kilogram, Liter>(2);

            var sourceWeight = new Value<Kilogram>(10);

            var targetVolume = ValueConverter.Convert<Liter>(sourceWeight, density);

            Assert.IsNotNull(targetVolume);
            Assert.IsInstanceOfType(targetVolume.Unit, typeof(Liter));
            Assert.AreEqual(5, targetVolume.Scalar);

            var targetWeight = ValueConverter.Convert<Kilogram>(targetVolume, density);

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(10, targetWeight.Scalar);
        }

        [TestMethod]
        public void MeterToMillimeter()
        {
            var density = new DensityValue(0.5, "kg/L");

            var source = new Value<Meter>(10.4);
            var target = ValueConverter.Convert<Millimeter>(source, density);
            Assert.AreEqual(10400.0, target.Scalar);
            Assert.AreEqual(typeof(Millimeter), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("m"));
            var target2 = ValueConverter.Convert<Millimeter>(source2);
            Assert.AreEqual(10400.0, target2.Scalar);
            Assert.AreEqual(typeof(Millimeter), target2.Unit.GetType());

            var source3 = new Value<Meter>(10.4);
            var target3 = ValueConverter.Convert<Millimeter>(source3, null);
            Assert.AreEqual(10400.0, target3.Scalar);
            Assert.AreEqual(typeof(Millimeter), target3.Unit.GetType());
        }

        [TestMethod]
        public void LiterToMilliliter()
        {
            var source = new Value<Liter>(10.4);
            var target = ValueConverter.Convert<Milliliter>(source);
            Assert.AreEqual(10400.0, target.Scalar);
            Assert.AreEqual(typeof(Milliliter), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("l"));
            var target2 = ValueConverter.Convert<Milliliter>(source2);
            Assert.AreEqual(10400.0, target2.Scalar);
            Assert.AreEqual(typeof(Milliliter), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToGram()
        {
            var source = new Value<Kilogram>(10.4);
            var target = ValueConverter.Convert<Gram>(source);
            Assert.AreEqual(10400.0, target.Scalar);
            Assert.AreEqual(typeof(Gram), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("kg"));
            var target2 = ValueConverter.Convert<Gram>(source2);
            Assert.AreEqual(10400.0, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToTon()
        {
            var source = new Value<Kilogram>(10.4);
            var target = ValueConverter.Convert<Ton>(source);
            Assert.AreEqual(0.0104, target.Scalar);
            Assert.AreEqual(typeof(Ton), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("kg"));
            var target2 = ValueConverter.Convert<Ton>(source2);
            Assert.AreEqual(0.0104, target2.Scalar);
            Assert.AreEqual(typeof(Ton), target2.Unit.GetType());
        }

        [TestMethod]
        public void MilliliterToKilogram2()
        {
            var source = new Value<Milliliter>(1000);
            var density = new DensityValue<Kilogram, Liter>(0.5);
            var target = ValueConverter.Convert(source, new Kilogram(), density);
            Assert.AreEqual(0.5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());

            var source2 = new Value<Milliliter>(1000);
            var density2 = new DensityValue<Kilogram, Liter>(2);
            var target2 = ValueConverter.Convert(source2, new Gram(), density2);
            Assert.AreEqual(2000, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());
            var target3 = ValueConverter.Convert<Kilogram>(target2);
            Assert.AreEqual(2, target3.Scalar);
            Assert.AreEqual(typeof(Kilogram), target3.Unit.GetType());
        }

        [TestMethod]
        public void JohnFuelConsumptionTest()
        {
            const double LiterPerKilometer = 5.9 / 100;
            const double GasMileage = 39.86688;

            Value source = new Value<ComplexUnit<Liter, Kilometer>>(LiterPerKilometer);
            Value target = ValueConverter.Convert<ComplexUnit<USLiquidGallon, Mile>>(source);
            var inverted = Math.Round(1 / target.Scalar, 5);

            Assert.AreEqual(GasMileage, inverted);
            Assert.AreEqual(typeof(ComplexUnit<USLiquidGallon, Mile>), target.Unit.GetType());

            source = new Value<ComplexUnit<Liter, Kilometer>>(LiterPerKilometer);
            target = ValueConverter.Convert<ComplexUnit<Mile, USLiquidGallon>>(source);
            var rounded = Math.Round(target.Scalar, 5);

            Assert.AreEqual(GasMileage, rounded);
            Assert.AreEqual(typeof(ComplexUnit<Mile, USLiquidGallon>), target.Unit.GetType());
        }

        [TestMethod]
        public void SupermanWeight() //220 lbs
        {
            var sourceWeight = new Value(220, new Pound());

            var targetWeight = ValueConverter.Convert<Kilogram>(sourceWeight);

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));

            targetWeight = targetWeight.Round(2);

            Assert.AreEqual(99.79d, targetWeight.Scalar);
        }

        [TestMethod]
        public void SupermanHeight() //6'4"
        {
            var sourceFeet = new Value(6, new Foot());

            var targetInch = ValueConverter.Convert<Inch>(sourceFeet);

            Assert.IsNotNull(targetInch);
            Assert.IsInstanceOfType(targetInch.Unit, typeof(Inch));
            Assert.AreEqual(6d * 12d, targetInch.Scalar); //1 foot = 12 inch

            targetInch = targetInch.Add(4d);

            var targetMeter = ValueConverter.Convert<Meter>(targetInch);

            Assert.IsNotNull(targetMeter);
            Assert.IsInstanceOfType(targetMeter.Unit, typeof(Meter));

            targetMeter = targetMeter.Round(4);

            Assert.AreEqual(1.9304d, targetMeter.Scalar);
        }

        [TestMethod]
        public void ImperialLengths()
        {
            var mile = new Value<Mile>(1.0);

            var yard = ValueConverter.Convert<Yard>(mile);

            yard = yard.Round(2);

            Assert.IsNotNull(yard);
            Assert.AreEqual(1760d, yard.Scalar);

            var foot = ValueConverter.Convert<Foot>(mile);

            foot = foot.Round(2);

            Assert.IsNotNull(foot);
            Assert.AreEqual(1760d * 3d, foot.Scalar);

            var inch = ValueConverter.Convert<Inch>(mile);

            inch = inch.Round(2);

            Assert.IsNotNull(inch);
            Assert.AreEqual(1760d * 3d * 12d, inch.Scalar);

            yard = new Value<Yard>(1.0);

            foot = ValueConverter.Convert<Foot>(yard);

            foot = foot.Round(2);

            Assert.IsNotNull(foot);
            Assert.AreEqual(3d, foot.Scalar);

            inch = ValueConverter.Convert<Inch>(yard);

            inch = inch.Round(2);

            Assert.IsNotNull(inch);
            Assert.AreEqual(3d * 12d, inch.Scalar);

            foot = new Value<Foot>(1.0);

            inch = ValueConverter.Convert<Inch>(foot);

            inch = inch.Round(2);

            Assert.IsNotNull(inch);
            Assert.AreEqual(12d, inch.Scalar);
        }

        [TestMethod]
        public void CubicMetersToTonsWithStandardDensity()
        {
            var density = new DensityValue(1.5, new Density<Kilogram, Liter>());

            var source = new Value<CubicMeter>(6.0);

            var target = ValueConverter.Convert<Ton>(source, density);

            Assert.IsNotNull(target);
            Assert.AreEqual(9.0, target.Scalar);
            Assert.IsInstanceOfType(target.Unit, typeof(Ton));
        }

        [TestMethod]
        public void AddOnePoundToOneKilo()
        {
            var source = new Value(1,"kg");

            var target = source.Add(new Value(1, "lb"));

            Assert.IsNotNull(target);
            Assert.AreEqual(1.45359237, target.Scalar);
            Assert.IsInstanceOfType(target.Unit, typeof(Kilogram));
        }

        [TestMethod]
        public void AddOneKilogramToOnePound()
        {
            var source = new Value<Pound>(1);

            var target = source.Add(new Value<Kilogram>(1));

            Assert.IsNotNull(target);
            Assert.AreEqual(3.20462262184878, target.Scalar);
            Assert.IsInstanceOfType(target.Unit, typeof(Pound));
        }

        [TestMethod]
        public void AddMilesPerHourToMetersPerSecond()
        {
            var source = new Value<ComplexUnit<Meter, Second>>(30);

            var target = source.Add(new Value<ComplexUnit<Mile, Hour>>(15));

            Assert.IsNotNull(target);
            Assert.AreEqual(36.7056, target.Scalar);
            Assert.IsInstanceOfType(target.Unit, typeof(ComplexUnit<Meter, Second>));
        }
    }
}