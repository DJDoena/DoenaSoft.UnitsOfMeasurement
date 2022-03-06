namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Weights
{
    /// <summary />
    public sealed class Ton : Weight
    {
        /// <summary>
        /// 1000kg
        /// </summary>
        public const decimal FactorToKilogram = 1000m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Ton"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToKilogram;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "t";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "t";
    }
}