using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Domain.Models
{
    /// <summary>
    /// Represents a model for a flight route.
    /// </summary>
    public class FlightRouteModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the flight route.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the airline associated with the flight route.
        /// </summary>
        public FlightRouteAirlineModel AirLine { get; set; }

        /// <summary>
        /// Gets or sets the departure airport associated with the flight route.
        /// </summary>
        public FlightRouteAirportModel DepartureAirport { get; set; }

        /// <summary>
        /// Gets or sets the arrival airport associated with the flight route.
        /// </summary>
        public FlightRouteAirportModel ArrivalAirport { get; set; }

        /// <summary>
        /// Gets or sets the Flight Number of the flight route.
        /// </summary>
        public string FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets the departure time of the flight route.
        /// </summary>
        public string DepartureTime { get; set; }

        /// <summary>
        /// Gets or sets the arrival time of the flight route.
        /// </summary>
        public string ArrivalTime { get; set; }
    }
}
