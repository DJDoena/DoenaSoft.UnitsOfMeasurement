using System;

namespace DoenaSoft.UnitsOfMeasurement.ComplexUnits
{
    using SimpleUnits;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Describes a unit that has a unit over another unit, e.g. <see cref="Liter"/>/<see cref="Second"/>
    /// </summary>
    public class ComplexUnit : UnitOfMeasurement, IComplexUnit, IEquatable<ComplexUnit>
    {
        /// <summary />
        public ISimpleUnit Numerator { get; }

        /// <summary />
        public ISimpleUnit Denominator { get; }

        /// <summary />
        IUnitOfMeasurement IComplexUnit.Numerator => this.Numerator;

        /// <summary />
        IUnitOfMeasurement IComplexUnit.Denominator => this.Denominator;

        /// <summary>
        /// Returns the category of the unit, e.g. <see cref="Weight"/>/<see cref="Volume"/>.
        /// </summary>
        public override sealed string UnitCategory => $"{this.Numerator.UnitCategory}/{this.Denominator.UnitCategory}";

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, e.g. <see cref="Liter"/>/<see cref="Second"/>
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new ComplexUnit((ISimpleUnit)this.Numerator.BaseUnit, (ISimpleUnit)this.Denominator.BaseUnit);

        /// <summary/>
        /// <param name="numerator"/>
        /// <param name="denominator"/>
        public ComplexUnit(ISimpleUnit numerator, ISimpleUnit denominator)
        {
            if (numerator == null)
            {
                throw new ArgumentNullException(nameof(numerator));
            }
            else if (denominator == null)
            {
                throw new ArgumentNullException(nameof(denominator));
            }

            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override sealed int GetHashCode() => this.Numerator.GetHashCode() ^ this.Denominator.GetHashCode();

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

            return this.Equals(obj as IComplexUnit);
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public override bool Equals(IUnitOfMeasurement other) => this.Equals(other as IComplexUnit);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(ComplexUnit other) => this.Equals(other as IComplexUnit);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(IComplexUnit other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                var thisComplexUnit = (IComplexUnit)this;

                var equals = thisComplexUnit.Numerator.Equals(other.Numerator)
                    && thisComplexUnit.Denominator.Equals(other.Denominator);

                return equals;
            }
        }

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override sealed string ToSerializable() => $"{this.Numerator.ToSerializable()}/{this.Denominator.ToSerializable()}";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override sealed string GetDisplayValue() => $"{this.Numerator.GetDisplayValue()}/{this.Denominator.GetDisplayValue()}";
    }

    /// <summary>
    /// Describes a unit that has a unit over another unit, e.g. <see cref="Liter"/>/<see cref="Hour"/>
    /// </summary>
    /// <typeparam name="TNumeratorUnit">the unit over the divider, e.g. <see cref="Liter"/></typeparam>
    /// <typeparam name="TDenominatorUnit">the unit under the divider, e.g. <see cref="Hour"/></typeparam>
    public class ComplexUnit<TNumeratorUnit, TDenominatorUnit> : ComplexUnit
        where TNumeratorUnit : ISimpleUnit, new()
        where TDenominatorUnit : ISimpleUnit, new()
    {
        /// <summary/>
        public ComplexUnit() : base(new TNumeratorUnit(), new TDenominatorUnit())
        {
        }
    }

    /// <summary>
    /// Eine Klasse für Einheiten, die nicht dem Standard Zähler/Nenner Format folgen.
    /// </summary>
    public sealed class CustomComplexUnit : ComplexUnit, ICustomUnit
    {
        private readonly string _unitKey;

        /// <summary/>
        /// <param name="numerator"/>
        /// <param name="denominator"/>
        /// <param name="unitKey">a string that uniquely identifies this particular unit, must not contain a '/'</param>
        public CustomComplexUnit(ISimpleUnit numerator, ISimpleUnit denominator, string unitKey) : base(numerator, denominator)
        {
            if (string.IsNullOrWhiteSpace(unitKey))
            {
                throw new ArgumentNullException(nameof(unitKey));
            }
            else if (unitKey.Contains("/"))
            {
                throw new ArgumentException("unitKey must not contain '/'", nameof(unitKey));
            }

            _unitKey = unitKey;
        }

        /// <summary/>
        /// <param name="numerator"/>
        /// <param name="denominator"/>
        public CustomComplexUnit(ISimpleUnit numerator, ISimpleUnit denominator) : base(numerator, denominator)
        {
            string numeratorKey = numerator is ICustomUnit customNumerator
                ? customNumerator.UnitKey
                : numerator.ToSerializable();

            string denominatorKey = denominator is ICustomUnit customDenominator
                ? customDenominator.UnitKey
                : denominator.ToSerializable();

            _unitKey = $"{numeratorKey}/{denominatorKey}";
        }

        string ICustomUnit.UnitKey => _unitKey;
    }
}