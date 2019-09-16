namespace CSharpFunctionalExtensions
{
    public partial struct Result
    {
        public static Result Ok()
        {
            return new Result(false, default);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(false, default, value);
        }

        public static Result<T, E> Ok<T, E>(T value)
        {
            return new Result<T, E>(false, default, value);
        }
    }
}
