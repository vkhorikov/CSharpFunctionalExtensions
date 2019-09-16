using System;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public Result<K> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Messages.ConvertFailureExceptionOnSuccess);

            return Fail<K>(Error);
        }
    }

    public partial struct Result<T>
    {
        public Result ConvertFailure()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);

            return Result.Fail(Error);
        }

        public Result<K> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);

            return Result.Fail<K>(Error);
        }
    }

    public partial struct Result<T, E>
    {
        public Result<K, E> ConvertFailure<K>()
        {
            if (IsSuccess)
                throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);

            return Result.Fail<K, E>(Error);
        }
    }
}
