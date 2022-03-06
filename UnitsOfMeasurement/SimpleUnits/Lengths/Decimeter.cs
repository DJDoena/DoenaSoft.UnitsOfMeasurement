namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    /// <summary />
    public sealed class Decimeter : Length
    {
        /// <summary>
        /// 0.1m
        /// </summary>
        public const decimal FactorToMeter = 0.1m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Decimeter"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "dm";

        /// <summary>
        /// Returns the unit text in the given language of the system.
        /// </summary>
        /// <returns>the unit text in the given language of the system</returns>
        public override string GetDisplayValue() => "dm";
    }
}