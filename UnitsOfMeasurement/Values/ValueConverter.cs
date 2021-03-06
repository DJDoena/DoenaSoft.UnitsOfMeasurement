using System;

namespace DoenaSoft.UnitsOfMeasurement.Values
{
    using Exceptions;
    using FractionUnits;
    using SimpleUnits;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.
    /// </summary>
    public static class ValueConverter
    {
        /// <summary>
        /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.<br/>
        /// A valid conversion is when both <see cref="Value.Unit">units</see> belong to the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// </summary>
        /// <typeparam name="TDestinationUnit">the target <see cref="UnitOfMeasurement"/></typeparam>
        /// <param name="sourceValue">the source <see cref="Value"/></param>
        /// <returns>the <see cref="Value.Scalar"/> with the target <see cref="Value.Unit"/></returns>
        public static Value<TDestinationUnit> Convert<TDestinationUnit>(Value sourceValue) where TDestinationUnit : UnitOfMeasurement, new() => Convert<TDestinationUnit>(sourceValue, null);

        /// <summary>
        /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.<br/>
        /// A valid conversion is when both <see cref="Value.Unit">units</see> belong to the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// </summary>
        /// <typeparam name="TDestinationUnit">the target <see cref="UnitOfMeasurement"/></typeparam>
        /// <param name="sourceValue">the source <see cref="Value"/></param>
        /// <param name="density">is necessary when it's a conversion from <see cref="Weight"/> to <see cref="Volume"/> or vice versa</param>
        /// <returns>the <see cref="Value.Scalar"/> with the target <see cref="Value.Unit"/></returns>
        public static Value<TDestinationUnit> Convert<TDestinationUnit>(Value sourceValue, DensityValue density)
            where TDestinationUnit : UnitOfMeasurement, new()
        {
            var targetValue = Convert(sourceValue, new TDestinationUnit(), density);

            return new Value<TDestinationUnit>(targetValue.Scalar);
        }

        /// <summary>
        /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.<br/>
        /// A valid conversion is when both <see cref="Value.Unit">units</see> belong to the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// </summary>
        /// <param name="sourceValue">the source <see cref="Value"/></param>
        /// <param name="destinationUnit">the target <see cref="UnitOfMeasurement"/></param>
        /// <returns>the <see cref="Value.Scalar"/> with the target <see cref="Value.Unit"/></returns>
        public static Value Convert(Value sourceValue, IUnitOfMeasurement destinationUnit) => Convert(sourceValue, destinationUnit, null);

        /// <summary>
        /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.<br/>
        /// A valid conversion is when both <see cref="Value.Unit">units</see> belong to the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// </summary>
        /// <param name="sourceValue">the source <see cref="Value"/></param>
        /// <param name="destinationUnit">the target <see cref="UnitOfMeasurement"/></param>
        /// <param name="density">is necessary when it's a conversion from <see cref="Weight"/> to <see cref="Volume"/> or vice versa</param>
        /// <returns>the <see cref="Value.Scalar"/> with the target <see cref="Value.Unit"/></returns>
        public static Value Convert(Value sourceValue, IUnitOfMeasurement destinationUnit, DensityValue density)
        {
            if (sourceValue == null)
            {
                throw new ArgumentNullException(nameof(sourceValue));
            }
            else if (destinationUnit == null)
            {
                throw new ArgumentNullException(nameof(destinationUnit));
            }
            else if (sourceValue.Unit.Equals(destinationUnit))
            {
                //already done -> saves computing power
                return sourceValue.Clone();
            }
            else if (sourceValue.Unit is SimpleUnit && destinationUnit is SimpleUnit simpleTargetUnit)
            {
                var targetValue = ConvertSimpleValue(sourceValue, simpleTargetUnit, density);

                return targetValue;
            }
            else if (sourceValue.Unit is FractionUnit && destinationUnit is FractionUnit fractionTargetUnit)
            {
                var targetValue = ConvertFractionValue(sourceValue, fractionTargetUnit);

                return targetValue;
            }
            else
            {
                throw new UnitConversionException($"Cannot convert from '{sourceValue.Unit}' to '{destinationUnit}'");
            }
        }

        /// <summary>
        /// Converts the throughput of a value over time
        /// </summary>
        /// <param name="valueOverTime">a fraction value where the denominator is <see cref="Time"/></param>
        /// <param name="time">a simple value where the unit is <see cref="Time"/></param>
        public static Value ConvertValueOverTimeToValue(Value valueOverTime, Value time)
        {
            if (valueOverTime == null)
            {
                throw new ArgumentNullException(nameof(valueOverTime));
            }
            else if (time == null)
            {
                throw new ArgumentNullException(nameof(time));
            }

            if (!(valueOverTime.Unit is FractionUnit sourceUnit))
            {
                throw new ArgumentException($"{nameof(valueOverTime)} is not a fraction unit!");
            }

            if (!(sourceUnit.Denominator is Time sourceTimeUnit))
            {
                throw new ArgumentException($"{nameof(valueOverTime)} is not a unit over time!");
            }

            if (!(time.Unit is Time))
            {
                throw new ArgumentException($"{nameof(time)} is not a time!");
            }

            var targetTime = ConvertSimpleValue(time, sourceTimeUnit); //make both time units identical

            var targetValue = new Value(valueOverTime.Scalar * targetTime.Scalar, sourceUnit.Numerator);

            return targetValue;
        }

        private static Value ConvertSimpleValue(Value sourceValue, SimpleUnit destinationUnit) => ConvertSimpleValue(sourceValue, destinationUnit, null);

        private static Value ConvertSimpleValue(Value sourceValue, SimpleUnit destinationUnit, DensityValue density)
        {
            if (sourceValue.Unit.Equals(destinationUnit))
            {
                //already done -> saves computing power
                return sourceValue.Clone();
            }
            else if (sourceValue.Unit is SimpleUnit sourceUnit
                && sourceValue.Unit.UnitCategory.Equals(destinationUnit.UnitCategory))
            {
                var sourceBaseScalar = sourceUnit.ToBaseUnitValue(sourceValue.Scalar);

                var destinationScalar = destinationUnit.FromBaseUnitValue(sourceBaseScalar);

                return new Value(destinationScalar, destinationUnit);
            }
            else if (sourceValue.Unit is Weight && destinationUnit is Volume targetVolumeUnit)
            {
                var targetValue = ConvertWeightToVolume(sourceValue, targetVolumeUnit, density);

                return targetValue;
            }
            else if (sourceValue.Unit is Volume && destinationUnit is Weight targetWeightUnit)
            {
                var targetValue = ConvertVolumeToWeight(sourceValue, targetWeightUnit, density);

                return targetValue;
            }
            else
            {
                throw new UnitConversionException($"Cannot convert from {sourceValue.Unit} to {destinationUnit}!");
            }
        }

        private static Value ConvertFractionValue(Value sourceValue, FractionUnit destinationUnit)
        {
            if (sourceValue.Unit.Equals(destinationUnit))
            {
                //already done -> saves computing power
                return sourceValue.Clone();
            }
            else if (sourceValue.Unit is FractionUnit sourceUnit)
            {
                var sourceNumeratorValue = new Value(sourceValue.Scalar, sourceUnit.Numerator);

                var sourceDenominatorValue = new Value(1.0m, sourceUnit.Denominator);

                var convertedValue = ConvertFractionValue(sourceNumeratorValue, sourceDenominatorValue, destinationUnit);

                return convertedValue;
            }
            else
            {
                throw new UnitConversionException($"Cannot convert from {sourceValue.Unit} to {destinationUnit}!");
            }
        }

        private static Value ConvertFractionValue(Value sourceNumeratorValue, Value sourceDenominatorValue, FractionUnit destinationUnit)
        {
            if (!(destinationUnit.Numerator is SimpleUnit destinationNumeratorUnit))
            {
                throw new UnitConversionException($"Destination numerator unit {destinationUnit.Numerator.GetType()} is not a {nameof(SimpleUnit)}");
            }

            if (!(destinationUnit.Denominator is SimpleUnit destinationDenominatorUnit))
            {
                throw new UnitConversionException($"Destination denominator unit {destinationUnit.Denominator.GetType()} is not a {nameof(SimpleUnit)}");
            }

            try
            {
                var convertedNumeratorValue = ConvertSimpleValue(sourceNumeratorValue, destinationNumeratorUnit);

                var convertedDenominatorValue = ConvertSimpleValue(sourceDenominatorValue, destinationDenominatorUnit);

                var scalar = convertedNumeratorValue.Scalar / convertedDenominatorValue.Scalar;

                return new Value(scalar, destinationUnit);
            }
            catch (UnitConversionException ex)
            {
                try  //inversion of fraction
                {
                    var convertedNumeratorValue = ConvertSimpleValue(sourceNumeratorValue, destinationDenominatorUnit);

                    var convertedDenominatorValue = ConvertSimpleValue(sourceDenominatorValue, destinationNumeratorUnit);

                    var scalar = convertedDenominatorValue.Scalar / convertedNumeratorValue.Scalar;

                    return new Value(scalar, destinationUnit);
                }
                catch (UnitConversionException nextEx)
                {
                    throw new UnitConversionException(ex.Message, nextEx);
                }
            }
        }

        private static Value ConvertWeightToVolume(Value weightValue, Volume targetVolumeUnit, DensityValue density)
        {
            if (density == null)
            {
                throw new ArgumentNullException(nameof(density));
            }

            //normalize density to base units
            var normalizedDensity = ConvertFractionValue(density, density.Unit.BaseUnit);

            //normalize to base unit
            var normalizedWeightValue = ConvertSimpleValue(weightValue, new Kilogram());

            var scalar = normalizedWeightValue.Scalar / normalizedDensity.Scalar;

            var normalizedVolumeValue = new Value<Liter>(scalar);

            //conversion to target unit
            var volumeValue = ConvertSimpleValue(normalizedVolumeValue, targetVolumeUnit);

            return volumeValue;
        }

        private static Value ConvertVolumeToWeight(Value volumeValue, Weight targetWeightUnit, DensityValue density)
        {
            if (density == null)
            {
                throw new ArgumentNullException(nameof(density));
            }

            //normalize density to base units
            var normalizedDensity = ConvertFractionValue(density, density.Unit.BaseUnit);

            //normalize to base unit
            var normalizedVolumeValue = ConvertSimpleValue(volumeValue, new Liter());

            var decimalScalar = normalizedVolumeValue.Scalar * normalizedDensity.Scalar;

            var normalizedWeightValue = new Value<Kilogram>(decimalScalar);

            //conversion to target unit
            var weightValue = ConvertSimpleValue(normalizedWeightValue, targetWeightUnit);

            return weightValue;
        }
    }
}