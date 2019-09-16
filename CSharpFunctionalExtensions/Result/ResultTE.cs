using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result<T, E> : IResult, ISerializable
    {
        private ResultCommonLogic<E> _logic;

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

        private readonly T _value;

        public T Value => IsSuccess ? _value : throw new ResultFailureException<E>(Error);

        internal Result(bool isFailure, E error, T value)
        {
            _logic = ResultCommonLogic<E>.Create(isFailure, error);
            _value = value;
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            bool isFailure = info.GetBoolean("IsFailure");

            T value;
            E error;

            if (isFailure)
            {
                value = default(T);
                error = (E)info.GetValue("Error", typeof(E));
            }
            else
            {
                value = (T)info.GetValue("Value", typeof(T));
                error = default(E);
            }

            _logic = ResultCommonLogic<E>.Create(isFailure, error);
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
    }
}
