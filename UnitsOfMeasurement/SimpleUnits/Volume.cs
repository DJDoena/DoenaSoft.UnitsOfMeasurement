using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    #region Volume

    /// <summary />
    public abstract class Volume : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Volume"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Volume);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Liter"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Liter();
    }

    #endregion

    #region Liter (dm³)

    /// <summary />
    public sealed class Liter : Volume
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Liter"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "dm3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "l";
    }

    #endregion

    #region Milliliter (cm³)

    /// <summary />
    public sealed class Milliliter : Volume
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Millimeter"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 0.001m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "cm3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ml";
    }

    #endregion

    #region m³

    /// <summary />
    public sealed class CubicMeter : Volume
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="CubicMeter"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1000m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "m3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "m³";
    }

    #endregion

    #region US Gallon

    /// <summary />
    public sealed class USLiquidGallon : Volume
    {
        /// <summary>
        /// 3.785411784l
        /// </summary>
        public const decimal FactorToLiter = 3.785411784m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="USLiquidGallon"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "US.liq.gal.";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "US.liq.gal.";
    }

    #endregion

    #region UK Gallon

    /// <summary />
    public sealed class ImperialGallon : Volume
    {
        /// <summary>
        /// 4.54609l
        /// </summary>
        public const decimal FactorToLiter = 4.54609m;

        /// <summary>
        /// Returns the multiplication factor of <see cref="ImperialGallon"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "Imp.gal.";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "Imp.gal.";
    }

    #endregion

    #region Cubic foot (ft³)

    /// <summary />
    public sealed class CubicFoot : Volume
    {
        /// <summary>
        /// 28.316846592l
        /// </summary>
        public const decimal FactorToLiter = 1000m * Foot.FactorToMeter * Foot.FactorToMeter * Foot.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="CubicFoot"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "ft3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "ft³";
    }

    #endregion

    #region Cubic inch (in³)

    /// <summary />
    public sealed class CubicInch : Volume
    {
        /// <summary>
        /// 0.016387064l
        /// </summary>
        public const decimal FactorToLiter = 1000m * Inch.FactorToMeter * Inch.FactorToMeter * Inch.FactorToMeter;

        /// <summary>
        /// Returns the multiplication factor of <see cref="CubicInch"/> in relation to the <see cref="Liter"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => FactorToLiter;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "in3";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "in³";
    }

    #endregion

    #region Custom Volume

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

    #endregion
}