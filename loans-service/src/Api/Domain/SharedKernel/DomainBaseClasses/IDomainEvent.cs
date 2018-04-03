namespace Gbm.Api.Scopes.Domain.SeedWork
{
    using System;

    public interface IDomainEvent
    {
        string EventName { get; set; }

        DateTime EventPublishedAt { get; set; }
    }
}
