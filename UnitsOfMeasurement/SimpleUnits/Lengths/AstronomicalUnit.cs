namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    /// <summary />
    public sealed class AstronomicalUnit : Length
    {
        /// <summary>
        /// 149,597,870,700m
        /// </summary>
        public const decimal FactorToMeter = 149_597_870_700m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="AstronomicalUnit"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "au";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "au";
    }
}