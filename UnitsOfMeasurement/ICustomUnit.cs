namespace DoenaSoft.UnitsOfMeasurement
{
    /// <summary>
    /// Describes a unit that is not predefined in this assembly.
    /// </summary>
    public interface ICustomUnit : IUnitOfMeasurement
    {
        /// <summary>
        /// A unique key that identifies the unit against all others.
        /// </summary>
        string UnitKey { get; }
    }
}