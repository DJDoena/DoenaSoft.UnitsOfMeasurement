namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    /// <summary />
    public sealed class SquareKilometer : Area
    {
        /// <summary>
        /// 1,000,000m²
        /// </summary>
        public const decimal FactorToSquareMeter = 1000m * 1000m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareKilometer"/> in relation to the <see cref="SquareMeter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "km2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "km²";
    }
}