namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    using Lengths;

    /// <summary />
    public sealed class CubicYard : Volume
    {
        /// <summary>
        /// 764.554857984l
        /// </summary>
        public const decimal FactorToLiter = 1000m * Yard.FactorToMeter * Yard.FactorToMeter * Yard.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="CubicYard"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "yd3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "yd³";
    }
}