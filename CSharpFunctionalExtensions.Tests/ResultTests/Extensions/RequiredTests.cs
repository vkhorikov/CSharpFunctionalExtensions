using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions;

public class RequiredTests
{
    [Fact]
    public void Required_returns_error_if_missing()
    {
        var input = Result.Success(Maybe<string>.None);
        var error = "Value is required";

        var result = input.Required(error);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }
    
    [Fact]
    public void Required_returns_success_if_present()
    {
        var expectedValue = "hello";
        var input = Result.Success(Maybe.From(expectedValue));
        var error = "Value is required";

        var result = input.Required(error);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(expectedValue);
    }
    
    [Fact]
    public void Required_E_returns_error_if_missing()
    {
        var input = Result.Success<Maybe<string>, int>(Maybe<string>.None);
        var error = 1;

        var result = input.Required(error);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(error);
    }
    
    [Fact]
    public void Required_E_returns_success_if_present()
    {
        var expectedValue = "hello";
        var input = Result.Success<Maybe<string>, int>(Maybe.From(expectedValue));
        var error = 1;

        var result = input.Required(error);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(expectedValue);
    }
}
