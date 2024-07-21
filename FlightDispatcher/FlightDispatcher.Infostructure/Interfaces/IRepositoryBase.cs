using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infrastructure.Interfaces
{
    public interface IRepositoryBase<TDocument>
    {
        /// <summary>
        /// Retrieves all documents from the repository.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a list of all documents as the result.</returns>
        Task<List<TDocument>> GetAll();

        /// <summary>
        /// Retrieves a document by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the document to retrieve.</param>
        /// <returns>A task representing the asynchronous operation, with the document as the result. 
        /// If no document with the specified id is found, the result will be null.</returns>
        Task<TDocument> GetById(ObjectId id);
    }
}
