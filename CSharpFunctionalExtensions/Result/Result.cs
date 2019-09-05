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