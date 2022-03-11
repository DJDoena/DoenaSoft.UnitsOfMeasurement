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

        private readonly Weight _builtInUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => _builtInUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToKilogram">the multiplication factor of this unit in relation to the <see cref="Kilogram"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomWeight(decimal conversionFactorToKilogram, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = conversionFactorToKilogram;

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtInUnit = new Kilogram();
            }
            else if (_factorToBaseUnit == Ton.FactorToKilogram)
            {
                _builtInUnit = new Ton();
            }
            else if (_factorToBaseUnit == Gram.FactorToKilogram)
            {
                _builtInUnit = new Gram();
            }
            else if (_factorToBaseUnit == Milligram.FactorToKilogram)
            {
                _builtInUnit = new Milligram();
            }
            else if (_factorToBaseUnit == Pound.FactorToKilogram)
            {
                _builtInUnit = new Pound();
            }
            else if (_factorToBaseUnit == ShortTon.FactorToKilogram)
            {
                _builtInUnit = new ShortTon();
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