using System;

namespace DoenaSoft.UnitsOfMeasurement.FractionUnits
{
    using SimpleUnits;

    /// <summary>
    /// A class for units that don't follow the numerator/denominator format
    /// </summary>
    public sealed class CustomFractionUnit : FractionUnit, ICustomUnit
    {
        private readonly string _unitKey;

        /// <summary/>
        /// <param name="numerator"/>
        /// <param name="denominator"/>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomFractionUnit(ISimpleUnit numerator, ISimpleUnit denominator, string unitKey) : base(numerator, denominator)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("unitKey must not contain '/'", nameof(unitKey));
            }

            _unitKey = unitKey;
        }

        /// <summary/>
        public CustomFractionUnit(ISimpleUnit numerator, ISimpleUnit denominator) : base(numerator, denominator)
        {
            string numeratorKey = numerator is ICustomUnit customNumerator
                ? customNumerator.UnitKey
                : numerator.ToSerializable();

            string denominatorKey = denominator is ICustomUnit customDenominator
                ? customDenominator.UnitKey
                : denominator.ToSerializable();

            _unitKey = $"{numeratorKey}/{denominatorKey}";
        }

        string ICustomUnit.UnitKey => _unitKey;
    }
}