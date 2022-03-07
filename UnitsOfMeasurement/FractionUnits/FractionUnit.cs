using System;

namespace DoenaSoft.UnitsOfMeasurement.FractionUnits
{
    using SimpleUnits;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Describes a unit that has a unit over another unit, e.g. <see cref="Liter"/>/<see cref="Second"/>
    /// </summary>
    public class FractionUnit : UnitOfMeasurement, IFractionUnit, IEquatable<FractionUnit>
    {
        /// <summary />
        public ISimpleUnit Numerator { get; }

        /// <summary />
        public ISimpleUnit Denominator { get; }

        /// <summary />
        IUnitOfMeasurement IFractionUnit.Numerator => this.Numerator;

        /// <summary />
        IUnitOfMeasurement IFractionUnit.Denominator => this.Denominator;

        /// <summary>
        /// Returns the category of the unit, e.g. <see cref="Weight"/>/<see cref="Volume"/>.
        /// </summary>
        public override sealed string UnitCategory => $"{this.Numerator.UnitCategory}/{this.Denominator.UnitCategory}";

        /// <summary>
        /// Returns the unit that all other units of this category refer to as the base unit, e.g. <see cref="Liter"/>/<see cref="Second"/>
        /// </summary>
        public override sealed IUnitOfMeasurement BaseUnit => new FractionUnit((ISimpleUnit)this.Numerator.BaseUnit, (ISimpleUnit)this.Denominator.BaseUnit);

        /// <summary/>
        /// <param name="numerator"/>
        /// <param name="denominator"/>
        public FractionUnit(ISimpleUnit numerator, ISimpleUnit denominator)
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

            return this.Equals(obj as IFractionUnit);
        }

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public override bool Equals(IUnitOfMeasurement other) => this.Equals(other as IFractionUnit);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(FractionUnit other) => this.Equals(other as IFractionUnit);

        /// <summary>
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        public bool Equals(IFractionUnit other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                var thisFractionUnit = (IFractionUnit)this;

                var equals = thisFractionUnit.Numerator.Equals(other.Numerator)
                    && thisFractionUnit.Denominator.Equals(other.Denominator);

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
    public class FractionUnit<TNumeratorUnit, TDenominatorUnit> : FractionUnit
        where TNumeratorUnit : ISimpleUnit, new()
        where TDenominatorUnit : ISimpleUnit, new()
    {
        /// <summary/>
        public FractionUnit() : base(new TNumeratorUnit(), new TDenominatorUnit())
        {
        }
    }
}