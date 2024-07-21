using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Infostructure.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Repositories
{
    /// <summary>
    /// Repository implementation for managing country documents in a MongoDB collection.
    /// </summary>
    public class CountryRepository : RepositoryBase<CountryDocument>, ICountryRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database.</param>
        public CountryRepository(IMongoDatabase database) : base(database, "Countries")
        {
            
        }
    }
}
