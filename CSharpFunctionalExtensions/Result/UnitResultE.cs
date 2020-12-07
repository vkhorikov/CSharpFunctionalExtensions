using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    ///     Represents the result of an operation that has no return value on success, or an error on failure.</summary>
    /// <typeparam name="E">
    ///     The error type returned by a failed operation.</typeparam>
    [Serializable]
    public partial struct UnitResult<E> : IResult<E>, ISerializable
    {
        private readonly ResultCommonLogic<E> _logic;
        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public E Error => _logic.Error;

        internal UnitResult(bool isFailure, E error)
        {
            _logic = new ResultCommonLogic<E>(isFailure, error);
        }

        private UnitResult(SerializationInfo info, StreamingContext context)
        {
            _logic = ResultCommonLogic<E>.Deserialize(info);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => _logic.GetObjectData(info);

        public static implicit operator UnitResult<E>(E error)
        {
            if (error is UnitResult<E> result)
                return result;

            //TODO: Implement UnitResult.Failure() factory method.
            return UnitResult.Failure<E>(error);
        }
    }
}
