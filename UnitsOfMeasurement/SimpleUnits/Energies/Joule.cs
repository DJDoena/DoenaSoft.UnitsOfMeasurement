﻿namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Energies
{
    using Areas;
    using Times;
    using Weights;

    /// <summary>
    /// Strictly speaking, <see cref="Joule"/> is not a simple unit as it's defined as (<see cref="Kilogram"/> * <see cref="SquareMeter"/>) / (<see cref="Second"/> * <see cref="Second"/>).
    /// But for the purpose of this library it's handled as a compound simple unit.
    /// </summary>
    public sealed class Joule : Energy
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Joule"/> in relation to the <see cref="Joule"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "J";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "J";
    }
}
