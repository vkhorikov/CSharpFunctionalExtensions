using Xunit;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class BindOptionalTests
{
    [Fact]
    public void BindOptional_with_value_returns_value()
    {
        Maybe<int> maybe = 42;
        var result = maybe.BindOptional(i => Result.Success(i.ToString()));
        result.IsSuccess.Should().BeTrue();
        result.Value.HasValue.Should().BeTrue();
        result.Value.Value.Should().Be("42");
    }

    [Fact]
    public void BindOptional_missing_value_returns_missing()
    {
        Maybe<int> maybe = Maybe<int>.None;
        var result = maybe.BindOptional(i => Result.Success(i.ToString()));
        result.IsSuccess.Should().BeTrue();
        result.Value.HasValue.Should().BeFalse();
    }

    [Fact]
    public void BindOptional_with_error_returns_error()
    {
        Maybe<int> maybe = 42;
        var result = maybe.BindOptional(i => Result.Failure<string>("Something went wrong"));
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be("Something went wrong");
    }

    [Fact]
    public void BindOptional_E_with_value_returns_value()
    {
        Maybe<int> maybe = 42;
        var result = maybe.BindOptional(i => Result.Success<string, string>(i.ToString()));
        result.IsSuccess.Should().BeTrue();
        result.Value.HasValue.Should().BeTrue();
        result.Value.Value.Should().Be("42");
    }

    [Fact]
    public void BindOptional_E_missing_value_returns_missing()
    {
        Maybe<int> maybe = Maybe<int>.None;
        var result = maybe.BindOptional(i => Result.Success<string, string>(i.ToString()));
        result.IsSuccess.Should().BeTrue();
        result.Value.HasValue.Should().BeFalse();
    }

    [Fact]
    public void BindOptional_E_with_error_returns_error()
    {
        Maybe<int> maybe = 42;
        var result = maybe.BindOptional(i => Result.Failure<string, string>("Something went wrong"));
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be("Something went wrong");
    }
}
