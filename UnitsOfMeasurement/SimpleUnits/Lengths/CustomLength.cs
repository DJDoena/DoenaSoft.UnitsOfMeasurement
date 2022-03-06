using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Lengths
{
    /// <summary>
    /// Describes an <see cref="Length"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomLength : Length, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly string _serializableValue;

        private readonly Length standardUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => standardUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToMeter">the multiplication factor of this unit in relation to the <see cref="Meter"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomLength(double conversionFactorToMeter, string serializableValue)
        {
            if (string.IsNullOrWhiteSpace(serializableValue))
            {
                throw new ArgumentNullException(nameof(serializableValue));
            }
            else if (serializableValue.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(serializableValue));
            }

            _factorToBaseUnit = System.Convert.ToDecimal(conversionFactorToMeter);
            _unitKey = serializableValue;
            _serializableValue = serializableValue;

            if (_factorToBaseUnit == 1m)
            {
                standardUnit = new Meter();
            }
            else if (_factorToBaseUnit == Kilometer.FactorToMeter)
            {
                standardUnit = new Kilometer();
            }
            else if (_factorToBaseUnit == Millimeter.FactorToMeter)
            {
                standardUnit = new Millimeter();
            }
            else if (_factorToBaseUnit == Centimeter.FactorToMeter)
            {
                standardUnit = new Centimeter();
            }
            else if (_factorToBaseUnit == Decimeter.FactorToMeter)
            {
                standardUnit = new Decimeter();
            }
            else if (_factorToBaseUnit == Mile.FactorToMeter)
            {
                standardUnit = new Mile();
            }
            else if (_factorToBaseUnit == Yard.FactorToMeter)
            {
                standardUnit = new Yard();
            }
            else if (_factorToBaseUnit == Foot.FactorToMeter)
            {
                standardUnit = new Foot();
            }
            else if (_factorToBaseUnit == Inch.FactorToMeter)
            {
                standardUnit = new Inch();
            }
        }

        string ICustomUnit.UnitKey => _unitKey;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => standardUnit?.ToSerializable() ?? _serializableValue;

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => standardUnit?.GetDisplayValue() ?? _serializableValue;
    }
}