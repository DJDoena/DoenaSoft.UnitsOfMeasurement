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

        private readonly Area _builtInUnit;

        /// <summary />
        public override decimal FactorToBaseUnit => _builtInUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToSquareMeter">the multiplication factor of this unit in relation to the <see cref="SquareMeter"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomArea(decimal conversionFactorToSquareMeter, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = conversionFactorToSquareMeter;

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtInUnit = new SquareMeter();
            }
            else if (_factorToBaseUnit == Hectare.FactorToSquareMeter)
            {
                _builtInUnit = new Hectare();
            }
            else if (_factorToBaseUnit == SquareKilometer.FactorToSquareMeter)
            {
                _builtInUnit = new SquareKilometer();
            }
            else if (_factorToBaseUnit == SquareInch.FactorToSquareMeter)
            {
                _builtInUnit = new SquareInch();
            }
            else if (_factorToBaseUnit == SquareFoot.FactorToSquareMeter)
            {
                _builtInUnit = new SquareFoot();
            }
            else if (_factorToBaseUnit == SquareYard.FactorToSquareMeter)
            {
                _builtInUnit = new SquareYard();
            }
            else if (_factorToBaseUnit == Acre.FactorToSquareMeter)
            {
                _builtInUnit = new Acre();
            }
        }

        string ICustomUnit.UnitKey => _unitKey;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => _builtInUnit?.ToSerializable() ?? _unitKey;

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => _builtInUnit?.GetDisplayValue() ?? _unitKey;
    }
}