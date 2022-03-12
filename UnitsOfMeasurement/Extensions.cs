namespace DoenaSoft.UnitsOfMeasurement
{
    /// <summary/>
    public static class Extensions
    {
        /// <summary>
        /// Converts a <see cref="string"/> representing a unit to a <see cref="UnitOfMeasurement"/>.
        /// </summary>
        /// <param name="unitOfMeasurement">a <see cref="string"/> representing a unit</param>
        /// <returns>a <see cref="UnitOfMeasurement"/></returns>
        public static UnitOfMeasurement ToUnit(this string unitOfMeasurement) => UnitConverter.ToUnitOfMeasurement(unitOfMeasurement);
    }
}