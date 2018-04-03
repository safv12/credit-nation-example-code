using System;
using Gbm.Api.Scopes.Domain.SeedWork;

namespace LoanService.Api.Domain.LoanAggregate.DomainEvents
{
    public class LoanCreated : IDomainEvent
    {
        public LoanCreated(Guid id)
        {
            this.LoanId = id;
            this.EventName = "LoanCreated";
            this.EventPublishedAt = DateTime.Now;
        }

        public Guid LoanId { get; private set; }

        public string EventName { get; set; }

        public DateTime EventPublishedAt { get; set; }
    }
}