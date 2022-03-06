using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DoenaSoft.UnitsOfMeasurement
{
    using ComplexUnits;
    using SimpleUnits;

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    public class DensityValue : Value
    {
        /// <summary/>
        public new Density Unit => (Density)base.Unit;

        /// <summary/>
        /// <param name="value"/>
        public DensityValue(string value) : this(double.Parse(Regex.Match(value, @"[\d,.]+").Groups[0].Value), value.Trim().Replace(Regex.Match(value, @"[\d,.]+").Groups[0].Value, "").Trim())
        {
        }

        /// <summary/>
        /// <param name="scalar"/>
        /// <param name="unit"/>
        public DensityValue(double scalar, string unit) : this(scalar, UnitConverter.ToDensityUnit(unit))
        {
        }

        /// <summary/>
        /// <param name="scalar"/>
        /// <param name="densityUnit"/>
        public DensityValue(double scalar, Density densityUnit) : base(scalar, densityUnit)
        {
        }

        /// <summary/>
        /// <param name="scalar"/>
        /// <param name="numerator"/>
        /// <param name="denominator"/>
        public DensityValue(double scalar, Weight numerator, Volume denominator) : base(scalar, new Density(numerator, denominator))
        {
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public new DensityValue Clone() => new DensityValue(this.Scalar, this.Unit);

        /// <summary>
        /// Adds the <see cref="Value.Scalar"/> and the given <paramref name="scalar"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <param name="scalar">the scalar to be added</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public new DensityValue Add(double scalar) => new DensityValue(this.Scalar + scalar, this.Unit);

        /// <summary>
        /// Rounds the <see cref="Value.Scalar"/> to the given <paramref name="digits"/> and returns a new value with the rounded scalar.
        /// </summary>
        /// <param name="digits">the precision</param>
        /// <returns>a new value with the rounded scalar</returns>
        public new DensityValue Round(int digits) => new DensityValue(Math.Round(this.Scalar, digits, MidpointRounding.AwayFromZero), this.Unit);

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
        public static bool operator ==(DensityValue left, DensityValue right) => ReferenceEquals(left, right) || (left is Value && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are not equal</returns>
        public static bool operator !=(DensityValue left, DensityValue right) => !(left == right);
    }

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    /// <typeparam name="TDensityUnit"/>
    [DebuggerDisplay("{ToString()}")]
    public class DensityValue<TDensityUnit> : DensityValue
        where TDensityUnit : Density, new()
    {
        /// <summary/>
        /// <param name="scalar"/>
        public DensityValue(double scalar) : base(scalar, new TDensityUnit())
        {
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public new DensityValue<TDensityUnit> Clone() => new DensityValue<TDensityUnit>(this.Scalar);

        /// <summary>
        /// Adds the <see cref="Value.Scalar"/> and the given <paramref name="scalar"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <param name="scalar">the scalar to be added</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public new DensityValue<TDensityUnit> Add(double scalar) => new DensityValue<TDensityUnit>(this.Scalar + scalar);

        /// <summary>
        /// Rounds the <see cref="Value.Scalar"/> to the given <paramref name="digits"/> and returns a new value with the rounded scalar.
        /// </summary>
        /// <param name="digits">the precision</param>
        /// <returns>a new value with the rounded scalar</returns>
        public new DensityValue<TDensityUnit> Round(int digits) => new DensityValue<TDensityUnit>(Math.Round(this.Scalar, digits, MidpointRounding.AwayFromZero));

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
        public static bool operator ==(DensityValue<TDensityUnit> left, DensityValue<TDensityUnit> right) => ReferenceEquals(left, right) || (left is Value && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are not equal</returns>
        public static bool operator !=(DensityValue<TDensityUnit> left, DensityValue<TDensityUnit> right) => !(left == right);
    }

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    /// <typeparam name="TWeight"/>
    /// <typeparam name="TVolume"/>
    [DebuggerDisplay("{ToString()}")]
    public class DensityValue<TWeight, TVolume> : DensityValue
        where TWeight : Weight, new()
        where TVolume : Volume, new()
    {
        /// <summary/>
        /// <param name="scalar"/>
        public DensityValue(double scalar) : base(scalar, new Density(new TWeight(), new TVolume()))
        {
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public new DensityValue<TWeight, TVolume> Clone() => new DensityValue<TWeight, TVolume>(this.Scalar);

        /// <summary>
        /// Adds the <see cref="Value.Scalar"/> and the given <paramref name="scalar"/> and returns a new value with the summed-up scalar.
        /// </summary>
        /// <param name="scalar">the scalar to be added</param>
        /// <returns>a new value with the summed-up scalar</returns>
        public new DensityValue<TWeight, TVolume> Add(double scalar) => new DensityValue<TWeight, TVolume>(this.Scalar + scalar);

        /// <summary>
        /// Rounds the <see cref="Value.Scalar"/> to the given <paramref name="digits"/> and returns a new value with the rounded scalar.
        /// </summary>
        /// <param name="digits">the precision</param>
        /// <returns>a new value with the rounded scalar</returns>
        public new DensityValue<TWeight, TVolume> Round(int digits) => new DensityValue<TWeight, TVolume>(Math.Round(this.Scalar, digits, MidpointRounding.AwayFromZero));

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
        public static bool operator ==(DensityValue<TWeight, TVolume> left, DensityValue<TWeight, TVolume> right) => ReferenceEquals(left, right) || (left is Value && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <param name="left"/>
        /// <param name="right"/>
        /// <returns>if the two given objects are not equal</returns>
        public static bool operator !=(DensityValue<TWeight, TVolume> left, DensityValue<TWeight, TVolume> right) => !(left == right);
    }
}