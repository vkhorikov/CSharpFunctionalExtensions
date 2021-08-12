namespace CSharpFunctionalExtensions
{
    public interface IResult
    {
        bool IsFailure { get; }
        bool IsSuccess { get; }
    }

    public interface IValue<out T>
    {
        T Value { get; }
    }

    public interface IError<out E>
    {
        E Error { get; }
    }

    public interface IResult<out T, out E> : IResult, IValue<T>, IError<E>
    {
    }

    public interface IResult<out T> : IResult<T, string>
    {
    }

    public interface IUnitResult<out E> : IResult, IError<E>
    {
    }
}
