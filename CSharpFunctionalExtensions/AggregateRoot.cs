using System.Collections.Generic;

namespace CSharpFunctionalExtensions
{
    public abstract class AggregateRoot<TDomainEvent> : Entity
    {
        private readonly List<TDomainEvent> _domainEvents = new List<TDomainEvent>();
        public virtual IReadOnlyList<TDomainEvent> DomainEvents => _domainEvents;

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