using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result<T, E> : IResult<T, E>, IValue<T>, ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly E _error;
        public E Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new ResultFailureException<E>(Error);

        internal Result(bool isFailure, E error, T value)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
            _value = value;
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            var values = ResultCommonLogic.Deserialize<E>(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
            _value = IsFailure ? default : (T)info.GetValue("Value", typeof(T));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) =>
            ResultCommonLogic.GetObjectData(this, info, this);

        public static implicit operator Result<T, E>(T value)
        {
            if (value is IResult<T, E> result)
            {
                E resultError = result.IsFailure ? result.Error : default;
                T resultValue = result.IsSuccess ? result.Value : default;

                return new Result<T, E>(result.IsFailure, resultError, resultValue);
            }

            return Result.Success<T, E>(value);
        }

        public static implicit operator Result<T, E>(E error)
        {
            if (error is IResult<T, E> result)
            {
                E resultError = result.IsFailure ? result.Error : default;
                T resultValue = result.IsSuccess ? result.Value : default;

                return new Result<T, E>(result.IsFailure, resultError, resultValue);
            }

            return Result.Failure<T, E>(error);
        }
    }
}
