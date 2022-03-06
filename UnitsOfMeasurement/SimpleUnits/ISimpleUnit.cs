using System;

namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    /// <summary>
    /// Describes an atomic unit.
    /// </summary>
    public interface ISimpleUnit : IUnitOfMeasurement, IEquatable<ISimpleUnit>
    {
    }
}