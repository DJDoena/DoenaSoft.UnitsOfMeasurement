using System;

namespace DoenaSoft.UnitsOfMeasurement
{
    /// <summary>
    /// Describes a unit that has no unit sign.
    /// </summary>
    public sealed class UndefinedUnitOfMeasurement : UnitOfMeasurement
    {
        /// <summary>
        /// Returns the category of the unit, "Undefined".
        /// </summary>
        public override string UnitCategory => "Undefined";

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="UndefinedUnitOfMeasurement"/>.
        /// </summary>
        public override IUnitOfMeasurement BaseUnit => this;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => 0;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is string serializableValue)
            {
                obj = UnitConverter.ToUnitOfMeasurement(serializableValue);
            }

            return obj is UndefinedUnitOfMeasurement;
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public override bool Equals(IUnitOfMeasurement other) => this.Equals(other as UndefinedUnitOfMeasurement);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(UndefinedUnitOfMeasurement other) => other != null;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => string.Empty;

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => string.Empty;
    }
}