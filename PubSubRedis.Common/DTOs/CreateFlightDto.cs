using System;

namespace PubSubRedis.Common.DTOs
{
    public record CreateFlightDto
    {
        public string FlightNumber { get; init; }
        public string Origin { get; init; }
        public string Destination { get; init; }
        public string Airline { get; init; }
        public DateTime DepartureDate { get; init; }
    }
}
