using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    #region Time

    /// <summary />
    public abstract class Time : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Time"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Time);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Second"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Second();
    }
    #endregion

    #region Second

    /// <summary />
    public sealed class Second : Time
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Second"/> in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "s";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "s";
    }


    #endregion

    #region Minute

    /// <summary />
    public sealed class Minute : Time
    {
        /// <summary>
        /// 60s
        /// </summary>
        public const decimal FactorToSecond = 60m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Minute"/> in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSecond;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "min";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "min";
    }

    #endregion    

    #region Hour

    /// <summary />
    public sealed class Hour : Time
    {
        /// <summary>
        /// 3600s
        /// </summary>
        public const decimal FactorToSecond = 60m * Minute.FactorToSecond;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Hour"/> in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSecond;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "h";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "h";
    }

    #endregion

    #region Day

    /// <summary />
    public sealed class Day : Time
    {
        /// <summary>
        /// 86400s
        /// </summary>
        public const decimal FactorToSecond = 24m * Hour.FactorToSecond;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Hour"/> in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSecond;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "d";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "d";
    }

    #endregion

    #region Custom Time

    /// <summary>
    /// Describes an <see cref="Time"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomTime : Time, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly string _serializableValue;

        private readonly Time standardUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Second"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => standardUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToSecond">the multiplication factor of this unit in relation to the <see cref="Second"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomTime(double conversionFactorToSecond, string serializableValue)
        {
            if (string.IsNullOrWhiteSpace(serializableValue))
            {
                throw new ArgumentNullException(nameof(serializableValue));
            }
            else if (serializableValue.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(serializableValue));
            }

            _factorToBaseUnit = System.Convert.ToDecimal(conversionFactorToSecond);
            _unitKey = serializableValue;
            _serializableValue = serializableValue;

            if (_factorToBaseUnit == 1m)
            {
                standardUnit = new Second();
            }
            else if (_factorToBaseUnit == Minute.FactorToSecond)
            {
                standardUnit = new Minute();
            }
            else if (_factorToBaseUnit == Hour.FactorToSecond)
            {
                standardUnit = new Hour();
            }
            else if (_factorToBaseUnit == Day.FactorToSecond)
            {
                standardUnit = new Day();
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