namespace DoenaSoft.UnitsOfMeasurement.Values
{
    using System;
    using Exceptions;
    using FractionUnits;
    using SimpleUnits;

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
        public static Value<TDestinationUnit> Convert<TDestinationUnit>(Value sourceValue)
            where TDestinationUnit : UnitOfMeasurement, new()
        {
            var targetValue = Convert(sourceValue, new TDestinationUnit());

            return new Value<TDestinationUnit>(targetValue.Scalar);
        }

        /// <summary>
        /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.<br/>
        /// A valid conversion is when both <see cref="Value.Unit">units</see> belong to the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// </summary>
        /// <param name="sourceValue">the source <see cref="Value"/></param>
        /// <param name="destinationUnit">the target <see cref="UnitOfMeasurement"/></param>
        /// <returns>the <see cref="Value.Scalar"/> with the target <see cref="Value.Unit"/></returns>
        public static Value Convert(Value sourceValue, IUnitOfMeasurement destinationUnit)
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
                var targetValue = ConvertSimpleValue(sourceValue, simpleTargetUnit);

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

        internal static Value ConvertSimpleValue(Value sourceValue, SimpleUnit destinationUnit)
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
            else
            {
                throw new UnitConversionException($"Cannot convert from {sourceValue.Unit} to {destinationUnit}!");
            }
        }

        internal static Value ConvertFractionValue(Value sourceValue, FractionUnit destinationUnit)
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
    }
}