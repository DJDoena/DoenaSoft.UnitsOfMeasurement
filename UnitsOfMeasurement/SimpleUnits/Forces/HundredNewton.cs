namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Forces
{
    using FractionUnits.Pressures;

    /// <summary />
    /// <remarks>
    /// Is only needed for the <see cref="HectoPascal"/> unit, should not be used by itself as it has no defined unit symbol.
    /// </remarks>
    public sealed class HundredNewton : Force
    {
        /// <summary>
        /// 100,000N
        /// </summary>
        public const decimal FactorToNewton = 100;

        /// <summary>
        /// Returns the multiplication factor of <see cref="HundredNewton"/> in relation to the <see cref="Newton"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToNewton;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "100N";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "100N";
    }
}