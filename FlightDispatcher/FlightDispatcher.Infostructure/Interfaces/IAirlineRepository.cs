using FlightDispatcher.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Interfaces
{
    /// <summary>
    /// Interface for airline repository, providing methods to perform CRUD operations on AirlineDocument.
    /// </summary>
    public interface IAirlineRepository : IRepositoryBase<AirlineDocument>, IRepositoryEditable<AirlineDocument>, IRepositoryErasable
    {
        // This interface inherits methods for retrieving, creating, updating, and deleting airline documents.
        // IRepositoryBase<AirlineDocument> provides methods to get all documents and to get a document by its ID.
        // IRepositoryEditable<AirlineDocument> provides methods to create and update documents.
        // IRepositoryErasable provides a method to delete a document by its ID.
    }
}
