using System;
using LoanService.Api.Domain.UserAggregate;
using StackExchange.Redis;

namespace LoanService.Api.Infrastructure.IntegrationEventSubscribers 
{
    public class UserCreatedSubscriber : IIntegrationEventSubscriber
    {
        ConnectionMultiplexer redisConn;
        private IUserRepository repo; 

        public UserCreatedSubscriber(IUserRepository repository)
        {
            this.repo = repository;
            var conn = Environment.GetEnvironmentVariable("REDIS_HOST");
            if (!String.IsNullOrEmpty(conn))
            {
                redisConn = ConnectionMultiplexer.Connect(conn);
            }
        }

        public void Subscribe()
        {
            if (redisConn != null && redisConn.IsConnected)
            {
                var subscriber = redisConn.GetSubscriber();
                subscriber.Subscribe("userCreated", (channel, message) => this.HandleEvent(message));
            }
        }

        public void HandleEvent(RedisValue message)
        {
            Console.WriteLine("Redis value message");
            Console.WriteLine(message);
        }
    }
}