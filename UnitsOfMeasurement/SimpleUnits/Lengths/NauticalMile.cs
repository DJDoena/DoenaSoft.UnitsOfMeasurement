namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    /// <summary />
    public sealed class NauticalMile : Length
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/Nautical_mile
        /// Today the international nautical mile is defined as exactly 1,852 metres 
        /// </summary>
        public const decimal FactorToMeter = 1_852m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="NauticalMile"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "nmi";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "nmi";
    }
}