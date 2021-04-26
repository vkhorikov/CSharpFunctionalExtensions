using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result : IResult, ISerializable
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
            var values = ResultCommonLogic.Deserialize(info);
            IsFailure = values.IsFailure;
            _error = values.Error;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) =>
            ResultCommonLogic.GetObjectData(this, info);
    }
}
