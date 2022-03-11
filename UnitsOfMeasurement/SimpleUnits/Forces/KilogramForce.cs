namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Forces
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/Kilogram-force
    /// </summary>
    public sealed class KilogramForce : Force
    {
        /// <summary>
        /// 9.80665N
        /// </summary>
        public const decimal FactorToNewton = StandardGravity;

        /// <summary>
        /// Returns the multiplication factor of <see cref="KilogramForce"/> in relation to the <see cref="Newton"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToNewton;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "kgf";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "kgf";
    }
}