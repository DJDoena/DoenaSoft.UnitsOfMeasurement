namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Weights
{
    /// <summary>
    /// 2000lb = 907.18474kg
    /// </summary>
    public sealed class ShortTon : Weight
    {
        /// <summary>
        /// 907.18474kg
        /// </summary>
        public const decimal FactorToKilogram = 2000m * Pound.FactorToKilogram;

        /// <summary>
        /// Returns the multiplication factor of <see cref="ShortTon"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToKilogram;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "stn";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "stn";
    }
}