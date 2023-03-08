using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public readonly partial struct Result<T> : IResult<T>, ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly string _error;
        public string Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new ResultFailureException(Error);

        internal Result(bool isFailure, string error, T value)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
            _value = value;
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            SerializationValue<string> values = ResultCommonLogic.Deserialize(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
            _value = IsFailure ? default : (T)info.GetValue("Value", typeof(T));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ResultCommonLogic.GetObjectData(this, info);
        }

        public T GetValueOrDefault(T defaultValue = default)
        {
            if (IsFailure)
                return defaultValue;

            return Value;
        }

        public static implicit operator Result<T>(T value)
        {
            if (value is IResult<T> result)
            {
                string resultError = result.IsFailure ? result.Error : default;
                T resultValue = result.IsSuccess ? result.Value : default;

                return new Result<T>(result.IsFailure, resultError, resultValue);
            }

            return Result.Success(value);
        }

        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
                return Result.Success();
            else
                return Result.Failure(result.Error);
        }

        public static implicit operator UnitResult<string>(Result<T> result)
        {
            if (result.IsSuccess)
                return UnitResult.Success<string>();
            else
                return UnitResult.Failure(result.Error);
        }
    }
}
