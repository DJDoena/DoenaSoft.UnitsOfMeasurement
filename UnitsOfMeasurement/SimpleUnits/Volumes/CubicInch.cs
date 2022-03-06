namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    using Lengths;

    /// <summary />
    public sealed class CubicInch : Volume
    {
        /// <summary>
        /// 0.016387064l
        /// </summary>
        public const decimal FactorToLiter = 1000m * Inch.FactorToMeter * Inch.FactorToMeter * Inch.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="CubicInch"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "in3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "in³";
    }
}