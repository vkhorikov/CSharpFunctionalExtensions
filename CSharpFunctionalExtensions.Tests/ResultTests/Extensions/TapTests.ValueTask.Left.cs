using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class TapTests_ValueTask_Left : TapTestsBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Tap_ValueTask_Left_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, ErrorMessage);

            var returned = await result.AsValueTask().Tap(Action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Tap_ValueTask_Left_T_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = await result.AsValueTask().Tap(Action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Tap_ValueTask_Left_T_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, ErrorMessage);

            var returned = await result.AsValueTask().Tap(Action_T);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Tap_ValueTask_Left_T_E_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = await result.AsValueTask().Tap(Action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Fact]
        public async Task Tap_ValueTask_Left_UnitResult_E_executes_action_on_success_and_returns_self()
        {
            UnitResult<E> result = UnitResult.Success<E>();

            var returned = await result.AsValueTask().Tap(Action);

            actionExecuted.Should().Be(true);
            result.Should().Be(returned);
        }

        [Fact]
        public async Task Tap_ValueTask_Left_UnitResult_E_executes_action_on_failure_and_returns_self()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);

            var returned = await result.AsValueTask().Tap(Action);

            actionExecuted.Should().Be(false);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Tap_ValueTask_Left_T_E_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);

            var returned = await result.AsValueTask().Tap(Action_T);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }
    }
}
