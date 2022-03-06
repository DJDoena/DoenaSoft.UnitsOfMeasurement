namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Temperatures
{
    /// <summary />
    public abstract class Temparature : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Temparature"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Temparature);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Celsius"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Celsius();
    }
}