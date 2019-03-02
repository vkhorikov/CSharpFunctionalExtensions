using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    internal class ResultCommonLogic<E>
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly E _error;

        public E Error
        {
            [DebuggerStepThrough]
            get
            {
                if (IsSuccess)
                    throw new ResultSuccessException();

                return _error;
            }
        }

        [DebuggerStepThrough]
        public ResultCommonLogic(bool isFailure, E error)
        {
            if (isFailure)
            {
                if (error == null)
                    throw new ArgumentNullException(nameof(error), ResultMessages.ErrorObjectIsNotProvidedForFailure);
            }
            else
            {
                if (error != null)
                    throw new ArgumentException(ResultMessages.ErrorObjectIsProvidedForSuccess, nameof(error));
            }

            IsFailure = isFailure;
            _error = error;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("IsFailure", IsFailure);
            info.AddValue("IsSuccess", IsSuccess);
            if (IsFailure)
            {
                info.AddValue("Error", Error);
            }
        }
    }

    internal sealed class ResultCommonLogic : ResultCommonLogic<string>
    {
        [DebuggerStepThrough]
        public static ResultCommonLogic Create(bool isFailure, string error)
        {
            if (isFailure)
            {
                if (string.IsNullOrEmpty(error))
                    throw new ArgumentNullException(nameof(error), ResultMessages.ErrorMessageIsNotProvidedForFailure);
            }
            else
            {
                if (error != null)
                    throw new ArgumentException(ResultMessages.ErrorMessageIsProvidedForSuccess, nameof(error));
            }

            return new ResultCommonLogic(isFailure, error);
        }

        public ResultCommonLogic(bool isFailure, string error) : base(isFailure, error)
        {
        }
    }

    internal static class ResultMessages
    {
        public static readonly string ErrorIsInaccessibleForSuccess = "There is no Error for a successful result.";

        public static readonly string ValueIsInaccessibleForFailure = "There is no Value for a failed result.";

        public static readonly string ErrorObjectIsNotProvidedForFailure =
            "You have tried to create a failure result, but error object appeared to be null, please review the code, generating error object.";

        public static readonly string ErrorObjectIsProvidedForSuccess =
            "You have tried to create a success result, but error object was also passed to the constructor, please try to review the code, creating a success result.";

        public static readonly string ErrorMessageIsNotProvidedForFailure = "There must be error message for failure.";

        public static readonly string ErrorMessageIsProvidedForSuccess = "There should be no error message for success.";
    }

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

        [DebuggerStepThrough]
        public static Result<T, E> Ok<T, E>(T value) where E : class
        {
            return new Result<T, E>(false, value, default(E));
        }

        [DebuggerStepThrough]
        public static Result<T, E> Fail<T, E>(E error) where E : class
        {
            return new Result<T, E>(true, default(T), error);
        }

        [DebuggerStepThrough]
        public static Result<T, E> Create<T, E>(bool isSuccess, T value, E error) where E : class
        {
            return isSuccess
                ? Ok<T, E>(value)
                : Fail<T, E>(error);
        }

        public static Result<T, E> Create<T, E>(Func<bool> predicate, T value, E error) where E : class
        {
            return predicate()
                ? Ok<T, E>(value)
                : Fail<T, E>(error);
        }

        public static async Task<Result<T, E>> Create<T, E>(Func<Task<bool>> predicate, T value, E error) where E : class
        {
            bool isSuccess = await predicate().ConfigureAwait(Result.DefaultConfigureAwait);
            return isSuccess
                ? Ok<T, E>(value)
                : Fail<T, E>(error);
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

        /// <summary>
        /// Returns failure which combined from all failures in the <paramref name="results"/> list. Error messages are separated by <paramref name="errorMessagesSeparator"/>. 
        /// If there is no failure returns success.
        /// </summary>
        /// <param name="errorMessagesSeparator">Separator for error messages.</param>
        /// <param name="results">List of results.</param>
        [DebuggerStepThrough]
        public static Result Combine(string errorMessagesSeparator, params Result[] results)
        {
            List<Result> failedResults = results.Where(x => x.IsFailure).ToList();

            if (!failedResults.Any())
                return Ok();

            string errorMessage = string.Join(errorMessagesSeparator, failedResults.Select(x => x.Error).ToArray());
            return Fail(errorMessage);
        }

        [DebuggerStepThrough]
        public static Result Combine(params Result[] results)
        {
            return Combine(ErrorMessagesSeparator, results);
        }

        [DebuggerStepThrough]
        public static Result Combine<T>(params Result<T>[] results)
        {
            return Combine(ErrorMessagesSeparator, results);
        }

        [DebuggerStepThrough]
        public static Result Combine<T>(string errorMessagesSeparator, params Result<T>[] results)
        {
            Result[] untyped = results.Select(result => (Result)result).ToArray();
            return Combine(errorMessagesSeparator, untyped);
        }

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
            where E : class
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
            where E : class
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
    }

    public struct Result<T> : IResult, ISerializable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _logic.GetObjectData(info, context);

            if (IsSuccess)
            {
                info.AddValue("Value", Value);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;

        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsSuccess)
                    throw new ResultFailureException(Error);

                return _value;
            }
        }

        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, string error)
        {
            _logic = ResultCommonLogic.Create(isFailure, error);
            _value = value;
        }

        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
                return Result.Ok();
            else
                return Result.Fail(result.Error);
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out T value)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(T);
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out T value, out string error)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(T);
            error = IsFailure ? Error : null;
        }
    }

    public struct Result<T, E> : IResult, ISerializable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic<E> _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public E Error => _logic.Error;

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _logic.GetObjectData(info, context);

            if (IsSuccess)
            {
                info.AddValue("Value", Value);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;

        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsSuccess)
                    throw new ResultFailureException<E>(Error);

                return _value;
            }
        }

        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, E error)
        {
            _logic = new ResultCommonLogic<E>(isFailure, error);
            _value = value;
        }

        public static implicit operator Result(Result<T, E> result)
        {
            if (result.IsSuccess)
                return Result.Ok();
            else
                return Result.Fail(result.Error.ToString());
        }

        public static implicit operator Result<T>(Result<T, E> result)
        {
            if (result.IsSuccess)
                return Result.Ok(result.Value);
            else
                return Result.Fail<T>(result.Error.ToString());
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out T value)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(T);
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out T value, out E error)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(T);
            error = IsFailure ? Error : default(E);
        }
    }
}
