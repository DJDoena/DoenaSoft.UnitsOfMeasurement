namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Times
{
    /// <summary />
    public sealed class Hour : Time
    {
        /// <summary>
        /// 3600s
        /// </summary>
        public const decimal FactorToSecond = 60m * Minute.FactorToSecond;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Hour"/> in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSecond;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "h";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "h";
    }
}