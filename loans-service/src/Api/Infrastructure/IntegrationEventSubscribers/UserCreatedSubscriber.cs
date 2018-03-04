using System;
using StackExchange.Redis;

namespace LoanService.Api.Infrastructure.IntegrationEventSubscribers 
{
    public class UserCreatedSubscriber : IIntegrationEventSubscriber
    {
        ConnectionMultiplexer redisConn;

        public UserCreatedSubscriber()
        {
            redisConn = ConnectionMultiplexer.Connect(Environment.GetEnvironmentVariable("REDIS_HOST"));
        }

        public void Subscribe()
        {
            var subscriber = redisConn.GetSubscriber();
            subscriber.Subscribe("userCreated", (channel, message) => this.HandleEvent(message));

        }

        public void HandleEvent(RedisValue message)
        {
            Console.WriteLine("Redis value message");
            Console.WriteLine(message);
        }
    }
}