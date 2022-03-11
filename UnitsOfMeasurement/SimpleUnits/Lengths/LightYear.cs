namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    using Times;

    /// <summary />
    public sealed class LightYear : Length
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/Light-year
        /// As defined by the International Astronomical Union (IAU), a light-year is the distance that light travels in vacuum in one Julian year (365.25 days)
        /// https://en.wikipedia.org/wiki/Speed_of_light
        /// Its exact value is defined as 299,792,458 metres per second
        /// </summary>
        public const decimal FactorToMeter = 365.25m * Day.FactorToSecond * 299_792_458m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="LightYear"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ly";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ly";
    }
}