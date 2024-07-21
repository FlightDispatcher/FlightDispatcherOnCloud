using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Models
{
    /// <summary>
    /// Represents a model for an airport used in flight routes.
    /// </summary>
    public class FlightRouteAirportModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the airport.
        /// </summary>
        public string Id { get; set; }

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
