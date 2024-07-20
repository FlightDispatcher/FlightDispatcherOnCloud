using FlightDispatcher.Domain.Interfaces;
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
    public class RepositoryFullCRUD<T> : RepositoryEditable<T>, IRepositoryErasable where T : IDocument
    {
        public RepositoryFullCRUD(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
            
        }

        #region Delete method
        public async Task Delete(ObjectId id)
        {
            await _collection.DeleteOneAsync(doc => doc.Id == id);
        }
        #endregion
    }
}
