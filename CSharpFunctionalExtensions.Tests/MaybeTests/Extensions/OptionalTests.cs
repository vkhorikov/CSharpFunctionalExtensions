using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions;

public class OptionalTests
{
    [Fact]
    public void Optional_AbsentResult_ShouldBeSuccessWithNoValue()
    {
        var absent = Maybe<Result<string, string>>.None.Optional();

        absent.IsSuccess.Should().BeTrue();
        absent.Value.HasNoValue.Should().BeTrue();
    }

    [Fact]
    public void Optional_PresentFailedResult_ShouldBeFailureWithError()
    {
        var presentFailed = Maybe.From(Result.Failure<string, string>("oops")).Optional();

        presentFailed.IsFailure.Should().BeTrue();
        presentFailed.Error.Should().Be("oops");
    }

    [Fact]
    public void Optional_PresentSuccessResult_ShouldBeSuccessWithValue()
    {
        var presentSuccess = Maybe.From(Result.Success<string, string>("yay")).Optional();

        presentSuccess.IsSuccess.Should().BeTrue();
        presentSuccess.Value.Value.Should().Be("yay");
    }
}
