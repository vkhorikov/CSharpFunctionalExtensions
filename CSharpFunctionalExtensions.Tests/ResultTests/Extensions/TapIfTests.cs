using FluentAssertions;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class TapIf : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result result = Result.Success();
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result result = Result.Success();
            bool actionExecuted = false;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            bool actionExecuted = false;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_func_T_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            bool actionExecuted = false;
            Func<T, Discard> func = (T _) => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            bool actionExecuted = false;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_func_T_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            bool actionExecuted = false;
            Func<T, Discard> func = (T _) => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }












        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_T_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action<K> action = (K _) => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_action_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_action_T_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action<K> action = (K _) => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_func_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_func_T_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K, Discard> func = (K _) => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_func_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<Discard> func = () => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_func_T_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K, Discard> func = (K _) => { actionExecuted = true; return Discard.Value; };

            var returned = result.TapIf(condition, func);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }
    }
}
