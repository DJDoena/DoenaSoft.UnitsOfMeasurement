using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using System;
    using FractionUnits.Pressures;
    using SimpleUnits.Areas;
    using SimpleUnits.Forces;
    using SimpleUnits.Weights;
    using Values;

    [TestClass]
    public class PressureTests
    {
        [TestMethod]
        public void PSI_Math()
        {
            var lb = new Value<Pound>(1m);

            var kg = ValueConverter.Convert<Kilogram>(lb);

            var poundsForce = kg.Scalar * Force.StandardGravity;

            var conversionFactor = Math.Round(poundsForce * (1m / (SquareInch.FactorToSquareMeter)), 10);

            Assert.AreEqual(6894.7572931684m, conversionFactor);

            var psi = new Value<PSI>(1m);

            var pa = ValueConverter.Convert<Pascal>(psi).Round(10);

            Assert.AreEqual(6894.7572931684m, pa.Scalar);

            var bar = ValueConverter.Convert<Bar>(psi).Round(10);

            Assert.AreEqual(0.0689475729m, bar.Scalar);

            pa = new Value<Pascal>(1m);

            psi = ValueConverter.Convert<PSI>(pa).Round(10);

            Assert.AreEqual(0.0001450377m, psi.Scalar);
        }

        [TestMethod]
        public void PSItoPascal()
        {
            var psi = new Value<PSI>(1m);

            var pa = ValueConverter.Convert<Pascal>(psi).Round(10);

            Assert.AreEqual(6894.7572931684m, pa.Scalar);

            pa = new Value<Pascal>(1m);

            psi = ValueConverter.Convert<PSI>(pa).Round(10);

            Assert.AreEqual(0.0001450377m, psi.Scalar);
        }

        [TestMethod]
        public void PSItoPascalToPSI()
        {
            var psi = new Value<PSI>(1m);

            var pa = ValueConverter.Convert<Pascal>(psi);

            psi = ValueConverter.Convert<PSI>(pa);

            Assert.AreEqual(1m, psi.Scalar);
        }

        [TestMethod]
        public void PSItoBar()
        {
            var psi = new Value<PSI>(1m);

            var bar = ValueConverter.Convert<Bar>(psi).Round(10);

            Assert.AreEqual(0.0689475729m, bar.Scalar);
        }

        [TestMethod]
        public void BarToPasal()
        {
            var bar = new Value<Bar>(1m);

            var pa = ValueConverter.Convert<Pascal>(bar);

            Assert.AreEqual(100_000m, pa.Scalar);
        }

        [TestMethod]
        public void Units()
        {
            var psi1 = UnitConverter.ToUnitOfMeasurement("psi");

            Assert.AreEqual(new PSI(), psi1);

            var psi2 = UnitConverter.ToPressureUnit("psi");

            Assert.AreEqual(psi1, psi2);
            Assert.AreEqual(new PSI(), psi2);
        }

        [TestMethod]
        public void PSIversusSelfBuilt()
        {
            var psi = new Value<PSI>(5m);

            var selfBuilt = new Value(5m, "lbf/in²");

            Assert.AreEqual(psi, selfBuilt);
        }
    }
}