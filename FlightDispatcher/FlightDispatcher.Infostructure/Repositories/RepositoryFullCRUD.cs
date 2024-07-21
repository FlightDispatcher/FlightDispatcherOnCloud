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
    /// <summary>
    /// Full CRUD repository implementation for managing documents in a MongoDB collection.
    /// </summary>
    /// <typeparam name="T">The type of document managed by this repository.</typeparam>
    public class RepositoryFullCRUD<T> : RepositoryEditable<T>, IRepositoryErasable where T : IDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryFullCRUD{T}"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database.</param>
        /// <param name="collectionName">The name of the collection.</param>
        public RepositoryFullCRUD(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
            
        }

        #region Delete method

        /// <summary>
        /// Deletes a document from the collection by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the document to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Delete(ObjectId id)
        {
            await _collection.DeleteOneAsync(doc => doc.Id == id);
        }
        #endregion
    }
}
