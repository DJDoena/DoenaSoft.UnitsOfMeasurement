using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    #region Length

    /// <summary />
    public abstract class Length : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Length"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Length);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Meter"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Meter();
    }

    #endregion

    #region Meter

    /// <summary />
    public sealed class Meter : Length
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Meter"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "m";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "m";
    }

    #endregion

    #region Kilometer

    /// <summary />
    public sealed class Kilometer : Length
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Kilometer"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1000m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "km";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "km";
    }

    #endregion

    #region Millimeter

    /// <summary />
    public sealed class Millimeter : Length
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Millimeter"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "mm";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "mm";
    }

    #endregion

    #region Centimeter

    /// <summary />
    public sealed class Centimeter : Length
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Centimeter"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "cm";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "cm";
    }

    #endregion

    #region Decimeter

    /// <summary />
    public sealed class Decimeter : Length
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Decimeter"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "dm";

        /// <summary>
        /// Returns the unit text in the given language of the system.
        /// </summary>
        /// <returns>the unit text in the given language of the system</returns>
        public override string GetDisplayValue() => "dm";
    }

    #endregion

    #region Mile

    /// <summary />
    public sealed class Mile : Length
    {
        /// <summary>
        /// 1609.344m
        /// </summary>
        public const decimal FactorToMeter = 1760m * Yard.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Mile"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "mi";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "mi";
    }

    #endregion

    #region Yard (yd)

    /// <summary />
    public sealed class Yard : Length
    {
        /// <summary>
        /// 0.9144m
        /// </summary>
        public const decimal FactorToMeter = 3m * Foot.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Yard"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "yd";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "yd";
    }

    #endregion

    #region Foot (ft)

    /// <summary />
    public sealed class Foot : Length
    {
        /// <summary>
        /// 0.3048m
        /// </summary>
        public const decimal FactorToMeter = 12m * Inch.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Foot"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ft";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ft";
    }

    #endregion

    #region Zoll / Inch (in)

    /// <summary />
    public sealed class Inch : Length
    {
        /// <summary>
        /// 0.0254m
        /// </summary>
        public const decimal FactorToMeter = 0.0254m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Inch"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "in";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "in";
    }

    #endregion

    #region AstronomicalUnit

    /// <summary />
    public sealed class AstronomicalUnit : Length
    {
        /// <summary>
        /// 149,597,870,700m
        /// </summary>
        public const decimal FactorToMeter = 149_597_870_700m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="AstronomicalUnit"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "au";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "au";
    }

    #endregion

    #region Parsec

    /// <summary />
    public sealed class Parsec : Length
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Parsec"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => (648_000m / Convert.ToDecimal(Math.PI)) * AstronomicalUnit.FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "pc";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "pc";
    }

    #endregion

    #region Light year

    /// <summary />
    public sealed class LightYear : Length
    {
        /// <summary>
        /// 1 Julian year: 365.25 days
        /// Light speed:   299,792,458m/s
        /// </summary>
        public const decimal FactorToMeter = 365.25m * Day.FactorToSecond * 299_792_458m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="LightYear"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ly";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ly";
    }

    #endregion

    #region Custom Length

    /// <summary>
    /// Describes an <see cref="Length"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomLength : Length, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly string _serializableValue;

        private readonly Length standardUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => standardUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToMeter">the multiplication factor of this unit in relation to the <see cref="Meter"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomLength(double conversionFactorToMeter, string serializableValue)
        {
            if (string.IsNullOrWhiteSpace(serializableValue))
            {
                throw new ArgumentNullException(nameof(serializableValue));
            }
            else if (serializableValue.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(serializableValue));
            }

            _factorToBaseUnit = System.Convert.ToDecimal(conversionFactorToMeter);
            _unitKey = serializableValue;
            _serializableValue = serializableValue;

            if (_factorToBaseUnit == 1m)
            {
                standardUnit = new Meter();
            }
            else if (_factorToBaseUnit == 1000m)
            {
                standardUnit = new Kilometer();
            }
            else if (_factorToBaseUnit == 0.001m)
            {
                standardUnit = new Millimeter();
            }
            else if (_factorToBaseUnit == 0.01m)
            {
                standardUnit = new Centimeter();
            }
            else if (_factorToBaseUnit == 0.1m)
            {
                standardUnit = new Decimeter();
            }
            else if (_factorToBaseUnit == Mile.FactorToMeter)
            {
                standardUnit = new Mile();
            }
            else if (_factorToBaseUnit == Yard.FactorToMeter)
            {
                standardUnit = new Yard();
            }
            else if (_factorToBaseUnit == Foot.FactorToMeter)
            {
                standardUnit = new Foot();
            }
            else if (_factorToBaseUnit == Inch.FactorToMeter)
            {
                standardUnit = new Inch();
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