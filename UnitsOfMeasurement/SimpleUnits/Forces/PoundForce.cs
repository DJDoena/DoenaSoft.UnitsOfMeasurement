namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Forces
{
    using Weights;

    /// <summary>
    /// https://en.wikipedia.org/wiki/Pound_(force)
    /// </summary>
    public sealed class PoundForce : Force
    {  
        /// <summary>
       /// 4.4482216152605N
       /// </summary>
        public const decimal FactorToNewton = Pound.FactorToKilogram * StandardGravity;

        /// <summary>
        /// Returns the multiplication factor of <see cref="PoundForce"/> in relation to the <see cref="Newton"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToNewton;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "lbf";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "lbf";
    }
}