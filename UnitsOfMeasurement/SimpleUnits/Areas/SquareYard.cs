namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    using Lengths;

    /// <summary />
    public sealed class SquareYard : Area
    {
        /// <summary>
        /// 0.83612736m²
        /// </summary>
        public const decimal FactorToSquareMeter = Yard.FactorToMeter * Yard.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareYard"/> in relation to the <see cref="SquareMeter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "yd2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "yd²";
    }
}