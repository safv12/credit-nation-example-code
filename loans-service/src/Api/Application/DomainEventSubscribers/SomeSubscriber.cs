namespace Gbm.Api.Scopes.Services.DomainEventSubscribers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using LoanService.Api.Domain.LoanAggregate.DomainEvents;
    using Microsoft.Extensions.Logging;

    public class SomeSubscriber : DomainEventSubscriber<LoanCreated>
    {
        protected override async Task EventHandler(LoanCreated eventData)
        {
            Console.WriteLine($"Domain event received, loanId: {eventData.LoanId}");

            // TODO: Handle the event in a real way
            await Task.FromResult(eventData);
        }
    }
}