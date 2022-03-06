using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Volumes
{
    /// <summary>
    /// Describes an <see cref="Volume"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomVolume : Volume, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly Volume _builtinUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => _builtinUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToLiter">the multiplication factor of this unit in relation to the <see cref="Liter"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomVolume(double conversionFactorToLiter, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = Convert.ToDecimal(conversionFactorToLiter);

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtinUnit = new Liter();
            }
            else if (_factorToBaseUnit == Milliliter.FactorToLiter)
            {
                _builtinUnit = new Milliliter();
            }
            else if (_factorToBaseUnit == CubicMeter.FactorToLiter)
            {
                _builtinUnit = new CubicMeter();
            }
            else if (_factorToBaseUnit == USLiquidGallon.FactorToLiter)
            {
                _builtinUnit = new USLiquidGallon();
            }
            else if (_factorToBaseUnit == ImperialGallon.FactorToLiter)
            {
                _builtinUnit = new ImperialGallon();
            }
            else if (_factorToBaseUnit == CubicFoot.FactorToLiter)
            {
                _builtinUnit = new CubicFoot();
            }
            else if (_factorToBaseUnit == CubicInch.FactorToLiter)
            {
                _builtinUnit = new CubicInch();
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