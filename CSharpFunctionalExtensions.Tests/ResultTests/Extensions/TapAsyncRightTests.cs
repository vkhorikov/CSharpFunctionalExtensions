using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class TapAsyncRight : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_AsyncRight_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, "Error");
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
            bool actionExecuted = false;
            Func<T, Task> func = (T _) => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Func<T, Task> func = (T _) => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_AsyncRight_executes_func_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.SuccessIf(isSuccess, "Error");
            bool actionExecuted = false;
            Func<Task<Discard>> func = () => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_func_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
            bool actionExecuted = false;
            Func<Task<Discard>> func = () => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_func_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
            bool actionExecuted = false;
            Func<T, Task<Discard>> func = (T _) => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_func_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Func<Task<Discard>> func = () => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_func_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Func<T, Task<Discard>> func = (T _) => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.Tap(func).Result;

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }
    }
}
