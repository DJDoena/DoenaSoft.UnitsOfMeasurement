namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Forces
{
    /// <summary />
    public sealed class KiloNewton : Force
    {
        /// <summary>
        /// 1000N
        /// </summary>
        public const decimal FactorToNewton = 1000;

        /// <summary>
        /// Returns the multiplication factor of <see cref="KiloNewton"/> in relation to the <see cref="Newton"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToNewton;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "kN";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "kN";
    }
}