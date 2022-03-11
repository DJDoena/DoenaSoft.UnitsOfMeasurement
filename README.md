This package allows the conversion of common SI and American units within the same category (area, energy, length, temperature, time, volume, weight)

All units can be accessed by type name (e.g. Meter) or serializable / SI value (e.g. "m");

Sample conversion from Kilogram to pound:

```c#
            var lb = new Value<Pound>(1);

            var kg = ValueConverter.Convert<Kilogram>(lb).Round(9);

            Assert.AreEqual(0.45359237, kg.Scalar);

            kg = new Value<Kilogram>(1);

            lb = ValueConverter.Convert<Pound>(kg).Round(9);

            Assert.AreEqual(2.204622622, lb.Scalar);
```

It also allows the registration of custom units (i.e not pre-defined in this assembly) with a conversion factor to the category's base unit.

```c#
            var custom = new CustomWeight(0.0311034768, "oz.tr."); // ounce

            UnitConverter.RegisterCustomUnit(custom);

            var result = UnitConverter.ToUnitOfMeasurement("oz.tr.");
```

It also alows the creation of fractional units such as meters per second

```c#
            var mps = UnitConverter.ToUnitOfMeasurement("m/s");
```

You can also add values from the same unit category to each other without converting the units first:

```c#
            var source = new Value<FractionUnit<Meter, Second>>(30);

            var target = source.Add(new Value<FractionUnit<Mile, Hour>>(15));
```

You can also convert between volume and weight units with a given density.

```c#
            const double DensityOfHelium = 0.1785; // kg/l

            var source = new Value(5, UnitConverter.ToUnitOfMeasurement("dm³"));
            var target = ValueConverter.Convert(source, new Kilogram(), new DensityValue<Density<Kilogram, Liter>>(DensityOfHelium));
```

You can even convert values with fractional units where the unit categories are inverted, such as liter per 100 km (volume/length) to gasmileage (length/volume)

```c#
            var source = new Value<FractionUnit<Liter, Kilometer>>(5.9 / 100);

            var target = ValueConverter.Convert(source, new FractionUnit<Mile, USLiquidGallon>()).Round(5); // 39.86688 miles per gallon
```

More examples can be found in the [unit tests for the project] (https://github.com/DJDoena/DoenaSoft.UnitsOfMeasurement/tree/main/UnitsOfMeasurement.Tests)