using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Interfaces
{
    public interface IRepositoryErasable
    {
        /// <summary>
        /// Deletes a document from the repository by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the document to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task Delete(ObjectId id);
    }
}
