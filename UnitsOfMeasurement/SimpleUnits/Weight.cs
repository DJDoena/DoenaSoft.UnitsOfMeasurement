using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    #region Weight

    /// <summary />
    public abstract class Weight : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Weight"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Weight);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Kilogram"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Kilogram();
    }

    #endregion

    #region Kilogramm

    /// <summary />
    public sealed class Kilogram : Weight
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Kilogram"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "kg";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "kg";
    }

    #endregion

    #region Tonne

    /// <summary />
    public sealed class Ton : Weight
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Ton"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1000m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "t";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "t";
    }

    #endregion

    #region Gramm

    /// <summary />
    public sealed class Gram : Weight
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Gram"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "g";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "g";
    }

    #endregion

    #region Milligramm

    /// <summary />
    public sealed class Milligram : Weight
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Milligram"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.000001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "mg";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "mg";
    }

    #endregion

    #region Pound (lb)

    /// <summary />
    public sealed class Pound : Weight
    {
        /// <summary>
        /// 0.45359237kg
        /// </summary>
        public const decimal FactorToKilogram = 0.45359237m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Pound"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToKilogram;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "lb";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "lb";
    }

    #endregion

    #region Short ton (2000 lb)

    /// <summary>
    /// 2000 lb
    /// </summary>
    public sealed class ShortTon : Weight
    {
        /// <summary>
        /// 907.18474kg
        /// </summary>
        public const decimal FactorToKilogram = 2000m * Pound.FactorToKilogram;

        /// <summary>
        /// Returns the multiplication factor of <see cref="ShortTon"/> in relation to the <see cref="Kilogram"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToKilogram;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "stn";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "stn";
    }

    #endregion

    #region Custom Weight

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

    #endregion
}