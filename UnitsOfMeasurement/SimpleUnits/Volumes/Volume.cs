namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    /// <summary />
    public abstract class Volume : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Volume"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Volume);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Liter"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Liter();
    }
}