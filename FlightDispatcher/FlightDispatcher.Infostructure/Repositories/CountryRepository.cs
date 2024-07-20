using FlightDispatcher.Domain.Documents;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Repositories
{
    public class CountryRepository : RepositoryBase<CountryDocument>
    {
        public CountryRepository(IMongoDatabase database) : base(database, "Countries")
        {
            
        }
    }
}
