using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace PubSubRedis.Subscriber
{
    public class FlightsHostedService : BackgroundService
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly ISubscriber _redisSubscriber;

        public FlightsHostedService(ConnectionMultiplexer redis)
        {
            _redis = redis;
            _redisSubscriber = _redis.GetSubscriber();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _redisSubscriber.SubscribeAsync("Flights", (channel, flight) =>
             {
                 Console.WriteLine("Adding new flight to Database...");
                 Console.WriteLine(flight);
             });

        }
    }
}
