using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Domain.DTOs
{
    public class FlightRouteDTO
    {
        public string? Id { get; set; }

        public FlightRouteAirlineDTO AirLine { get; set; }

        public FlightRouteAirportDTO DepartureAirport { get; set; }
        public FlightRouteAirportDTO ArrivalAirport { get; set; }

        [Required(ErrorMessage = "Flight Number is required")]
        public string FlightNumber { get; set; }

        [Required(ErrorMessage = "Departure time is required")]
        public string DepartureTime { get; set; }

        [Required(ErrorMessage = "Arrival time is required")]
        public string ArrivalTime { get; set; }
    }
}
