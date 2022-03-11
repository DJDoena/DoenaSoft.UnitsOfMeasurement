using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using Exceptions;
    using FractionUnits;
    using FractionUnits.Densities;
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
            var sourceValue = new Value(10.4m, UnitConverter.ToUnitOfMeasurement("t"));
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
            var source = new Value<Millimeter>(50m);
            var target = ValueConverter.Convert(source, new Kilometer());
            Assert.AreEqual(0.00005m, target.Scalar);
            Assert.AreEqual(typeof(Kilometer), target.Unit.GetType());
        }

        [TestMethod]
        public void MeterToMillimeter()
        {
            var source = new Value<Meter>(10.4m);
            var target = ValueConverter.Convert(source, new Millimeter());
            Assert.AreEqual(10400.0m, target.Scalar);
            Assert.AreEqual(typeof(Millimeter), target.Unit.GetType());

            var source2 = new Value(10.4m, UnitConverter.ToUnitOfMeasurement("m"));
            var target2 = ValueConverter.Convert(source2, new Millimeter());
            Assert.AreEqual(10400.0m, target2.Scalar);
            Assert.AreEqual(typeof(Millimeter), target2.Unit.GetType());
        }

        [TestMethod]
        public void LiterToMilliliter()
        {
            var source = new Value<Liter>(10.4m);
            var target = ValueConverter.Convert(source, new Milliliter());
            Assert.AreEqual(10400.0m, target.Scalar);
            Assert.AreEqual(typeof(Milliliter), target.Unit.GetType());

            var source2 = new Value(10.4m, UnitConverter.ToUnitOfMeasurement("l"));
            var target2 = ValueConverter.Convert(source2, new Milliliter());
            Assert.AreEqual(10400.0m, target2.Scalar);
            Assert.AreEqual(typeof(Milliliter), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToGram()
        {
            var source = new Value<Kilogram>(10.4m);
            var target = ValueConverter.Convert(source, new Gram());
            Assert.AreEqual(10400.0m, target.Scalar);
            Assert.AreEqual(typeof(Gram), target.Unit.GetType());

            var source2 = new Value(10.4m, UnitConverter.ToUnitOfMeasurement("kg"));
            var target2 = ValueConverter.Convert(source2, new Gram());
            Assert.AreEqual(10400.0m, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToTon()
        {
            var source = new Value<Kilogram>(10.4m);
            var target = ValueConverter.Convert(source, new Ton());
            Assert.AreEqual(0.0104m, target.Scalar);
            Assert.AreEqual(typeof(Ton), target.Unit.GetType());

            var source2 = new Value(10.4m, UnitConverter.ToUnitOfMeasurement("kg"));
            var target2 = ValueConverter.Convert(source2, new Ton());
            Assert.AreEqual(0.0104m, target2.Scalar);
            Assert.AreEqual(typeof(Ton), target2.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToBaseUnit()
        {
            var source = new Value<Gram>(10.4m);
            var target = ValueConverter.ConvertToBaseValue(source);

            var scalar = Math.Round(target.Scalar, 4, MidpointRounding.AwayFromZero);

            Assert.AreEqual(0.0104m, scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());

            var source2 = new Value(10.4m, UnitConverter.ToUnitOfMeasurement("t"));
            var target2 = ValueConverter.ConvertToBaseValue(source2);

            scalar = Math.Round(target2.Scalar, 4, MidpointRounding.AwayFromZero);

            Assert.AreEqual(10400m, scalar);
            Assert.AreEqual(typeof(Kilogram), target2.Unit.GetType());

            var source3 = new Value(10.4m, "km/s");
            var target3 = ValueConverter.ConvertToBaseValue(source3);
            var scalar3 = Math.Round(target3.Scalar, 4, MidpointRounding.AwayFromZero);

            Assert.AreEqual(10400m, scalar3);
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
            var source = new Value<Milliliter>(1000m);
            var target = ValueConverter.Convert(source, new Kilogram(), new DensityValue<Density<Kilogram, Liter>>(0.5m));
            Assert.AreEqual(0.5m, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());

            var source2 = new Value<Milliliter>(1000m);
            var target2 = ValueConverter.Convert(source2, new Gram(), new DensityValue<Density<Kilogram, Liter>>(2m));
            Assert.AreEqual(2000m, target2.Scalar);
            Assert.AreEqual(typeof(Gram), target2.Unit.GetType());
            var target3 = ValueConverter.Convert(target2, new Kilogram());
            Assert.AreEqual(2m, target3.Scalar);
            Assert.AreEqual(typeof(Kilogram), target3.Unit.GetType());
        }

        [TestMethod]
        public void LiterToKilogram()
        {
            const decimal DensityOfHelium = 0.1785m; // kg/l

            var source = new Value(5m, UnitConverter.ToUnitOfMeasurement("dm³"));
            var target = ValueConverter.Convert(source, new Kilogram(), new DensityValue<Density<Kilogram, Liter>>(DensityOfHelium));
            Assert.AreEqual(DensityOfHelium * 5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());
        }

        [TestMethod]
        public void LiterToKilogram2()
        {
            const decimal DensityOfHelium = 0.1785m; // kg/l

            var source = new Value(5m, UnitConverter.ToUnitOfMeasurement("L"));
            var target = ValueConverter.Convert(source, new Kilogram(), new DensityValue<Kilogram, Liter>(DensityOfHelium));
            Assert.AreEqual(DensityOfHelium * 5, target.Scalar);
            Assert.AreEqual(typeof(Kilogram), target.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToLiter()
        {
            const decimal DensityOfHelium = 0.1785m; // kg/l

            // 5 kg Helium / 0.1785 = 28,011 Liter
            var source = new Value(5m, UnitConverter.ToUnitOfMeasurement("kg"));
            var target = ValueConverter.Convert(source, new Liter(), new DensityValue<Kilogram, Liter>(DensityOfHelium));
            Assert.AreEqual(5m / 0.1785m, target.Scalar);
            Assert.AreEqual(typeof(Liter), target.Unit.GetType());
        }

        [TestMethod]
        public void KilogramToLiter2()
        {
            const decimal DensityOfHelium = 0.1785m; // kg/l

            // 5 kg Helium / 0.1785 = 28,011 Liter
            var source = new Value(5m, UnitConverter.ToUnitOfMeasurement("kg"));
            var target = ValueConverter.Convert(source, new Liter(), new DensityValue<Density<Kilogram, Liter>>(DensityOfHelium));
            Assert.AreEqual(5 / 0.1785m, target.Scalar);
            Assert.AreEqual(typeof(Liter), target.Unit.GetType());
        }

        [TestMethod]
        public void CubicCentimeterToGram()
        {
            const decimal DensityOfGold = 19.302m; // g/cm³

            var source = new Value(2m, UnitConverter.ToUnitOfMeasurement("cm³"));
            var target = ValueConverter.Convert(source, new Gram(), new DensityValue(DensityOfGold, " g/cm³"));
            Assert.AreEqual(DensityOfGold * 2, target.Scalar);
            Assert.AreEqual(typeof(Gram), target.Unit.GetType());
        }

        [TestMethod]
        public void JohnFuelConsumptionTest()
        {
            const decimal LiterPerKilometer = 5.9m / 100m;
            const decimal GasMileage = 39.86688m;

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
            var sourceWeight = new Value(10m, new Kilogram());

            var density = new DensityValue<Density<Kilogram, Liter>>(0.5);

            var targetVolume = ValueConverter.Convert(sourceWeight, new Liter(), density);

            Assert.IsNotNull(targetVolume);
            Assert.IsInstanceOfType(targetVolume.Unit, typeof(Liter));
            Assert.AreEqual(20m, targetVolume.Scalar);

            var targetWeight = ValueConverter.Convert(targetVolume, new Kilogram(), density);

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(10m, targetWeight.Scalar);
        }

        [TestMethod]
        [ExpectedException(typeof(UnitConversionException))]
        public void LengthToWeight()
        {
            var density = new DensityValue<Kilogram, Liter>(0.5m);

            var sourceWeight = new Value(10m, new Meter());

            ValueConverter.Convert(sourceWeight, new Kilogram(), density);
        }

        [TestMethod]
        public void VolumeToWeightAndBackAgainGeneral()
        {
            var density = new DensityValue<Density<Kilogram, Liter>>(0.5);

            var sourceWeight = new Value(10m, new Kilogram());

            var targetVolume = ValueConverter.Convert(sourceWeight, new Liter(), new DensityValue(density.Scalar, "kg/L"));

            Assert.IsNotNull(targetVolume);
            Assert.IsInstanceOfType(targetVolume.Unit, typeof(Liter));
            Assert.AreEqual(20m, targetVolume.Scalar);

            var targetWeight = ValueConverter.Convert(targetVolume, new Kilogram(), density);

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(10m, targetWeight.Scalar);
        }

        [TestMethod]
        public void VolumeToWeightAndBackAgainWithConversionFactor()
        {
            var conversionfactor = 0.5m;

            var sourceWeight = new Value(10m, new Kilogram());

            var targetVolume = ValueConverter.Convert(sourceWeight, new Liter(), new DensityValue<Kilogram, Liter>(conversionfactor));

            Assert.IsNotNull(targetVolume);
            Assert.IsInstanceOfType(targetVolume.Unit, typeof(Liter));
            Assert.AreEqual(20m, targetVolume.Scalar);

            var targetWeight = ValueConverter.Convert(targetVolume, new Kilogram(), new DensityValue<Kilogram, Liter>(conversionfactor));

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(10m, targetWeight.Scalar);
        }

        [TestMethod]
        public void ELinkConversionFactor()
        {
            var density = new DensityValue<Kilogram, Liter>(0.8m);

            var sourceVolume = new Value(10m, new Liter());

            var targetWeight = ValueConverter.Convert(sourceVolume, new Kilogram(), density);

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));
            Assert.AreEqual(8.0m, targetWeight.Scalar);
        }

        [TestMethod]
        public void SupermanWeight() //220 lbs
        {
            var sourceWeight = new Value(220m, new Pound());

            var targetWeight = ValueConverter.Convert(sourceWeight, new Kilogram());

            Assert.IsNotNull(targetWeight);
            Assert.IsInstanceOfType(targetWeight.Unit, typeof(Kilogram));

            targetWeight = targetWeight.Round(2);

            Assert.AreEqual(99.79m, targetWeight.Scalar);
        }

        [TestMethod]
        public void SupermanHeight() //6'4"
        {
            var sourceFeet = new Value(6m, new Foot());

            var targetInch = ValueConverter.Convert(sourceFeet, new Inch());

            Assert.IsNotNull(targetInch);
            Assert.IsInstanceOfType(targetInch.Unit, typeof(Inch));
            Assert.AreEqual(6m * 12m, targetInch.Scalar); //1 foot = 12 inch

            targetInch = targetInch.Add(4m);

            var targetMeter = ValueConverter.Convert(targetInch, new Meter());

            Assert.IsNotNull(targetMeter);
            Assert.IsInstanceOfType(targetMeter.Unit, typeof(Meter));

            targetMeter = targetMeter.Round(4);

            Assert.AreEqual(1.9304m, targetMeter.Scalar);
        }

        [TestMethod]
        public void ImperialLengths()
        {
            var mile = new Value<Mile>(1.0m);

            var yard = ValueConverter.Convert(mile, new Yard());

            Assert.IsNotNull(yard);
            Assert.IsInstanceOfType(yard.Unit, typeof(Yard));

            yard = yard.Round(2);

            Assert.AreEqual(1760m, yard.Scalar);

            var foot = ValueConverter.Convert(mile, new Foot());

            Assert.IsNotNull(foot);
            Assert.IsInstanceOfType(foot.Unit, typeof(Foot));

            foot = foot.Round(2);

            Assert.AreEqual(1760m * 3m, foot.Scalar);

            var inch = ValueConverter.Convert(mile, new Inch());

            Assert.IsNotNull(inch);
            Assert.IsInstanceOfType(inch.Unit, typeof(Inch));

            inch = inch.Round(2);

            Assert.AreEqual(1760m * 3m * 12m, inch.Scalar);

            yard = new Value<Yard>(1.0m);

            foot = ValueConverter.Convert(yard, new Foot());

            Assert.IsNotNull(foot);
            Assert.IsInstanceOfType(foot.Unit, typeof(Foot));

            foot = foot.Round(2);

            Assert.AreEqual(3m, foot.Scalar);

            inch = ValueConverter.Convert(yard, new Inch());

            Assert.IsNotNull(inch);
            Assert.IsInstanceOfType(inch.Unit, typeof(Inch));

            inch = inch.Round(2);

            Assert.AreEqual(3m * 12m, inch.Scalar);

            foot = new Value<Foot>(1.0m);

            inch = ValueConverter.Convert(foot, new Inch());

            Assert.IsNotNull(inch);
            Assert.IsInstanceOfType(inch.Unit, typeof(Inch));

            inch = inch.Round(2);

            Assert.AreEqual(12m, inch.Scalar);
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

            var pcValue = new Value(1.0m, pcUnit);

            var lyValue = ValueConverter.Convert(pcValue, lyUnit);

            Assert.IsInstanceOfType(lyValue.Unit, typeof(CustomLength));

            lyValue = lyValue.Round(5);

            Assert.AreEqual(3.26156m, lyValue.Scalar);
        }

        [TestMethod]
        public void BuiltInParsecToLightYear()
        {
            var pcUnit = new Parsec();

            var lyUnit = new LightYear();

            var pcValue = new Value(1.0m, pcUnit);

            var lyValue = ValueConverter.Convert(pcValue, lyUnit);

            lyValue = lyValue.Round(5);

            Assert.AreEqual(3.26156m, lyValue.Scalar);

            var mValue = ValueConverter.Convert(pcValue, new Meter());

            mValue = mValue.Round(0);

            Assert.AreEqual(30_856_775_814_913_705m.ToString(), mValue.Scalar.ToString());
        }

        [TestMethod]
        public void LitersPerHourToLiters()
        {
            var litersPerHour = new Value(12.0m, new FractionUnit<Liter, Hour>());

            var time = new Value<Minute>(30m);

            var liters = ValueConverter.ConvertValueOverTimeToValue(litersPerHour, time);

            Assert.IsNotNull(liters);
            Assert.AreEqual(6m, liters.Scalar);
            Assert.IsInstanceOfType(liters.Unit, typeof(Liter));
        }

        [TestMethod]
        public void CubicMetersToTonsWithStandardDensity()
        {
            var density = new DensityValue(1.5m, new Density<Kilogram, Liter>());

            var source = new Value<CubicMeter>(6.0m);

            var target = ValueConverter.Convert(source, new Ton(), density);

            Assert.IsNotNull(target);
            Assert.AreEqual(9.0m, target.Scalar);
            Assert.IsInstanceOfType(target.Unit, typeof(Ton));
        }

        [TestMethod]
        public void CubicMetersToCubicFeet()
        {
            var m3 = new Value<CubicMeter>(1.0m);

            var ft3 = ValueConverter.Convert<CubicFoot>(m3);

            Assert.IsNotNull(ft3);
            Assert.IsInstanceOfType(ft3.Unit, typeof(CubicFoot));

            ft3 = ft3.Round(4);

            Assert.AreEqual(35.3147m, ft3.Scalar);
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
            Assert.IsTrue(new Value(5m, "kg") == new Value(5m, "kg"));
            Assert.IsTrue(new Value(5m, "t") == new Value(5000m, "kg"));
            Assert.IsTrue(new Value(5000m, "kg") == new Value(5m, "t"));
            Assert.IsTrue(new Value(5m, "kg/m3") == new DensityValue<Kilogram, CubicMeter>(5m));
            Assert.IsTrue(new Value(5m, "t/m3") == new DensityValue<Kilogram, Liter>(5m));
            Assert.IsTrue(new Value<Foot>(6m) == new Value<Yard>(2m));

            Assert.IsTrue(new Value(5m, "kg") != null);
            Assert.IsTrue(null != new Value(5m, "kg"));

            Assert.IsFalse(new Value<Foot>(6m) != new Value<Yard>(2m));
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
            var pph_in = UnitConverter.ToUnitOfMeasurement("PPH", "Weight", 0.45359237m, "lb", "Time", 60.0m * 60.0m, "h");

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
            var freezeCelsius = new Value<Celsius>(0m);

            var freezeKelvin = ValueConverter.Convert<Kelvin>(freezeCelsius);

            Assert.AreEqual(273.15m, freezeKelvin.Scalar);

            var freezeCelsius2 = ValueConverter.Convert(freezeKelvin, new Celsius());

            Assert.AreEqual(0m, freezeCelsius2.Scalar);

            var freezeCelsius3 = ValueConverter.Convert(freezeCelsius, new Celsius());

            Assert.AreEqual(0m, freezeCelsius3.Scalar);

            var freezeFahrenheit = ValueConverter.Convert(freezeCelsius, new Fahrenheit());

            Assert.AreEqual(32.0m, freezeFahrenheit.Scalar);

            var bodyFahrenheit = new Value<Fahrenheit>(98.6m);

            var bodyCelsius = ValueConverter.Convert(bodyFahrenheit, UnitConverter.ToUnitOfMeasurement("°c"));

            Assert.AreEqual(37.0m, bodyCelsius.Scalar);

            var absoluteZeroKelvin = new Value<Kelvin>(0m);

            var absoluteZeroFahrenheit = ValueConverter.Convert<Fahrenheit>(absoluteZeroKelvin);

            Assert.AreEqual(-459.67m, absoluteZeroFahrenheit.Scalar);
        }

        [TestMethod]
        public void GallonsPerMinuteToKilogramm()
        {
            var gpmUnit = UnitConverter.ToUnitOfMeasurement("GPM", "volume", 3.785411784m, "US.liq.gal.", "time", 60, "min");

            UnitConverter.RegisterCustomUnit(gpmUnit);

            //Hier würde es losgehen

            var gpmValue = new Value(20m, UnitConverter.ToUnitOfMeasurement("GPM"));

            //Hier würde integriert werden

            var gValue = new Value(gpmValue.Scalar, UnitConverter.ToUnitOfMeasurement("US.liq.gal."));

            var densityValue = new DensityValue(1.3m, "lb/ft3");

            var kgUnit = UnitConverter.ToUnitOfMeasurement("kg");

            var kgValue = ValueConverter.Convert(gValue, kgUnit, densityValue);

            kgValue = kgValue.Round(3);

            Assert.AreEqual(1.577m, kgValue.Scalar);
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
            var shortTon = new Value<Pound>(2000m);

            var kg = ValueConverter.Convert(shortTon, new Kilogram());

            Assert.AreEqual(907.18474m, kg.Scalar);

            var std = new Value(2000m, new FractionUnit<Pound, Day>());

            var kph = ValueConverter.Convert(std, new FractionUnit<Kilogram, Hour>()).Round(10);

            Assert.AreEqual(37.7993641667m, kph.Scalar);
        }
    }
}