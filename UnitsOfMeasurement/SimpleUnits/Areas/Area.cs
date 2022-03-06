namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    /// <summary />
    public abstract class Area : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Area"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Area);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="SquareMeter"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new SquareMeter();
    }
}