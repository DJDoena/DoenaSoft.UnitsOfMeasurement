using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    #region Area

    /// <summary />
    public abstract class Area : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Area"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Area);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="SquareMeter"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new SquareMeter();
    }

    #endregion

    #region m²

    /// <summary />
    public sealed class SquareMeter : Area
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareMeter"/> in relation to the <see cref="SquareMeter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "m2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "m²";
    }

    #endregion

    #region Hectare

    /// <summary />
    public sealed class Hectare : Area
    {
        /// <summary>
        /// 10,000m²
        /// </summary>
        public const decimal FactorToSquareMeter = 100m * 100m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Hectare"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ha";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ha";
    }

    #endregion

    #region km²

    /// <summary />
    public sealed class SquareKilometer : Area
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareKilometer"/> in relation to the <see cref="SquareMeter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1000m * 1000m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "km2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "km²";
    }

    #endregion

    #region Square inch (in²)

    /// <summary />
    public sealed class SquareInch : Area
    {
        /// <summary>
        /// 0.00064516m²
        /// </summary>
        public const decimal FactorToSquareMeter = Inch.FactorToMeter * Inch.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareInch"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "in2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "in²";
    }

    #endregion

    #region Square foot (ft²)

    /// <summary />
    public sealed class SquareFoot : Area
    {
        /// <summary>
        /// 0.09290304m²
        /// </summary>
        public const decimal FactorToSquareMeter = Foot.FactorToMeter * Foot.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="SquareFoot"/> in relation to the <see cref="SquareMeter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ft2";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ft²";
    }

    #endregion

    #region Acre

    /// <summary />
    public sealed class Acre : Area
    {
        /// <summary>
        /// 4046.8564224m²
        /// </summary>
        public const decimal FactorToSquareMeter = 43_560m * SquareFoot.FactorToSquareMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="Acre"/> in relation to the <see cref="Meter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToSquareMeter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ac";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ac";
    }

    #endregion

    #region Custom Area

    /// <summary>
    /// Describes an <see cref="Area"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomArea : Area, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly string _serializableValue;

        private readonly Area standardUnit;

        /// <summary />
        public override decimal FactorToBaseUnit => standardUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToSquareMeter">the multiplication factor of this unit in relation to the <see cref="SquareMeter"/></param>
        /// <param name="serializableValue">the unit in a format that can be sent over a data stream, must not contain a '/'</param>
        public CustomArea(double conversionFactorToSquareMeter, string serializableValue)
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
                standardUnit = new SquareMeter();
            }
            else if (_factorToBaseUnit == Hectare.FactorToSquareMeter)
            {
                standardUnit = new Hectare();
            }
            else if (_factorToBaseUnit == 1000m * 1000m)
            {
                standardUnit = new SquareKilometer();
            }
            else if (_factorToBaseUnit == SquareInch.FactorToSquareMeter)
            {
                standardUnit = new SquareInch();
            }
            else if (_factorToBaseUnit == SquareFoot.FactorToSquareMeter)
            {
                standardUnit = new SquareFoot();
            }
            else if (_factorToBaseUnit == Acre.FactorToSquareMeter)
            {
                standardUnit = new Acre();
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