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
    /// Represents an airline document in the MongoDB collection.
    /// </summary>
    public class AirlineDocument: IDocument
    {
        /// <summary>
        /// Gets or sets the unique identifier of the airline.
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the airline.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the IATA code of the airline.
        /// </summary>
        public string IATA { get; set; }

        /// <summary>
        /// Gets or sets the ICAO code of the airline.
        /// </summary>
        public string ICAO { get; set; }
    }
}
