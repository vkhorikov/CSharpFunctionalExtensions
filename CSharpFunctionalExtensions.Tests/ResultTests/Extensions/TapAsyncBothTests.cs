using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class TapAsyncBoth : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_AsyncBoth_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, "Error");
            Task<Result> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = resultTask.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncBoth_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
            Task<Result<T>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = resultTask.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncBoth_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
            Task<Result<T>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<T, Task> func = (T _) => { actionExecuted = true; return Task.CompletedTask; };

            var returned = resultTask.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncBoth_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            Task<Result<T, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = resultTask.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncBoth_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            Task<Result<T, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<T, Task> func = (T _) => { actionExecuted = true; return Task.CompletedTask; };

            var returned = resultTask.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }
    }
}
