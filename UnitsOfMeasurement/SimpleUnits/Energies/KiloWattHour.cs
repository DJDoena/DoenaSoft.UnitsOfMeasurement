namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Energies
{
    /// <summary />
    public sealed class KiloWattHour : Energy
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="KiloWattHour"/> in relation to the <see cref="KiloWattHour"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1000m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "kWh";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "kWh";
    }
}