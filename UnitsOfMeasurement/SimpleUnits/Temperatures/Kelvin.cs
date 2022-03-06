using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Temperatures
{
    /// <summary />
    public sealed class Kelvin : Temparature
    {
        /// <summary>
        /// Not supported.
        /// </summary>
        public override decimal FactorToBaseUnit => throw new NotSupportedException();

        internal override decimal ToBaseUnitValue(decimal value) => value - 273.15m;

        internal override decimal FromBaseUnitValue(decimal baseUnitValue) => baseUnitValue + 273.15m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "K";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "K";
    }
}