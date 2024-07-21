using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Interfaces;
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
    /// Base repository implementation for reading data from a MongoDB collection.
    /// </summary>
    /// <typeparam name="T">The type of document managed by this repository.</typeparam>
    public class RepositoryBase<T> : IRepositoryBase<T> where T : IDocument
    {
        /// <summary>
        /// The MongoDB collection used by this repository.
        /// </summary>
        protected readonly IMongoCollection<T> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database.</param>
        /// <param name="collectionName">The name of the collection.</param>
        public RepositoryBase(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }

        #region Read Methods

        /// <summary>
        /// Retrieves all documents from the collection.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a list of all documents as the result.</returns>
        public async Task<List<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        /// <summary>
        /// Retrieves a document by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the document to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, with the document as the result. 
        /// If no document with the specified id is found, the result will be null.</returns>
        public async Task<T> GetById(ObjectId id)
        {
            return await _collection.Find(doc => doc.Id == id).FirstOrDefaultAsync();
        }
        #endregion

    }
}
