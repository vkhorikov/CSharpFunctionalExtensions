using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapAsyncLeft : TapTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_AsyncLeft_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = result.AsTask().Tap(Action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncLeft_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.AsTask().Tap(Action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncLeft_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = result.AsTask().Tap(Action_T).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncLeft_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.AsTask().Tap(Action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncLeft_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = result.AsTask().Tap(Action_T).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_AsyncLeft_func_result(bool resultSuccess, bool funcSuccess)
        {
            Result<T> result = Result.SuccessIf(resultSuccess, T.Value, ErrorMessage);

            var returned = result.AsTask().Tap(_ => GetResult(funcSuccess)).Result;

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : FailedResultT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_AsyncLeft_func_result_K(bool resultSuccess, bool funcSuccess)
        {
            Result<T> result = Result.SuccessIf(resultSuccess, T.Value, ErrorMessage);

            var returned = result.AsTask().Tap(Func_Result_K(funcSuccess)).Result;

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : FailedResultT);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public void Tap_T_AsyncLeft_func_result_KE(bool resultSuccess, bool funcSuccess)
        {
            Result<T, E> result = Result.SuccessIf(resultSuccess, T.Value, E.Value);

            var returned = result.AsTask().Tap(Func_Result_KE(funcSuccess)).Result;

            actionExecuted.Should().Be(resultSuccess);
            returned.Should().Be(funcSuccess ? result : returned);
        }
    }
}
