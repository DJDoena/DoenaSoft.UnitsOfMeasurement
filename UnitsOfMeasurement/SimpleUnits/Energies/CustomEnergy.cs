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

        private readonly string _serializableValue;

        private readonly Energy standardUnit;

        /// <summary />
        public override decimal FactorToBaseUnit => standardUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToKiloWattHour">the multiplication factor of this unit in relation to the <see cref="KiloWattHour"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomEnergy(double conversionFactorToKiloWattHour, string serializableValue)
        {
            if (string.IsNullOrWhiteSpace(serializableValue))
            {
                throw new ArgumentNullException(nameof(serializableValue));
            }
            else if (serializableValue.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(serializableValue));
            }

            _factorToBaseUnit = System.Convert.ToDecimal(conversionFactorToKiloWattHour);
            _unitKey = serializableValue;
            _serializableValue = serializableValue;

            if (_factorToBaseUnit == WattHour.FactorToKiloWattHour)
            {
                standardUnit = new WattHour();
            }
            else if (_factorToBaseUnit == 1m)
            {
                standardUnit = new KiloWattHour();
            }
            else if (_factorToBaseUnit == MegaWattHour.FactorToKiloWattHour)
            {
                standardUnit = new MegaWattHour();
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