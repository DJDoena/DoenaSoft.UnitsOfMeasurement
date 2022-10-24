namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Powers
{
    /// <summary />
    public sealed class Watt : Power
    {       
        /// <summary>
        /// Returns the multiplication factor of <see cref="Watt"/> in relation to the <see cref="Watt"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "W";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "W";
    }
}