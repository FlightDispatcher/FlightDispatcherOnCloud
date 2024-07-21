using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Infrastructure.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infrastructure.Repositories
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

        /// <summary>
        /// Retrieves an airport document by its IATA code.
        /// </summary>
        /// <param name="code">The IATA code of the airport.</param>
        /// <returns>The airport document with the specified IATA code.</returns>
        public async Task<AirportDocument> GetByIATACode(string code)
        {
            return await _collection.Find(doc => doc.IATA == code).FirstOrDefaultAsync();
        }
    }
}
