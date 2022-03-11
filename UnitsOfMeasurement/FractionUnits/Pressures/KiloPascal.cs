namespace DoenaSoft.UnitsOfMeasurement.FractionUnits.Pressures
{
    using SimpleUnits.Areas;
    using SimpleUnits.Forces;

    /// <summary />
    public sealed class KiloPascal : Pressure<KiloNewton, SquareMeter>
    {
        /// <summary />
        public new KiloNewton Numerator => (KiloNewton)base.Numerator;

        /// <summary />
        public new SquareMeter Denominator => (SquareMeter)base.Denominator;

        /// <summary>
        /// Returns the base <see cref="Pressure"/> unit, i.e. <see cref="Pascal"/>.
        /// </summary>
        public new Pascal BaseUnit => new Pascal();

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "kPa";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "kPa";
    }
}