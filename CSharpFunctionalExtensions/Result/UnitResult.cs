using System;
using System.Runtime.Serialization;
using CSharpFunctionalExtensions.Internal;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    ///     Represents the result of an operation that has no return value on success, or an error on failure.
    /// </summary>
    /// <typeparam name="E">
    ///     The error type returned by a failed operation.
    /// </typeparam>
    [Serializable]
    public partial struct UnitResult<E> : IUnitResult<E>, ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly E _error;
        public E Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        internal UnitResult(bool isFailure, E error)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
        }

        private UnitResult(SerializationInfo info, StreamingContext context)
        {
            SerializationValue<E> values = ResultCommonLogic.Deserialize<E>(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ResultCommonLogic.GetObjectData(this, info);
        }

        public static implicit operator UnitResult<E>(E error)
        {
            if (error is IUnitResult<E> result)
            {
                E resultError = result.IsFailure ? result.Error : default;
                return new UnitResult<E>(result.IsFailure, resultError);
            }

            return UnitResult.Failure(error);
        }
    }

    /// <summary>
    /// Alternative entrypoint for <see cref="UnitResult{E}" /> to avoid ambiguous calls
    /// </summary>
    public static class UnitResult
    {
        /// <summary>
        ///     Creates a failure result with the given error.
        /// </summary>
        public static UnitResult<E> Failure<E>(E error)
        {
            return new UnitResult<E>(true, error);
        }

        /// <summary>
        ///     Creates a success result containing the given error.
        /// </summary>
        public static UnitResult<E> Success<E>()
        {
            return Result.Success<E>();
        }
    }
}
