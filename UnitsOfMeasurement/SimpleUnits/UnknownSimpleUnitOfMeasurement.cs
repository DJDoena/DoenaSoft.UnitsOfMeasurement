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

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is string serializableValue)
            {
                obj = UnitConverter.ToUnitOfMeasurement(serializableValue);
            }

            var equals = base.Equals(obj as UnknownSimpleUnitOfMeasurement);

            return equals;
        }
    }
}