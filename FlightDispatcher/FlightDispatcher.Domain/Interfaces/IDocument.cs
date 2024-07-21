using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Interfaces
{
    /// <summary>
    /// Interface representing a document stored in a MongoDB collection.
    /// </summary>
    public interface IDocument
    {
        /// <summary>
        /// Gets or sets the unique identifier of the document.
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
