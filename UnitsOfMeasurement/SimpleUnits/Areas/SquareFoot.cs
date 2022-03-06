namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    using Lengths;

    /// <summary />
    public sealed class SquareFoot : Area
    {
        /// <summary>
        /// 0.09290304m²
        /// </summary>
        public const decimal FactorToSquareMeter = Foot.FactorToMeter * Foot.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareFoot"/> in relation to the <see cref="SquareMeter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ft2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ft²";
    }
}