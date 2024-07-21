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
    /// Represents a country document in the MongoDB collection.
    /// </summary>
    public class CountryDocument : IDocument
    {
        /// <summary>
        /// Gets or sets the unique identifier of the country.
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the country (ISO country code).
        /// </summary>
        public string Code { get; set; }
    }
}
