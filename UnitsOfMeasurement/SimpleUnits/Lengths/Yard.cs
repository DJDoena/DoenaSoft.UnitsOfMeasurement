namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    /// <summary />
    public sealed class Yard : Length
    {
        /// <summary>
        /// 0.9144m
        /// </summary>
        public const decimal FactorToMeter = 3m * Foot.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Yard"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "yd";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "yd";
    }
}