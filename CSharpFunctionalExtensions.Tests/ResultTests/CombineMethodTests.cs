using FluentAssertions;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class CombineMethodTests
    {
        [Fact]
        public void FirstFailureOrSuccess_returns_the_first_failed_result()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Fail("Failure 1");
            Result result3 = Result.Fail("Failure 2");

            Result result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Failure 1");
        }

        [Fact]
        public void FirstFailureOrSuccess_returns_Ok_if_no_failures()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Ok();
            Result result3 = Result.Ok();

            Result result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Combine_combines_all_errors_together()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Fail("Failure 1", "Private failure 1");
            Result result3 = Result.Fail("Failure 2", "Private failure 2");

            Result result = Result.Combine(";", result1, result2, result3);

            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Failure 1;Failure 2");
            result.PrivateError.Should().Be("Private failure 1;Private failure 2");
        }

        [Fact]
        public void Combine_returns_Ok_if_no_failures()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Ok();
            Result<string> result3 = Result.Ok("Some string");

            Result result = Result.Combine(";", result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }
    }
}
