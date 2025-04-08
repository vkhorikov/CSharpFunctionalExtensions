using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class EnsureNotTests
    {
        [Fact]
        public void EnsureNot_passes_when_test_fails()
        {
            var result = Result.Success(5);
            var newResult = result.EnsureNot(x => x > 10, "Value should be less than or equal to 10");

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(5);
        }

        [Fact]
        public void EnsureNot_Fails_with_error_when_test_passes()
        {
            var result = Result.Success(15);
            var newResult = result.EnsureNot(x => x > 10, "Value should be less than or equal to 10");

            newResult.IsFailure.Should().BeTrue();
            newResult.Error.Should().Be("Value should be less than or equal to 10");
        }

        [Fact]
        public void EnsureNot_E_passes_when_test_fails()
        {
            var result = Result.Success<int, string>(5);
            var newResult = result.EnsureNot(x => x > 10, "Value should be less than or equal to 10");

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(5);
        }

        [Fact]
        public void EnsureNot_E_Fails_with_error_when_test_passes()
        {
            var result = Result.Success<int, string>(15);
            var newResult = result.EnsureNot(x => x > 10, "Value should be less than or equal to 10");

            newResult.IsFailure.Should().BeTrue();
            newResult.Error.Should().Be("Value should be less than or equal to 10");
        }
    }
}
