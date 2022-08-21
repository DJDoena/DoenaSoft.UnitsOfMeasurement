namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Powers
{
    /// <summary />
    public abstract class Power : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Power"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Power);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Watt"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Watt();
    }
}