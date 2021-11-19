using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnFailureAsyncRightTests : OnFailureTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task OnFailure_AsyncRight_executes_action_on_result_failure_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            Result returned = await result.OnFailure(AsyncAction);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task OnFailure_AsyncRight_executes_action_string_on_result_failure_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            Result returned = await result.OnFailure(AsyncActionString);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task OnFailure_AsyncRight_T_executes_action_on_result_failure_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Result<T> returned = await result.OnFailure(AsyncAction);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task OnFailure_AsyncRight_T_executes_action_string_on_result_failure_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            Result<T> returned = await result.OnFailure(AsyncActionString);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task OnFailure_AsyncRight_unit_result_E_executes_action_on_failure_and_returns_self(bool isSuccess)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            UnitResult<E> returned = await result.OnFailure(AsyncAction);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task OnFailure_AsyncRight_unit_result_E_executes_E_action_on_failure_and_returns_self(bool isSuccess)
        {
            UnitResult<E> result = UnitResult.SuccessIf(isSuccess, E.Value);

            UnitResult<E> returned = await result.OnFailure(AsyncActionError);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task OnFailure_AsyncRight_T_E_executes_action_on_result_failure_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            Result<T, E> returned = await result.OnFailure(AsyncAction);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task OnFailure_AsyncRight_T_E_executes_action_T_on_result_failure_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            Result<T, E> returned = await result.OnFailure(AsyncActionError);

            actionExecuted.Should().Be(!isSuccess);
            result.Should().Be(returned);
        }
    }
}