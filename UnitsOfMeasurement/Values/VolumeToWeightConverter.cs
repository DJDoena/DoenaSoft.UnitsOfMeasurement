namespace DoenaSoft.UnitsOfMeasurement.Values
{
    using System;
    using Exceptions;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.
    /// </summary>
    public static class VolumeToWeightConverter
    {
        /// <summary>
        /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.<br/>
        /// A valid conversion is when both <see cref="Value.Unit">units</see> belong to the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// </summary>
        /// <typeparam name="TDestinationUnit">the target <see cref="UnitOfMeasurement"/></typeparam>
        /// <param name="sourceValue">the source <see cref="Value"/></param>
        /// <param name="density">is necessary when it's a conversion from <see cref="Weight"/> to <see cref="Volume"/> or vice versa</param>
        /// <returns>the <see cref="Value.Scalar"/> with the target <see cref="Value.Unit"/></returns>
        public static Value<TDestinationUnit> Convert<TDestinationUnit>(Value sourceValue, DensityValue density)
            where TDestinationUnit : Weight, new()
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
        /// <param name="density">is necessary when it's a conversion from <see cref="Weight"/> to <see cref="Volume"/> or vice versa</param>
        /// <returns>the <see cref="Value.Scalar"/> with the target <see cref="Value.Unit"/></returns>
        public static Value Convert(Value sourceValue, IUnitOfMeasurement destinationUnit, DensityValue density)
        {
            if (sourceValue == null)
            {
                throw new ArgumentNullException(nameof(sourceValue));
            }
            else if (!(sourceValue.Unit is Volume))
            {
                throw new UnitConversionException($"{nameof(sourceValue)} is not a {typeof(Volume)}");
            }
            else if (destinationUnit == null)
            {
                throw new ArgumentNullException(nameof(destinationUnit));
            }
            else if (!(destinationUnit is Weight))
            {
                throw new UnitConversionException($"{nameof(destinationUnit)} is not a {typeof(Weight)}");
            }
            else if (density == null)
            {
                throw new UnitConversionException($"{nameof(density)} is null");
            }

            var targetValue = ConvertVolumeToWeight(sourceValue, (Weight)destinationUnit, density);

            return targetValue;
        }

        private static Value ConvertVolumeToWeight(Value volumeValue, Weight targetWeightUnit, DensityValue density)
        {
            //normalize density to base units
            var normalizedDensity = ValueConverter.ConvertFractionValue(density, density.Unit.BaseUnit);

            //normalize to base unit
            var normalizedVolumeValue = ValueConverter.ConvertSimpleValue(volumeValue, new Liter());

            var decimalScalar = normalizedVolumeValue.Scalar * normalizedDensity.Scalar;

            var normalizedWeightValue = new Value<Kilogram>(decimalScalar);

            //conversion to target unit
            var weightValue = ValueConverter.ConvertSimpleValue(normalizedWeightValue, targetWeightUnit);

            return weightValue;
        }
    }
}