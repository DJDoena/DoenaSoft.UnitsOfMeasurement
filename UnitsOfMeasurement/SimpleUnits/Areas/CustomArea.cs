using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Areas
{
    /// <summary>
    /// Describes an <see cref="Area"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomArea : Area, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly Area _builtinUnit;

        /// <summary />
        public override decimal FactorToBaseUnit => _builtinUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToSquareMeter">the multiplication factor of this unit in relation to the <see cref="SquareMeter"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomArea(double conversionFactorToSquareMeter, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = Convert.ToDecimal(conversionFactorToSquareMeter);

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtinUnit = new SquareMeter();
            }
            else if (_factorToBaseUnit == Hectare.FactorToSquareMeter)
            {
                _builtinUnit = new Hectare();
            }
            else if (_factorToBaseUnit == SquareKilometer.FactorToSquareMeter)
            {
                _builtinUnit = new SquareKilometer();
            }
            else if (_factorToBaseUnit == SquareInch.FactorToSquareMeter)
            {
                _builtinUnit = new SquareInch();
            }
            else if (_factorToBaseUnit == SquareFoot.FactorToSquareMeter)
            {
                _builtinUnit = new SquareFoot();
            }
            else if (_factorToBaseUnit == Acre.FactorToSquareMeter)
            {
                _builtinUnit = new Acre();
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