using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public interface IAggregateRoot<TDomainEvent>
    {
        IEnumerable<TDomainEvent> DomainEvents { get; }
    }

    public abstract class AggregateRoot<TId, TDomainEvent> : Entity<TId>, IAggregateRoot<TDomainEvent>
    {
        private readonly List<TDomainEvent> _domainEvents = new List<TDomainEvent>();
        public virtual IEnumerable<TDomainEvent> DomainEvents => _domainEvents;

        protected virtual void Raise(TDomainEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }

        protected virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}