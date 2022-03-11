namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.WizardCurrencies
{
    /// <summary />
    public sealed class SilverSickle : WizardCurrency
    {
        /// <summary>
        /// 29 Knut
        /// </summary>
        public const decimal FactorToBronzeKnut = 29m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="SilverSickle"/> in relation to the <see cref="BronzeKnut"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToBronzeKnut;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "Sickle";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "Sickle";
    }
}