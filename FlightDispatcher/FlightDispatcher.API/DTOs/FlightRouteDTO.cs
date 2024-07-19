using FlightDispatcher.Domain.Models;

namespace FlightDispatcher.API.DTOs
{
    public class FlightRouteDTO
    {
        public string Id { get; set; }

        public FlightRouteAirlineDTO AirLine { get; set; }

        public FlightRouteAirportDTO DepartureAirport { get; set; }
        public FlightRouteAirportDTO ArrivalAirport { get; set; }

        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}
