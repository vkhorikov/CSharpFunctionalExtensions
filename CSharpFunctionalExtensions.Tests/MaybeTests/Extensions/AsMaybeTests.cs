using CSharpFunctionalExtensions.Tests.ResultTests;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class AsMaybeTests : TestBase
{
    [Fact]
    public void AsMaybe_Struct_maybe_conversion_equality_none()
    {
        double? none = default;
        Maybe<double> maybeNone = none.AsMaybe();
        maybeNone.HasValue.Should().Be(none.HasValue);
    }

    [Fact]
    public void AsMaybe_Struct_maybe_conversion_equality_some()
    {
        double? some = 123;
        Maybe<double> someMaybe = some.AsMaybe();
        someMaybe.HasValue.Should().Be(some.HasValue);
        someMaybe.Value.Should().Be(some);
    }

    [Fact]
    public void AsMaybe_Class_maybe_conversion_none()
    {
        Maybe<T> maybeT = null;
        maybeT.HasValue.Should().BeFalse();
    }

    [Fact]
    public void AsMaybe_Class_maybe_conversion_some()
    {
        Maybe<T> maybeT = T.Value.AsMaybe();
        maybeT.HasValue.Should().BeTrue();
        maybeT.Value.Should().Be(T.Value);
    }
}
