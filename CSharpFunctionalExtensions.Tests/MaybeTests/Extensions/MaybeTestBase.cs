using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions.Tests.ResultTests;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class MaybeTestBase : TestBase
    {
        private bool errorFuncExecuted;

        protected E ErrorFunc()
        {
            errorFuncExecuted = true;
            return E.Value;
        }

        protected void AssertErrorFuncCalled()
        {
            errorFuncExecuted.Should().BeTrue();
        }

        protected void AssertErrorFuncNotCalled()
        {
            errorFuncExecuted.Should().BeFalse();
        }
        
        protected static Func<T, R> ExpectAndReturn<R>(T expected, R result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return result;
            };
        }

        protected static Func<T, Maybe<R>> ExpectAndReturnMaybe<R>(T expected, R result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return result;
            };
        }

        protected static Func<T, Maybe<T>> ExpectAndReturnMaybe(T expected, T result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return result;
            };
        }
        
        protected static Func<T, Task<R>> ExpectAndReturn_Task<R>(T expected, R result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return Task.FromResult(result);
            };
        }

        protected static Func<T, Task<Maybe<R>>> ExpectAndReturnMaybe_Task<R>(T expected, R result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return Task.FromResult(Maybe<R>.From(result));
            };
        }

        protected static Func<T, Task<Maybe<T>>> ExpectAndReturnMaybe_Task(T expected, T result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return Task.FromResult(Maybe<T>.From(result));
            };
        }
        
        protected static Func<T, ValueTask<R>> ExpectAndReturn_ValueTask<R>(T expected, R result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return result.AsCompletedValueTask();
            };
        }

        protected static Func<T, ValueTask<Maybe<R>>> ExpectAndReturnMaybe_ValueTask<R>(T expected, R result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return Maybe<R>.From(result).AsCompletedValueTask();
            };
        }

        protected static Func<T, ValueTask<Maybe<T>>> ExpectAndReturnMaybe_ValueTask(T expected, T result)
        {
            return actual =>
            {
                actual.Should().Be(expected);
                return Maybe<T>.From(result).AsCompletedValueTask();
            };
        }
    }
}