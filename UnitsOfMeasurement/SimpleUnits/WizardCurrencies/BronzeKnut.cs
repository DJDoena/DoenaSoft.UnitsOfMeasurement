namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.WizardCurrencies
{
    /// <summary />
    public sealed class BronzeKnut : WizardCurrency
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="BronzeKnut"/> in relation to the <see cref="BronzeKnut"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "Knut";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "Knut";
    }
}