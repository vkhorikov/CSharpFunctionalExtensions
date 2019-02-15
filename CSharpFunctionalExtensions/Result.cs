using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    internal class ResultCommonLogic<TError>
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TError _error;

        public TError Error
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
        public ResultCommonLogic(bool isFailure, TError error)
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

        public void GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            oInfo.AddValue("IsFailure", IsFailure);
            oInfo.AddValue("IsSuccess", IsSuccess);
            if (IsFailure)
            {
                oInfo.AddValue("Error", Error);
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

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            _logic.GetObjectData(oInfo, oContext);
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

        public static async Task<Result> Create(Func<Task<bool>> predicate, string error, bool continueOnCapturedContext = true)
        {
            bool isSuccess = await predicate().ConfigureAwait(continueOnCapturedContext);
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
        
        public static async Task<Result<T>> Create<T>(Func<Task<bool>> predicate, T value, string error, bool continueOnCapturedContext = true)
        {
            bool isSuccess = await predicate().ConfigureAwait(continueOnCapturedContext);
            return Create(isSuccess, value, error);
        }

        [DebuggerStepThrough]
        public static Result<TValue, TError> Ok<TValue, TError>(TValue value) where TError : class
        {
            return new Result<TValue, TError>(false, value, default(TError));
        }

        [DebuggerStepThrough]
        public static Result<TValue, TError> Fail<TValue, TError>(TError error) where TError : class
        {
            return new Result<TValue, TError>(true, default(TValue), error);
        }

        [DebuggerStepThrough]
        public static Result<TValue, TError> Create<TValue, TError>(bool isSuccess, TValue value, TError error) where TError : class
        {
            return isSuccess
                ? Ok<TValue, TError>(value)
                : Fail<TValue, TError>(error);
        }
        
        public static Result<TValue, TError> Create<TValue, TError>(Func<bool> predicate, TValue value, TError error) where TError : class
        {
            return predicate()
                ? Ok<TValue, TError>(value)
                : Fail<TValue, TError>(error);
        }
        
        public static async Task<Result<TValue, TError>> Create<TValue, TError>(Func<Task<bool>> predicate, TValue value, TError error, bool continueOnCapturedContext = true) where TError : class
        {
            bool isSuccess = await predicate().ConfigureAwait(continueOnCapturedContext);
            return isSuccess
                ? Ok<TValue, TError>(value)
                : Fail<TValue, TError>(error);
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
            catch(Exception exc)
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
            catch(Exception exc)
            {
                string message = errorHandler(exc);

                return Fail<T>(message);
            }
        }
        
        public static async Task<Result<T>> Try<T>(Func<Task<T>> func, Func<Exception, string> errorHandler = null, bool continueOnCapturedContext = true)
        {
            errorHandler = errorHandler ?? DefaultTryErrorHandler;
            
            try
            {
                var result = await func().ConfigureAwait(continueOnCapturedContext);
                
                return Ok(result);
            }
            catch(Exception exc)
            {
                string message = errorHandler(exc);

                return Fail<T>(message);
            }
        }
        
        public static Result<TValue, TError> Try<TValue, TError>(Func<TValue> func, Func<Exception, TError> errorHandler)
            where TError: class
        {
            try
            {
                return Ok<TValue, TError>(func());
            }
            catch(Exception exc)
            {
                TError error = errorHandler(exc);

                return Fail<TValue, TError>(error);
            }
        }
        
        public static async Task<Result<TValue, TError>> Try<TValue, TError>(Func<Task<TValue>> func, Func<Exception, TError> errorHandler, bool continueOnCapturedContext = true)
            where TError: class
        {
            try
            {
                var result = await func().ConfigureAwait(continueOnCapturedContext);
                
                return Ok<TValue, TError>(result);
            }
            catch(Exception exc)
            {
                TError error = errorHandler(exc);

                return Fail<TValue, TError>(error);
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

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            _logic.GetObjectData(oInfo, oContext);

            if (IsSuccess)
            {
                oInfo.AddValue("Value", Value);
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

    public struct Result<TValue, TError> : IResult, ISerializable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic<TError> _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public TError Error => _logic.Error;

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            _logic.GetObjectData(oInfo, oContext);

            if (IsSuccess)
            {
                oInfo.AddValue("Value", Value);
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly TValue _value;

        public TValue Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsSuccess)
                    throw new ResultFailureException<TError>(Error);

                return _value;
            }
        }

        [DebuggerStepThrough]
        internal Result(bool isFailure, TValue value, TError error)
        {
            _logic = new ResultCommonLogic<TError>(isFailure, error);
            _value = value;
        }

        public static implicit operator Result(Result<TValue, TError> result)
        {
            if (result.IsSuccess)
                return Result.Ok();
            else
                return Result.Fail(result.Error.ToString());
        }

        public static implicit operator Result<TValue>(Result<TValue, TError> result)
        {
            if (result.IsSuccess)
                return Result.Ok(result.Value);
            else
                return Result.Fail<TValue>(result.Error.ToString());
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out TValue value)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(TValue);
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out TValue value, out TError error)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(TValue);
            error = IsFailure ? Error : default(TError);
        }
    }
}
