namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Weights
{
    /// <summary />
    public sealed class Milligram : Weight
    {
        /// <summary>
        /// 0.000001kg
        /// </summary>
        public const decimal FactorToKilogram = 0.001m * 0.001m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Milligram"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToKilogram;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "mg";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "mg";
    }
}