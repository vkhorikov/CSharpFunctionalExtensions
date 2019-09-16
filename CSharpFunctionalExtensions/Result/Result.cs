using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result : IResult, ISerializable
    {
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _logic.GetObjectData(info, context);
        }

        private ResultCommonLogic<string> _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;

        private Result(bool isFailure, string error)
        {
            _logic = ResultCommonLogic<string>.Create(isFailure, error);
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            bool isFailure = info.GetBoolean("IsFailure");
            string error = isFailure ? info.GetString("Error") : null;

            _logic = ResultCommonLogic<string>.Create(isFailure, error);
        }

        public Result<T> MapFailure<T>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Messages.MapFailureExceptionOnSuccess);

            return Fail<T>(Error);
        }
    }
}