using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    #region Energy

    /// <summary />
    public abstract class Energy : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Energy"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Energy);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="KiloWattHour"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new KiloWattHour();
    }

    #endregion

    #region Watt-hour

    /// <summary />
    public sealed class WattHour : Energy
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="WattHour"/> in relation to the <see cref="WattHour"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "Wh";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "Wh";
    }

    #endregion

    #region KiloWatt-hour

    /// <summary />
    public sealed class KiloWattHour : Energy
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="WattHour"/> in relation to the <see cref="WattHour"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1000m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "kWh";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "kWh";
    }

    #endregion

    #region MegaWatt-hour

    /// <summary />
    public sealed class MegaWattHour : Energy
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="MegaWattHour"/> in relation to the <see cref="WattHour"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1000m * 1000m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "MWh";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "MWh";
    }

    #endregion

    #region CustomEnergy

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
        /// <param name="conversionFactorToSquareMeter">the multiplication factor of this unit in relation to the <see cref="SquareMeter"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomEnergy(double conversionFactorToSquareMeter, string serializableValue)
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
                standardUnit = new WattHour();
            }
            else if (_factorToBaseUnit == 1000m)
            {
                standardUnit = new KiloWattHour();
            }
            else if (_factorToBaseUnit == 1000m * 1000m)
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

    #endregion
}