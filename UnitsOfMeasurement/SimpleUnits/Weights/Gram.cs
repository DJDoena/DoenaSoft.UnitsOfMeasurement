namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Weights
{
    /// <summary />
    public sealed class Gram : Weight
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Gram"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "g";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "g";
    }
}