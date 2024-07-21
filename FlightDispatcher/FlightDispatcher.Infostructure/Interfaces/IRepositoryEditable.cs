using FlightDispatcher.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infrastructure.Interfaces
{
    public interface IRepositoryEditable<TDocument>
    {
        /// <summary>
        /// Creates a new document in the repository.
        /// </summary>
        /// <param name="document">The document to create.</param>
        /// <returns>A task representing the asynchronous operation, with the created document as the result.</returns>
        Task<TDocument> Create(TDocument document);

        /// <summary>
        /// Updates an existing document in the repository.
        /// </summary>
        /// <param name="document">The document with updated information.</param>
        /// <returns>A task representing the asynchronous operation, with the updated document as the result.</returns>
        Task<TDocument> Update(TDocument document);
    }
}
