using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        [DebuggerStepThrough]
        public static Result Create(bool isSuccess, string error)
        {
            return isSuccess
                ? Ok()
                : Fail(error);
        }

        public static Result Create(Func<bool> predicate, string error)
        {
            return Create(predicate(), error);
        }

        public static async Task<Result> Create(Func<Task<bool>> predicate, string error)
        {
            bool isSuccess = await predicate().ConfigureAwait(DefaultConfigureAwait);
            return Create(isSuccess, error);
        }

        public static Result<T> Create<T>(bool isSuccess, T value, string error)
        {
            return isSuccess
                ? Ok(value)
                : Fail<T>(error);
        }

        public static Result<T> Create<T>(Func<bool> predicate, T value, string error)
        {
            return Create(predicate(), value, error);
        }

        public static async Task<Result<T>> Create<T>(Func<Task<bool>> predicate, T value, string error)
        {
            bool isSuccess = await predicate().ConfigureAwait(DefaultConfigureAwait);
            return Create(isSuccess, value, error);
        }

        [DebuggerStepThrough]
        public static Result<T, E> Create<T, E>(bool isSuccess, T value, E error)
        {
            return isSuccess
                ? Ok<T, E>(value)
                : Fail<T, E>(error);
        }

        public static Result<T, E> Create<T, E>(Func<bool> predicate, T value, E error)
        {
            return predicate()
                ? Ok<T, E>(value)
                : Fail<T, E>(error);
        }

        public static async Task<Result<T, E>> Create<T, E>(Func<Task<bool>> predicate, T value, E error)
        {
            bool isSuccess = await predicate().ConfigureAwait(Result.DefaultConfigureAwait);
            return isSuccess
                ? Ok<T, E>(value)
                : Fail<T, E>(error);
        }
    }
}
