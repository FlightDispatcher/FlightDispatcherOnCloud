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
    /// Repository implementation for managing flight route documents in a MongoDB collection.
    /// </summary>
    public class FlightRouteRepository : RepositoryFullCRUD<FlightRouteDocument>, IFlightRouteRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightRouteRepository"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database.</param>
        public FlightRouteRepository(IMongoDatabase database) : base(database, "FlightRoutes")
        {
            
        }
    }
}
