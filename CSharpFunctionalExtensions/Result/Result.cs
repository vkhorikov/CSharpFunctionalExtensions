using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public readonly partial struct Result : IResult, ISerializable
    {
        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;

        private readonly string _error;
        public string Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

        private Result(bool isFailure, string error)
        {
            IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
            _error = error;
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            SerializationValue<string> values = ResultCommonLogic.Deserialize(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ResultCommonLogic.GetObjectData(this, info);
        }

        public static implicit operator UnitResult<string>(in Result result)
        {
            if (result.IsSuccess)
                return UnitResult.Success<string>();
            else
                return UnitResult.Failure(result.Error);
        }
    }
}
