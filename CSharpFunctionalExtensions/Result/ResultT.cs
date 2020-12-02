using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result<T> : IResult<T, string>, ISerializable
    {
        private readonly ResultCommonLogic<string> _logic;
        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;

        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new ResultFailureException(Error);

        internal Result(bool isFailure, string error, T value)
        {
            _logic = new ResultCommonLogic<string>(isFailure, error);
            _value = value;
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            _logic = ResultCommonLogic<string>.Deserialize(info);
            _value = _logic.IsFailure ? default : (T)info.GetValue("Value", typeof(T));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => _logic.GetObjectData(info, this);

        public static implicit operator Result<T>(T value)
        {
            if (value is IResult<T, string> result)
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
            => result.IsSuccess
                ? Result.Success<string>()
                : Result.Failure(result.Error);
    }
}
