using System;
using LoanService.Api.Domain.UserAggregate;
using StackExchange.Redis;
using Newtonsoft.Json;

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

        public async void HandleEvent(RedisValue message)
        {
            var json = message.ToString();
            Console.WriteLine($"Redis value message: {json}");
            var user = JsonConvert.DeserializeObject<User>(json);
            var userSaved = await repo.SaveUserAsync(user).ConfigureAwait(false);
            Console.WriteLine($"User saved data: {userSaved.Id}");
        }
    }
}