namespace DoenaSoft.UnitsOfMeasurement.SimpleUnits.Forces
{
    using System;

    /// <summary>
    /// Describes an <see cref="Force"/> unit that is not predefined in this assembly.
    /// </summary>
    public sealed class CustomForce : Force, ICustomUnit
    {
        private readonly decimal _factorToBaseUnit;

        private readonly string _unitKey;

        private readonly Force _builtInUnit;

        /// <summary>
        /// Returns the multiplication factor of this unit in relation to the <see cref="Newton"/>.
        /// </summary>
        public override decimal FactorToBaseUnit => _builtInUnit?.FactorToBaseUnit ?? _factorToBaseUnit;

        /// <summary/>
        /// <param name="conversionFactorToNewton">the multiplication factor of this unit in relation to the <see cref="Newton"/></param>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomForce(decimal conversionFactorToNewton, string unitKey)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("serializableValue must not contain '/'", nameof(unitKey));
            }

            _factorToBaseUnit = conversionFactorToNewton;

            _unitKey = unitKey;

            if (_factorToBaseUnit == 1m)
            {
                _builtInUnit = new Newton();
            }
            else if (_factorToBaseUnit == KilogramForce.FactorToNewton)
            {
                _builtInUnit = new KilogramForce();
            }
            else if (_factorToBaseUnit == KiloNewton.FactorToNewton)
            {
                _builtInUnit = new KiloNewton();
            }
            else if (_factorToBaseUnit == PoundForce.FactorToNewton)
            {
                _builtInUnit = new PoundForce();
            }
        }

        string ICustomUnit.UnitKey => _unitKey;

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => _builtInUnit?.ToSerializable() ?? _unitKey;

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => _builtInUnit?.GetDisplayValue() ?? _unitKey;
    }
}