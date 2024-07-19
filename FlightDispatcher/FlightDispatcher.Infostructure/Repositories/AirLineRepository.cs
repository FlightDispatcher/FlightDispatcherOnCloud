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
        private readonly IMongoCollection<AirlineDocument> _collection;

        public AirlineRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<AirlineDocument>("Airlines");
        }

        #region CRUD Methods
        public async Task<List<AirlineDocument>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<AirlineDocument> GetById(ObjectId id)
        {
            return await _collection.Find(doc => doc.Id == id).FirstOrDefaultAsync();
        }

        public async Task<AirlineDocument> Create(AirlineDocument document)
        {
            await _collection.InsertOneAsync(document);
            return document;
        }

        public async Task<AirlineDocument> Update(AirlineDocument document)
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
