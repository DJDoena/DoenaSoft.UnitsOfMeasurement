using System;

namespace DoenaSoft.UnitsOfMeasurement
{
    /// <summary>
    /// Abstract base class to all units.
    /// </summary>
    public abstract class UnitOfMeasurement : IUnitOfMeasurement, IEquatable<UnitOfMeasurement>
    {
        /// <summary>
        /// Returns the category of the unit, e.g. Weight or Volume.
        /// </summary>
        public abstract string UnitCategory { get; }

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit.
        /// </summary>
        public abstract IUnitOfMeasurement BaseUnit { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override sealed string ToString() => this.GetDisplayValue();

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public abstract string ToSerializable();

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public abstract string GetDisplayValue();

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override abstract int GetHashCode();

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override abstract bool Equals(object obj);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public virtual bool Equals(IUnitOfMeasurement other) => this.EqualsUnit(other);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(UnitOfMeasurement other) => this.Equals(other as IUnitOfMeasurement);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        protected bool EqualsUnit(IUnitOfMeasurement other)
        {
            if (other == null)
            {
                return false;
            }

            var equals = this.UnitCategory.Equals(other.UnitCategory)
                && this.ToSerializable().Equals(other.ToSerializable(), StringComparison.OrdinalIgnoreCase);

            return equals;
        }

        /// <summary>
        /// The == (equality) operators checks if the two given objects are equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are equal</returns>
        public static bool operator ==(UnitOfMeasurement left, UnitOfMeasurement right) => ReferenceEquals(left, right) || (left is UnitOfMeasurement && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are not equal</returns>
        public static bool operator !=(UnitOfMeasurement left, UnitOfMeasurement right) => !(left == right);
    }
}