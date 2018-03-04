using System;

namespace LoanService.Api.Infrastructure.IntegrationEventSubscribers 
{
    public class UserCreatedIntegrationEvent
    {
        public Guid UserId { get; set; }
    }
}