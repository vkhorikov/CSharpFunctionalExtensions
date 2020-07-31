using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result<T> : IResult<T>, ISerializable
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
            if (value is Result<T> result)
                return result;

            return Result.Success(value);
        }

        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
                return Result.Success();
            else
                return Result.Failure(result.Error);
        }
    }
}
