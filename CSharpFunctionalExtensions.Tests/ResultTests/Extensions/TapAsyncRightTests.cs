using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapAsyncRight : TapTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_AsyncRight_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.Tap(Task_Action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.Tap(Task_Action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.Tap(Task_Action_T).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Fact]
        public void Tap_unit_result_E_executes_action_on_success_and_returns_self()
        {
            UnitResult<E> result = UnitResult.Success<E>();

            var returned = result.Tap(Task_Action).Result;

            actionExecuted.Should().Be(true);
            result.Should().Be(returned);
        }

        [Fact]
        public void Tap_unit_result_E_executes_action_on_failure_and_returns_self()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);

            var returned = result.Tap(Task_Action).Result;

            actionExecuted.Should().Be(false);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.Tap(Task_Action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.Tap(Task_Action_T).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }
    }
}
