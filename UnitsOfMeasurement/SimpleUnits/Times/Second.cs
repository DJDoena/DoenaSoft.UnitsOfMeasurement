namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Times
{
    /// <summary />
    public sealed class Second : Time
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Second"/> in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "s";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "s";
    }
}