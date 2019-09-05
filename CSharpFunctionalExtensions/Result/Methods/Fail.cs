using System.Diagnostics;

namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        [DebuggerStepThrough]
        public static Result Fail(string error)
        {
            return new Result(true, error);
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(true, default, error);
        }

        [DebuggerStepThrough]
        public static Result<T, E> Fail<T, E>(E error)
        {
            return new Result<T, E>(true, default, error);
        }
    }
}
