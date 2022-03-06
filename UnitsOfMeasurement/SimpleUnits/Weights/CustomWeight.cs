using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Weights
{
    /// <summary>
    /// Describes an <see cref="Weight"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomWeight : Weight, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly Weight _builtinUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => _builtinUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToKilogram">the multiplication factor of this unit in relation to the <see cref="Kilogram"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomWeight(double conversionFactorToKilogram, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = Convert.ToDecimal(conversionFactorToKilogram);

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtinUnit = new Kilogram();
            }
            else if (_factorToBaseUnit == Ton.FactorToKilogram)
            {
                _builtinUnit = new Ton();
            }
            else if (_factorToBaseUnit == Gram.FactorToKilogram)
            {
                _builtinUnit = new Gram();
            }
            else if (_factorToBaseUnit == Milligram.FactorToKilogram)
            {
                _builtinUnit = new Milligram();
            }
            else if (_factorToBaseUnit == Pound.FactorToKilogram)
            {
                _builtinUnit = new Pound();
            }
            else if (_factorToBaseUnit == ShortTon.FactorToKilogram)
            {
                _builtinUnit = new ShortTon();
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