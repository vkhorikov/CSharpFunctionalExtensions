using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static Result CreateFailure(bool isFailure, string error)
        {
            return isFailure
                ? Fail(error)
                : Ok();
        }

        public static Result CreateFailure(Func<bool> failurePredicate, string error)
        {
            return failurePredicate()
                ? Fail(error)
                : Ok();
        }

        public static async Task<Result> CreateFailure(Func<Task<bool>> failurePredicate, string error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(Result.DefaultConfigureAwait);
            return isFailure
                ? Fail(error)
                : Ok();
        }

        public static Result<T> CreateFailure<T>(bool isFailure, T value, string error)
        {
            return isFailure
                ? Fail<T>(error)
                : Ok<T>(value);
        }

        public static Result<T> CreateFailure<T>(Func<bool> failurePredicate, T value, string error)
        {
            return failurePredicate()
                ? Fail<T>(error)
                : Ok<T>(value);
        }

        public static async Task<Result<T>> CreateFailure<T>(Func<Task<bool>> failurePredicate, T value, string error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(Result.DefaultConfigureAwait);
            return isFailure
                ? Fail<T>(error)
                : Ok<T>(value);
        }

        [DebuggerStepThrough]
        public static Result<T, E> CreateFailure<T, E>(bool isFailure, T value, E error)
        {
            return isFailure
                ? Fail<T, E>(error)
                : Ok<T, E>(value);
        }

        public static Result<T, E> CreateFailure<T, E>(Func<bool> failurePredicate, T value, E error)
        {
            return failurePredicate()
                ? Fail<T, E>(error)
                : Ok<T, E>(value);
        }

        public static async Task<Result<T, E>> CreateFailure<T, E>(Func<Task<bool>> failurePredicate, T value, E error)
        {
            bool isFailure = await failurePredicate().ConfigureAwait(Result.DefaultConfigureAwait);
            return isFailure
                ? Fail<T, E>(error)
                : Ok<T, E>(value);
        }
    }
}