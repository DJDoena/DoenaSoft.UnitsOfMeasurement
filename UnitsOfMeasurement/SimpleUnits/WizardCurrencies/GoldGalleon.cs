namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.WizardCurrencies
{
    /// <summary />
    public sealed class GoldGalleon : WizardCurrency
    {
        /// <summary>
        /// 493 Knut
        /// </summary>
        public const decimal FactorToBronzeKnut = 493m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="GoldGalleon"/> in relation to the <see cref="BronzeKnut"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToBronzeKnut;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "Galleon";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "Galleon";
    }
}