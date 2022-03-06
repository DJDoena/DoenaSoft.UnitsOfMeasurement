using System;

namespace DoenaSoft.UnitsOfMeasurement
{
    /// <summary>
    /// Describes a unit that has a unit over another unit, e.g. <see cref="SimpleUnits.Liter"/>/<see cref="SimpleUnits.Hour"/>
    /// </summary>
    public interface IComplexUnit : IUnitOfMeasurement, IEquatable<IComplexUnit>
    {
        /// <summary />
        IUnitOfMeasurement Numerator { get; }

        /// <summary />
        IUnitOfMeasurement Denominator { get; }
    }
}