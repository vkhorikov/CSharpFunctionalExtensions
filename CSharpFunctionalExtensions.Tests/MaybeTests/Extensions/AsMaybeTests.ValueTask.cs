using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class AsMaybeTests_ValueTask : TestBase
{
    [Fact]
    public async Task AsMaybe_ValueTask_Struct_maybe_conversion_equality_none()
    {
        double? none = default;
        var maybeNone = await none.AsValueTask().AsMaybe();
        maybeNone.HasValue.Should().Be(none.HasValue);
    }

    [Fact]
    public async Task AsMaybe_ValueTask_Struct_maybe_conversion_equality_some()
    {
        double? some = 123;
        var someMaybe = await some.AsValueTask().AsMaybe();
        someMaybe.HasValue.Should().Be(some.HasValue);
        someMaybe.Value.Should().Be(some);
    }

    [Fact]
    public async Task AsMaybe_ValueTask_Class_maybe_conversion_none()
    {
        var maybeT = await Maybe<T>.None.AsValueTask();
        maybeT.HasValue.Should().BeFalse();
    }

    [Fact]
    public async Task AsMaybe_ValueTask_Class_maybe_conversion_some()
    {
        var maybeT = await T.Value.AsValueTask().AsMaybe();
        maybeT.HasValue.Should().BeTrue();
        maybeT.Value.Should().Be(T.Value);
    }
}
