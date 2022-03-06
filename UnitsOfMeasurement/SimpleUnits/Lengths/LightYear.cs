namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    using Times;

    /// <summary />
    public sealed class LightYear : Length
    {
        /// <summary>
        /// 1 Julian year: 365.25 days
        /// Light speed:   299,792,458m/s
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