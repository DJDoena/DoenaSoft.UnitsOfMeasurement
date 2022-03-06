namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Energies
{
    /// <summary />
    public sealed class WattHour : Energy
    {
        /// <summary>
        /// 0.001kWh
        /// </summary>
        public const decimal FactorToKiloWattHour = 0.001m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="WattHour"/> in relation to the <see cref="WattHour"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToKiloWattHour;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "Wh";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "Wh";
    }
}