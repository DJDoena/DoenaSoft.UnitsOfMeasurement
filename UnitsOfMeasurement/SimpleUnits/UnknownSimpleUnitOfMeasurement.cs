using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    /// <summary>
    /// A simple unit that does not fall into any of the known categories.
    /// </summary>
    public sealed class UnknownSimpleUnitOfMeasurement : UnknownUnitOfMeasurement, ISimpleUnit, IEquatable<UnknownSimpleUnitOfMeasurement>
    {
        internal UnknownSimpleUnitOfMeasurement(string unit) : base(unit)
        {
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => base.GetHashCode();

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

            return this.Equals(obj as ISimpleUnit);
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public override bool Equals(IUnitOfMeasurement other) => this.Equals(other as UnknownSimpleUnitOfMeasurement);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(UnknownSimpleUnitOfMeasurement other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                var equals = base.Equals(other);

                return equals;
            }
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(ISimpleUnit other) => this.Equals(other as UnknownSimpleUnitOfMeasurement);
    }
}