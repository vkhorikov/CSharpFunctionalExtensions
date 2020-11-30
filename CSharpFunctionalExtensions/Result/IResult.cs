namespace CSharpFunctionalExtensions
{
    public interface IResult
    {
        bool IsFailure { get; }
        bool IsSuccess { get; }
    }

    public interface IResult<E> : IResult
    {
        E Error { get; }
    }

    public interface IValue<out T>
    {
        T Value { get; }
    }

    public interface IResult<out T, E> : IResult<E>, IValue<T>
    {
    }
}
