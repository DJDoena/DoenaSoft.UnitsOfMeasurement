namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    /// <summary />
    public sealed class ImperialGallon : Volume
    {
        /// <summary>
        /// 4.54609l
        /// </summary>
        public const decimal FactorToLiter = 4.54609m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="ImperialGallon"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "Imp.gal.";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "Imp.gal.";
    }
}