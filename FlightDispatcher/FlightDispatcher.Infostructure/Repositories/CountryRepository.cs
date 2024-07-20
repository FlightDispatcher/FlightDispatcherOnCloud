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
    public class CountryRepository : RepositoryBase<CountryDocument>, ICountryRepository
    {
        public CountryRepository(IMongoDatabase database) : base(database, "Countries")
        {
            
        }
    }
}
