namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static Result Success()
        {
            return new Result(false, default);
        }

        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(false, default, value);
        }

        public static Result<T, E> Success<T, E>(T value)
        {
            return new Result<T, E>(false, default, value);
        }
    }
}
