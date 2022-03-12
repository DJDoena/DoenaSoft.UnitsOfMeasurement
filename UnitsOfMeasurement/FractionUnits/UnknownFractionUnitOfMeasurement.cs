namespace DoenaSoft.UnitsOfMeasurement.FractionUnits
{
    /// <summary>
    /// A fraction unit that does not fall into any of the known categories.
    /// </summary>
    public sealed class UnknownFractionUnitOfMeasurement : UnknownUnitOfMeasurement, IFractionUnit
    {
        /// <summary />
        public IUnitOfMeasurement Numerator { get; }

        /// <summary />
        public IUnitOfMeasurement Denominator { get; }

        internal UnknownFractionUnitOfMeasurement(string unit) : base(unit)
        {
            var indexOfSlash = unit.IndexOf("/");

            this.Numerator = UnitConverter.ToUnitOfMeasurement(unit.Substring(0, indexOfSlash));

            this.Denominator = UnitConverter.ToUnitOfMeasurement(unit.Substring(indexOfSlash + 1));
        }
    }
}