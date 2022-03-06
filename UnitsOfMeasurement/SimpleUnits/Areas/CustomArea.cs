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

        private readonly string _serializableValue;

        private readonly Area standardUnit;

        /// <summary />
        public override decimal FactorToBaseUnit => standardUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToSquareMeter">the multiplication factor of this unit in relation to the <see cref="SquareMeter"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomArea(double conversionFactorToSquareMeter, string serializableValue)
        {
            if (string.IsNullOrWhiteSpace(serializableValue))
            {
                throw new ArgumentNullException(nameof(serializableValue));
            }
            else if (serializableValue.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(serializableValue));
            }

            _factorToBaseUnit = System.Convert.ToDecimal(conversionFactorToSquareMeter);
            _unitKey = serializableValue;
            _serializableValue = serializableValue;

            if (_factorToBaseUnit == 1m)
            {
                standardUnit = new SquareMeter();
            }
            else if (_factorToBaseUnit == Hectare.FactorToSquareMeter)
            {
                standardUnit = new Hectare();
            }
            else if (_factorToBaseUnit == SquareKilometer.FactorToSquareMeter)
            {
                standardUnit = new SquareKilometer();
            }
            else if (_factorToBaseUnit == SquareInch.FactorToSquareMeter)
            {
                standardUnit = new SquareInch();
            }
            else if (_factorToBaseUnit == SquareFoot.FactorToSquareMeter)
            {
                standardUnit = new SquareFoot();
            }
            else if (_factorToBaseUnit == Acre.FactorToSquareMeter)
            {
                standardUnit = new Acre();
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