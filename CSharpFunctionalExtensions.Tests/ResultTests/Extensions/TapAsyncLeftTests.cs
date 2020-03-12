using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class TapAsyncLeft : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_AsyncLeft_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, "Error");
            Task<Result> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = resultTask.Tap(action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncLeft_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
            Task<Result<T>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = resultTask.Tap(action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncLeft_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
            Task<Result<T>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = resultTask.Tap(action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncLeft_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            Task<Result<T, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = resultTask.Tap(action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncLeft_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            Task<Result<T, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = resultTask.Tap(action).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }
    }
}
