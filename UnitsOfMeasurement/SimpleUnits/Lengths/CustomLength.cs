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

        private readonly Length _builtinUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => _builtinUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToMeter">the multiplication factor of this unit in relation to the <see cref="Meter"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomLength(double conversionFactorToMeter, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = Convert.ToDecimal(conversionFactorToMeter);

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtinUnit = new Meter();
            }
            else if (_factorToBaseUnit == Kilometer.FactorToMeter)
            {
                _builtinUnit = new Kilometer();
            }
            else if (_factorToBaseUnit == Millimeter.FactorToMeter)
            {
                _builtinUnit = new Millimeter();
            }
            else if (_factorToBaseUnit == Centimeter.FactorToMeter)
            {
                _builtinUnit = new Centimeter();
            }
            else if (_factorToBaseUnit == Decimeter.FactorToMeter)
            {
                _builtinUnit = new Decimeter();
            }
            else if (_factorToBaseUnit == Mile.FactorToMeter)
            {
                _builtinUnit = new Mile();
            }
            else if (_factorToBaseUnit == Yard.FactorToMeter)
            {
                _builtinUnit = new Yard();
            }
            else if (_factorToBaseUnit == Foot.FactorToMeter)
            {
                _builtinUnit = new Foot();
            }
            else if (_factorToBaseUnit == Inch.FactorToMeter)
            {
                _builtinUnit = new Inch();
            }
        }

        string ICustomUnit.UnitKey => _unitKey;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => _builtinUnit?.ToSerializable() ?? _unitKey;

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => _builtinUnit?.GetDisplayValue() ?? _unitKey;
    }
}