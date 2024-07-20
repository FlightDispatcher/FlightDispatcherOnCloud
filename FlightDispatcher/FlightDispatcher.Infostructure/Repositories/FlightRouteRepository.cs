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
    public class FlightRouteRepository : RepositoryFullCRUD<FlightRouteDocument>, IFlightRouteRepository
    {

        public FlightRouteRepository(IMongoDatabase database) : base(database, "FlightRoutes")
        {
            
        }
    }
}
