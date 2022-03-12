namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    /// <summary>
    /// A simple unit that does not fall into any of the known categories.
    /// </summary>
    public sealed class UnknownSimpleUnitOfMeasurement : UnknownUnitOfMeasurement, ISimpleUnit
    {
        internal UnknownSimpleUnitOfMeasurement(string unit) : base(unit)
        {
        }
    }
}