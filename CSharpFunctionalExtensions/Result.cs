using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace CSharpFunctionalExtensions
{
    public interface IResult
    {
        bool IsFailure { get; }
        bool IsSuccess { get; }
        string Error { get; }

        string PrivateError { get; }
    }


    public interface IResult<out T> : IResult
    {
        T Value { get; }
    }


    internal sealed class ResultCommonLogic
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _error;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _privateError;

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        public string Error
        {
            [DebuggerStepThrough]
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("There is no error message for success.");

                return _error;
            }
        }

        public string PrivateError
        {
            [DebuggerStepThrough]
            get
            {
                if (IsSuccess)
                    throw new InvalidOperationException("There is no private error message for success.");

                return _privateError;
            }
        }


        [DebuggerStepThrough]
        public ResultCommonLogic(bool isFailure, string error, string privateError = null)
        {
            if (isFailure)
            {
                if (string.IsNullOrEmpty(error))
                    throw new ArgumentNullException(nameof(error), "There must be error message for failure.");
            }
            else
            {
                if (error != null)
                    throw new ArgumentException("There should be no error message for success.", nameof(error));
                if (privateError != null)
                    throw new ArgumentException("There should be no private error message for success.", nameof(privateError));
            }

            IsFailure = isFailure;
            _error = error;
            _privateError = privateError ?? error;
        }
    }


    public struct Result : IResult
    {
        private static readonly Result OkResult = new Result(false, null);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;
        public string PrivateError => _logic.PrivateError;

        [DebuggerStepThrough]
        private Result(bool isFailure, string error, string privateError = null)
        {
            _logic = new ResultCommonLogic(isFailure, error, privateError);
        }

        [DebuggerStepThrough]
        public static Result Ok()
        {
            return OkResult;
        }

        [DebuggerStepThrough]
        public static Result Fail(string error, string privateError = null)
        {
            return new Result(true, error, privateError);
        }

        [DebuggerStepThrough]
        public static Result Fail(Exception ex)
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex), "Exception can't be null");

            return new Result(true, ex.Message, ex.ToString());
        }

        [DebuggerStepThrough]
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(false, value, null);
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(string error, string privateError = null)
        {
            return new Result<T>(true, default(T), error, privateError);
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(Exception ex)
        {
            if (ex == null) throw new ArgumentNullException(nameof(ex), "Exception can't be null");

            return new Result<T>(true, default(T), ex.Message, ex.ToString());
        }

        /// <summary>
        /// Returns first failure in the list of <paramref name="results"/>. If there is no failure returns success.
        /// </summary>
        /// <param name="results">List of results.</param>
        [DebuggerStepThrough]
        public static Result FirstFailureOrSuccess(params IResult[] results)
        {
            foreach (IResult result in results)
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
        public static Result Combine(string errorMessagesSeparator, params IResult[] results)
        {
            List<IResult> failedResults = results.Where(x => x.IsFailure).ToList();

            if (!failedResults.Any())
                return Ok();

            string errorMessage = string.Join(errorMessagesSeparator, failedResults.Select(x => x.Error).ToArray());
            string privateErrorMessage = string.Join(errorMessagesSeparator, failedResults.Select(x => x.PrivateError).ToArray());
            return Fail(errorMessage, privateErrorMessage);
        }

        [DebuggerStepThrough]
        public static Result Combine(params IResult[] results)
        {
            return Combine(", ", results);
        }

        public static Result FailOnException(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));

            try
            {
                action();
                return Ok();
            }
            catch (Exception ex)
            {
                return Fail(ex);
            }
        }

        public static Result<T> FailOnException<T>(Func<T> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));

            try
            {
                return Ok(func());
            }
            catch (Exception ex)
            {
                return Fail<T>(ex);
            }
        }
    }


    public struct Result<T> : IResult<T>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;
        public string PrivateError => _logic.PrivateError;

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
        internal Result(bool isFailure, T value, string error, string privateError = null)
        {
            if (!isFailure && value == null)
                throw new ArgumentNullException(nameof(value));

            _logic = new ResultCommonLogic(isFailure, error, privateError);
            _value = value;
        }
    }
}
