namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Temperatures
{
    /// <summary />
    public sealed class Celsius : Temparature
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Celsius"/> in relation to the <see cref="Celsius"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "°C";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "°C";
    }
}