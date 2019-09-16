namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static Result Fail(string error)
        {
            return new Result(true, error);
        }

        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(true, error, default);
        }

        public static Result<T, E> Fail<T, E>(E error)
        {
            return new Result<T, E>(true, error, default);
        }
    }
}
