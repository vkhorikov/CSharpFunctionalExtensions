using System.Linq;
using System.Runtime.Serialization;
using CSharpFunctionalExtensions.Internal;

namespace CSharpFunctionalExtensions
{
    public readonly struct UnitResult<TErr> : IResult, IValue<Unit>, ISerializable
    {
        private readonly ResultCommonLogic<TErr> _logic;

        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;
        public TErr Error => _logic.Error;
        public Unit Value => IsSuccess ? Unit.Default : throw new ResultFailureException<TErr>(Error); 
        
        internal UnitResult(bool isFailure, TErr error)
            => _logic = new ResultCommonLogic<TErr>(isFailure, error);
	 
        private UnitResult(SerializationInfo info, StreamingContext context)
            => _logic = ResultCommonLogic<TErr>.Deserialize(info);

        public void GetObjectData(SerializationInfo info, StreamingContext context)
            => _logic.GetObjectData(info, this);
    }
}