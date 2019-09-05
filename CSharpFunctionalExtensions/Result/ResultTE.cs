using CSharpFunctionalExtensions.Internal;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public struct Result<T, E> : IResult, ISerializable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic<E> _logic;

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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;

        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsSuccess)
                    throw new ResultFailureException<E>(Error);

                return _value;
            }
        }

        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, E error)
        {
            _logic = new ResultCommonLogic<E>(isFailure, error);
            _value = value;
        }

        Result(SerializationInfo info, StreamingContext context)
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

            _logic = new ResultCommonLogic<E>(isFailure, error);
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

        public void Deconstruct(out bool isSuccess, out bool isFailure)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out T value)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(T);
        }

        public void Deconstruct(out bool isSuccess, out bool isFailure, out T value, out E error)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(T);
            error = IsFailure ? Error : default(E);
        }

        public Result<K, E> MapFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException($"{nameof(MapFailure)} failed because result is in success state");

            return Result.Fail<K, E>(Error);
        }
    }
}