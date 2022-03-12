namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits
{
    /// <summary>
    /// Describes an atomic unit.
    /// </summary>
    public abstract class SimpleUnit : UnitOfMeasurement, ISimpleUnit
    {
        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the base unit of this category.
        /// </summary>
        public abstract decimal FactorToBaseUnit { get; }

        internal virtual decimal ToBaseUnitValue(decimal value) => value * this.FactorToBaseUnit;

        internal virtual decimal FromBaseUnitValue(decimal baseUnitValue) => baseUnitValue / this.FactorToBaseUnit;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override sealed int GetHashCode() => this.UnitCategory.GetHashCode() ^ this.ToSerializable().GetHashCode();
    }
}