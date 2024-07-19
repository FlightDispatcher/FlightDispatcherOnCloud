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
    public class FlightRouteRepository : IFlightRouteRepository
    {
        private readonly IMongoCollection<FlightRouteDocument> _collection;

        public FlightRouteRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<FlightRouteDocument>("FlighRoutes");
        }

        #region CRUD Methods
        public async Task<FlightRouteDocument> Create(FlightRouteDocument document)
        {
            await _collection.InsertOneAsync(document);
            return document;
        }

        public async Task Delete(ObjectId id)
        {
            await _collection.DeleteOneAsync(doc => doc.Id == id);
        }

        public async Task<List<FlightRouteDocument>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<FlightRouteDocument> GetById(ObjectId id)
        {
            return await _collection.Find(doc => doc.Id == id).FirstOrDefaultAsync();
        }

        public async Task<FlightRouteDocument> Update(FlightRouteDocument document)
        {
            await _collection.ReplaceOneAsync(doc => doc.Id == document.Id, document);
            return document;
        }
        #endregion
    }
}
