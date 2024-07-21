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
    /// Repository implementation for managing airline documents in a MongoDB collection.
    /// </summary>
    public class AirlineRepository : RepositoryFullCRUD<AirlineDocument>, IAirlineRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirlineRepository"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database.</param>
        public AirlineRepository(IMongoDatabase database): base(database, "Airlines")
        {
            
        }

        /// <summary>
        /// Retrieves an airline document by its IATA code.
        /// </summary>
        /// <param name="iata">The IATA code of the airline.</param>
        /// <returns>The airline document with the specified IATA code.</returns>
        public async Task<AirlineDocument> GetByIATACode(string iata)
        {
            return await _collection.Find(doc => doc.IATA == iata).FirstOrDefaultAsync();
        }
    }
}
