namespace CSharpFunctionalExtensions.Tests.ValueObjectTests
{
    public sealed class TestEnumValueObject : EnumValueObject<TestEnumValueObject>
    {
        public static readonly TestEnumValueObject One = new TestEnumValueObject(nameof(One));

        public static readonly TestEnumValueObject Two = new TestEnumValueObject(nameof(Two));

        public TestEnumValueObject(string key) : base(key)
        {
        }
    }
}