using FlightDispatcher.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace FlightDispatcher.API.DTOs
{
    public class FlightRouteDTO
    {
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        public FlightRouteAirlineDTO AirLine { get; set; }

        public FlightRouteAirportDTO DepartureAirport { get; set; }
        public FlightRouteAirportDTO ArrivalAirport { get; set; }

        [Required(ErrorMessage = "Departure time is required")]
        public string DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required")]
        public string ArrivalTime { get; set; }
    }
}
