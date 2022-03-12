using System;
using System.Globalization;

namespace DoenaSoft.UnitsOfMeasurement.Values
{
    /// <summary>
    /// Describes a scalar with an <see cref="IUnitOfMeasurement"/> unit.
    /// </summary>
    public class Value
    {
        /// <summary/>
        public decimal Scalar { get; }

        /// <summary/>
        public double ScalarAsDouble => Convert.ToDouble(this.Scalar);

        /// <summary/>
        public IUnitOfMeasurement Unit { get; }

        /// <summary/>
        public Value(double scalar, string unit) : this(Convert.ToDecimal(scalar), unit)
        {
        }

        /// <summary/>
        public Value(decimal scalar, string unit) : this(scalar, UnitConverter.ToUnitOfMeasurement(unit))
        {
        }

        /// <summary/>
        public Value(double scalar, IUnitOfMeasurement unit) : this(Convert.ToDecimal(scalar), unit)
        {
        }

        /// <summary/>
        public Value(decimal scalar, IUnitOfMeasurement unit)
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
        public SerializableValue ToSerializable() => new SerializableValue(this.Scalar, this.Unit.ToSerializable());

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
        public Value Add(double scalar) => this.Add(Convert.ToDecimal(scalar));

        /// <summary>
        /// Adds the <see cref="Scalar"/> and the given <paramref name="scalar"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <param name="scalar">the scalar to be added</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public Value Add(decimal scalar) => new Value(this.Scalar + scalar, this.Unit);

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
                throw new InvalidOperationException($"Cannot add null to a value");
            }
            else if (this.Unit.Equals(other.Unit))
            {
                var newScalar = this.Scalar + other.Scalar;

                return new Value(newScalar, this.Unit);
            }
            else
            {
                try
                {
                    var convertedOtherValue = ValueConverter.Convert(other, this.Unit);

                    var newScalar = this.Scalar + convertedOtherValue.Scalar;

                    return new Value(newScalar, this.Unit);
                }
                catch
                {
                    throw new InvalidOperationException($"Cannot add a value of unit '{other.Unit}' to a value of unit '{this.Unit}'");
                }
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
        /// <remarks>
        /// The <see cref="Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public override bool Equals(object obj)
        {
            if (!(obj is Value other))
            {
                return false;
            }

            var equals = this.Unit.Equals(other.Unit);

            Func<decimal, decimal, bool> comparer = (l, r) => RoundForComparison(l) == RoundForComparison(r);

            if (equals)
            {
                equals = comparer(this.Scalar, other.Scalar);
            }
            else
            {
                try
                {
                    var otherConverted = ValueConverter.Convert(other, this.Unit);

                    equals = comparer(this.Scalar, otherConverted.Scalar);
                }
                catch
                {
                    equals = false;
                }
            }

            return equals;
        }

        /// <summary>
        /// To accomodate for conversion discrepencies.
        /// </summary>
        private static decimal RoundForComparison(decimal scalar) => Math.Round(scalar, 18, MidpointRounding.AwayFromZero);

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
        /// <remarks>
        /// The <see cref="Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator ==(Value left, Value right) => ReferenceEquals(left, right) || (left is Value && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <returns>if the two given objects are not equal</returns>
        /// <remarks>
        /// The <see cref="Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator !=(Value left, Value right) => !(left == right);

        /// <summary>
        /// The &gt;= (greater than or equal) operator returns true if its left-hand operand is greater than or equal to its right-hand operand, false otherwise.
        /// </summary>
        /// <remarks>
        /// The <see cref="Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator >=(Value left, Value right) => Compare(left, right, (l, r) => RoundForComparison(l) >= RoundForComparison(r));

        /// <summary>
        /// The &lt;= (less than or equal) operator returns true if its left-hand operand is less than or equal to its right-hand operand, false otherwise.
        /// </summary>
        /// <remarks>
        /// The <see cref="Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator <=(Value left, Value right) => Compare(left, right, (l, r) => RoundForComparison(l) <= RoundForComparison(r));

        /// <summary>
        /// The &gt; (greater than) operator returns true if its left-hand operand is greater than its right-hand operand, false otherwise.
        /// </summary>
        /// <remarks>
        /// The <see cref="Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator >(Value left, Value right) => Compare(left, right, (l, r) => RoundForComparison(l) > RoundForComparison(r));

        /// <summary>
        /// The &lt; (less than) operator returns true if its left-hand operand is less than its right-hand operand, false otherwise.
        /// </summary>
        /// <remarks>
        /// The <see cref="Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator <(Value left, Value right) => Compare(left, right, (l, r) => RoundForComparison(l) < RoundForComparison(r));

        private static bool Compare(Value left, Value right, Func<decimal, decimal, bool> comparer)
        {
            if (ReferenceEquals(left, right))
            {
                if (ReferenceEquals(left, null))
                {
                    throw new InvalidOperationException($"Cannot compare to a null value");
                }
                else
                {
                    var result = comparer(left.Scalar, right.Scalar);

                    return result;
                }
            }
            else if (left == null)
            {
                throw new InvalidOperationException($"Cannot compare to a null value");
            }
            else if (right == null)
            {
                throw new InvalidOperationException($"Cannot compare to a null value");
            }
            else if (left.Unit.Equals(right.Unit))
            {
                var result = comparer(left.Scalar, right.Scalar);

                return result;
            }
            else
            {
                try
                {
                    var rightConverted = ValueConverter.Convert(right, left.Unit);

                    var result = comparer(left.Scalar, rightConverted.Scalar);

                    return result;
                }
                catch
                {
                    throw new InvalidOperationException($"Cannot compare a value of unit '{left.Unit}' with a value of unit '{right.Unit}'");
                }
            }
        }

        /// <summary>
        /// Adds <paramref name="left"/> and the given <paramref name="right"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <remarks>
        /// This only works if both values are in the same <see cref="UnitOfMeasurement.UnitCategory"/>.
        /// The result value will always have the <see cref="Unit"/> of <paramref name="left"/>  value.
        /// </remarks>
        /// <returns>a new value with the summed-up scalar</returns>
        public static Value operator +(Value left, Value right)
        {
            Func<Value, Value, Value> adder = (l, r) => l.Add(r);

            if (ReferenceEquals(left, right))
            {
                if (ReferenceEquals(left, null))
                {
                    throw new InvalidOperationException($"Cannot add to a null value");
                }
                else
                {
                    var result = adder(left, right);

                    return result;
                }
            }
            else if (left == null)
            {
                throw new InvalidOperationException($"Cannot add to a null value");
            }
            else if (right == null)
            {
                throw new InvalidOperationException($"Cannot add null to a value");
            }
            else
            {
                var result = adder(left, right);

                return result;
            }
        }
    }

    /// <summary>
    /// Describes a scalar with an <see cref="IUnitOfMeasurement"/> unit.
    /// </summary>
    /// <typeparam name="TUnit">the <see cref="IUnitOfMeasurement"/> unit</typeparam>
    public class Value<TUnit> : Value where TUnit : IUnitOfMeasurement, new()
    {
        /// <summary/>
        public Value(double scalar) : this(Convert.ToDecimal(scalar))
        {
        }

        /// <summary/>
        public Value(decimal scalar) : base(scalar, new TUnit())
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
        public new Value<TUnit> Add(double scalar) => this.Add(Convert.ToDecimal(scalar));

        /// <summary>
        /// Adds the <see cref="Value.Scalar"/> and the given <paramref name="scalar"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <param name="scalar">the scalar to be added</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public new Value<TUnit> Add(decimal scalar) => new Value<TUnit>(this.Scalar + scalar);

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
            var baseResult = base.Add(other);

            return new Value<TUnit>(baseResult.Scalar);
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
    }
}