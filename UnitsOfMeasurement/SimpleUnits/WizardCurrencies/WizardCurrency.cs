namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.WizardCurrencies
{
    /// <summary />
    public abstract class WizardCurrency : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="WizardCurrency"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(WizardCurrency);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="BronzeKnut"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new BronzeKnut();
    }
}