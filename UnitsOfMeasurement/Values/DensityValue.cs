using System;

namespace DoenaSoft.UnitsOfMeasurement.Values
{
    using FractionUnits.Densities;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    /// <remarks><see cref="DensityValue"/> is immutable. Any operation that results in a different <see cref="Value.Scalar"/> will return a new instance.</remarks>
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
    }

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    /// <remarks><see cref="DensityValue{TDensityUnit}"/> is immutable. Any operation that results in a different <see cref="Value.Scalar"/> will return a new instance.</remarks>
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
    }

    /// <summary>
    /// Describes a scalar with a <see cref="Density"/> unit.
    /// </summary>
    /// <remarks><see cref="DensityValue{TWeight, TVolume}"/> is immutable. Any operation that results in a different <see cref="Value.Scalar"/> will return a new instance.</remarks>
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