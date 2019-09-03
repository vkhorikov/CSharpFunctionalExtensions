using FluentAssertions;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class Tap : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.Create(isSuccess, "Error");
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.Tap(action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.Create(isSuccess, T.Value, "Error");
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.Tap(action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.Create(isSuccess, T.Value, "Error");
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = result.Tap(action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_executes_action_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.Create(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.Tap(action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_executes_action_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.Create(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = result.Tap(action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_executes_func_on_result_success_and_returns_self(bool isSuccess)
        {
            Result result = Result.Create(isSuccess, "Error");
            bool actionExecuted = false;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.Tap(func);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_executes_func_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.Create(isSuccess, T.Value, "Error");
            bool actionExecuted = false;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.Tap(func);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_executes_func_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T> result = Result.Create(isSuccess, T.Value, "Error");
            bool actionExecuted = false;
            Func<T, Discard> func = (T _) => { actionExecuted = true; return Discard.Value; };

            var returned = result.Tap(func);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_executes_func_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.Create(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.Tap(func);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_executes_func_T_on_result_success_and_returns_self(bool isSuccess)
        {
            Result<T, E> result = Result.Create(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Func<T, Discard> func = (T _) => { actionExecuted = true; return Discard.Value; };

            var returned = result.Tap(func);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }
    }
}
