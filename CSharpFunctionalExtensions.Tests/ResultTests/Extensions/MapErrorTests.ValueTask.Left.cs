using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapErrorTests_ValueTask_Left : TestBase
    {
        private const string ContextMessage = "Context-specific error";

        [Fact]
        public async Task MapError_ValueTask_Left_returns_success()
        {
            ValueTask<Result> result = Result.Success().AsValueTask();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_returns_success_with_context()
        {
            ValueTask<Result> result = Result.Success().AsValueTask();
            var invocations = 0;

            Result actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return $"{error} {error}";
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_returns_new_failure()
        {
            ValueTask<Result> result = Result.Failure(ErrorMessage).AsValueTask();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_returns_new_failure_with_context()
        {
            ValueTask<Result> result = Result.Failure(ErrorMessage).AsValueTask();
            var invocations = 0;

            Result actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return $"{error} {error}";
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_returns_UnitResult_success()
        {
            ValueTask<Result> result = Result.Success().AsValueTask();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(error =>
            {
                invocations++;
                return E.Value;
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_returns_UnitResult_success_with_context()
        {
            ValueTask<Result> result = Result.Success().AsValueTask();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return E.Value;
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_returns_new_UnitResult_failure()
        {
            ValueTask<Result> result = Result.Failure(ErrorMessage).AsValueTask();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(error =>
            {
                invocations++;
                return E.Value;
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_returns_new_UnitResult_failure_with_context()
        {
            ValueTask<Result> result = Result.Failure(ErrorMessage).AsValueTask();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return E.Value;
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_returns_success()
        {
            ValueTask<Result<T>> result = Result.Success(T.Value).AsValueTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_returns_success_with_context()
        {
            ValueTask<Result<T>> result = Result.Success(T.Value).AsValueTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return $"{error} {error}";
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_returns_new_failure()
        {
            ValueTask<Result<T>> result = Result.Failure<T>(ErrorMessage).AsValueTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_returns_new_failure_with_context()
        {
            ValueTask<Result<T>> result = Result.Failure<T>(ErrorMessage).AsValueTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return $"{error} {error}";
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_UnitResult_returns_success()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Success<E>().AsValueTask();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_UnitResult_returns_success_with_context()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Success<E>().AsValueTask();
            var invocations = 0;

            Result actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return $"{error} {error}";
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_UnitResult_returns_new_failure()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Failure(E.Value).AsValueTask();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return "error";
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_UnitResult_returns_new_failure_with_context()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Failure(E.Value).AsValueTask();
            var invocations = 0;

            Result actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return "error";
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_E_UnitResult_returns_success()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Success<E>().AsValueTask();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(error =>
            {
                invocations++;
                return E2.Value;
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_E_UnitResult_returns_success_with_context()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Success<E>().AsValueTask();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return E2.Value;
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_E_UnitResult_returns_new_failure()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Failure(E.Value).AsValueTask();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return E2.Value;
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_E_UnitResult_returns_new_failure_with_context()
        {
            ValueTask<UnitResult<E>> result = UnitResult.Failure(E.Value).AsValueTask();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return E2.Value;
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_returns_success()
        {
            ValueTask<Result<T>> result = Result.Success(T.Value).AsValueTask();
            var invocations = 0;

            Result<T, E> actual = await result.MapError(_ =>
            {
                invocations++;
                return E.Value;
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_returns_success_with_context()
        {
            ValueTask<Result<T>> result = Result.Success(T.Value).AsValueTask();
            var invocations = 0;

            Result<T, E> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return E.Value;
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_returns_new_failure()
        {
            ValueTask<Result<T>> result = Result.Failure<T>(ErrorMessage).AsValueTask();
            var invocations = 0;

            Result<T, E> actual = await result.MapError(error =>
            {
                error.Should().Be(ErrorMessage);
                invocations++;
                return E.Value;
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_returns_new_failure_with_context()
        {
            ValueTask<Result<T>> result = Result.Failure<T>(ErrorMessage).AsValueTask();
            var invocations = 0;

            Result<T, E> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(ErrorMessage);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return E.Value;
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_string_returns_success()
        {
            ValueTask<Result<T, E>> result = Result.Success<T, E>(T.Value).AsValueTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(_ =>
            {
                invocations++;
                return "error";
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_string_returns_success_with_context()
        {
            ValueTask<Result<T, E>> result = Result.Success<T, E>(T.Value).AsValueTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return "error";
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_E2_returns_success()
        {
            ValueTask<Result<T, E>> result = Result.Success<T, E>(T.Value).AsValueTask();
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(_ =>
            {
                invocations++;
                return E2.Value;
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_E2_returns_success_with_context()
        {
            ValueTask<Result<T, E>> result = Result.Success<T, E>(T.Value).AsValueTask();
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return E2.Value;
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_string_returns_new_failure()
        {
            ValueTask<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsValueTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return "string";
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("string");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_string_returns_new_failure_with_context()
        {
            ValueTask<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsValueTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return "string";
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("string");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_E2_returns_new_failure()
        {
            ValueTask<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsValueTask();
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return E2.Value;
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_ValueTask_Left_T_E_E2_returns_new_failure_with_context()
        {
            ValueTask<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsValueTask();
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return E2.Value;
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }
    }
}
