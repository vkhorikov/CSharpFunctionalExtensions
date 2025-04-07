using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions;

public class BindOptionalTests
{
    [Fact]
    public void BindOptional_returns_result_value()
    {
        var present = Result.Success<Maybe<string>, string>("yay")
            .BindOptional(x => Result.Success<int, string>(1));

        present.Value.Should().Be(1);
    }

    [Fact]
    public void BindOptional_with_nothing_is_success()
    {
        var absent  = Result.Success<Maybe<string>, string>(Maybe<string>.None)
            .BindOptional(x => Result.Success<int, string>(1));
        absent.IsSuccess.Should().BeTrue();
        absent.Value.HasNoValue.Should().BeTrue();
    }

    [Fact]
    public void BindOptional_initial_failure_bind_not_run()
    {
        var initialFailure = Result.Failure<Maybe<string>, string>("nay")
            .BindOptional(x => Result.Success<int, string>(1));

        initialFailure.IsFailure.Should().BeTrue();
        initialFailure.Error.IsSameOrEqualTo("nay");
    }
    
    [Fact]
    public void BindOptional_bind_fails_is_error()
    {
        var bindFailure = Result.Success<Maybe<string>, string>("yay")
            .BindOptional(x => Result.Failure<string, string>("nay"));

        bindFailure.IsFailure.Should().BeTrue();
        bindFailure.Error.IsSameOrEqualTo("nay");
    }
}
