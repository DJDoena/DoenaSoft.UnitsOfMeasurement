namespace DoenaSoft.UnitsOfMeasurement.Exceptions
{
    using System;

    /// <summary/>
    public sealed class UnitConversionException : Exception
    {
        /// <summary/>
        public UnitConversionException(string message) : base(message)
        {
        }

        /// <summary/>
        public UnitConversionException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}