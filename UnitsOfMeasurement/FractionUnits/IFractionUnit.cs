namespace DoenaSoft.UnitsOfMeasurement.FractionUnits
{
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;

    /// <summary>
    /// Describes a unit that has a unit over another unit, e.g. <see cref="Liter"/>/<see cref="Hour"/>
    /// </summary>
    public interface IFractionUnit : IUnitOfMeasurement
    {
        /// <summary />
        IUnitOfMeasurement Numerator { get; }

        /// <summary />
        IUnitOfMeasurement Denominator { get; }
    }
}