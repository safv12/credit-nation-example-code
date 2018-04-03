namespace Gbm.Api.Scopes.Domain.SeedWork
{
    using System.Collections.Generic;
    using System.Linq;
    using LoanService.Api.Domain.SharedKernel;

    public class AggregateRoot<TId> : Entity<TId>
    {
        private readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        protected AggregateRoot(TId id)
            : base(id)
        {
        }

        public virtual IReadOnlyList<IDomainEvent> DomainEvents => this.domainEvents;

        public virtual void Dispatch()
        {
            if (!this.domainEvents.Any())
            {
                return;
            }

            foreach (var domainEvent in this.domainEvents)
            {
                DomainEventPublisher.PublishEvent(domainEvent);
            }

            this.ClearEvents();
        }

        public virtual void ClearEvents()
        {
            this.domainEvents.Clear();
        }

        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            this.domainEvents.Add(newEvent);
        }
    }
}
