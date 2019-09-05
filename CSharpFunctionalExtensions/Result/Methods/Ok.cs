using System.Diagnostics;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        [DebuggerStepThrough]
        public static Result Ok()
        {
            return new Result(false, default);
        }

        [DebuggerStepThrough]
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(false, value, default);
        }

        [DebuggerStepThrough]
        public static Result<T, E> Ok<T, E>(T value)
        {
            return new Result<T, E>(false, value, default);
        }
    }
}
