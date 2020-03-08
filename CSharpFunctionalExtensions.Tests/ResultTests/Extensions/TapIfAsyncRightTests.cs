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
            Result result = Result.Success();
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
            Result<T> result = Result.Success(T.Value);
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
            Result<T> result = Result.Success(T.Value);
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
            Result<T, E> result = Result.Success<T, E>(T.Value);
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
            Result<T, E> result = Result.Success<T, E>(T.Value);
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
            Result result = Result.Success();
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
            Result<T> result = Result.Success(T.Value);
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
            Result<T> result = Result.Success(T.Value);
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
            Result<T, E> result = Result.Success<T, E>(T.Value);
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
            Result<T, E> result = Result.Success<T, E>(T.Value);
            bool actionExecuted = false;
            Func<T, Task<Discard>> func = (T _) => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncRight_executes_action_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_action_T_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K, Task> func = (K _) => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_action_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<Task> func = () => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_action_T_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K, Task> func = (K _) => { actionExecuted = true; return Task.CompletedTask; };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_func_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<Task<Discard>> func = () => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_AsyncRight_executes_func_T_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K, Task<Discard>> func = (K _) => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_func_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<Task<Discard>> func = () => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Tap_T_E_AsyncRight_executes_func_T_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K, Task<Discard>> func = (K _) => { actionExecuted = true; return Task.FromResult(Discard.Value); };

            var returned = result.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }
    }
}
