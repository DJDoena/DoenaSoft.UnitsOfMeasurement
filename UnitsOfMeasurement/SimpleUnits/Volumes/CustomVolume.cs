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

        private readonly string _serializableValue;

        private readonly Volume standardUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => standardUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToLiter">the multiplication factor of this unit in relation to the <see cref="Liter"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomVolume(double conversionFactorToLiter, string serializableValue)
        {
            if (string.IsNullOrWhiteSpace(serializableValue))
            {
                throw new ArgumentNullException(nameof(serializableValue));
            }
            else if (serializableValue.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(serializableValue));
            }

            _factorToBaseUnit = System.Convert.ToDecimal(conversionFactorToLiter);
            _unitKey = serializableValue;
            _serializableValue = serializableValue;

            if (_factorToBaseUnit == 1m)
            {
                standardUnit = new Liter();
            }
            else if (_factorToBaseUnit == 0.001m)
            {
                standardUnit = new Milliliter();
            }
            else if (_factorToBaseUnit == 1000m)
            {
                standardUnit = new CubicMeter();
            }
            else if (_factorToBaseUnit == USLiquidGallon.FactorToLiter)
            {
                standardUnit = new USLiquidGallon();
            }
            else if (_factorToBaseUnit == ImperialGallon.FactorToLiter)
            {
                standardUnit = new ImperialGallon();
            }
            else if (_factorToBaseUnit == CubicFoot.FactorToLiter)
            {
                standardUnit = new CubicFoot();
            }
            else if (_factorToBaseUnit == CubicInch.FactorToLiter)
            {
                standardUnit = new CubicInch();
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