using System;

namespace DoenaSoft.UnitsOfMeasurement
{
    /// <summary>
    /// Describes an atomic unit.
    /// </summary>
    public interface ISimpleUnit : IUnitOfMeasurement, IEquatable<ISimpleUnit>
    {
    }
}