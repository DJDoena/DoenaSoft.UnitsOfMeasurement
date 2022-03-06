namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    using Lengths;

    /// <summary />
    public sealed class Milliliter : Volume
    {
        /// <summary>
        /// 0.001l
        /// </summary>
        public const decimal FactorToLiter = 0.001m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Millimeter"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "cm3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ml";
    }
}