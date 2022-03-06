namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    /// <summary />
    public abstract class Length : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Length"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Length);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Meter"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Meter();
    }
}