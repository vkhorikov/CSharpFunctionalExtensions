using CSharpFunctionalExtensions.Internal;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result : IResult, ISerializable
    {
        private static readonly Result OkResult = new Result(false, null);

        public static string ErrorMessagesSeparator = ", ";
        public static bool DefaultConfigureAwait = false;

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _logic.GetObjectData(info, context);
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;

        [DebuggerStepThrough]
        private Result(bool isFailure, string error)
        {
            _logic = ResultCommonLogic.Create(isFailure, error);
        }

        Result(SerializationInfo info, StreamingContext context)
        {
            bool isFailure = info.GetBoolean("IsFailure");
            string error = isFailure ? info.GetString("Error") : null;

            _logic = ResultCommonLogic.Create(isFailure, error);
        }

        [DebuggerStepThrough]
        public static Result Ok()
        {
            return OkResult;
        }

        [DebuggerStepThrough]
        public static Result Fail(string error)
        {
            return new Result(true, error);
        }

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

        [DebuggerStepThrough]
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(false, value, null);
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(true, default(T), error);
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
        public static Result<T, E> Ok<T, E>(T value)
        {
            return new Result<T, E>(false, value, default(E));
        }

        [DebuggerStepThrough]
        public static Result<T, E> Fail<T, E>(E error)
        {
            return new Result<T, E>(true, default(T), error);
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

        /// <summary>
        /// Returns first failure in the list of <paramref name="results"/>. If there is no failure returns success.
        /// </summary>
        /// <param name="results">List of results.</param>
        [DebuggerStepThrough]
        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                    return Fail(result.Error);
            }

            return Ok();
        }

        public Result<T> MapFailure<T>()
        {
            if (IsSuccess)
                throw new InvalidOperationException($"{nameof(MapFailure)} failed because result is in success state");

            return Fail<T>(Error);
        }
    }
}