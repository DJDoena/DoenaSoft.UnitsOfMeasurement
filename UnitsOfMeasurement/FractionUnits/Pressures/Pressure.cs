﻿using System;

namespace DoenaSoft.UnitsOfMeasurement.FractionUnits.Pressures
{
    using SimpleUnits.Areas;
    using SimpleUnits.Forces;

    /// <summary>
    /// Describes a <see cref="FractionUnit"/> of <see cref="Force"/>/<see cref="Area"/>
    /// </summary>
    public class Pressure : FractionUnit, IEquatable<Pressure>
    {
        /// <summary />
        public new Force Numerator => (Force)base.Numerator;

        /// <summary />
        public new Area Denominator => (Area)base.Denominator;

        /// <summary>
        /// Returns the base <see cref="Pressure"/> unit, i.e. <see cref="Pascal"/>.
        /// </summary>
        public new Pascal BaseUnit => new Pascal();

        /// <summary/>
        public Pressure(Force numerator, Area denominator) : base(numerator, denominator)
        {
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(Pressure other)
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
    /// Describes a <see cref="FractionUnit{TForce, TArea}"/> of <see cref="Force"/>/<see cref="Area"/>
    /// </summary>
    public class Pressure<TForce, TArea> : Pressure, IEquatable<Pressure<TForce, TArea>>
        where TForce : Force, new()
        where TArea : Area, new()
    {
        /// <summary/>
        public Pressure() : base(new TForce(), new TArea())
        {
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(Pressure<TForce, TArea> other)
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