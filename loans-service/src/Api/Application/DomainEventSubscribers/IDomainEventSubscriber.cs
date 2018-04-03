namespace Gbm.Api.Scopes.Services.DomainEventSubscribers
{
    using System;
    using System.Reactive.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Gbm.Api.Scopes.Domain.SeedWork;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public interface IDomainEventSubscriber
    {
        void Subscribe();

        void Unsubscribe();
    }

    public abstract class DomainEventSubscriber<T> : IDomainEventSubscriber
        where T : IDomainEvent
    {
        private IDisposable subscriberDisposer;

        public void Subscribe()
        {
            this.subscriberDisposer = DomainEventPublisher
                .DomainEvent
                .Where(domainEvent => domainEvent is T)
                .Subscribe(async domainEvent =>
                {
                    try
                    {
                        await this.EventHandler((T)domainEvent).ConfigureAwait(false);
                    }
                    catch (Exception error)
                    {
                        Console.WriteLine($"An error ocurred while handling domain event: {error.Message}");
                    }
                });
        }

        public void Unsubscribe()
        {
            this.subscriberDisposer.Dispose();
        }

        protected virtual Task EventHandler(T eventInstance) => throw new NotImplementedException();
    }
}