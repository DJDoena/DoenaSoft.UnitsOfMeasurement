namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    using Lengths;

    /// <summary />
    public sealed class SquareInch : Area
    {
        /// <summary>
        /// 0.00064516m²
        /// </summary>
        public const decimal FactorToSquareMeter = Inch.FactorToMeter * Inch.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareInch"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "in2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "in²";
    }
}