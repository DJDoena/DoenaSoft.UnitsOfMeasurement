namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    using Lengths;

    /// <summary />
    public sealed class Acre : Area
    {
        /// <summary>
        /// 4046.8564224m²
        /// </summary>
        public const decimal FactorToSquareMeter = 43_560m * SquareFoot.FactorToSquareMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Acre"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ac";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ac";
    }
}