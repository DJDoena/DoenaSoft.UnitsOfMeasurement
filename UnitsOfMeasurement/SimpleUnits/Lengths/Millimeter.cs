namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    /// <summary />
    public sealed class Millimeter : Length
    {
        /// <summary>
        /// 0.001m
        /// </summary>
        public const decimal FactorToMeter = 0.001m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Millimeter"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "mm";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "mm";
    }
}