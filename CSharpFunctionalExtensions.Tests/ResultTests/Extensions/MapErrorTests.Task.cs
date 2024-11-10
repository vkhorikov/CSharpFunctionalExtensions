using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapError_Task_Tests : TestBase
    {
        private const string ContextMessage = "Context-specific error";

        [Fact]
        public async Task MapError_Task_returns_success()
        {
            Task<Result> result = Result.Success().AsTask();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_returns_success_with_context()
        {
            Task<Result> result = Result.Success().AsTask();
            var invocations = 0;

            Result actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_returns_new_failure()
        {
            Task<Result> result = Result.Failure(ErrorMessage).AsTask();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_returns_new_failure_with_context()
        {
            Task<Result> result = Result.Failure(ErrorMessage).AsTask();
            var invocations = 0;

            Result actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_returns_UnitResult_success()
        {
            Task<Result> result = Result.Success().AsTask();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_returns_UnitResult_success_with_context()
        {
            Task<Result> result = Result.Success().AsTask();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_returns_new_UnitResult_failure()
        {
            Task<Result> result = Result.Failure(ErrorMessage).AsTask();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_returns_new_UnitResult_failure_with_context()
        {
            Task<Result> result = Result.Failure(ErrorMessage).AsTask();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_T_returns_success()
        {
            Task<Result<T>> result = Result.Success(T.Value).AsTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_T_returns_success_with_context()
        {
            Task<Result<T>> result = Result.Success(T.Value).AsTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_T_returns_new_failure()
        {
            Task<Result<T>> result = Result.Failure<T>(ErrorMessage).AsTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_T_returns_new_failure_with_context()
        {
            Task<Result<T>> result = Result.Failure<T>(ErrorMessage).AsTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_UnitResult_returns_success()
        {
            Task<UnitResult<E>> result = UnitResult.Success<E>().AsTask();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_UnitResult_returns_success_with_context()
        {
            Task<UnitResult<E>> result = UnitResult.Success<E>().AsTask();
            var invocations = 0;

            Result actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult($"{error} {error}");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_UnitResult_returns_new_failure()
        {
            Task<UnitResult<E>> result = UnitResult.Failure(E.Value).AsTask();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return Task.FromResult("error");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_UnitResult_returns_new_failure_with_context()
        {
            Task<UnitResult<E>> result = UnitResult.Failure(E.Value).AsTask();
            var invocations = 0;

            Result actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult("error");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_E_UnitResult_returns_success()
        {
            Task<UnitResult<E>> result = UnitResult.Success<E>().AsTask();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_E_UnitResult_returns_success_with_context()
        {
            Task<UnitResult<E>> result = UnitResult.Success<E>().AsTask();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(
                (error, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E2.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_E_UnitResult_returns_new_failure()
        {
            Task<UnitResult<E>> result = UnitResult.Failure(E.Value).AsTask();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_E_UnitResult_returns_new_failure_with_context()
        {
            Task<UnitResult<E>> result = UnitResult.Failure(E.Value).AsTask();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E2.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_T_E_returns_success()
        {
            Task<Result<T>> result = Result.Success(T.Value).AsTask();
            var invocations = 0;

            Result<T, E> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_T_E_returns_success_with_context()
        {
            Task<Result<T>> result = Result.Success(T.Value).AsTask();
            var invocations = 0;

            Result<T, E> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_T_E_returns_new_failure()
        {
            Task<Result<T>> result = Result.Failure<T>(ErrorMessage).AsTask();
            var invocations = 0;

            Result<T, E> actual = await result.MapError(error =>
            {
                error.Should().Be(ErrorMessage);
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_T_E_returns_new_failure_with_context()
        {
            Task<Result<T>> result = Result.Failure<T>(ErrorMessage).AsTask();
            var invocations = 0;

            Result<T, E> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(ErrorMessage);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_T_E_string_returns_success()
        {
            Task<Result<T, E>> result = Result.Success<T, E>(T.Value).AsTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult("error");
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_T_E_string_returns_success_with_context()
        {
            Task<Result<T, E>> result = Result.Success<T, E>(T.Value).AsTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult("error");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_T_E_E2_returns_success()
        {
            Task<Result<T, E>> result = Result.Success<T, E>(T.Value).AsTask();
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_T_E_E2_returns_success_with_context()
        {
            Task<Result<T, E>> result = Result.Success<T, E>(T.Value).AsTask();
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(
                (_, context) =>
                {
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E2.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_T_E_string_returns_new_failure()
        {
            Task<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return Task.FromResult("string");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("string");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_T_E_string_returns_new_failure_with_context()
        {
            Task<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsTask();
            var invocations = 0;

            Result<T> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult("string");
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("string");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_T_E_E2_returns_new_failure()
        {
            Task<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsTask();
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_T_E_E2_returns_new_failure_with_context()
        {
            Task<Result<T, E>> result = Result.Failure<T, E>(E.Value).AsTask();
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(
                (error, context) =>
                {
                    error.Should().Be(E.Value);
                    context.Should().Be(ContextMessage);
                    invocations++;
                    return Task.FromResult(E2.Value);
                },
                ContextMessage
            );

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }
    }
}
