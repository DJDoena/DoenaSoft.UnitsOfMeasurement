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

        private readonly string _serializableValue;

        private readonly Weight standardUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => standardUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToKilogram">the multiplication factor of this unit in relation to the <see cref="Kilogram"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomWeight(double conversionFactorToKilogram, string serializableValue)
        {
            if (string.IsNullOrWhiteSpace(serializableValue))
            {
                throw new ArgumentNullException(nameof(serializableValue));
            }
            else if (serializableValue.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(serializableValue));
            }

            _factorToBaseUnit = System.Convert.ToDecimal(conversionFactorToKilogram);
            _unitKey = serializableValue;
            _serializableValue = serializableValue;

            if (_factorToBaseUnit == 1m)
            {
                standardUnit = new Kilogram();
            }
            else if (_factorToBaseUnit == 1000m)
            {
                standardUnit = new Ton();
            }
            else if (_factorToBaseUnit == 0.001m)
            {
                standardUnit = new Gram();
            }
            else if (_factorToBaseUnit == 0.000001m)
            {
                standardUnit = new Milligram();
            }
            else if (_factorToBaseUnit == Pound.FactorToKilogram)
            {
                standardUnit = new Pound();
            }
            else if (_factorToBaseUnit == ShortTon.FactorToKilogram)
            {
                standardUnit = new ShortTon();
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