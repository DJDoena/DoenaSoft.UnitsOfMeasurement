namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Weights
{
    /// <summary />
    public sealed class Pound : Weight
    {
        /// <summary>
        /// 0.45359237kg
        /// </summary>
        public const decimal FactorToKilogram = 0.45359237m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Pound"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToKilogram;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "lb";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "lb";
    }
}