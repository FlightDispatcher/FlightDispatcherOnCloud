using FlightDispatcher.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Documents
{
    /// <summary>
    /// Represents a flight route document in the MongoDB collection.
    /// </summary>
    public class FlightRouteDocument: IDocument
    {
        /// <summary>
        /// Gets or sets the unique identifier of the flight route.
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the airline associated with the flight route.
        /// </summary>
        public FlightRouteAirlineDocument AirLine { get; set; }

        /// <summary>
        /// Gets or sets the departure airport associated with the flight route.
        /// </summary>
        public FlightRouteAirportDocument DepartureAirport { get; set; }

        /// <summary>
        /// Gets or sets the arrival airport associated with the flight route.
        /// </summary>
        public FlightRouteAirportDocument ArrivalAirport { get; set; }

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
