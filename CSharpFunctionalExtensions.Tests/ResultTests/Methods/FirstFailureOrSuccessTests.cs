using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods
{
    public class FirstFailureOrSuccessTests
    {
        [Fact]
        public void FirstFailureOrSuccess_returns_the_first_failed_result()
        {
            Result result1 = Result.Success();
            Result result2 = Result.Failure("Failure 1");
            Result result3 = Result.Failure("Failure 2");

            Result result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Failure 1");
            result.Should().Be(result2);
        }

        [Fact]
        public void FirstFailureOrSuccess_returns_success_if_no_failures()
        {
            Result result1 = Result.Success();
            Result result2 = Result.Success();
            Result result3 = Result.Success();

            Result result = Result.FirstFailureOrSuccess(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
            result.Should().Be(Result.Success());
        }
    }
}
