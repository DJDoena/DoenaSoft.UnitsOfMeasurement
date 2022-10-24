namespace DoenaSoft.UnitsOfMeasurement.Values
{
    using System;
    using FractionUnits;
    using SimpleUnits.Times;

    /// <summary>
    /// Converts the <see cref="Value.Scalar"/> of a <see cref="Value"/> into a <see cref="Value.Scalar"/> of a compatible <see cref="Value.Unit"/>.
    /// </summary>
    public static class ValueOverTimeConverter
    {
        /// <summary>
        /// Converts the throughput of a value over time
        /// </summary>
        /// <param name="valueOverTime">a fraction value where the denominator is <see cref="Time"/></param>
        /// <param name="time">a simple value where the unit is <see cref="Time"/></param>
        public static Value Convert(Value valueOverTime, Value time)
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

            var targetTime = ValueConverter.ConvertSimpleValue(time, sourceTimeUnit); //make both time units identical

            var targetValue = new Value(valueOverTime.Scalar * targetTime.Scalar, sourceUnit.Numerator);

            return targetValue;
        }
    }
}