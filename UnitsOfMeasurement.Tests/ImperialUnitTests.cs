using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using SimpleUnits.Areas;
    using SimpleUnits.Lengths;
    using SimpleUnits.Volumes;
    using SimpleUnits.Weights;
    using Values;

    [TestClass]
    public class ImperialUnitTests
    {
        [TestMethod]
        public void SquareInch()
        {
            var in2 = new Value<SquareInch>(1m);

            var m2 = ValueConverter.Convert<SquareMeter>(in2).Round(9);

            Assert.AreEqual(0.00064516m, m2.Scalar);

            m2 = new Value<SquareMeter>(1m);

            in2 = ValueConverter.Convert<SquareInch>(m2).Round(9);

            Assert.AreEqual(1550.003100006m, in2.Scalar);
        }

        [TestMethod]
        public void SquareFoot()
        {
            var ft2 = new Value<SquareFoot>(1m);

            var m2 = ValueConverter.Convert<SquareMeter>(ft2).Round(9);

            Assert.AreEqual(0.09290304m, m2.Scalar);

            m2 = new Value<SquareMeter>(1m);

            ft2 = ValueConverter.Convert<SquareFoot>(m2).Round(9);

            Assert.AreEqual(10.763910417m, ft2.Scalar);

            ft2 = new Value<SquareFoot>(1m);

            var in2 = ValueConverter.Convert<SquareInch>(ft2).Round(9);

            Assert.AreEqual(12m * 12m, in2.Scalar);
        }

        [TestMethod]
        public void Acre()
        {
            var ac = new Value<Acre>(1m);

            var m2 = ValueConverter.Convert<SquareMeter>(ac).Round(9);

            Assert.AreEqual(4046.8564224m, m2.Scalar);

            m2 = new Value<SquareMeter>(1m);

            ac = ValueConverter.Convert<Acre>(m2).Round(9);

            Assert.AreEqual(0.000247105m, ac.Scalar);
        }

        [TestMethod]
        public void Mile()
        {
            var mi = new Value<Mile>(1m);

            var m = ValueConverter.Convert<Meter>(mi).Round(9);

            Assert.AreEqual(1609.344m, m.Scalar);

            m = new Value<Meter>(1m);

            mi = ValueConverter.Convert<Mile>(m).Round(9);

            Assert.AreEqual(0.000621371m, mi.Scalar);
        }

        [TestMethod]
        public void Yard()
        {
            var yd = new Value<Yard>(1m);

            var m = ValueConverter.Convert<Meter>(yd).Round(9);

            Assert.AreEqual(0.9144m, m.Scalar);

            m = new Value<Meter>(1m);

            yd = ValueConverter.Convert<Yard>(m).Round(9);

            Assert.AreEqual(1.093613298m, yd.Scalar);

            yd = new Value<Yard>(1m);

            var ft = ValueConverter.Convert<Foot>(yd).Round(9);

            Assert.AreEqual(3m, ft.Scalar);
        }

        [TestMethod]
        public void Foot()
        {
            var ft = new Value<Foot>(1m);

            var m = ValueConverter.Convert<Meter>(ft).Round(9);

            Assert.AreEqual(0.3048m, m.Scalar);

            m = new Value<Meter>(1m);

            ft = ValueConverter.Convert<Foot>(m).Round(9);

            Assert.AreEqual(3.280839895m, ft.Scalar);

            ft = new Value<Foot>(1m);

            var inc = ValueConverter.Convert<Inch>(ft).Round(9);

            Assert.AreEqual(12m, inc.Scalar);
        }

        [TestMethod]
        public void Inch()
        {
            var inc = new Value<Inch>(1m);

            var m = ValueConverter.Convert<Meter>(inc).Round(9);

            Assert.AreEqual(0.0254m, m.Scalar);

            m = new Value<Meter>(1m);

            inc = ValueConverter.Convert<Inch>(m).Round(9);

            Assert.AreEqual(39.37007874m, inc.Scalar);
        }

        [TestMethod]
        public void USGallon()
        {
            var gal = new Value(1m, "us.liq.gal.");

            var l = ValueConverter.Convert<Liter>(gal).Round(9);

            Assert.AreEqual(3.785411784m, l.Scalar);

            l = new Value<Liter>(1m);

            gal = ValueConverter.Convert<USLiquidGallon>(l).Round(9);

            Assert.AreEqual(0.264172052m, gal.Scalar);
        }

        [TestMethod]
        public void UKGallon()
        {
            var gal = new Value(1m, "imp.gal.");

            var l = ValueConverter.Convert<Liter>(gal).Round(9);

            Assert.AreEqual(4.54609m, l.Scalar);

            l = new Value<Liter>(1m);

            gal = ValueConverter.Convert<ImperialGallon>(l).Round(9);

            Assert.AreEqual(0.219969248m, gal.Scalar);
        }

        [TestMethod]
        public void CubicInch()
        {
            var in3 = new Value<CubicInch>(1m);

            var l = ValueConverter.Convert<Liter>(in3).Round(9);

            Assert.AreEqual(0.016387064m, l.Scalar);

            l = new Value<Liter>(1m);

            in3 = ValueConverter.Convert<CubicInch>(l).Round(9);

            Assert.AreEqual(61.023744095m, in3.Scalar);
        }

        [TestMethod]
        public void CubicFoot()
        {
            var ft3 = new Value<CubicFoot>(1m);

            var l = ValueConverter.Convert<Liter>(ft3).Round(9);

            Assert.AreEqual(28.316846592m, l.Scalar);

            l = new Value<Liter>(1m);

            ft3 = ValueConverter.Convert<CubicFoot>(l).Round(9);

            Assert.AreEqual(0.035314667m, ft3.Scalar);

            ft3 = new Value<CubicFoot>(1m);

            var in3 = ValueConverter.Convert<CubicInch>(ft3).Round(9);

            Assert.AreEqual(12m * 12m * 12m, in3.Scalar);
        }

        [TestMethod]
        public void Pound()
        {
            var lb = new Value<Pound>(1m);

            var kg = ValueConverter.Convert<Kilogram>(lb).Round(9);

            Assert.AreEqual(0.45359237m, kg.Scalar);

            kg = new Value<Kilogram>(1m);

            lb = ValueConverter.Convert<Pound>(kg).Round(9);

            Assert.AreEqual(2.204622622m, lb.Scalar);
        }

        [TestMethod]
        public void ShortTon()
        {
            var stn = new Value<ShortTon>(1m);

            var kg = ValueConverter.Convert<Kilogram>(stn).Round(9);

            Assert.AreEqual(907.18474m, kg.Scalar);

            kg = new Value<Kilogram>(1m);

            stn = ValueConverter.Convert<ShortTon>(kg).Round(9);

            Assert.AreEqual(0.001102311m, stn.Scalar);

            stn = new Value<ShortTon>(1m);

            var lb = ValueConverter.Convert<Pound>(stn).Round(9);

            Assert.AreEqual(2000m, lb.Scalar);
        }
    }
}