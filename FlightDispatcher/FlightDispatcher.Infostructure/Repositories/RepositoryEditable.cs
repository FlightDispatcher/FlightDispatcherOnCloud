using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Interfaces;
using FlightDispatcher.Infostructure.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Repositories
{
    public class RepositoryEditable<T> : RepositoryBase<T>, IRepositoryEditable<T> where T : IDocument
    {
        public RepositoryEditable(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
            
        }

        #region Create / Update Methods
        public async Task<T> Create(T document)
        {
            await _collection.InsertOneAsync(document);
            return document;
        }

        public async Task<T> Update(T document)
        {
            await _collection.ReplaceOneAsync(doc => doc.Id == document.Id, document);
            return document;
        }
        #endregion

    }
}
