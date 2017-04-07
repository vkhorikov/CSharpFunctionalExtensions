using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace CSharpFunctionalExtensions
{
    internal sealed class ResultCommonLogic
    {
        public bool IsFailure { get; private set; }
        public bool IsSuccess => !IsFailure;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _error;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Exception _exception;

        public string Error
        {
            [DebuggerStepThrough]
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("There is no error message for success.");

                return _error;
            }
            private set { _error = value; }
        }

        public Exception Exception
        {
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("There is no exception for success.");

                if (_exception == null && !string.IsNullOrWhiteSpace(_error))
                    throw new InvalidOperationException("Result was created by passing in an error message instead of an exception.");

                return _exception;
            }
            private set { _exception = value; }
        }

        [DebuggerStepThrough]
        public static ResultCommonLogic CreateFailureCommonLogic(Exception exception)
        {
            if (exception is null)
                throw new ArgumentNullException(nameof(exception));

            return new ResultCommonLogic()
            {
                Exception = exception,
                Error = exception.ToString(),
                IsFailure = true
            };
        }

        [DebuggerStepThrough]
        public static ResultCommonLogic CreateFailureCommonLogic(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            return new ResultCommonLogic()
            {
                Error = errorMessage,
                IsFailure = true
            };
        }

        [DebuggerStepThrough]
        public static ResultCommonLogic CreateSuccessCommonLogic()
        {
            return new ResultCommonLogic()
            {
                IsFailure = false
            };
        }
    }


    public struct Result
    {
        private static readonly Result OkResult = new Result(false, error: string.Empty);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;
        public Exception Exception => _logic.Exception;

        [DebuggerStepThrough]
        private Result(bool isFailure, string error)
        {
            _logic = isFailure ? ResultCommonLogic.CreateFailureCommonLogic(error) : ResultCommonLogic.CreateSuccessCommonLogic();
        }

        [DebuggerStepThrough]
        private Result(bool isFailure, Exception exception)
        {
            _logic = isFailure ? ResultCommonLogic.CreateFailureCommonLogic(exception) : ResultCommonLogic.CreateSuccessCommonLogic();
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
        public static Result Fail(Exception exception)
        {
            return new Result(true, exception);
        }

        [DebuggerStepThrough]
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(false, value);
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(true, default(T), error);
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(Exception exception)
        {
            return new Result<T>(true, default(T), exception);
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
            return Combine(", ", results);
        }

        [DebuggerStepThrough]
        public static Result Combine<T>(params Result<T>[] results)
        {
            return Combine(", ", results);
        }

        [DebuggerStepThrough]
        public static Result Combine<T>(string errorMessagesSeparator, params Result<T>[] results)
        {
            Result[] untyped = results.Select(result => (Result)result).ToArray();
            return Combine(errorMessagesSeparator, untyped);
        }
    }


    public struct Result<T>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        public bool IsFailure =>  _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;
        public Exception Exception => _logic.Exception;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;

        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException("There is no value for failure.");

                return _value;
            }
        }

        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, string error)
        {
            if (!isFailure && value == null)
                throw new ArgumentNullException(nameof(value), "For successful result, you need to pass in a value.");

            _logic = isFailure ? ResultCommonLogic.CreateFailureCommonLogic(error) : ResultCommonLogic.CreateSuccessCommonLogic();
            _value = value;
        }

        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, Exception exception = null)
        {
            if (!isFailure && value == null)
                throw new ArgumentNullException(nameof(value), "For successful result, you need to pass in a value.");

            _logic = isFailure ? ResultCommonLogic.CreateFailureCommonLogic(exception) : ResultCommonLogic.CreateSuccessCommonLogic();
            _value = value;
        }

        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
                return Result.Ok();
            else
                return Result.Fail(result.Error);
        }
    }
}
