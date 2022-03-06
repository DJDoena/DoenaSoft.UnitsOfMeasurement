namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    using Lengths;

    /// <summary />
    public sealed class Hectare : Area
    {
        /// <summary>
        /// 10,000m²
        /// </summary>
        public const decimal FactorToSquareMeter = 100m * 100m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Hectare"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ha";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ha";
    }
}