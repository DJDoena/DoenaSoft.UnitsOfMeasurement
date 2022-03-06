using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Temperatures
{
    /// <summary />
    public sealed class Fahrenheit : Temparature
    {
        /// <summary>
        /// Not supported.
        /// </summary>
        public override decimal FactorToBaseUnit => throw new NotSupportedException();

        internal override decimal ToBaseUnitValue(decimal value) => (value - 32m) * 5m / 9m;

        internal override decimal FromBaseUnitValue(decimal baseUnitValue) => (baseUnitValue * 9m / 5m) + 32m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "°F";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "°F";
    }
}