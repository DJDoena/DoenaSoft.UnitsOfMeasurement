namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Energies
{
    /// <summary />
    public abstract class Energy : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Energy"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Energy);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="KiloWattHour"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new KiloWattHour();
    }
}