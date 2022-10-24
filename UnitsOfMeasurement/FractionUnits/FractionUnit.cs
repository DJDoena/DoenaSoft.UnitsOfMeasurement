namespace DoenaSoft.UnitsOfMeasurement.FractionUnits
{
    using System;
    using SimpleUnits;
    using SimpleUnits.Times;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;

    /// <summary>
    /// Describes a unit that has a unit over another unit, e.g. <see cref="Liter"/>/<see cref="Second"/>
    /// </summary>
    public class FractionUnit : UnitOfMeasurement, IFractionUnit
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
        /// Checks if this unit is equal to another unit.
        /// </summary>
        /// <param name="other">the other unit</param>
        /// <returns>if this unit is equal to another unit</returns>
        protected override bool EqualsUnit(IUnitOfMeasurement other)
        {
            if (!(other is IFractionUnit otherFractionUnit))
            {
                return false;
            }
            else
            {
                var thisFractionUnit = (IFractionUnit)this;

                var equals = thisFractionUnit.Numerator.Equals(otherFractionUnit.Numerator)
                    && thisFractionUnit.Denominator.Equals(otherFractionUnit.Denominator);

                return equals;
            }
        }

        /// <summary>
        /// Returns the unit in a format that can be sent over a data stream.
        /// </summary>
        /// <returns>the unit in a format that can be sent over a data stream</returns>
        public override string ToSerializable() => $"{this.Numerator.ToSerializable()}/{this.Denominator.ToSerializable()}";

        /// <summary>
        /// Returns the unit text in a well-formatted way.
        /// </summary>
        /// <returns>the unit text in a well-formatted way</returns>
        public override string GetDisplayValue() => $"{this.Numerator.GetDisplayValue()}/{this.Denominator.GetDisplayValue()}";
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