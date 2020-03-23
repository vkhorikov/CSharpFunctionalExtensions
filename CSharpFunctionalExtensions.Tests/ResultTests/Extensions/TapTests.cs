using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class Tap : TapTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.Tap(Action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.Tap(Action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.Tap(Action_T);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.Tap(Action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.Tap(Action_T);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_func_result(bool resultSuccess, bool funcSuccess)
        {
            Result<T> result = Result.SuccessIf(resultSuccess, T.Value, ErrorMessage);

            var returned = result.Tap(_ => GetResult(funcSuccess));

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : FailedResultT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_func_result_K(bool resultSuccess, bool funcSuccess)
        {
            Result<T> result = Result.SuccessIf(resultSuccess, T.Value, ErrorMessage);

            var returned = result.Tap(Func_Result_K(funcSuccess));

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : FailedResultT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_func_result_KE(bool resultSuccess, bool funcSuccess)
        {
            Result<T, E> result = Result.SuccessIf(resultSuccess, T.Value, E.Value);

            var returned = result.Tap(Func_Result_KE(funcSuccess));

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : returned);
        }
    }
}
