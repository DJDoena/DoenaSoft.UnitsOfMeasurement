﻿namespace DoenaSoft.UnitsOfMeasurement.FractionUnits.Densities
{
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Describes a <see cref="FractionUnit"/> of <see cref="Weight"/>/<see cref="Volume"/>
    /// </summary>
    public class Density : FractionUnit
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
    }

    /// <summary>
    /// Describes a <see cref="FractionUnit{TWeight, TVolume}"/> of <see cref="Weight"/>/<see cref="Volume"/>
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