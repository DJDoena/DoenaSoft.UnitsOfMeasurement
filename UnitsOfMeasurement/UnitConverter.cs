using System;
using System.Collections.Generic;
using System.Linq;

namespace DoenaSoft.UnitsOfMeasurement
{
    using ComplexUnits;
    using Exceptions;
    using SimpleUnits;
    using SimpleUnits.Areas;
    using SimpleUnits.Energies;
    using SimpleUnits.Lengths;
    using SimpleUnits.Temperatures;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Converts <see cref="string"/>s representing units to <see cref="UnitOfMeasurement"/>s.
    /// </summary>
    public static class UnitConverter
    {
        private static readonly Dictionary<string, UnitOfMeasurement> _units;

        static UnitConverter()
        {
            _units = new Dictionary<string, UnitOfMeasurement>();

            #region Length  

            _units.Add("m", new Meter());

            _units.Add("km", new Kilometer());

            _units.Add("mm", new Millimeter());

            _units.Add("cm", new Centimeter());

            _units.Add("dm", new Decimeter());

            var mi = new Mile();
            _units.Add("mi", mi);
            _units.Add("mei", mi);

            _units.Add("yd", new Yard());

            var ft = new Foot();
            _units.Add("ft", ft);
            _units.Add("'", ft);

            var inch = new Inch();
            _units.Add("in", inch);
            _units.Add("inc", inch);
            _units.Add("\"", inch);

            _units.Add("au", new AstronomicalUnit());

            _units.Add("pc", new Parsec());

            _units.Add("ly", new LightYear());

            #endregion

            #region Volume

            var l = new Liter();
            _units.Add("dm3", l);
            _units.Add("l", l);
            _units.Add("dm³", l);

            var ml = new Milliliter();
            _units.Add("cm3", ml);
            _units.Add("ml", ml);
            _units.Add("cm³", ml);

            var m3 = new CubicMeter();
            _units.Add("m3", m3);
            _units.Add("m³", m3);

            var ft3 = new CubicFoot();
            _units.Add("ft3", ft3);
            _units.Add("ft³", ft3);
            _units.Add("'3", ft3);
            _units.Add("'³", ft3);

            var in3 = new CubicInch();
            _units.Add("in3", in3);
            _units.Add("in³", in3);
            _units.Add("\"3", in3);
            _units.Add("\"³", in3);

            _units.Add("US.liq.gal.", new USLiquidGallon());

            _units.Add("Imp.gal.", new ImperialGallon());

            #endregion

            #region Weight

            var t = new Ton();
            _units.Add("t", t);

            _units.Add("kg", new Kilogram());

            _units.Add("g", new Gram());

            _units.Add("mg", new Milligram());

            var lb = new Pound();
            _units.Add("lb", lb);
            _units.Add("lb.", lb);
            _units.Add("lbs", lb);

            var stn = new ShortTon();
            _units.Add("stn", stn);
            _units.Add("short ton", stn);

            #endregion

            #region Time

            var h = new Hour();
            _units.Add("h", h);
            _units.Add("hr", h);
            _units.Add("hour", h);
            _units.Add("hours", h);

            var min = new Minute();
            _units.Add("min", min);
            _units.Add("minute", min);
            _units.Add("minutes", min);

            var sec = new Second();
            _units.Add("s", sec);
            _units.Add("sec", sec);
            _units.Add("second", sec);
            _units.Add("seconds", sec);

            var day = new Day();
            _units.Add("d", day);
            _units.Add("day", day);
            _units.Add("days", day);

            #endregion

            #region  Area

            var m2 = new SquareMeter();
            _units.Add("m2", m2);
            _units.Add("m²", m2);

            _units.Add("ha", new Hectare());

            var km2 = new SquareKilometer();
            _units.Add("km2", km2);
            _units.Add("km²", km2);

            var ft2 = new SquareFoot();
            _units.Add("ft2", ft2);
            _units.Add("ft²", ft2);
            _units.Add("'2", ft2);
            _units.Add("'²", ft2);

            var in2 = new SquareInch();
            _units.Add("in2", in2);
            _units.Add("in²", in2);
            _units.Add("\"2", in2);
            _units.Add("\"²", in2);

            var acre = new Acre();
            _units.Add("ac", acre);
            _units.Add("acre", acre);

            #endregion

            #region Temperature

            _units.Add("K", new Kelvin());

            var celsius = new Celsius();
            _units.Add("°C", celsius);
            _units.Add("C", celsius);

            var fahrenheit = new Fahrenheit();
            _units.Add("°F", fahrenheit);
            _units.Add("F", fahrenheit);

            #endregion

            #region Energy

            _units.Add("J", new Joule());

            _units.Add("kJ", new KiloJoule());

            _units.Add("Wh", new WattHour());

            _units.Add("kWh", new KiloWattHour());

            _units.Add("MWh", new MegaWattHour());

            #endregion
        }

        /// <summary>
        /// Returns all known <see cref="UnitOfMeasurement"/>
        /// </summary>
        public static IReadOnlyList<UnitOfMeasurement> GetKnownUnits() => _units.Values.Distinct().ToList();

        /// <summary>
        /// Converts a <see cref="string"/> representing a unit to a <see cref="UnitOfMeasurement"/>.
        /// </summary>
        /// <param name="unitOfMeasurement">a <see cref="string"/> representing a unit</param>
        /// <returns>a <see cref="UnitOfMeasurement"/></returns>
        public static UnitOfMeasurement ToUnitOfMeasurement(string unitOfMeasurement)
        {
            if (string.IsNullOrWhiteSpace(unitOfMeasurement) || unitOfMeasurement == "?")
            {
                return new UndefinedUnitOfMeasurement();
            }

            unitOfMeasurement = unitOfMeasurement.Trim();

            if (_units.TryGetValue(unitOfMeasurement, out var unit))
            {
                return unit;
            }

            var fraction = unitOfMeasurement.Split('/');

            if (fraction.Length > 1)
            {
                if (fraction.Length == 2
                    && ToUnitOfMeasurement(fraction[0]) is ISimpleUnit numeratorUnit
                    && ToUnitOfMeasurement(fraction[1]) is ISimpleUnit denominatorUnit)
                {
                    if (numeratorUnit is Weight weight && denominatorUnit is Volume volume)
                    {
                        return new Density(weight, volume);
                    }
                    else
                    {
                        return new ComplexUnit(numeratorUnit, denominatorUnit);
                    }
                }
                else
                {
                    return new UnknownComplexUnitOfMeasurement(unitOfMeasurement);
                }
            }
            else if (unitOfMeasurement.Any(char.IsWhiteSpace))
            {
                return new UnknownUnitOfMeasurement(unitOfMeasurement);
            }
            else
            {
                var possibleMatchingUnits = _units.Where(kvp => kvp.Key.ToLowerInvariant() == unitOfMeasurement.ToLowerInvariant()).ToList();

                if (possibleMatchingUnits.Any())
                {
                    var firstMatchingUnit = possibleMatchingUnits[0].Value;

                    //if we do this then all matching keys must be the same unit
                    if (possibleMatchingUnits.All(u => u.Value.Equals(firstMatchingUnit)))
                    {
                        return firstMatchingUnit;
                    }
                    else
                    {
                        return new UnknownSimpleUnitOfMeasurement(unitOfMeasurement);
                    }
                }
                else
                {
                    return new UnknownSimpleUnitOfMeasurement(unitOfMeasurement);
                }
            }
        }

        /// <summary>
        /// Converts the given data into a <see cref="ICustomUnit"/>.
        /// </summary>
        /// <param name="unitCategory">the category this unit belongs to</param>
        /// <param name="conversionFactorToBaseUnit">the multiplication factor of this unit in relation to the base unit of the given category</param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream</param>
        /// <returns>a <see cref="ICustomUnit"/></returns>
        public static ICustomUnit ToUnitOfMeasurement(string unitCategory, double conversionFactorToBaseUnit, string serializableValue)
        {
            unitCategory = unitCategory?.ToLowerInvariant();

            switch (unitCategory)
            {
                case "area":
                    {
                        return new CustomArea(conversionFactorToBaseUnit, serializableValue);
                    }
                case "length":
                    {
                        return new CustomLength(conversionFactorToBaseUnit, serializableValue);
                    }
                case "time":
                    {
                        return new CustomTime(conversionFactorToBaseUnit, serializableValue);
                    }
                case "volume":
                    {
                        return new CustomVolume(conversionFactorToBaseUnit, serializableValue);
                    }
                case "weight":
                    {
                        return new CustomWeight(conversionFactorToBaseUnit, serializableValue);
                    }
                case "energy":
                    {
                        return new CustomEnergy(conversionFactorToBaseUnit, serializableValue);
                    }
                default:
                    {
                        throw new NotSupportedException($"Unit category '{unitCategory}' is not supported.");
                    }
            }
        }

        /// <summary>
        /// Converts the given data into a <see cref="ICustomUnit"/>.
        /// </summary>
        /// <param name="complexUnitSerializableValue">the complex unit in a format that can be sent over a data stream</param>
        /// <param name="numeratorUnitCategory">the category the numerator unit belongs to</param>
        /// <param name="numeratorConversionFactorToBaseUnit">the multiplication factor of the numerator unit in relation to the base unit of the given category</param>
        /// <param name="numeratorSerializableValue">the numerator unit in a format that can be sent over a data stream</param>
        /// <param name="denominatorUnitCategory">the category the denominator unit belongs to</param>
        /// <param name="denominatorConversionFactorToBaseUnit">the multiplication factor of the denominator unit in relation to the base unit of the given category</param>
        /// <param name="denominatorSerializableValue">the denominator unit in a format that can be sent over a data stream</param>
        /// <returns>a <see cref="ICustomUnit"/></returns>
        public static ICustomUnit ToUnitOfMeasurement(string complexUnitSerializableValue
            , string numeratorUnitCategory, double numeratorConversionFactorToBaseUnit, string numeratorSerializableValue
            , string denominatorUnitCategory, double denominatorConversionFactorToBaseUnit, string denominatorSerializableValue)
        {
            var numeratorUnit = ToUnitOfMeasurement(numeratorUnitCategory, numeratorConversionFactorToBaseUnit, numeratorSerializableValue);

            var denominatorUnit = ToUnitOfMeasurement(denominatorUnitCategory, denominatorConversionFactorToBaseUnit, denominatorSerializableValue);

            if (!(numeratorUnit is ISimpleUnit simpleNumeratorUnit))
            {
                throw new NotSupportedException($"Unit category '{numeratorUnit.UnitCategory}' is not supported.");
            }

            if (!(denominatorUnit is ISimpleUnit simpleDenominatorUnit))
            {
                throw new NotSupportedException($"Unit category '{denominatorUnit.UnitCategory}' is not supported.");
            }

            return new CustomComplexUnit(simpleNumeratorUnit, simpleDenominatorUnit, complexUnitSerializableValue);
        }

        /// <summary>
        /// Converts a <see cref="string"/> representing a unit to a <see cref="Density"/> unit.
        /// </summary>
        /// <param name="unitOfMeasurement">a <see cref="string"/> representing a unit</param>
        /// <returns>a <see cref="Density"/> unit</returns>
        public static Density ToDensityUnit(string unitOfMeasurement)
        {
            const string ErrorText = "Only " + nameof(Weight) + "/" + nameof(Volume) + " units allowed.";

            var unit = ToUnitOfMeasurement(unitOfMeasurement);

            if (!(unit is ComplexUnit complexUnit))
            {
                throw new UnitConversionException(ErrorText);
            }
            else if (!(complexUnit.Numerator is Weight weight))
            {
                throw new UnitConversionException(ErrorText);
            }
            else if (!(complexUnit.Denominator is Volume volume))
            {
                throw new UnitConversionException(ErrorText);
            }
            else
            {
                return new Density(weight, volume);
            }
        }

        /// <summary>
        /// Registers an <see cref="ICustomUnit"/> in the system to be retreived/used later.
        /// </summary>
        /// <param name="customUnit">an <see cref="ICustomUnit"/></param>
        /// <returns>true if unit was registered newly, false if already registered</returns>
        public static bool RegisterCustomUnit(ICustomUnit customUnit)
        {
            if (!(customUnit is UnitOfMeasurement))
            {
                throw new ArgumentException($"{nameof(customUnit)} is not a {nameof(UnitOfMeasurement)}!");
            }

            switch (customUnit)
            {
                case CustomArea customArea:
                    {
                        return RegisterCustomUnit(customArea);
                    }
                case CustomLength customLength:
                    {
                        return RegisterCustomUnit(customLength);
                    }
                case CustomTime customTime:
                    {
                        return RegisterCustomUnit(customTime);
                    }
                case CustomVolume customVolume:
                    {
                        return RegisterCustomUnit(customVolume);
                    }
                case CustomWeight customWeight:
                    {
                        return RegisterCustomUnit(customWeight);
                    }
                case CustomEnergy customEnergy:
                    {
                        return RegisterCustomUnit(customEnergy);
                    }
                case CustomComplexUnit customComplexUnit:
                    {
                        return RegisterCustomUnit(customComplexUnit);
                    }
                default:
                    {
                        throw new NotSupportedException($"{customUnit.GetType().Name} is not supported.");
                    }
            }
        }

        /// <summary>
        /// Registers a custom <see cref="SimpleUnit"/> in the system to be retreived/used later.
        /// </summary>
        /// <typeparam name="TUnit"/>
        /// <param name="customUnit">a custom <see cref="SimpleUnit"/></param>
        /// <returns>true if unit was registered newly, false if already registered</returns>
        public static bool RegisterCustomUnit<TUnit>(TUnit customUnit) where TUnit : SimpleUnit, ICustomUnit
        {
            if (customUnit == null)
            {
                throw new ArgumentNullException(nameof(customUnit));
            }

            var unitKey = customUnit.UnitKey;

            var newlyRegistered = RegisterCustomSimpleUnit(customUnit, unitKey);

            return newlyRegistered;
        }

        /// <summary>
        /// Registers a <see cref="CustomComplexUnit"/> in the system to be retreived/used later.
        /// </summary>
        /// <param name="customUnit">the <see cref="CustomComplexUnit"/></param>
        /// <returns>true if unit was registered newly, false if already registered</returns>
        public static bool RegisterCustomUnit(CustomComplexUnit customUnit)
        {
            if (customUnit == null)
            {
                throw new ArgumentNullException(nameof(customUnit));
            }

            if (customUnit.Numerator is ICustomUnit numeratorCustomUnit && customUnit.Numerator is SimpleUnit numeratorCustomSimpleUnit)
            {
                RegisterCustomSimpleUnit(numeratorCustomSimpleUnit, numeratorCustomUnit.UnitKey);
            }

            if (customUnit.Denominator is ICustomUnit denominatorCustomUnit && customUnit.Denominator is SimpleUnit denominatorCustomSimpleUnit)
            {
                RegisterCustomSimpleUnit(denominatorCustomSimpleUnit, denominatorCustomUnit.UnitKey);
            }

            var unitKey = ((ICustomUnit)customUnit).UnitKey;

            if (!_units.TryGetValue(unitKey, out var existingUnit))
            {
                _units.Add(unitKey, customUnit);

                return true;
            }
            else
            {
                if (!customUnit.Equals(existingUnit))
                {
                    throw new InvalidOperationException($"Key '{unitKey}' is already registered with unit {existingUnit.ToSerializable()}!");
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool RegisterCustomSimpleUnit(SimpleUnit customUnit, string unitKey)
        {
            if (!_units.TryGetValue(unitKey, out var existingUnit))
            {
                _units.Add(unitKey, customUnit);

                return true;
            }
            else
            {
                if (!(existingUnit is SimpleUnit existingSimpleUnit))
                {
                    throw new InvalidOperationException($"Key '{unitKey}' is already registered as a non-simple unit '{existingUnit}'!");
                }
                else if (customUnit.FactorToBaseUnit != existingSimpleUnit.FactorToBaseUnit)
                {
                    throw new InvalidOperationException($"Key '{unitKey}' is already registered with factor {existingSimpleUnit.FactorToBaseUnit}!");
                }
                else if (!customUnit.UnitCategory.Equals(existingSimpleUnit.UnitCategory))
                {
                    throw new InvalidOperationException($"Key '{unitKey}' is already registered with category {existingSimpleUnit.UnitCategory}!");
                }

                return false;
            }
        }
    }
}