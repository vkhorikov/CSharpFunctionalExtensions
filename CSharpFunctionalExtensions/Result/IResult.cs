namespace CSharpFunctionalExtensions
{
    public interface IResult
    {
        bool IsFailure { get; }
        bool IsSuccess { get; }
    }

    public interface IValue<T>
    {
        T Value { get; }
    }
}
