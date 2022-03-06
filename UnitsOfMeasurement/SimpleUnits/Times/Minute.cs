namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Times
{
    /// <summary />
    public sealed class Minute : Time
    {
        /// <summary>
        /// 60s
        /// </summary>
        public const decimal FactorToSecond = 60m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Minute"/> in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSecond;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "min";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "min";
    }
}