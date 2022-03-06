using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using SimpleUnits;

    [TestClass]
    public class ImperialUnits
    {
        [TestMethod]
        public void SquareInch()
        {
            var in2 = new Value<SquareInch>(1);

            var m2 = ValueConverter.Convert<SquareMeter>(in2).Round(9);

            Assert.AreEqual(0.00064516, m2.Scalar);

            m2 = new Value<SquareMeter>(1);

            in2 = ValueConverter.Convert<SquareInch>(m2).Round(9);

            Assert.AreEqual(1550.003100006, in2.Scalar);
        }

        [TestMethod]
        public void SquareFoot()
        {
            var ft2 = new Value<SquareFoot>(1);

            var m2 = ValueConverter.Convert<SquareMeter>(ft2).Round(9);

            Assert.AreEqual(0.09290304, m2.Scalar);

            m2 = new Value<SquareMeter>(1);

            ft2 = ValueConverter.Convert<SquareFoot>(m2).Round(9);

            Assert.AreEqual(10.763910417, ft2.Scalar);

            ft2 = new Value<SquareFoot>(1);

            var in2 = ValueConverter.Convert<SquareInch>(ft2).Round(9);

            Assert.AreEqual(12 * 12, in2.Scalar);
        }

        [TestMethod]
        public void Acre()
        {
            var ac = new Value<Acre>(1);

            var m2 = ValueConverter.Convert<SquareMeter>(ac).Round(9);

            Assert.AreEqual(4046.8564224, m2.Scalar);

            m2 = new Value<SquareMeter>(1);

            ac = ValueConverter.Convert<Acre>(m2).Round(9);

            Assert.AreEqual(0.000247105, ac.Scalar);
        }

        [TestMethod]
        public void Mile()
        {
            var mi = new Value<Mile>(1);

            var m = ValueConverter.Convert<Meter>(mi).Round(9);

            Assert.AreEqual(1609.344, m.Scalar);

            m = new Value<Meter>(1);

            mi = ValueConverter.Convert<Mile>(m).Round(9);

            Assert.AreEqual(0.000621371, mi.Scalar);
        }

        [TestMethod]
        public void Yard()
        {
            var yd = new Value<Yard>(1);

            var m = ValueConverter.Convert<Meter>(yd).Round(9);

            Assert.AreEqual(0.9144, m.Scalar);

            m = new Value<Meter>(1);

            yd = ValueConverter.Convert<Yard>(m).Round(9);

            Assert.AreEqual(1.093613298, yd.Scalar);

            yd = new Value<Yard>(1);

            var ft = ValueConverter.Convert<Foot>(yd).Round(9);

            Assert.AreEqual(3, ft.Scalar);
        }

        [TestMethod]
        public void Foot()
        {
            var ft = new Value<Foot>(1);

            var m = ValueConverter.Convert<Meter>(ft).Round(9);

            Assert.AreEqual(0.3048, m.Scalar);

            m = new Value<Meter>(1);

            ft = ValueConverter.Convert<Foot>(m).Round(9);

            Assert.AreEqual(3.280839895, ft.Scalar);

            ft = new Value<Foot>(1);

            var inc = ValueConverter.Convert<Inch>(ft).Round(9);

            Assert.AreEqual(12, inc.Scalar);
        }

        [TestMethod]
        public void Inch()
        {
            var inc = new Value<Inch>(1);

            var m = ValueConverter.Convert<Meter>(inc).Round(9);

            Assert.AreEqual(0.0254, m.Scalar);

            m = new Value<Meter>(1);

            inc = ValueConverter.Convert<Inch>(m).Round(9);

            Assert.AreEqual(39.37007874, inc.Scalar);
        }

        [TestMethod]
        public void USGallon()
        {
            var gal = new Value(1, "us.liq.gal.");

            var l = ValueConverter.Convert<Liter>(gal).Round(9);

            Assert.AreEqual(3.785411784, l.Scalar);

            l = new Value<Liter>(1);

            gal = ValueConverter.Convert<USLiquidGallon>(l).Round(9);

            Assert.AreEqual(0.264172052, gal.Scalar);
        }

        [TestMethod]
        public void UKGallon()
        {
            var gal = new Value(1, "imp.gal.");

            var l = ValueConverter.Convert<Liter>(gal).Round(9);

            Assert.AreEqual(4.54609, l.Scalar);

            l = new Value<Liter>(1);

            gal = ValueConverter.Convert<ImperialGallon>(l).Round(9);

            Assert.AreEqual(0.219969248, gal.Scalar);
        }

        [TestMethod]
        public void CubicInch()
        {
            var in3 = new Value<CubicInch>(1);

            var l = ValueConverter.Convert<Liter>(in3).Round(9);

            Assert.AreEqual(0.016387064, l.Scalar);

            l = new Value<Liter>(1);

            in3 = ValueConverter.Convert<CubicInch>(l).Round(9);

            Assert.AreEqual(61.023744095, in3.Scalar);
        }

        [TestMethod]
        public void CubicFoot()
        {
            var ft3 = new Value<CubicFoot>(1);

            var l = ValueConverter.Convert<Liter>(ft3).Round(9);

            Assert.AreEqual(28.316846592, l.Scalar);

            l = new Value<Liter>(1);

            ft3 = ValueConverter.Convert<CubicFoot>(l).Round(9);

            Assert.AreEqual(0.035314667, ft3.Scalar);

            ft3 = new Value<CubicFoot>(1);

            var in3 = ValueConverter.Convert<CubicInch>(ft3).Round(9);

            Assert.AreEqual(12 * 12 * 12, in3.Scalar);
        }

        [TestMethod]
        public void Pound()
        {
            var lb = new Value<Pound>(1);

            var kg = ValueConverter.Convert<Kilogram>(lb).Round(9);

            Assert.AreEqual(0.45359237, kg.Scalar);

            kg = new Value<Kilogram>(1);

            lb = ValueConverter.Convert<Pound>(kg).Round(9);

            Assert.AreEqual(2.204622622, lb.Scalar);
        }

        [TestMethod]
        public void ShortTon()
        {
            var stn = new Value<ShortTon>(1);

            var kg = ValueConverter.Convert<Kilogram>(stn).Round(9);

            Assert.AreEqual(907.18474, kg.Scalar);

            kg = new Value<Kilogram>(1);

            stn = ValueConverter.Convert<ShortTon>(kg).Round(9);

            Assert.AreEqual(0.001102311, stn.Scalar);

            stn = new Value<ShortTon>(1);

            var lb = ValueConverter.Convert<Pound>(stn).Round(9);

            Assert.AreEqual(2000, lb.Scalar);
        }
    }
}