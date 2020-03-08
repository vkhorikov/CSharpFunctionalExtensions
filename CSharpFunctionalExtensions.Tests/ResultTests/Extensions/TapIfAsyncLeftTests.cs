using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class TapIfAsyncLeft : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_AsyncLeft_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result result = Result.Success();
            Task<Result> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncLeft_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            Task<Result<T>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncLeft_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            Task<Result<T>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_AsyncLeft_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            Task<Result<T, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_AsyncLeft_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            Task<Result<T, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Action<T> action = (T _) => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_AsyncLeft_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result result = Result.Success();
            Task<Result> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<T> func = () => { actionExecuted = true; return T.Value; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncLeft_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            Task<Result<T>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<T> func = () => { actionExecuted = true; return T.Value; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncLeft_executes_func_T_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            Task<Result<T>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<T, Discard> func = (T _) => { actionExecuted = true; return Discard.Value; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_AsyncLeft_executes_func_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            Task<Result<T, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<T> func = () => { actionExecuted = true; return T.Value; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_AsyncLeft_executes_func_T_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            Task<Result<T, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<T, Discard> func = (T _) => { actionExecuted = true; return Discard.Value; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }











        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncLeft_executes_action_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            Task<Result<K>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action action = () => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncLeft_executes_action_T_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            Task<Result<K>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action<K> action = (K _) => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_AsyncLeft_executes_action_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            Task<Result<K, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action action = () => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_AsyncLeft_executes_action_T_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            Task<Result<K, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action<K> action = (K _) => actionExecuted = true;

            var returned = resultTask.TapIf(condition, action).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncLeft_executes_func_based_on_func_and_returns_self(bool value)
        {
            K resultValue = K.FromBool(value);
            K tapIfFuncReturn = K.FromBool(value);

            Result<K> result = Result.Success<K>(resultValue);
            Task<Result<K>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K> func = () => { actionExecuted = true; return tapIfFuncReturn; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_AsyncLeft_executes_func_T_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success<K>(K.FromBool(value));
            Task<Result<K>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K, Discard> func = (K _) => { actionExecuted = true; return Discard.Value; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_AsyncLeft_executes_func_based_on_func_and_returns_self(bool value)
        {
            K resultValue = K.FromBool(value);
            K tapIfFuncReturn = K.FromBool(value);

            Result<K, E> result = Result.Success<K, E>(resultValue);
            Task<Result<K, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K> func = () => { actionExecuted = true; return tapIfFuncReturn; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_AsyncLeft_executes_func_T_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            Task<Result<K, E>> resultTask = Task.FromResult(result);
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Func<K, Discard> func = (K _) => { actionExecuted = true; return Discard.Value; };

            var returned = resultTask.TapIf(condition, func).Result;

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }
    }
}
