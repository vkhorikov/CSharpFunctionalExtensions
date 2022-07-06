using System;

using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Methods
{
    public class TryGetTests
    {
        public const string ErrorMessage = "Error from result";

        [Fact]
        public void Simple_result_tryGetError_is_false_Success_value_expected()
        {
            Result result = Result.Success(ErrorMessage);
            result.TryGetError(out string error).Should().BeFalse();
            error.Should().BeNull();
        }

        [Fact]
        public void Simple_result_tryGetError_is_true_Failure_value_expected()
        {
            Result result = Result.Failure(ErrorMessage);
            result.TryGetError(out string error).Should().BeTrue();
            error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void Generic_result_tryGetError_is_false_Success_value_expected()
        {
            Result<string> result = Result.Success("Success");
            result.TryGetError(out string error).Should().BeFalse();
            error.Should().BeNull();
        }

        [Fact]
        public void Generic_result_tryGetError_is_true_Failure_value_expected()
        {
            Result<string> result = Result.Failure<string>(ErrorMessage);
            result.TryGetError(out string error).Should().BeTrue();
            error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void Generic_result_tryGetSuccess_is_false_Failure_value_expected()
        {
            Result<string> result = Result.Failure<string>(ErrorMessage);
            result.TryGetValue(out string value).Should().BeFalse();
            value.Should().BeNull();
        }

        [Fact]
        public void Generic_result_tryGetSuccess_is_true_Success_value_expected()
        {
            Result<string> result = Result.Success("Success");
            result.TryGetValue(out string value).Should().BeTrue();
            value.Should().Be("Success");
        }

        [Fact]
        public void Value_Error_Generic_result_tryGetError_is_false_Success_value_expected()
        {
            Result<string, string> result = Result.Success<string, string>("Success");
            result.TryGetError(out string error).Should().BeFalse();
            error.Should().BeNull();
        }

        [Fact]
        public void Value_Error_Generic_result_tryGetError_is_true_Failure_value_expected()
        {
            Result<string, string> result = Result.Failure<string, string>(ErrorMessage);
            result.TryGetError(out string error).Should().BeTrue();
            error.Should().Be(ErrorMessage);
        }

        [Fact]
        public void Value_Error_Generic_result_tryGetSuccess_is_false_Failure_value_expected()
        {
            Result<string, string> result = Result.Failure<string, string>(ErrorMessage);
            result.TryGetValue(out string value).Should().BeFalse();
            value.Should().BeNull();
        }

        [Fact]
        public void Value_Error_Generic_result_tryGetSuccess_is_true_Success_value_expected()
        {
            Result<string, string> result = Result.Success<string, string>("Success");
            result.TryGetValue(out string value).Should().BeTrue();
            value.Should().Be("Success");
        }
    }
}