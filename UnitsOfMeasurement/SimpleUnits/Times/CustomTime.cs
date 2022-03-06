using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Times
{
    /// <summary>
    /// Describes an <see cref="Time"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomTime : Time, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _serializableValue;

        private readonly Time _builtinUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => _builtinUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToSecond">the multiplication factor of this unit in relation to the <see cref="Second"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomTime(double conversionFactorToSecond, string serializableValue)
        {
            if (string.IsNullOrWhiteSpace(serializableValue))
            {
                throw new ArgumentNullException(nameof(serializableValue));
            }
            else if (serializableValue.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(serializableValue));
            }

            _factorToBaseUnit = Convert.ToDecimal(conversionFactorToSecond);

            _serializableValue = serializableValue;

            if (_factorToBaseUnit == 1m)
            {
                _builtinUnit = new Second();
            }
            else if (_factorToBaseUnit == Minute.FactorToSecond)
            {
                _builtinUnit = new Minute();
            }
            else if (_factorToBaseUnit == Hour.FactorToSecond)
            {
                _builtinUnit = new Hour();
            }
            else if (_factorToBaseUnit == Day.FactorToSecond)
            {
                _builtinUnit = new Day();
            }
        }

        string ICustomUnit.UnitKey => _serializableValue;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => _builtinUnit?.ToSerializable() ?? _serializableValue;

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => _builtinUnit?.GetDisplayValue() ?? _serializableValue;
    }
}