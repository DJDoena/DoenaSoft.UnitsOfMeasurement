namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Energies
{
    /// <summary />
    public sealed class MegaWattHour : Energy
    {
        /// <summary>
        /// 1000kWh
        /// </summary>
        public const decimal FactorToKiloWattHour = 0.001m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="MegaWattHour"/> in relation to the <see cref="KiloWattHour"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToKiloWattHour;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "MWh";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "MWh";
    }
}