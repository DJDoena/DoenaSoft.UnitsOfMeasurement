namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    /// <summary />
    public sealed class SquareMeter : Area
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareMeter"/> in relation to the <see cref="SquareMeter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "m2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "m²";
    }
}