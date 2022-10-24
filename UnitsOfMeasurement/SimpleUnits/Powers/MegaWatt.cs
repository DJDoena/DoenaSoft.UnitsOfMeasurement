namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Powers
{
    /// <summary />
    public sealed class MegaWatt : Power
    {
        /// <summary>
        /// 3,600,000J
        /// </summary>
        public const decimal FactorToWatt = 1000m * KiloWatt.FactorToWatt;

        /// <summary>
        /// Returns the multiplication factor of <see cref="MegaWatt"/> in relation to the <see cref="Watt"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToWatt;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "MW";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "MW";
    }
}