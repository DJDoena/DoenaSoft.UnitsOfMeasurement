using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using Exceptions;
    using FractionUnits;
    using SimpleUnits.Lengths;
    using SimpleUnits.Times;
    using SimpleUnits.Weights;
    using Values;

    [TestClass]
    public class ValueOperatorTests
    {
        [TestMethod]
        public void YardToMeter()
        {
            var yd = new Value<Yard>(1m);

#pragma warning disable CS1718 // Comparison made to same variable
            Assert.IsFalse(yd < yd);
            Assert.IsTrue(yd <= yd);
            Assert.IsFalse(yd != yd);
            Assert.IsFalse(yd > yd);
            Assert.IsTrue(yd >= yd);
            Assert.IsTrue(yd == yd);
#pragma warning restore CS1718 // Comparison made to same variable

            var m = new Value<Meter>(1m);

            Assert.IsTrue(yd < m);
            Assert.IsTrue(yd <= m);
            Assert.IsTrue(yd != m);
            Assert.IsFalse(yd > m);
            Assert.IsFalse(yd >= m);
            Assert.IsFalse(yd == m);

            m = new Value<Meter>(0.9144m);

            Assert.IsFalse(yd < m);
            Assert.IsTrue(yd <= m);
            Assert.IsFalse(yd != m);
            Assert.IsFalse(yd > m);
            Assert.IsTrue(yd >= m);
            Assert.IsTrue(yd == m);

            yd = new Value<Yard>(2m);

            Assert.IsFalse(yd < m);
            Assert.IsFalse(yd <= m);
            Assert.IsTrue(yd != m);
            Assert.IsTrue(yd > m);
            Assert.IsTrue(yd >= m);
            Assert.IsFalse(yd == m);
        }

        [TestMethod]
        public void KmhTomps()
        {
            var kmh = new Value<FractionUnit<Kilometer, Hour>>(30m);

            var mps = new Value<FractionUnit<Meter, Second>>(30m);

            Assert.IsTrue(kmh < mps);
            Assert.IsTrue(kmh <= mps);
            Assert.IsTrue(kmh != mps);
            Assert.IsFalse(kmh > mps);
            Assert.IsFalse(kmh >= mps);
            Assert.IsFalse(kmh == mps);
        }

        [TestMethod]
        public void Inversion()
        {
            var mpkg = new Value<FractionUnit<Meter, Kilogram>>(10m);

            var kgpm = new Value<FractionUnit<Kilogram, Meter>>(0.1m);

            Assert.IsFalse(mpkg < kgpm);
            Assert.IsTrue(mpkg <= kgpm);
            Assert.IsFalse(mpkg != kgpm);
            Assert.IsFalse(mpkg > kgpm);
            Assert.IsTrue(mpkg >= kgpm);
            Assert.IsTrue(mpkg == kgpm);

            kgpm = new Value<FractionUnit<Kilogram, Meter>>(0.09m);

            Assert.IsTrue(mpkg < kgpm);
            Assert.IsTrue(mpkg <= kgpm);
            Assert.IsTrue(mpkg != kgpm);
            Assert.IsFalse(mpkg > kgpm);
            Assert.IsFalse(mpkg >= kgpm);
            Assert.IsFalse(mpkg == kgpm);

            kgpm = new Value<FractionUnit<Kilogram, Meter>>(0.11m);

            Assert.IsFalse(mpkg < kgpm);
            Assert.IsFalse(mpkg <= kgpm);
            Assert.IsTrue(mpkg != kgpm);
            Assert.IsTrue(mpkg > kgpm);
            Assert.IsTrue(mpkg >= kgpm);
            Assert.IsFalse(mpkg == kgpm);

            var kmh = new Value<FractionUnit<Kilometer, Hour>>(60m);

            var minpkm = new Value<FractionUnit<Minute, Kilometer>>(1m);

            Assert.IsTrue(kmh == minpkm);
        }

        [TestMethod]
        public void KilometersPerHour()
        {
            var kmh = new Value<FractionUnit<Kilometer, Hour>>(60m);

            var minpkm = new Value<FractionUnit<Minute, Kilometer>>(1m);

            Assert.IsTrue(kmh == minpkm);

            var kmh2 = ValueConverter.Convert<FractionUnit<Kilometer, Hour>>(minpkm);

            Assert.IsTrue(kmh == kmh2);
            Assert.IsTrue(minpkm == kmh2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GreaterOrEqualLeftNull()
        {
            Assert.IsTrue(null >= new Value(5m, "kg"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GreaterLeftNull()
        {
            Assert.IsTrue(null > new Value(5m, "kg"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LessOrEqualLeftNull()
        {
            Assert.IsTrue(null <= new Value(5m, "kg"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LessRightNull()
        {
            Assert.IsTrue(new Value(5m, "kg") <= null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GreaterOrEqualRightNull()
        {
            Assert.IsTrue(new Value(5m, "kg") >= null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GreaterRightNull()
        {
            Assert.IsTrue(new Value(5m, "kg") > null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LessOrEqualRightNull()
        {
            Assert.IsTrue(new Value(5m, "kg") <= null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LessLeftNull()
        {
            Assert.IsTrue(null <= new Value(5m, "kg"));
        }

        [TestMethod]
        public void NullEquality()
        {
            Value left = null;
            Value right = null;

            Assert.IsTrue(left == right);
        }

        [TestMethod]
        public void Adding()
        {
            var v1 = new Value<Ton>(5m);

            var v2 = new Value<Kilogram>(7m);

            var v3 = v1 + v2;

            Assert.AreEqual(5.007m, v3.Scalar);
            Assert.AreEqual(new Ton(), v3.Unit);

            var v4 = v2 + v1;

            Assert.AreEqual(5007m, v4.Scalar);
            Assert.AreEqual(new Kilogram(), v4.Unit);

            Assert.IsTrue(v3 == v4);

            var v5 = v1.Add(v2);

            Assert.IsTrue(v3 == v5);
            Assert.IsTrue(v4 == v5);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void AddingFailSimple()
        {
            var v1 = new Value<Ton>(5m);

            var v2 = new Value<Meter>(7m);

            var _ = v1 + v2;
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void AddingFailComplex()
        {
            var v1 = new Value<FractionUnit<Ton, Hour>>(5m);

            var v2 = new Value<Meter>(7m);

            var _ = v1 + v2;
        }
    }
}