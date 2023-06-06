using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public interface IAggregateRoot<TDomainEvent>
    {
        IEnumerable<TDomainEvent> DomainEvents { get; }
    }
}