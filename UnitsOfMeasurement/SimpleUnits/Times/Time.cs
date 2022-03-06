namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Times
{
    /// <summary />
    public abstract class Time : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Time"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Time);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Second"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Second();
    }
}