using FlightDispatcher.Domain.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Documents
{
    public class FlightRouteDocument: IDocument
    {
        public ObjectId Id { get; set; }

        public FlightRouteAirlineDocument AirLine { get; set; }

        public FlightRouteAirportDocument DepartureAirport { get; set; }
        public FlightRouteAirportDocument ArrivalAirport { get; set; }

        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}
