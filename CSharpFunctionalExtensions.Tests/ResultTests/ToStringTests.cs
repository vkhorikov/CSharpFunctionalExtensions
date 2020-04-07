using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ToStringTests
    {
        [Fact]
        public void ToString_returns_failure_with_error_when_failure()
        {
            var subject = Result.Failure("BigError");
            Assert.Equal("Failure(BigError)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_failure_with_generic_result_error_when_failure()
        {
            var subject = Result.Failure<string>("BigError");
            Assert.Equal("Failure(BigError)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_failure_with_generic_error_when_failure()
        {
            var subject = Result.Failure<String, ErrorType>(ErrorType.Error1);
            Assert.Equal("Failure(Error1)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_success()
        {
            var subject = Result.Success();
            Assert.Equal("Success", subject.ToString());
        }

        [Fact]
        public void ToString_returns_success_with_generic_result()
        {
            var subject = Result.Success(1);
            Assert.Equal("Success(1)", subject.ToString());
        }

        [Fact]
        public void ToString_returns_success_with_generic_result_and_generic_error()
        {
            var subject = Result.Success<int, ErrorType>(1);
            Assert.Equal("Success(1)", subject.ToString());
        }


        enum ErrorType
        {
            Error1
        }
    }
}