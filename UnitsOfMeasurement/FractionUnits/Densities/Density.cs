using System;

namespace DoenaSoft.UnitsOfMeasurement.FractionUnits.Densities
{
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Describes a <see cref="FractionUnit"/> of <see cref="Weight"/>/<see cref="Volume"/>
    /// </summary>
    public class Density : FractionUnit, IEquatable<Density>
    {
        /// <summary />
        public new Weight Numerator => (Weight)base.Numerator;

        /// <summary />
        public new Volume Denominator => (Volume)base.Denominator;

        /// <summary>
        /// Returns the base <see cref="Density"/> unit, i.e. <see cref="Kilogram"/>/<see cref="Liter"/>.
        /// </summary>
        public new Density<Kilogram, Liter> BaseUnit => new Density<Kilogram, Liter>();

        /// <summary/>
        public Density(Weight numerator, Volume denominator) : base(numerator, denominator)
        {
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(Density other)
        {
            if (other == null)
            {
                return false;
            }

            var equals = this.Numerator.Equals(other.Numerator)
                && this.Denominator.Equals(other.Denominator);

            return equals;
        }
    }

    /// <summary>
    /// Describes a <see cref="FractionUnit{TWeight, TVolume}"/> of <see cref="Weight"/>/<see cref="Volume"/>
    /// </summary>
    public class Density<TWeight, TVolume> : Density, IEquatable<Density<TWeight, TVolume>>
        where TWeight : Weight, new()
        where TVolume : Volume, new()
    {
        /// <summary/>
        public Density() : base(new TWeight(), new TVolume())
        {
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(Density<TWeight, TVolume> other)
        {
            if (other == null)
            {
                return false;
            }

            var equals = this.Numerator.Equals(other.Numerator)
                && this.Denominator.Equals(other.Denominator);

            return equals;
        }
    }
}