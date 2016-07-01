using FluentAssertions;
using Xunit;


namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class CombineMethodTests
    {
        [Fact]
        public void Returns_the_first_failed_result()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Fail("Failure 1");
            Result result3 = Result.Fail("Failure 2");

            Result result = Result.Combine(result1, result2, result3);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Failure 1");
        }

        [Fact]
        public void Returns_Ok_if_no_failures()
        {
            Result result1 = Result.Ok();
            Result result2 = Result.Ok();
            Result result3 = Result.Ok();

            Result result = Result.Combine(result1, result2, result3);

            result.IsSuccess.Should().BeTrue();
        }
    }
}
