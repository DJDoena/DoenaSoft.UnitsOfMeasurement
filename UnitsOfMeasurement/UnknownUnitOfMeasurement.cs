namespace DoenaSoft.UnitsOfMeasurement
{
    using System;

    /// <summary>
    /// A unit that does not fall into any of the known categories.
    /// </summary>
    public class UnknownUnitOfMeasurement : UnitOfMeasurement, IEquatable<UnknownUnitOfMeasurement>
    {
        /// <summary/>
        protected readonly string _unit;

        /// <summary>
        /// Returns the category of the unit, "Unknown".
        /// </summary>
        public override sealed string UnitCategory => "Unknown";

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, <see cref="UnknownUnitOfMeasurement"/>.
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => this;

        internal UnknownUnitOfMeasurement(string unit)
        {
            if (string.IsNullOrWhiteSpace(unit))
            {
                throw new ArgumentNullException(nameof(unit));
            }

            _unit = unit;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override sealed int GetHashCode() => _unit.GetHashCode();

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(UnknownUnitOfMeasurement other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                var equals = this.EqualsUnit(other);

                return equals;
            }
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public override bool Equals(IUnitOfMeasurement other) => this.Equals(other as UnknownUnitOfMeasurement);

        /// <summary>
        /// Returns whether two <see cref="UnknownUnitOfMeasurement"/> units are identical.
        /// </summary>
        /// <param name="other">the other <see cref="UnknownUnitOfMeasurement"/> unit</param>
        /// <returns>whether two <see cref="UnknownUnitOfMeasurement"/> units are identical</returns>
        private bool EqualsUnit(UnknownUnitOfMeasurement other) => this.ToSerializable().Equals(other.ToSerializable(), StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override sealed string ToSerializable() => _unit;

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override sealed string GetDisplayValue() => _unit;
    }
}