namespace CSharpFunctionalExtensions.Tests.ValueObjectTests
{
    public sealed class AnotherTestEnumValueObject : EnumValueObject<AnotherTestEnumValueObject, long>
    {
        public static readonly AnotherTestEnumValueObject One = new AnotherTestEnumValueObject(1, "name");

        public static readonly AnotherTestEnumValueObject Two = new AnotherTestEnumValueObject(2, "test");
        
        private AnotherTestEnumValueObject(long id, string name) : base(id, name)
        {
        }
    }
}