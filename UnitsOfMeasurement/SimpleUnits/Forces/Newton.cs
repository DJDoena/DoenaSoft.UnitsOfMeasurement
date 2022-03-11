namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Forces
{
    using Lengths;
    using Times;
    using Weights;

    /// <summary>
    /// Strictly speaking, <see cref="Newton"/> is not a simple unit as it's defined as (<see cref="Kilogram"/> * <see cref="Meter"/>) / (<see cref="Second"/> * <see cref="Second"/>).
    /// But for the purpose of this library it's handled as a compound simple unit.
    /// </summary>
    public sealed class Newton : Force
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Newton"/> in relation to the <see cref="Newton"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "N";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "N";
    }
}