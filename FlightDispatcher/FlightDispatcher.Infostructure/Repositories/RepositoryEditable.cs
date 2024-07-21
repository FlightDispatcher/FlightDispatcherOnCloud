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
    /// <summary>
    /// Editable repository implementation for creating and updating documents in a MongoDB collection.
    /// </summary>
    /// <typeparam name="T">The type of document managed by this repository.</typeparam>
    public class RepositoryEditable<T> : RepositoryBase<T>, IRepositoryEditable<T> where T : IDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryEditable{T}"/> class.
        /// </summary>
        /// <param name="database">The MongoDB database.</param>
        /// <param name="collectionName">The name of the collection.</param>
        public RepositoryEditable(IMongoDatabase database, string collectionName) : base(database, collectionName)
        {
            
        }

        #region Create / Update Methods

        /// <summary>
        /// Creates a new document in the collection.
        /// </summary>
        /// <param name="document">The document to create.</param>
        /// <returns>A task representing the asynchronous operation, with the created document as the result.</returns>
        public async Task<T> Create(T document)
        {
            await _collection.InsertOneAsync(document);
            return document;
        }

        /// <summary>
        /// Updates an existing document in the collection.
        /// </summary>
        /// <param name="document">The document with updated information.</param>
        /// <returns>A task representing the asynchronous operation, with the updated document as the result.</returns>
        public async Task<T> Update(T document)
        {
            await _collection.ReplaceOneAsync(doc => doc.Id == document.Id, document);
            return document;
        }
        #endregion

    }
}
