using System;
using System.Diagnostics;
using System.Globalization;

namespace DoenaSoft.UnitsOfMeasurement
{
    /// <summary>
    /// Describes a scalar with an <see cref="IUnitOfMeasurement"/> unit.
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public class Value
    {
        /// <summary/>
        public double Scalar { get; }

        /// <summary/>
        public IUnitOfMeasurement Unit { get; }

        /// <summary/>
        /// <param name="scalar"/>
        /// <param name="unit"/>
        public Value(double scalar, string unit) : this(scalar, UnitConverter.ToUnitOfMeasurement(unit))
        {
        }

        /// <summary/>
        public Value(double scalar, IUnitOfMeasurement unit)
        {
            this.Scalar = scalar;
            this.Unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override sealed string ToString() => this.ToString(CultureInfo.CurrentCulture);

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <param name="culture">the culture which formats the <see cref="Scalar"/></param>
        /// <returns>A string that represents the current object.</returns>
        public string ToString(CultureInfo culture) => $"{this.Scalar.ToString(culture)} {this.Unit.GetDisplayValue()}";

        /// <summary>
        /// Returns the value in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the value in a format that can be sent over a data stream</returns>
        public SerializableValue ToSerializable()
        {
            var value = new SerializableValue()
            {
                Scalar = Scalar,
                UnitOfMeasurement = this.Unit.ToSerializable(),
            };

            return value;
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public Value Clone() => new Value(this.Scalar, this.Unit);

        /// <summary>
        /// Adds the <see cref="Scalar"/> and the given <paramref name="scalar"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <param name="scalar">the scalar to be added</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public Value Add(double scalar) => new Value(Convert.ToDouble(Convert.ToDecimal(this.Scalar) + Convert.ToDecimal(scalar)), this.Unit);

        /// <summary>
        /// Adds this value and the given <paramref name="other"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <remarks>
        /// This only works if both values are in the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// The result value will always have the <see cref="Unit"/> of this value.
        /// </remarks>
        /// <param name="other">the other value</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public Value Add(Value other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            else if (!this.Unit.UnitCategory.Equals(other.Unit.UnitCategory))
            {
                throw new ArgumentException("Values have different unit categories!", nameof(other));
            }
            else if (this.Unit.Equals(other.Unit))
            {
                var newScalar = Convert.ToDouble(Convert.ToDecimal(this.Scalar) + Convert.ToDecimal(other.Scalar));

                return new Value(newScalar, this.Unit);
            }
            else
            {
                var convertedOtherValue = ValueConverter.Convert(other, this.Unit);

                var newScalar = Convert.ToDouble(Convert.ToDecimal(this.Scalar) + Convert.ToDecimal(convertedOtherValue.Scalar));

                return new Value(newScalar, this.Unit);
            }
        }

        /// <summary>
        /// Rounds the <see cref="Scalar"/> to the given <paramref name="digits"/> and returns a new value with the rounded scalar.
        /// </summary>
        /// <param name="digits">the precision</param>
        /// <returns>a new value with the rounded scalar</returns>
        public Value Round(int digits) => new Value(Math.Round(this.Scalar, digits, MidpointRounding.AwayFromZero), this.Unit);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Value other))
            {
                return false;
            }

            var equals = this.Unit.Equals(other.Unit);

            if (equals)
            {
                equals = this.Scalar.Equals(other.Scalar);
            }
            else
            {
                try
                {
                    var leftBase = ValueConverter.ConvertToBaseValue(this);

                    var rightBase = ValueConverter.ConvertToBaseValue(other);

                    equals = leftBase.Unit.Equals(rightBase.Unit);

                    if (equals)
                    {
                        equals = leftBase.Scalar.Equals(rightBase.Scalar);
                    }
                }
                catch
                {
                    equals = false;
                }
            }

            return equals;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => this.Scalar.GetHashCode() ^ this.Unit.GetHashCode();

        /// <summary>
        /// The == (equality) operators checks if the two given objects are equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are equal</returns>
        public static bool operator ==(Value left, Value right) => ReferenceEquals(left, right) || (left is Value && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are not equal</returns>
        public static bool operator !=(Value left, Value right) => !(left == right);
    }

    /// <summary>
    /// Describes a scalar with an <see cref="IUnitOfMeasurement"/> unit.
    /// </summary>
    /// <typeparam name="TUnit">the <see cref="IUnitOfMeasurement"/> unit</typeparam>
    [DebuggerDisplay("{ToString()}")]
    public class Value<TUnit> : Value where TUnit : IUnitOfMeasurement, new()
    {
        /// <summary/>
        /// <param name="scalar"/>
        public Value(double scalar) : base(scalar, new TUnit())
        {
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public new Value<TUnit> Clone() => new Value<TUnit>(this.Scalar);

        /// <summary>
        /// Adds the <see cref="Value.Scalar"/> and the given <paramref name="scalar"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <param name="scalar">the scalar to be added</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public new Value<TUnit> Add(double scalar) => new Value<TUnit>(this.Scalar + scalar);

        /// <summary>
        /// Adds this value and the given <paramref name="other"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <remarks>
        /// This only works if both values are in the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// The result value will always have the <see cref="Value.Unit"/> of this value.
        /// </remarks>
        /// <param name="other">the other value</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public new Value<TUnit> Add(Value other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }
            else if (!this.Unit.UnitCategory.Equals(other.Unit.UnitCategory))
            {
                throw new ArgumentException("Values have different unit categories!", nameof(other));
            }
            else if (this.Unit.Equals(other.Unit))
            {
                var newScalar = Convert.ToDouble(Convert.ToDecimal(this.Scalar) + Convert.ToDecimal(other.Scalar));

                return new Value<TUnit>(newScalar);
            }
            else
            {
                var convertedOtherValue = ValueConverter.Convert(other, this.Unit);

                var newScalar = Convert.ToDouble(Convert.ToDecimal(this.Scalar) + Convert.ToDecimal(convertedOtherValue.Scalar));

                return new Value<TUnit>(newScalar);
            }
        }

        /// <summary>
        /// Rounds the <see cref="Value.Scalar"/> to the given <paramref name="digits"/> and returns a new value with the rounded scalar.
        /// </summary>
        /// <param name="digits">the precision</param>
        /// <returns>a new value with the rounded scalar</returns>
        public new Value<TUnit> Round(int digits) => new Value<TUnit>(Math.Round(this.Scalar, digits, MidpointRounding.AwayFromZero));

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// The == (equality) operators checks if the two given objects are equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are equal</returns>
        public static bool operator ==(Value<TUnit> left, Value<TUnit> right) => ReferenceEquals(left, right) || (left is Value && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are not equal</returns>
        public static bool operator !=(Value<TUnit> left, Value<TUnit> right) => !(left == right);
    }
}