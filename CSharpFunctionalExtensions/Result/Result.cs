using CSharpFunctionalExtensions.Internal;
using System;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions
{
    [Serializable]
    public partial struct Result : IResult<string>, ISerializable
    {
        private readonly ResultCommonLogic<string> _logic;
        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public string Error => _logic.Error;

        private Result(bool isFailure, string error)
        {
            _logic = new ResultCommonLogic<string>(isFailure, error);
        }

        private Result(SerializationInfo info, StreamingContext context)
        {
            _logic = ResultCommonLogic<string>.Deserialize(info);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            => _logic.GetObjectData(info);
        
        public static implicit operator UnitResult<string>(Result result)
            => result.IsSuccess
                ? Success<string>()
                : Failure(result.Error);
    }
}
