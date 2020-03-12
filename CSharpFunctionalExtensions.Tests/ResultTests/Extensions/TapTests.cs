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
            Result result = Result.SuccessIf(isSuccess, "Error");
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
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
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
            Result<T> result = Result.SuccessIf(isSuccess, T.Value, "Error");
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
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
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
            Result<T, E> result = Result.SuccessIf(isSuccess, T.Value, E.Value);
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = result.Tap(action);

            actionExecuted.Should().Be(isSuccess);
            result.Should().Be(returned);
        }
    }
}
