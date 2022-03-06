namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Weights
{
    /// <summary />
    public abstract class Weight : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Weight"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Weight);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Kilogram"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Kilogram();
    }
}