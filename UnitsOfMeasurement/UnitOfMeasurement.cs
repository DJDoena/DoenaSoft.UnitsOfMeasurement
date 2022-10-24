namespace DoenaSoft.UnitsOfMeasurement
{
    using System;
    using SimpleUnits.Areas;
    using SimpleUnits.Energies;
    using SimpleUnits.Forces;
    using SimpleUnits.Lengths;
    using SimpleUnits.Temperatures;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;
    using SimpleUnits.WizardCurrencies;

    /// <summary>
    /// Abstract base class to all units.
    /// </summary>
    /// <remarks>All of <see cref="UnitOfMeasurement"/>'s derived classes inside this library are immutable.</remarks>
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
        public override sealed bool Equals(object obj)
        {
            if (obj is string serializableValue)
            {
                obj = UnitConverter.ToUnitOfMeasurement(serializableValue);
            }

            var result = this.Equals(obj as IUnitOfMeasurement);

            return result;
        }

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
        protected virtual bool EqualsUnit(IUnitOfMeasurement other)
        {
            if (other == null)
            {
                return false;
            }

            var equals = this.UnitCategory.Equals(other.UnitCategory)
                && this.ToSerializable().Equals(other.ToSerializable());

            if (equals)
            {
                equals = EnsureBuiltInTypes(other);
            }

            return equals;
        }

        /// <summary>
        /// Check that the built-in categories are not polluted with outside implementations of IUnitOfMeasurement that do not derive from the correct base unit
        /// </summary>
        private static bool EnsureBuiltInTypes(IUnitOfMeasurement other)
        {
            bool equals;
            switch (other.UnitCategory)
            {
                case nameof(Area):
                    {
                        equals = IsOfType(other, typeof(Area));

                        break;
                    }
                case nameof(Energy):
                    {
                        equals = IsOfType(other, typeof(Energy));

                        break;
                    }
                case nameof(Force):
                    {
                        equals = IsOfType(other, typeof(Force));

                        break;
                    }
                case nameof(Length):
                    {
                        equals = IsOfType(other, typeof(Length));

                        break;
                    }
                case nameof(Temparature):
                    {
                        equals = IsOfType(other, typeof(Temparature));

                        break;
                    }
                case nameof(Time):
                    {
                        equals = IsOfType(other, typeof(Time));

                        break;
                    }
                case nameof(Volume):
                    {
                        equals = IsOfType(other, typeof(Volume));

                        break;
                    }
                case nameof(Weight):
                    {
                        equals = IsOfType(other, typeof(Weight));

                        break;
                    }
                case nameof(WizardCurrency):
                    {
                        equals = IsOfType(other, typeof(WizardCurrency));

                        break;
                    }
                default:
                    {
                        throw new NotSupportedException();
                    }
            }

            return equals;
        }

        private static bool IsOfType(IUnitOfMeasurement other, Type requested)
        {
            var actual = other.GetType();

            while (actual != null && !actual.Equals(typeof(object)))
            {
                if (actual.Equals(requested))
                {
                    return true;
                }
                else
                {
                    actual = actual.BaseType;
                }
            }

            return false;
        }

        /// <summary>
        /// The == (equality) operators checks if the two given objects are equal.
        /// </summary>
        /// <returns>if the two given objects are equal</returns>
        public static bool operator ==(UnitOfMeasurement left, UnitOfMeasurement right) => ReferenceEquals(left, right) || (left is UnitOfMeasurement && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <returns>if the two given objects are not equal</returns>
        public static bool operator !=(UnitOfMeasurement left, UnitOfMeasurement right) => !(left == right);
    }
}