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

        private readonly Energy _builtInUnit;

        /// <summary />
        public override decimal FactorToBaseUnit => _builtInUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToJoule">the multiplication factor of this unit in relation to the <see cref="Joule"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomEnergy(double conversionFactorToJoule, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = Convert.ToDecimal(conversionFactorToJoule);

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtInUnit = new Joule();
            }
            else if (_factorToBaseUnit == KiloJoule.FactorToJoule)
            {
                _builtInUnit = new KiloJoule();
            }
            else if (_factorToBaseUnit == WattHour.FactorToJoule)
            {
                _builtInUnit = new WattHour();
            }
            else if (_factorToBaseUnit == KiloWattHour.FactorToJoule)
            {
                _builtInUnit = new KiloWattHour();
            }
            else if (_factorToBaseUnit == MegaWattHour.FactorToJoule)
            {
                _builtInUnit = new MegaWattHour();
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