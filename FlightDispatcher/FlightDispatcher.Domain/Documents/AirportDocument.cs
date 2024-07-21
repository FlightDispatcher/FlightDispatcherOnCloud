using FlightDispatcher.Domain.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Documents
{
    /// <summary>
    /// Represents an airport document in the MongoDB collection.
    /// </summary>
    public class AirportDocument: IDocument
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

        /// <summary>
        /// Gets or sets the ICAO code of the airport.
        /// </summary>
        public string ICAO { get; set; }

        /// <summary>
        /// Gets or sets the location of the airport (e.g., city).
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the country where the airport is located.
        /// </summary>
        public string Country { get; set; }
    }
}
