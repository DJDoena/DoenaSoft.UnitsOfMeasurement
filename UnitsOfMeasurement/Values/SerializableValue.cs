using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DoenaSoft.UnitsOfMeasurement.Values
{
    /// <summary>
    /// Represents a scalar with a unit in a format that can be sent over a data stream.
    /// </summary>
    [DebuggerDisplay("{Scalar} {UnitOfMeasurement}")]
    public class SerializableValue
    {
        /// <summary/>
        [Required]
        public double Scalar { get; set; }

        /// <summary/>
        public string UnitOfMeasurement { get; set; }

        /// <summary/>
        public SerializableValue()
        {
        }

        /// <summary/>
        public SerializableValue(double scalar, string unitOfMeasurement)
        {
            this.Scalar = scalar;
            this.UnitOfMeasurement = unitOfMeasurement;
        }

        /// <summary>
        /// Converts this <see cref="SerializableValue"/> into a <see cref="Value"/>.
        /// </summary>
        /// <returns>a <see cref="Value"/></returns>
        public Value ToValue()
        {
            var unit = this.GetUnitOfMeasurement();

            var value = new Value(this.Scalar, unit);

            return value;
        }

        /// <summary>
        /// Returns the <see cref="UnitOfMeasurement"/> of this value.
        /// </summary>
        /// <returns>the <see cref="UnitOfMeasurement"/> of this value</returns>
        public UnitOfMeasurement GetUnitOfMeasurement()
        {
            var unit = this.UnitOfMeasurement.ToUnit();

            return unit;
        }

        /// <summary>
        /// Create a copy of this value.
        /// </summary>
        /// <returns>a copy of this value</returns>
        public SerializableValue Clone() => new SerializableValue(this.Scalar, this.UnitOfMeasurement);
    }
}