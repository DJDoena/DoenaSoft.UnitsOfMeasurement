namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    using Lengths;

    /// <summary />
    public sealed class CubicFoot : Volume
    {
        /// <summary>
        /// 28.316846592l
        /// </summary>
        public const decimal FactorToLiter = 1000m * Foot.FactorToMeter * Foot.FactorToMeter * Foot.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="CubicFoot"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ft3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ft³";
    }
}