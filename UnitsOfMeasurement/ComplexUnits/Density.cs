﻿namespace DoenaSoft.UnitsOfMeasurement.ComplexUnits
{
    using SimpleUnits;

    /// <summary>
    /// Describes a <see cref="ComplexUnit"/> of <see cref="Weight"/>/<see cref="Volume"/>
    /// </summary>
    public class Density : ComplexUnit
    {
        /// <summary>
        /// Zähler
        /// </summary>
        public new Weight Numerator => (Weight)base.Numerator;

        /// <summary>
        /// Nenner
        /// </summary>
        public new Volume Denominator => (Volume)base.Denominator;

        /// <summary>
        /// Returns the base <see cref="Density"/> unit, i.e. <see cref="Kilogram"/>/<see cref="Liter"/>.
        /// </summary>
        public new Density BaseUnit => new Density((Weight)this.Numerator.BaseUnit, (Volume)this.Denominator.BaseUnit);

        /// <summary/>
        /// <param name="numerator"/>
        /// <param name="denominator"/>
        public Density(Weight numerator, Volume denominator) : base(numerator, denominator)
        {
        }
    }

    /// <summary>
    /// Describes a <see cref="ComplexUnit{TWeight, TVolume}"/> of <see cref="Weight"/>/<see cref="Volume"/>
    /// </summary>
    public class Density<TWeight, TVolume> : Density
        where TWeight : Weight, new()
        where TVolume : Volume, new()
    {
        /// <summary/>
        public Density() : base(new TWeight(), new TVolume())
        {
        }
    }
}