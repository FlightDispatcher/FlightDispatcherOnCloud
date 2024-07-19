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
    public class AirlineRepository : IAirlineRepository
    {
        private readonly IMongoCollection<AirLineDocument> _collection;

        public AirlineRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<AirLineDocument>("AirLine");
        }

        #region CRUD Methods
        public async Task<List<AirLineDocument>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<AirLineDocument> GetById(ObjectId id)
        {
            return await _collection.Find(doc => doc.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AirLineDocument> Create(AirLineDocument document)
        {
            await _collection.InsertOneAsync(document);
            return document;
        }

        public async Task<AirLineDocument> Update(AirLineDocument document)
        {
            await _collection.ReplaceOneAsync(doc => doc.Id == document.Id, document);
            return document;
        }

        public async Task Delete(ObjectId id)
        {
            await _collection.DeleteOneAsync(doc => doc.Id == id);
        }
        #endregion
    }
}
