using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    /// <summary />
    public sealed class Parsec : Length
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Parsec"/> in relation to the <see cref="Meter"/>.
        /// https://en.wikipedia.org/wiki/Parsec
        /// [...] the International Astronomical Union (IAU) [...] mentioned an existing explicit definition of the parsec as exactly 648,000/π au
        /// </summary>
        public override decimal FactorToBaseUnit => (648_000m / Convert.ToDecimal(Math.PI)) * AstronomicalUnit.FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "pc";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "pc";
    }
}