using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public struct Result<T> : IResult, ISerializable
    {
        private ResultCommonLogic<string> _logic;

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

        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new ResultFailureException(Error);

        internal Result(bool isFailure, T value, string error)
        {
            _logic = ResultCommonLogic<string>.Create(isFailure, error);
            _value = value;
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            bool isFailure = info.GetBoolean("IsFailure");

            T value;
            string error;

            if (isFailure)
            {
                value = default(T);
                error = info.GetString("Error");
            }
            else
            {
                value = (T)info.GetValue("Value", typeof(T));
                error = null;
            }

            _logic = ResultCommonLogic<string>.Create(isFailure, error);
            _value = value;
        }

        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
                return Result.Ok();
            else
                return Result.Fail(result.Error);
        }

        public Result<K> MapFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.MapFailureExceptionOnSuccess);

            return Result.Fail<K>(Error);
        }

        public Result MapFailure()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.MapFailureExceptionOnSuccess);

            return Result.Fail(Error);
        }
    }
}