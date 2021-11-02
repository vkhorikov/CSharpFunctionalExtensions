using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class ChooseTests
{
    [Fact]
    public void Choose_double_values()
    {
        var source = new[]
        {
            Maybe<int>.None,
            1,
            Maybe<int>.None,
            2,
            3
        };

        var doubled = source.Choose(x => x * 2);

        var expected = new[] { 2, 4, 6 };
        doubled.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Choose_values()
    {
        var source = new[]
        {
            Maybe<int>.None,
            1,
            Maybe<int>.None,
            2,
            3
        };

        var values = source.Choose();

        var expected = new[] { 1, 2, 3 };
        values.Should().BeEquivalentTo(expected);
    }
}