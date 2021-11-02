using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class AsNullableTests
{
    [Fact]
    public void Struct_nullable_conversion_equality_none()
    {
        Maybe<double> none = default;
        double? noneNullable = none.AsNullable();
        noneNullable.HasValue.Should().Be(none.HasValue);
    }

    [Fact]
    public void Struct_nullable_conversion_equality_some()
    {
        Maybe<double> some = 123;
        double? someNullable = some.AsNullable();
        someNullable.HasValue.Should().Be(some.HasValue);
        someNullable.Should().Be(some.Value);
    }
}