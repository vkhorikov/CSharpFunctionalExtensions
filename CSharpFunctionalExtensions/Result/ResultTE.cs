using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result<T, E> : IResult, IValue<T>, ISerializable
    {
        private readonly ResultCommonLogic<E> _logic;
        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public E Error => _logic.Error;

        private readonly T _value;
        public T Value => IsSuccess ? _value : throw new ResultFailureException<E>(Error);

        internal Result(bool isFailure, E error, T value)
        {
            _logic = new ResultCommonLogic<E>(isFailure, error);
            _value = value;
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            _logic = ResultCommonLogic<E>.Deserialize(info);
            _value = _logic.IsFailure ? default : (T)info.GetValue("Value", typeof(T));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => _logic.GetObjectData(info, this);

        public static implicit operator Result<T, E>(T value) => Result.Success<T, E>(value);
    }
}
