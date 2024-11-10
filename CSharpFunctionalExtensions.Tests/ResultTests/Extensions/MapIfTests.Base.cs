using System;
using System.Threading.Tasks;
using FluentAssertions;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public abstract class MapIfTestsBase : TestBase
    {
        protected bool actionExecuted;
        protected bool predicateExecuted;

        protected MapIfTestsBase()
        {
            actionExecuted = false;
            predicateExecuted = false;
        }

        protected Func<T, T> GetAction() =>
            value =>
            {
                actionExecuted.Should().BeFalse();
                value.Should().Be(T.Value);

                actionExecuted = true;
                return T.Value2;
            };

        protected Func<T, Task<T>> GetTaskAction()
        {
            return t => Task.FromResult(GetAction()(t));
        }

        protected Func<T, ValueTask<T>> GetValueTaskAction()
        {
            return t => ValueTask.FromResult(GetAction()(t));
        }

        protected Func<T, bool> GetValuePredicate(bool value)
        {
            return t =>
            {
                predicateExecuted.Should().BeFalse();
                t.Should().Be(T.Value);

                predicateExecuted = true;
                return value;
            };
        }

        protected static Result<T> GetExpectedValueResult(bool isSuccess, bool condition)
        {
            var resultChanged = isSuccess && condition;

            if (!resultChanged)
            {
                return Result.SuccessIf(isSuccess, T.Value, ErrorMessage);
            }

            return Result.SuccessIf(isSuccess, T.Value2, ErrorMessage2);
        }

        protected static Result<T, E> GetExpectedValueErrorResult(bool isSuccess, bool condition)
        {
            var resultChanged = isSuccess && condition;

            if (!resultChanged)
            {
                return Result.SuccessIf(isSuccess, T.Value, E.Value);
            }

            return Result.SuccessIf(isSuccess, T.Value2, E.Value2);
        }

        protected readonly string ContextMessage = "Context data";
    }
}
