namespace CSharpFunctionalExtensions
{
    public interface IEntity<TId>
    {
        TId Id { get; }
        bool Equals(object obj);
        bool IsTransient();
        int GetHashCode();
    }
}