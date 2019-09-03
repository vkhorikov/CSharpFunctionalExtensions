using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class TapIfAsyncRight : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_AsyncRight_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result result = Result.Ok();
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncRight_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Ok(T.Value);
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Ok(T.Value);
            bool actionExecuted = false;
            Func<T, Task> func = (T _) => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Ok<T, E>(T.Value);
            bool actionExecuted = false;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Ok<T, E>(T.Value);
            bool actionExecuted = false;
            Func<T, Task> func = (T _) => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_AsyncRight_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result result = Result.Ok();
            bool actionExecuted = false;
            Func<Task<Discard>> func = () => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Ok(T.Value);
            bool actionExecuted = false;
            Func<Task<Discard>> func = () => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_func_T_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Ok(T.Value);
            bool actionExecuted = false;
            Func<T, Task<Discard>> func = (T _) => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Ok<T, E>(T.Value);
            bool actionExecuted = false;
            Func<Task<Discard>> func = () => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_func_T_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Ok<T, E>(T.Value);
            bool actionExecuted = false;
            Func<T, Task<Discard>> func = (T _) => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }
    }
}
