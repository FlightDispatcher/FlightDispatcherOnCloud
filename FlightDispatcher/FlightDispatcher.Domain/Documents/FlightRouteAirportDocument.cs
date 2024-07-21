using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Documents
{
    /// <summary>
    /// Represents an airport document specifically for flight routes.
    /// </summary>
    public class FlightRouteAirportDocument
    {
        /// <summary>
        /// Gets or sets the unique identifier of the airport.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the airport.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IATA code of the airport.
        /// </summary>
        public string IATA { get; set; }
    }
}
