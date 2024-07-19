using FlightDispatcher.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Models
{
    public class FlightRouteModel
    {
        public string Id { get; set; }

        public FlightRouteAirlineModel AirLine { get; set; }

        public FlightRouteAirportModel DepartureAirport { get; set; }
        public FlightRouteAirportModel ArrivalAirport { get; set; }

        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}
