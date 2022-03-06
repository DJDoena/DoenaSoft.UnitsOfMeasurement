using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    #region Temperature

    /// <summary />
    public abstract class Temparature : SimpleUnit
    {
        /// <summary>
        /// Returns the category of the unit, <see cref="Temparature"/>.
        /// </summary>
        public override sealed string UnitCategory => nameof(Temparature);

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="Celsius"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new Celsius();
    }

    #endregion

    #region Celsius

    /// <summary />
    public sealed class Celsius : Temparature
    {
        /// <summary>
        /// Returns the multiplication factor of <see cref="Celsius"/> in relation to the <see cref="Celsius"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => 1m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "°C";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "°C";
    }

    #endregion

    #region Kelvin

    /// <summary />
    public sealed class Kelvin : Temparature
    {
        /// <summary>
        /// Not supported.
        /// </summary>
        public override decimal FactorToBaseUnit => throw new NotSupportedException();

        internal override decimal ToBaseUnitValue(decimal value) => value - 273.15m;

        internal override decimal FromBaseUnitValue(decimal baseUnitValue) => baseUnitValue + 273.15m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "K";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "K";
    }

    #endregion

    #region Fahrenheit

    /// <summary />
    public sealed class Fahrenheit : Temparature
    {
        /// <summary>
        /// Not supported.
        /// </summary>
        public override decimal FactorToBaseUnit => throw new NotSupportedException();

        internal override decimal ToBaseUnitValue(decimal value) => (value - 32m) * 5m / 9m;

        internal override decimal FromBaseUnitValue(decimal baseUnitValue) => (baseUnitValue * 9m / 5m) + 32m;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => "°F";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => "°F";
    }

    #endregion
}