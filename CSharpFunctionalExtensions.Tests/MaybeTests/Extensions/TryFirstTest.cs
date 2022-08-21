using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class TryFirstTest
{
    [Fact]
    public void TryFirst_source_has_elements()
    {
        var source = new[]
        {
            new { Index = 1, Value = 1 },
            new { Index = 2, Value = 2 },
            new { Index = 3, Value = 3 }
        };

        var maybe = source.TryFirst();

        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(source[0]);
    }

    [Fact]
    public void TryFirst_source_has_no_elements()
    {
        var source = Array.Empty<int>();

        var maybe = source.TryFirst();

        maybe.HasValue.Should().BeFalse();
    }

    [Fact]
    public void TryFirst_source_predicate_contains()
    {
        var source = new[]
        {
            new { Index = 1, Value = 1 },
            new { Index = 2, Value = 2 },
            new { Index = 3, Value = 2 }
        };

        var maybe = source.TryFirst(x => x.Value == 2);

        maybe.HasValue.Should().BeTrue();
        maybe.Value.Should().Be(source[1]);
    }

    [Fact]
    public void TryFirst_source_predicate_not_contains()
    {
        var source = new[]
        {
            new { Index = 1, Value = 1 },
            new { Index = 2, Value = 2 },
            new { Index = 3, Value = 3 }
        };

        var maybe = source.TryFirst(x => x.Value == 5);

        maybe.HasValue.Should().BeFalse();
    }

    [Fact]
    public void TryFirst_source_predicate_not_contains_default_is_not_null()
    {
        var source = new[] { 1, 2, 3 };

        var maybe = source.TryFirst(x => x == 5);

        maybe.HasValue.Should().BeFalse();
    }
}