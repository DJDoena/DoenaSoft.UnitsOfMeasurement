using System;

namespace DoenaSoft.UnitsOfMeasurement.Values
{
    using FractionUnits.Densities;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    public class DensityValue : Value
    {
        /// <summary/>
        public new Density Unit => (Density)base.Unit;

        /// <summary/>
        public DensityValue(double scalar, string unit) : this(Convert.ToDecimal(scalar), unit)
        {
        }

        /// <summary/>
        public DensityValue(decimal scalar, string unit) : this(scalar, UnitConverter.ToDensityUnit(unit))
        {
        }

        /// <summary/>
        public DensityValue(double scalar, Density densityUnit) : this(Convert.ToDecimal(scalar), densityUnit)
        {
        }

        /// <summary/>
        public DensityValue(decimal scalar, Density densityUnit) : base(scalar, densityUnit)
        {
        }

        /// <summary/>
        public DensityValue(double scalar, Weight numerator, Volume denominator) : this(Convert.ToDecimal(scalar), numerator, denominator)
        {
        }

        /// <summary/>
        public DensityValue(decimal scalar, Weight numerator, Volume denominator) : base(scalar, new Density(numerator, denominator))
        {
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public new DensityValue Clone() => new DensityValue(this.Scalar, this.Unit);

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
        /// <remarks>
        /// The <see cref="Value.Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// The == (equality) operators checks if the two given objects are equal.
        /// </summary>
        /// <returns>if the two given objects are equal</returns>
        /// <remarks>
        /// The <see cref="Value.Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator ==(DensityValue left, DensityValue right) => ReferenceEquals(left, right) || (left is Value && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <returns>if the two given objects are not equal</returns>
        /// <remarks>
        /// The <see cref="Value.Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator !=(DensityValue left, DensityValue right) => !(left == right);
    }

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    /// <typeparam name="TDensityUnit"/>
    public class DensityValue<TDensityUnit> : DensityValue
        where TDensityUnit : Density, new()
    {
        /// <summary/>
        public DensityValue(double scalar) : this(Convert.ToDecimal(scalar))
        {
        }

        /// <summary/>
        public DensityValue(decimal scalar) : base(scalar, new TDensityUnit())
        {
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public new DensityValue<TDensityUnit> Clone() => new DensityValue<TDensityUnit>(this.Scalar);

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
        /// <remarks>
        /// The <see cref="Value.Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// The == (equality) operators checks if the two given objects are equal.
        /// </summary>
        /// <returns>if the two given objects are equal</returns>
        /// <remarks>
        /// The <see cref="Value.Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator ==(DensityValue<TDensityUnit> left, DensityValue<TDensityUnit> right) => ReferenceEquals(left, right) || (left is Value && left.Equals(right));

        /// <summary>
        /// The != (inequality) operators checks if the two given objects are not equal.
        /// </summary>
        /// <returns>if the two given objects are not equal</returns>
        /// <remarks>
        /// The <see cref="Value.Scalar"/> value will be rounded to the 18th decimal place (atto) to accommodate for converting discrepancies.
        /// In the context of this library, any difference smaller than that will be considered equal.
        /// </remarks>
        public static bool operator !=(DensityValue<TDensityUnit> left, DensityValue<TDensityUnit> right) => !(left == right);
    }

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    /// <typeparam name="TWeight"/>
    /// <typeparam name="TVolume"/>
    public class DensityValue<TWeight, TVolume> : DensityValue
        where TWeight : Weight, new()
        where TVolume : Volume, new()
    {
        /// <summary/>
        public DensityValue(double scalar) : this(Convert.ToDecimal(scalar))
        {
        }

        /// <summary/>
        public DensityValue(decimal scalar) : base(scalar, new Density(new TWeight(), new TVolume()))
        {
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public new DensityValue<TWeight, TVolume> Clone() => new DensityValue<TWeight, TVolume>(this.Scalar);

        /// <summary>
        /// Rounds the <see cref="Value.Scalar"/> to the given <paramref name="digits"/> and returns a new value with the rounded scalar.
        /// </summary>
        /// <param name="digits">the precision</param>
        /// <returns>a new value with the rounded scalar</returns>
        public new DensityValue<TWeight, TVolume> Round(int digits) => new DensityValue<TWeight, TVolume>(Math.Round(this.Scalar, digits, MidpointRounding.AwayFromZero));
    }
}