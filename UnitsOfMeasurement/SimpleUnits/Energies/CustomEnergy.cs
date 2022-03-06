using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Energies
{
    /// <summary>
    /// Describes an <see cref="Energy"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomEnergy : Energy, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly Energy _builtinUnit;

        /// <summary />
        public override decimal FactorToBaseUnit => _builtinUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToKiloWattHour">the multiplication factor of this unit in relation to the <see cref="KiloWattHour"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomEnergy(double conversionFactorToKiloWattHour, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = Convert.ToDecimal(conversionFactorToKiloWattHour);

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtinUnit = new Joule();
            }
            else if (_factorToBaseUnit == KiloJoule.FactorToJoule)
            {
                _builtinUnit = new KiloJoule();
            }
            else if (_factorToBaseUnit == WattHour.FactorToJoule)
            {
                _builtinUnit = new WattHour();
            }
            else if (_factorToBaseUnit == KiloWattHour.FactorToJoule)
            {
                _builtinUnit = new KiloWattHour();
            }
            else if (_factorToBaseUnit == MegaWattHour.FactorToJoule)
            {
                _builtinUnit = new MegaWattHour();
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