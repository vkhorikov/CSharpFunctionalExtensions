using CSharpFunctionalExtensions.Internal;
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public struct Result<T> : IResult, ISerializable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

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

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;

        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                if (!IsSuccess)
                    throw new ResultFailureException(Error);

                return _value;
            }
        }

        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, string error)
        {
            _logic = ResultCommonLogic.Create(isFailure, error);
            _value = value;
        }

        Result(SerializationInfo info, StreamingContext context)
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

            _logic = ResultCommonLogic.Create(isFailure, error);
            _value = value;
        }

        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
                return Result.Ok();
            else
                return Result.Fail(result.Error);
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

        public void Deconstruct(out bool isSuccess, out bool isFailure, out T value, out string error)
        {
            isSuccess = IsSuccess;
            isFailure = IsFailure;
            value = IsSuccess ? Value : default(T);
            error = IsFailure ? Error : null;
        }

        public Result<K> MapFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException($"{nameof(MapFailure)} failed because result is in success state");

            return Result.Fail<K>(Error);
        }

        public Result MapFailure()
        {
            if (IsSuccess)
                throw new InvalidOperationException($"{nameof(MapFailure)} failed because result is in success state");

            return Result.Fail(Error);
        }
    }
}