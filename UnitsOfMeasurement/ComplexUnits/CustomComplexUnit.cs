﻿using System;

namespace DoenaSoft.UnitsOfMeasurement.ComplexUnits
{
    using SimpleUnits;

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