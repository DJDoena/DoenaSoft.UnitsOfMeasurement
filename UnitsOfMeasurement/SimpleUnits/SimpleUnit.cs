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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override sealed bool Equals(object obj)
        {
            if (obj is string serializableValue)
            {
                obj = UnitConverter.ToUnitOfMeasurement(serializableValue);
            }

            var equals = base.Equals(obj as ISimpleUnit);

            return equals;
        }
    }
}