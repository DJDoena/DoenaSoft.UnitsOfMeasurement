namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    /// <summary />
    public sealed class USLiquidGallon : Volume
    {
        /// <summary>
        /// 3.785411784l
        /// </summary>
        public const decimal FactorToLiter = 3.785411784m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="USLiquidGallon"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "US.liq.gal.";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "US.liq.gal.";
    }
}