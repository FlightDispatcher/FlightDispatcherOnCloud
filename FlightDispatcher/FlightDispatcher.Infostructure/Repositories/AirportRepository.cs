using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Infostructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing airport documents in a MongoDB collection.
    /// </summary>
    public class AirportRepository : RepositoryFullCRUD<AirportDocument>, IAirportRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirportRepository"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database.</param>
        public AirportRepository(IMongoDatabase database): base(database, "Airports")
        {
            
        }
    }
}
