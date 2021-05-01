using System;
using System.Threading.Tasks;
using PubSubRedis.Common.DTOs;
using StackExchange.Redis;

namespace PubSubRedis.Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ConnectionMultiplexer redis =
                await ConnectionMultiplexer.ConnectAsync("localhost");

            ISubscriber publisher = redis.GetSubscriber();

            while (true)
            {
                Console.WriteLine("Please enter Flight number:");
                string flightNumber = Console.ReadLine();

                Console.WriteLine("Please enter Origin:");
                string origin = Console.ReadLine();

                Console.WriteLine("Please enter Destination:");
                string destination = Console.ReadLine();


                Console.WriteLine("Please enter Airline:");
                string airLine = Console.ReadLine();

                Console.WriteLine("Please enter Departure Date:");
                string departureDate = Console.ReadLine();

                bool isDepartureDateParsed =
                    DateTime.TryParse(departureDate, out DateTime departureDateParsed);

                if (isDepartureDateParsed)
                {
                    CreateFlightDto createFlightDto = new()
                    {
                        Airline = airLine,
                        FlightNumber = flightNumber,
                        Origin = origin,
                        Destination = destination,
                        DepartureDate = departureDateParsed,
                    };

                    await publisher.PublishAsync("Flights", createFlightDto.ToString());

                }

                else
                {
                    continue;
                }


            }
        }
    }
}
