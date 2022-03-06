using System;

namespace DoenaSoft.UnitsOfMeasurement
{
    using SimpleUnits;

    /// <summary>
    /// Base interface to all units of measurement.
    /// </summary>
    public interface IUnitOfMeasurement : IEquatable<IUnitOfMeasurement>
    {
        /// <summary>
        /// Returns the category of the unit, e.g. <see cref="Weight"/> or <see cref="Volume"/>.
        /// </summary>
        string UnitCategory { get; }

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit.
        /// </summary>
        IUnitOfMeasurement BaseUnit { get; }

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        string GetDisplayValue();

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        string ToSerializable();
    }
}