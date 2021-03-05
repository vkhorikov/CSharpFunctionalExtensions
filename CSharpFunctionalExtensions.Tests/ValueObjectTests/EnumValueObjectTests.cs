using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ValueObjectTests
{
    public class EnumValueObjectTests
    {
        [Fact]
        public void GivenEnumValueObject_WhenCallingToString_ThenKeyIsReturned()
        {
            // Arrange
            var testEnum = TestEnumValueObject.One;

            // Act
            var display = testEnum.ToString();

            // Assert
            display.Should().Be(testEnum.Key);
        }
        
        [Fact]
        public void GivenEnumValueObject_WhenCallingAll_ThenAllPartsAreReturned()
        {
            // Act
            var all = TestEnumValueObject.All;

            // Assert
            all.Should().Contain(TestEnumValueObject.One);
            all.Should().Contain(TestEnumValueObject.Two);
        }

        [Fact]
        public void GivenEnumValueObject_WhenComparingEqualOnes_ThenEqual()
        {
            // Arrange
            var enum1 = TestEnumValueObject.One;
            var alsoEnum1 = TestEnumValueObject.Create("One").Value;

            // Act
            var isEqual = enum1 == alsoEnum1;

            isEqual.Should().BeTrue();
        }

        [Fact]
        public void GivenEnumValueObject_WhenComparingWithStringKey_ThenEqual()
        {
            // Arrange
            var enum1 = TestEnumValueObject.One;
            const string enum1Key = "One";

            // Act
            var isEqual = enum1 == enum1Key;

            // Assert
            isEqual.Should().BeTrue();
        }

        [Fact]
        public void GivenInvalidKey_WhenCreatingEnumValueObject_ThenNoReturn()
        {
            // Act
            var maybe = TestEnumValueObject.Create("InvalidKey");

            // Assert
            maybe.Should().Be(Maybe<TestEnumValueObject>.None);
        }
        
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void GivenNullOrEmptyKey_WhenCreating_ThenException(string key)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => new TestEnumValueObject(key));
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("Four", false)]
        [InlineData(nameof(TestEnumValueObject.Two), true)]
        [InlineData(nameof(TestEnumValueObject.One), true)]
        public void GivenPossibleKey_WhenCheckingIfKeyIsEnumValueObject_ThenShouldReturnTrueIfKeyRecognized(string possibleKey, bool isIn)
        {
            // Act
            var isEnumValueObject = TestEnumValueObject.Is(possibleKey);

            // Assert
            isEnumValueObject.Should().Be(isIn);
        }
    }
    
    public sealed class TestEnumValueObject : EnumValueObject<TestEnumValueObject>
    {
        public static readonly TestEnumValueObject One = new TestEnumValueObject(nameof(One));

        public static readonly TestEnumValueObject Two = new TestEnumValueObject(nameof(Two));

        public TestEnumValueObject(string key) : base(key)
        {
        }
    }
}