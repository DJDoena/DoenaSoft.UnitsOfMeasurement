using System;

namespace DoenaSoft.UnitsOfMeasurement.ComplexUnits
{
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;

    /// <summary>
    /// Describes a unit that has a unit over another unit, e.g. <see cref="Liter"/>/<see cref="Hour"/>
    /// </summary>
    public interface IComplexUnit : IUnitOfMeasurement, IEquatable<IComplexUnit>
    {
        /// <summary />
        IUnitOfMeasurement Numerator { get; }

        /// <summary />
        IUnitOfMeasurement Denominator { get; }
    }
}