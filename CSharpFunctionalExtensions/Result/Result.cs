using CSharpFunctionalExtensions.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public struct Result : IResult, ISerializable
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

        [DebuggerStepThrough]
        public static Result Combine(IEnumerable<Result> results, string errorMessagesSeparator = null)
        {
            List<Result> failedResults = results.Where(x => x.IsFailure).ToList();

            if (failedResults.Count == 0)
                return Ok();

            string errorMessage = string.Join(errorMessagesSeparator ?? ErrorMessagesSeparator, failedResults.Select(x => x.Error));
            return Fail(errorMessage);
        }

        [DebuggerStepThrough]
        public static Result Combine<T>(IEnumerable<Result<T>> results, string errorMessagesSeparator = null)
        {
            var untyped = results.Select(result => (Result)result);
            return Combine(untyped, errorMessagesSeparator);
        }

        /// <summary>
        /// Combines several results (and any error messages) into a single result.
        /// The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        /// Error messages are concatenated with the default <see cref="Result.ErrorMessagesSeparator" /> between each message.
        /// </summary>
        /// <param name="results">The Results to be combined.</param>
        /// <returns>A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        [DebuggerStepThrough]
        public static Result Combine(params Result[] results)
            => Combine(results, ErrorMessagesSeparator);

        /// <summary>
        /// Combines several results (and any error messages) into a single result.
        /// The returned result will be a failure if any of the input <paramref name="results"/> are failures.
        /// Error messages are concatenated with the specified <paramref name="errorMessagesSeparator"/> between each message.
        /// </summary>
        /// <param name="errorMessagesSeparator">The string to use as a separator. If omitted, the default <see cref="Result.ErrorMessagesSeparator" /> is used instead.</param>
        /// <param name="results">The Results to be combined.</param>
        /// <returns>A Result that is a success when all the input <paramref name="results"/> are also successes.</returns>
        [DebuggerStepThrough]
        public static Result Combine(string errorMessagesSeparator, params Result[] results)
            => Combine(results, errorMessagesSeparator);

        [DebuggerStepThrough]
        public static Result Combine<T>(params Result<T>[] results)
            => Combine(results, ErrorMessagesSeparator);

        [DebuggerStepThrough]
        public static Result Combine<T>(string errorMessagesSeparator, params Result<T>[] results)
            => Combine(results, errorMessagesSeparator);

        private static readonly Func<Exception, string> DefaultTryErrorHandler = exc => exc.Message;

        public static Result Try(Action action, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                action();
                return Ok();
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Fail(message);
            }
        }

        public static Result<T> Try<T>(Func<T> func, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                return Ok(func());
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Fail<T>(message);
            }
        }

        public static async Task<Result<T>> Try<T>(Func<Task<T>> func, Func<Exception, string> errorHandler = null)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;

            try
            {
                var result = await func().ConfigureAwait(Result.DefaultConfigureAwait);
                return Ok(result);
            }
            catch (Exception exc)
            {
                string message = errorHandler(exc);
                return Fail<T>(message);
            }
        }

        public static Result<T, E> Try<T, E>(Func<T> func, Func<Exception, E> errorHandler)
        {
            try
            {
                return Ok<T, E>(func());
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Fail<T, E>(error);
            }
        }

        public static async Task<Result<T, E>> Try<T, E>(Func<Task<T>> func, Func<Exception, E> errorHandler)
        {
            try
            {
                var result = await func().ConfigureAwait(DefaultConfigureAwait);
                return Ok<T, E>(result);
            }
            catch (Exception exc)
            {
                E error = errorHandler(exc);
                return Fail<T, E>(error);
            }
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out string error)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            error = IsFailure ? Error : null;
        }

        public Result<T> MapFailure<T>()
        {
            if (IsSuccess)
                throw new InvalidOperationException($"{nameof(MapFailure)} failed because result is in success state");

            return Fail<T>(Error);
        }
    }
}