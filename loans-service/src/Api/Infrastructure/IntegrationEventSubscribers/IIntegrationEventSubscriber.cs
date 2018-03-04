using StackExchange.Redis;

namespace LoanService.Api.Infrastructure.IntegrationEventSubscribers 
{
    public interface IIntegrationEventSubscriber
    {
        void Subscribe();

        void HandleEvent(RedisValue message);
    }
}