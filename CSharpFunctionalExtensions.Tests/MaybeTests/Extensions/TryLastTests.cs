using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class TryLastTests
{
    [Fact]
    public void TryLast_source_has_elements()
    {
        var source = new[]
        {
            new { Index = 1, Value = 1 },
            new { Index = 2, Value = 2 },
            new { Index = 3, Value = 3 }
        };

        var maybe = source.TryLast();

        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(source[2]);
    }

    [Fact]
    public void TryLast_source_has_no_elements()
    {
        var source = Array.Empty<int>();

        var maybe = source.TryLast();

        maybe.HasValue.Should().Be(false);
    }

    [Fact]
    public void TryLast_source_predicate_contains()
    {
        var source = new[]
        {
            new { Index = 1, Value = 2 },
            new { Index = 2, Value = 2 },
            new { Index = 3, Value = 3 }
        };

        var maybe = source.TryLast(x => x.Value == 2);

        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(source[1]);
    }

    [Fact]
    public void TryLast_source_predicate_not_contains()
    {
        var source = new[]
        {
            new { Index = 1, Value = 1 },
            new { Index = 2, Value = 2 },
            new { Index = 3, Value = 3 }
        };

        var maybe = source.TryLast(x => x.Value == 5);

        maybe.HasValue.Should().BeFalse();
    }
}