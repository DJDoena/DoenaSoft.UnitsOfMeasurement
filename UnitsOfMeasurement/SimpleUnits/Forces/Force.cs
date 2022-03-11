namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Forces
{
    /// <summary />
    public abstract class Force : SimpleUnit
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/Standard_gravity
        /// It is defined by standard as 9.80665 m/s².
        /// </summary>
        public const decimal StandardGravity = 9.80665m;

        /// <summary>
        /// Returns the category of the unit, <see cref="Force"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Force);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Newton"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Newton();
    }
}