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
            display.Should().Be(testEnum.Id);
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
            var alsoEnum1 = TestEnumValueObject.FromId("One").Value;

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
            var maybe = TestEnumValueObject.FromId("InvalidKey");

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
        public void GivenPossibleKey_WhenCheckingIfKeyIsEnumValueObject_ThenShouldReturnTrueIfKeyRecognized(string possibleId, bool isIn)
        {
            // Act
            var isEnumValueObject = TestEnumValueObject.Is(possibleId);

            // Assert
            isEnumValueObject.Should().Be(isIn);
        }
        
        [Fact]
        public void GivenId_WhenCreating_ThenCorrectOneReturned()
        {
            var maybeEnum = AnotherTestEnumValueObject.FromId(1);

            maybeEnum.HasValue.Should().BeTrue();
            maybeEnum.Value.Should().Be(AnotherTestEnumValueObject.One);
        }

        [Fact]
        public void GivenName_WhenCreating_ThenCorrectOneReturned()
        {
            var maybeEnum = AnotherTestEnumValueObject.FromName(AnotherTestEnumValueObject.One.Name);

            maybeEnum.HasValue.Should().BeTrue();
            maybeEnum.Value.Should().Be(AnotherTestEnumValueObject.One);
        }
    }
}