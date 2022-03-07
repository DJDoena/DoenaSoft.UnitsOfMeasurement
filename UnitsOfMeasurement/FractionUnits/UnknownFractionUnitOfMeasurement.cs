using System;

namespace DoenaSoft.UnitsOfMeasurement.FractionUnits
{
    /// <summary>
    /// A fraction unit that does not fall into any of the known categories.
    /// </summary>
    public sealed class UnknownFractionUnitOfMeasurement : UnknownUnitOfMeasurement, IFractionUnit, IEquatable<UnknownFractionUnitOfMeasurement>
    {
        /// <summary>
        /// Zähler
        /// </summary>
        public IUnitOfMeasurement Numerator { get; }

        /// <summary>
        /// Nenner
        /// </summary>
        public IUnitOfMeasurement Denominator { get; }

        internal UnknownFractionUnitOfMeasurement(string unit) : base(unit)
        {
            var indexOfSlash = unit.IndexOf("/");

            this.Numerator = UnitConverter.ToUnitOfMeasurement(unit.Substring(0, indexOfSlash));

            this.Denominator = UnitConverter.ToUnitOfMeasurement(unit.Substring(indexOfSlash + 1));
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

            var equals = this.Equals(obj as IFractionUnit);

            return equals;
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public override bool Equals(IUnitOfMeasurement other) => this.Equals(other as UnknownFractionUnitOfMeasurement);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(UnknownFractionUnitOfMeasurement other)
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
        public bool Equals(IFractionUnit other) => this.Equals(other as UnknownFractionUnitOfMeasurement);
    }
}