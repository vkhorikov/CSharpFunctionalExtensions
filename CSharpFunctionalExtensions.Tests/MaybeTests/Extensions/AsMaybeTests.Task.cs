using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class AsMaybeTests_Task : TestBase
{
    [Fact]
    public async Task AsMaybe_Task_Struct_maybe_conversion_equality_none()
    {
        double? none = default;
        var maybeNone = await none.AsTask().AsMaybe();
        maybeNone.HasValue.Should().Be(none.HasValue);
    }

    [Fact]
    public async Task AsMaybe_Task_Struct_maybe_conversion_equality_some()
    {
        double? some = 123;
        var someMaybe = await some.AsTask().AsMaybe();
        someMaybe.HasValue.Should().Be(some.HasValue);
        someMaybe.Value.Should().Be(some);
    }

    [Fact]
    public async Task AsMaybe_Task_Class_maybe_conversion_none()
    {
        var maybeT = await Maybe<T>.None.AsTask();
        maybeT.HasValue.Should().BeFalse();
    }

    [Fact]
    public async Task AsMaybe_Task_Class_maybe_conversion_some()
    {
        var maybeT = await T.Value.AsMaybe().AsTask();
        maybeT.HasValue.Should().BeTrue();
        maybeT.Value.Should().Be(T.Value);
    }
}
