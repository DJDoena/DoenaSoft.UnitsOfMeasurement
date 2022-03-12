namespace DoenaSoft.UnitsOfMeasurement.Tests
{
    using SimpleUnits.Weights;

    internal class TestUnit : UnitOfMeasurement
    {
        public override string UnitCategory => "Test";

        public override IUnitOfMeasurement BaseUnit => this;

        public override string GetDisplayValue() => "Test";

        public override string ToSerializable() => "Test";

        public override int GetHashCode() => 42;
    }

    internal class TestWeightUnit : Weight
    {
        public override decimal FactorToBaseUnit => 42;

        public override string GetDisplayValue() => "TestWeight";

        public override string ToSerializable() => "TestWeight";
    }

    internal class TestFakeWeightUnit : IUnitOfMeasurement
    {
        public string UnitCategory => nameof(Weight);

        public IUnitOfMeasurement BaseUnit => new Ton();

        public bool Equals(IUnitOfMeasurement other) => true;

        public string GetDisplayValue() => "kg";

        public string ToSerializable() => "kg";
    }
}