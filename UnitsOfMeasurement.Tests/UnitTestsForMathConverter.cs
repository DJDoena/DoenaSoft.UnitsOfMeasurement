using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using FractionUnits;
    using Exceptions;
    using SimpleUnits;
    using SimpleUnits.Lengths;
    using SimpleUnits.Temperatures;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;
    using Values;

    [TestClass]
    public class UnitTestsForMathConverter
    {
        [TestMethod]
        public void TonsToKilogram()
        {
            var sourceValue = new Value(10.4, UnitConverter.ToUnitOfMeasurement("t"));
            Assert.AreEqual(new Ton(), sourceValue.Unit);
            var targetUnit = UnitConverter.ToUnitOfMeasurement("KG") as SimpleUnit;
            Assert.IsNotNull(targetUnit);
            Assert.AreEqual(new Kilogram(), targetUnit);
            var targetValue = ValueConverter.Convert(sourceValue, targetUnit);
            Assert.AreEqual(10400, targetValue.Scalar);
            Assert.AreEqual(new Kilogram(), targetValue.Unit);
        }

        [TestMethod]
        public void MillimeterToKilometer()
        {
            var source = new Value<Millimeter>(50);
            var target = ValueConverter.Convert(source, new Kilometer());
            Assert.AreEqual(0.00005, target.Scalar);
            Assert.AreEqual(typeof(Kilometer), target.Unit.GetType());
        }

        [TestMethod]
        public void MeterToMillimeter()
        {
            var source = new Value<Meter>(10.4);
            var target = ValueConverter.Convert(source, new Millimeter());
            Assert.AreEqual(10400.0, target.Scalar);
            Assert.AreEqual(typeof(Millimeter), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("m"));
            var target2 = ValueConverter.Convert(source2, new Millimeter());
            Assert.AreEqual(10400.0, target2.Scalar);
            Assert.AreEqual(typeof(Millimeter), target2.Unit.GetType());
        }

        [TestMethod]
        public void LiterToMilliliter()
        {
            var source = new Value<Liter>(10.4);
            var target = ValueConverter.Convert(source, new Milliliter());
            Assert.AreEqual(10400.0, target.Scalar);
            Assert.AreEqual(typeof(Milliliter), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("l"));
            var target2 = ValueConverter.Convert(source2, new Milliliter());
            Assert.AreEqual(10400.0, target2.Scalar);
            Assert.AreEqual(typeof(Milliliter), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToGram()
        {
            var source = new Value<Kilogram>(10.4);
            var target = ValueConverter.Convert(source, new Gram());
            Assert.AreEqual(10400.0, target.Scalar);
            Assert.AreEqual(typeof(Gram), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("kg"));
            var target2 = ValueConverter.Convert(source2, new Gram());
            Assert.AreEqual(10400.0, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToTon()
        {
            var source = new Value<Kilogram>(10.4);
            var target = ValueConverter.Convert(source, new Ton());
            Assert.AreEqual(0.0104, target.Scalar);
            Assert.AreEqual(typeof(Ton), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("kg"));
            var target2 = ValueConverter.Convert(source2, new Ton());
            Assert.AreEqual(0.0104, target2.Scalar);
            Assert.AreEqual(typeof(Ton), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToBaseUnit()
        {
            var source = new Value<Gram>(10.4);
            var target = ValueConverter.ConvertToBaseValue(source);

            var scalar = Math.Round(target.Scalar, 4, MidpointRounding.AwayFromZero);

            Assert.AreEqual(0.0104, scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());

            var source2 = new Value(10.4, UnitConverter.ToUnitOfMeasurement("t"));
            var target2 = ValueConverter.ConvertToBaseValue(source2);

            scalar = Math.Round(target2.Scalar, 4, MidpointRounding.AwayFromZero);

            Assert.AreEqual(10400d, scalar);
            Assert.AreEqual(typeof(Kilogram), target2.Unit.GetType());

            var source3 = new Value(10.4, "km/s");
            var target3 = ValueConverter.ConvertToBaseValue(source3);
            var scalar3 = Math.Round(target3.Scalar, 4, MidpointRounding.AwayFromZero);

            Assert.AreEqual(10400d, scalar3);
            Assert.AreEqual("m/s", target3.Unit.ToString());
        }

        [TestMethod]
        public void UnknownTripleFractionUnit()
        {
            var unit = "m/s/s";

            var unitOfMeasurement = UnitConverter.ToUnitOfMeasurement(unit);

            Assert.AreEqual(typeof(UnknownFractionUnitOfMeasurement), unitOfMeasurement.GetType());
            Assert.AreEqual(unit, unitOfMeasurement.ToSerializable());
            Assert.AreEqual(unit, unitOfMeasurement.GetDisplayValue());
        }

        [TestMethod]
        public void UnknownSimpleUnit()
        {
            var unit = "Meilen";

            var unitOfMeasurement = UnitConverter.ToUnitOfMeasurement(unit);

            Assert.AreEqual(typeof(UnknownSimpleUnitOfMeasurement), unitOfMeasurement.GetType());
            Assert.AreEqual(unit, unitOfMeasurement.ToSerializable());
            Assert.AreEqual(unit, unitOfMeasurement.GetDisplayValue());
        }

        [TestMethod]
        public void UnknownMilesPerHour()
        {
            var unit = "Meilen/Stunde";

            var unitOfMeasurement = UnitConverter.ToUnitOfMeasurement(unit);

            var fractionUnit = unitOfMeasurement as FractionUnit;

            Assert.IsNotNull(fractionUnit);
            Assert.AreEqual(unit, unitOfMeasurement.ToSerializable());
            Assert.AreEqual(unit, unitOfMeasurement.GetDisplayValue());
            Assert.AreEqual(typeof(UnknownSimpleUnitOfMeasurement), fractionUnit.Numerator.GetType());
            Assert.AreEqual(typeof(UnknownSimpleUnitOfMeasurement), fractionUnit.Denominator.GetType());

            unit = "Meilen pro Stunde";

            unitOfMeasurement = UnitConverter.ToUnitOfMeasurement(unit);

            Assert.AreEqual(typeof(UnknownUnitOfMeasurement), unitOfMeasurement.GetType());
            Assert.AreEqual(unit, unitOfMeasurement.ToSerializable());
            Assert.AreEqual(unit, unitOfMeasurement.GetDisplayValue());
        }

        [TestMethod]
        public void MilliliterToKilogram()
        {
            var source = new Value<Milliliter>(1000);
            var target = ValueConverter.Convert(source, new Kilogram(), new DensityValue<Density<Kilogram, Liter>>(0.5));
            Assert.AreEqual(0.5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());

            var source2 = new Value<Milliliter>(1000);
            var target2 = ValueConverter.Convert(source2, new Gram(), new DensityValue<Density<Kilogram, Liter>>(2));
            Assert.AreEqual(2000, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());
            var target3 = ValueConverter.Convert(target2, new Kilogram());
            Assert.AreEqual(2, target3.Scalar);
            Assert.AreEqual(typeof(Kilogram), target3.Unit.GetType());
        }

        [TestMethod]
        public void LiterToKilogram()
        {
            const double DensityOfHelium = 0.1785; // kg/l

            var source = new Value(5, UnitConverter.ToUnitOfMeasurement("dm³"));
            var target = ValueConverter.Convert(source, new Kilogram(), new DensityValue<Density<Kilogram, Liter>>(DensityOfHelium));
            Assert.AreEqual(DensityOfHelium * 5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());
        }

        [TestMethod]
        public void LiterToKilogram2()
        {
            const double DensityOfHelium = 0.1785; // kg/l

            var source = new Value(5, UnitConverter.ToUnitOfMeasurement("L"));
            var target = ValueConverter.Convert(source, new Kilogram(), new DensityValue<Kilogram, Liter>(DensityOfHelium));
            Assert.AreEqual(DensityOfHelium * 5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToLiter()
        {
            const double DensityOfHelium = 0.1785; // kg/l

            // 5 kg Helium / 0.1785 = 28,011 Liter
            var source = new Value(5, UnitConverter.ToUnitOfMeasurement("kg"));
            var target = ValueConverter.Convert(source, new Liter(), new DensityValue<Kilogram, Liter>(DensityOfHelium));
            Assert.AreEqual(5 / 0.1785, target.Scalar);
            Assert.AreEqual(typeof(Liter), target.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToLiter2()
        {
            const double DensityOfHelium = 0.1785; // kg/l

            // 5 kg Helium / 0.1785 = 28,011 Liter
            var source = new Value(5, UnitConverter.ToUnitOfMeasurement("kg"));
            var target = ValueConverter.Convert(source, new Liter(), new DensityValue<Density<Kilogram, Liter>>(DensityOfHelium));
            Assert.AreEqual(5 / 0.1785, target.Scalar);
            Assert.AreEqual(typeof(Liter), target.Unit.GetType());
        }

        [TestMethod]
        public void CubicCentimeterToGram()
        {
            const double DensityOfGold = 19.302; // g/cm³

            var source = new Value(2, UnitConverter.ToUnitOfMeasurement("cm³"));
            var target = ValueConverter.Convert(source, new Gram(), new DensityValue(DensityOfGold, " g/cm³"));
            Assert.AreEqual(DensityOfGold * 2, target.Scalar);
            Assert.AreEqual(typeof(Gram), target.Unit.GetType());
        }

        [TestMethod]
        public void JohnFuelConsumptionTest()
        {
            const double LiterPerKilometer = 5.9 / 100;
            const double GasMileage = 39.86688;

            Value source = new Value<FractionUnit<Liter, Kilometer>>(LiterPerKilometer);
            Value target = ValueConverter.Convert(source, new FractionUnit<USLiquidGallon, Mile>());
            var inverted = Math.Round(1 / target.Scalar, 5);

            Assert.AreEqual(GasMileage, inverted);
            Assert.AreEqual(typeof(FractionUnit<USLiquidGallon, Mile>), target.Unit.GetType());

            source = new Value<FractionUnit<Liter, Kilometer>>(LiterPerKilometer);
            target = ValueConverter.Convert(source, new FractionUnit<Mile, USLiquidGallon>());
            inverted = target.Round(5).Scalar;

            Assert.AreEqual(GasMileage, inverted);
            Assert.AreEqual(typeof(FractionUnit<Mile, USLiquidGallon>), target.Unit.GetType());
        }

        [TestMethod]
        public void SerializeUom()
        {
            var original = UnitConverter.ToUnitOfMeasurement("M³");
            Assert.AreEqual(typeof(CubicMeter), original.GetType());

            var serialized = original.ToSerializable();
            Assert.AreEqual("m3", serialized);

            var copy = UnitConverter.ToUnitOfMeasurement(serialized);
            Assert.AreEqual(typeof(CubicMeter), copy.GetType());
        }

        [TestMethod]
        public void VolumeToWeightAndBackAgainGeneralByGenericFunction()
        {
            var sourceWeight = new Value(10d, new Kilogram());

            var density = new DensityValue<Density<Kilogram, Liter>>(0.5);

            var targetVolume = ValueConverter.Convert(sourceWeight, new Liter(), density);

            Assert.IsNotNull(targetVolume);
            Assert.IsInstanceOfType(targetVolume.Unit, typeof(Liter));
            Assert.AreEqual(20d, targetVolume.Scalar);

            var targetWeight = ValueConverter.Convert(targetVolume, new Kilogram(), density);

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(10d, targetWeight.Scalar);
        }

        [TestMethod]
        [ExpectedException(typeof(UnitConversionException))]
        public void LengthToWeight()
        {
            var density = new DensityValue<Kilogram, Liter>(0.5);

            var sourceWeight = new Value(10d, new Meter());

            ValueConverter.Convert(sourceWeight, new Kilogram(), density);
        }

        [TestMethod]
        public void VolumeToWeightAndBackAgainGeneral()
        {
            var density = new DensityValue<Density<Kilogram, Liter>>(0.5);

            var sourceWeight = new Value(10d, new Kilogram());

            var targetVolume = ValueConverter.Convert(sourceWeight, new Liter(), new DensityValue(density.Scalar, "kg/L"));

            Assert.IsNotNull(targetVolume);
            Assert.IsInstanceOfType(targetVolume.Unit, typeof(Liter));
            Assert.AreEqual(20d, targetVolume.Scalar);

            var targetWeight = ValueConverter.Convert(targetVolume, new Kilogram(), density);

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(10d, targetWeight.Scalar);
        }

        [TestMethod]
        public void VolumeToWeightAndBackAgainWithConversionFactor()
        {
            var conversionfactor = 0.5;

            var sourceWeight = new Value(10d, new Kilogram());

            var targetVolume = ValueConverter.Convert(sourceWeight, new Liter(), new DensityValue<Kilogram, Liter>(conversionfactor));

            Assert.IsNotNull(targetVolume);
            Assert.IsInstanceOfType(targetVolume.Unit, typeof(Liter));
            Assert.AreEqual(20d, targetVolume.Scalar);

            var targetWeight = ValueConverter.Convert(targetVolume, new Kilogram(), new DensityValue<Kilogram, Liter>(conversionfactor));

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(10d, targetWeight.Scalar);
        }

        [TestMethod]
        public void ELinkConversionFactor()
        {
            var density = new DensityValue<Kilogram, Liter>(0.8);

            var sourceVolume = new Value(10, new Liter());

            var targetWeight = ValueConverter.Convert(sourceVolume, new Kilogram(), density);

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(8.0d, targetWeight.Scalar);
        }

        [TestMethod]
        public void SupermanWeight() //220 lbs
        {
            var sourceWeight = new Value(220, new Pound());

            var targetWeight = ValueConverter.Convert(sourceWeight, new Kilogram());

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));

            targetWeight = targetWeight.Round(2);

            Assert.AreEqual(99.79d, targetWeight.Scalar);
        }

        [TestMethod]
        public void SupermanHeight() //6'4"
        {
            var sourceFeet = new Value(6, new Foot());

            var targetInch = ValueConverter.Convert(sourceFeet, new Inch());

            Assert.IsNotNull(targetInch);
            Assert.IsInstanceOfType(targetInch.Unit, typeof(Inch));
            Assert.AreEqual(6d * 12d, targetInch.Scalar); //1 foot = 12 inch

            targetInch = targetInch.Add(4d);

            var targetMeter = ValueConverter.Convert(targetInch, new Meter());

            Assert.IsNotNull(targetMeter);
            Assert.IsInstanceOfType(targetMeter.Unit, typeof(Meter));

            targetMeter = targetMeter.Round(4);

            Assert.AreEqual(1.9304d, targetMeter.Scalar);
        }

        [TestMethod]
        public void ImperialLengths()
        {
            var mile = new Value<Mile>(1.0);

            var yard = ValueConverter.Convert(mile, new Yard());

            Assert.IsNotNull(yard);
            Assert.IsInstanceOfType(yard.Unit, typeof(Yard));

            yard = yard.Round(2);

            Assert.AreEqual(1760d, yard.Scalar);

            var foot = ValueConverter.Convert(mile, new Foot());

            Assert.IsNotNull(foot);
            Assert.IsInstanceOfType(foot.Unit, typeof(Foot));

            foot = foot.Round(2);

            Assert.AreEqual(1760d * 3d, foot.Scalar);

            var inch = ValueConverter.Convert(mile, new Inch());

            Assert.IsNotNull(inch);
            Assert.IsInstanceOfType(inch.Unit, typeof(Inch));

            inch = inch.Round(2);

            Assert.AreEqual(1760d * 3d * 12d, inch.Scalar);

            yard = new Value<Yard>(1.0);

            foot = ValueConverter.Convert(yard, new Foot());

            Assert.IsNotNull(foot);
            Assert.IsInstanceOfType(foot.Unit, typeof(Foot));

            foot = foot.Round(2);

            Assert.AreEqual(3d, foot.Scalar);

            inch = ValueConverter.Convert(yard, new Inch());

            Assert.IsNotNull(inch);
            Assert.IsInstanceOfType(inch.Unit, typeof(Inch));

            inch = inch.Round(2);

            Assert.AreEqual(3d * 12d, inch.Scalar);

            foot = new Value<Foot>(1.0);

            inch = ValueConverter.Convert(foot, new Inch());

            Assert.IsNotNull(inch);
            Assert.IsInstanceOfType(inch.Unit, typeof(Inch));

            inch = inch.Round(2);

            Assert.AreEqual(12d, inch.Scalar);
        }

        [TestMethod]
        public void SpellingDifference()
        {
            var unit = UnitConverter.ToUnitOfMeasurement("kM");

            Assert.IsNotNull(unit);
            Assert.IsInstanceOfType(unit, typeof(Kilometer));

            unit = UnitConverter.ToUnitOfMeasurement("Yd");

            Assert.IsNotNull(unit);
            Assert.IsInstanceOfType(unit, typeof(Yard));
        }

        [TestMethod]
        public void ManualParsecToLightYear()
        {
            var pcUnit = UnitConverter.ToUnitOfMeasurement("Length", 30_856_775_814_913_700, "pc");

            var lyUnit = UnitConverter.ToUnitOfMeasurement("Length", 9_460_730_472_580_800, "ly");

            var pcValue = new Value(1.0, pcUnit);

            var lyValue = ValueConverter.Convert(pcValue, lyUnit);

            Assert.IsInstanceOfType(lyValue.Unit, typeof(CustomLength));

            lyValue = lyValue.Round(5);

            Assert.AreEqual(3.26156d, lyValue.Scalar);
        }

        [TestMethod]
        public void BuiltInParsecToLightYear()
        {
            var pcUnit = new Parsec();

            var lyUnit = new LightYear();

            var pcValue = new Value(1.0, pcUnit);

            var lyValue = ValueConverter.Convert(pcValue, lyUnit);

            lyValue = lyValue.Round(5);

            Assert.AreEqual(3.26156d, lyValue.Scalar);

            var mValue = ValueConverter.Convert(pcValue, new Meter());

            mValue = mValue.Round(0);

            Assert.AreEqual(30_856_775_814_913_673d.ToString(), mValue.Scalar.ToString());
        }

        [TestMethod]
        public void LitersPerHourToLiters()
        {
            var litersPerHour = new Value(12.0, new FractionUnit<Liter, Hour>());

            var time = new Value<Minute>(30);

            var liters = ValueConverter.ConvertValueOverTimeToValue(litersPerHour, time);

            Assert.IsNotNull(liters);
            Assert.AreEqual(6d, liters.Scalar);
            Assert.IsInstanceOfType(liters.Unit, typeof(Liter));
        }

        [TestMethod]
        public void CubicMetersToTonsWithStandardDensity()
        {
            var density = new DensityValue(1.5, new Density<Kilogram, Liter>());

            var source = new Value<CubicMeter>(6.0);

            var target = ValueConverter.Convert(source, new Ton(), density);

            Assert.IsNotNull(target);
            Assert.AreEqual(9.0, target.Scalar);
            Assert.IsInstanceOfType(target.Unit, typeof(Ton));
        }

        [TestMethod]
        public void CubicMetersToCubicFeet()
        {
            var m3 = new Value<CubicMeter>(1.0d);

            var ft3 = ValueConverter.Convert<CubicFoot>(m3);

            Assert.IsNotNull(ft3);
            Assert.IsInstanceOfType(ft3.Unit, typeof(CubicFoot));

            ft3 = ft3.Round(4);

            Assert.AreEqual(35.3147d, ft3.Scalar);
        }

        [TestMethod]
        public void UnitEquality()
        {
            var kg = new Kilogram();

            Assert.IsTrue(kg == UnitConverter.ToUnitOfMeasurement("kg"));
            Assert.IsTrue(kg == UnitConverter.ToUnitOfMeasurement("KG"));

            var kgm_in = new CustomWeight(1, "kgm");

            Assert.IsTrue(kg == kgm_in);

            UnitConverter.RegisterCustomUnit(kgm_in);

            var kgm_out = UnitConverter.ToUnitOfMeasurement("kgm");

            Assert.IsTrue(kg == kgm_out);

            Assert.IsFalse(kg == null);
            Assert.IsFalse(null == kg);

            Assert.IsTrue(kg != null);
            Assert.IsTrue(null != kg);

            Assert.IsFalse(kg != kgm_in);
        }

        [TestMethod]
        public void ValueEquality()
        {
            Assert.IsTrue(new Value(5, "kg") == new Value(5, "kg"));
            Assert.IsTrue(new Value(5, "t") == new Value(5000, "kg"));
            Assert.IsTrue(new Value(5000, "kg") == new Value(5, "t"));
            Assert.IsTrue(new Value(5, "kg/m3") == new DensityValue<Kilogram, CubicMeter>(5));
            Assert.IsTrue(new Value(5, "t/m3") == new DensityValue<Kilogram, Liter>(5));
            Assert.IsTrue(new Value<Foot>(6) == new Value<Yard>(2));

            Assert.IsTrue(new Value(5, "kg") != null);
            Assert.IsTrue(null != new Value(5, "kg"));

            Assert.IsFalse(new Value<Foot>(6) != new Value<Yard>(2));
        }

        [TestMethod]
        public void FallbackFail()
        {
            UnitConverter.RegisterCustomUnit(new CustomWeight(15, "aB"));
            UnitConverter.RegisterCustomUnit(new CustomVolume(25, "Ab"));

            var ab = UnitConverter.ToUnitOfMeasurement("ab");

            Assert.IsInstanceOfType(ab, typeof(UnknownSimpleUnitOfMeasurement));

            var AB = UnitConverter.ToUnitOfMeasurement("AB");

            Assert.IsInstanceOfType(AB, typeof(UnknownSimpleUnitOfMeasurement));
        }

        [TestMethod]
        public void CustomFractionUnitsFromText()
        {
            var pph_in = UnitConverter.ToUnitOfMeasurement("PPH", "Weight", 0.45359237, "lb", "Time", 60.0 * 60.0, "h");

            var success = UnitConverter.RegisterCustomUnit(pph_in);

            Assert.IsTrue(success);

            var pph_out = UnitConverter.ToUnitOfMeasurement("PPH");

            Assert.IsNotNull(pph_out);
            Assert.IsInstanceOfType(pph_out, typeof(FractionUnit));
            Assert.AreSame(pph_in, pph_out);

            var fractionPph = (FractionUnit)pph_out;

            Assert.IsInstanceOfType(fractionPph.Numerator, typeof(CustomWeight));
            Assert.IsInstanceOfType(fractionPph.Denominator, typeof(CustomTime));
        }

        [TestMethod]
        public void CustomFractionUnitsFromUnit()
        {
            var pph_in = new CustomFractionUnit(new Pound(), new Hour());

            var success = UnitConverter.RegisterCustomUnit(pph_in);

            Assert.IsTrue(success);

            var pph_out = UnitConverter.ToUnitOfMeasurement("lb/h");

            Assert.IsNotNull(pph_out);
            Assert.IsInstanceOfType(pph_out, typeof(FractionUnit));
            Assert.AreSame(pph_in, pph_out);

            var fractionPph = (FractionUnit)pph_out;

            Assert.IsInstanceOfType(fractionPph.Numerator, typeof(Pound));
            Assert.IsInstanceOfType(fractionPph.Denominator, typeof(Hour));
        }

        [TestMethod]
        public void Temperature()
        {
            var freezeCelsius = new Value<Celsius>(0);

            var freezeKelvin = ValueConverter.Convert<Kelvin>(freezeCelsius);

            Assert.AreEqual(273.15d, freezeKelvin.Scalar);

            var freezeCelsius2 = ValueConverter.Convert(freezeKelvin, new Celsius());

            Assert.AreEqual(0, freezeCelsius2.Scalar);

            var freezeCelsius3 = ValueConverter.Convert(freezeCelsius, new Celsius());

            Assert.AreEqual(0, freezeCelsius3.Scalar);

            var freezeFahrenheit = ValueConverter.Convert(freezeCelsius, new Fahrenheit());

            Assert.AreEqual(32.0, freezeFahrenheit.Scalar);

            var bodyFahrenheit = new Value<Fahrenheit>(98.6);

            var bodyCelsius = ValueConverter.Convert(bodyFahrenheit, UnitConverter.ToUnitOfMeasurement("°c"));

            Assert.AreEqual(37.0, bodyCelsius.Scalar);

            var absoluteZeroKelvin = new Value<Kelvin>(0);

            var absoluteZeroFahrenheit = ValueConverter.Convert<Fahrenheit>(absoluteZeroKelvin);

            Assert.AreEqual(-459.67, absoluteZeroFahrenheit.Scalar);
        }

        [TestMethod]
        public void GallonsPerMinuteToKilogramm()
        {
            var gpmUnit = UnitConverter.ToUnitOfMeasurement("GPM", "volume", 3.785411784, "US.liq.gal.", "time", 60, "min");

            UnitConverter.RegisterCustomUnit(gpmUnit);

            //Hier würde es losgehen

            var gpmValue = new Value(20, UnitConverter.ToUnitOfMeasurement("GPM"));

            //Hier würde integriert werden

            var gValue = new Value(gpmValue.Scalar, UnitConverter.ToUnitOfMeasurement("US.liq.gal."));

            var densityValue = new DensityValue(1.3, "lb/ft3");

            var kgUnit = UnitConverter.ToUnitOfMeasurement("kg");

            var kgValue = ValueConverter.Convert(gValue, kgUnit, densityValue);

            kgValue = kgValue.Round(3);

            Assert.AreEqual(1.577, kgValue.Scalar);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterDifferentFactors()
        {
            var hurzUnit = UnitConverter.ToUnitOfMeasurement("time", 23, "hurz");

            UnitConverter.RegisterCustomUnit(hurzUnit);

            var hotzOverHurz = UnitConverter.ToUnitOfMeasurement("HoH", "volume", 42, "hotz", "time", 12, "hurz");

            UnitConverter.RegisterCustomUnit(hotzOverHurz);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RegisterDifferentCategories()
        {
            var hurzUnit = UnitConverter.ToUnitOfMeasurement("time", 23, "hurz");

            UnitConverter.RegisterCustomUnit(hurzUnit);

            var hotzOverHurz = UnitConverter.ToUnitOfMeasurement("HoH", "volume", 42, "hotz", "weight", 23, "hurz");

            UnitConverter.RegisterCustomUnit(hotzOverHurz);
        }

        [TestMethod]
        public void KilogramIsKilogram()
        {
            var areEqual = (new Kilogram()).Equals("kg");

            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void ShortTon()
        {
            var shortTon = new Value<Pound>(2000);

            var kg = ValueConverter.Convert(shortTon, new Kilogram());

            Assert.AreEqual(907.18474m, Convert.ToDecimal(kg.Scalar));

            var std = new Value(2000, new FractionUnit<Pound, Day>());

            var kph = ValueConverter.Convert(std, new FractionUnit<Kilogram, Hour>());

            Assert.AreEqual(37.7993641666667m, Convert.ToDecimal(kph.Scalar));
        }
    }
}