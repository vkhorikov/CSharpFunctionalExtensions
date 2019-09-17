namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static Result Failure(string error)
        {
            return new Result(true, error);
        }

        public static Result<T> Failure<T>(string error)
        {
            return new Result<T>(true, error, default);
        }

        public static Result<T, E> Failure<T, E>(E error)
        {
            return new Result<T, E>(true, error, default);
        }
    }
}
