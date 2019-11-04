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
}
