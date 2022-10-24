namespace DoenaSoft.UnitsOfMeasurement.Values
{
    using System;
    using DoenaSoft.UnitsOfMeasurement.Exceptions;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.
    /// </summary>
    public static class GenericValueConverter
    {
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
            else if (sourceValue.Unit is Weight && destinationUnit is Volume)
            {
                var targetValue = WeightToVolumeConverter.Convert(sourceValue, destinationUnit, density);

                return targetValue;
            }
            else if (sourceValue.Unit is Weight && destinationUnit is Volume)
            {
                var targetValue = WeightToVolumeConverter.Convert(sourceValue, destinationUnit, density);

                return targetValue;
            }
            else if (density != null)
            {
                throw new UnitConversionException($"{nameof(density)} is not supported for this conversion");
            }
            else
            {
                var targetValue = ValueConverter.Convert(sourceValue, destinationUnit);

                return targetValue;
            }
        }
    }
}