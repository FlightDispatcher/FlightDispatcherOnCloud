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
    public class AirportRepository : IAirportRepository
    {
        private readonly IMongoCollection<AirportDocument> _collection;

        public AirportRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<AirportDocument>("Airports");
        }

        #region CRUD Methods
        public async Task<AirportDocument> Create(AirportDocument document)
        {
            await _collection.InsertOneAsync(document);
            return document;
        }

        public async Task Delete(ObjectId id)
        {
            await _collection.DeleteOneAsync(doc => doc.Id == id);
        }

        public async Task<List<AirportDocument>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<AirportDocument> GetById(ObjectId id)
        {
            return await _collection.Find(doc => doc.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AirportDocument> Update(AirportDocument document)
        {
            await _collection.ReplaceOneAsync(doc => doc.Id == document.Id, document);
            return document;
        }
        #endregion
    }
}
