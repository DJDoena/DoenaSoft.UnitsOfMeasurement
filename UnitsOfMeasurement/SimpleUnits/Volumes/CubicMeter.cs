namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    /// <summary />
    public sealed class CubicMeter : Volume
    {
        /// <summary>
        /// 1000l
        /// </summary>
        public const decimal FactorToLiter = 1000m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="CubicMeter"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "m3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "m³";
    }
}