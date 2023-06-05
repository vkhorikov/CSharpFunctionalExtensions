using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapTryTests : TapTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapTry_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.TapTry(Action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }
        
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapTry_handles_exception_and_returns_error(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.TapTry(Throwing);

            actionExecuted.Should().BeFalse();
            
            if (isSuccess)
                result.Should().NotBe(returned);
            else
                result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapTryIf_executes_action_on_result_success_and_returns_self(bool isSuccess, bool condition)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.TapIfTry(condition, Action);

            actionExecuted.Should().Be(condition && isSuccess);
            result.Should().Be(returned);
        }
        
        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [InlineData(false, false)]
        public void TapTryIf_handles_exception_and_returns_error(bool isSuccess, bool condition)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.TapIfTry(condition, Throwing);

            actionExecuted.Should().BeFalse();
            
            if (condition && isSuccess)
                result.Should().NotBe(returned);
            else
                result.Should().Be(returned);
        }
        
        protected void Throwing() => throw new Exception(ErrorMessage);
    }
}
