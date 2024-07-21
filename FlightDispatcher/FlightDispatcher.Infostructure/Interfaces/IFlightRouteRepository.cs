using FlightDispatcher.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for flight route repository, providing methods to perform CRUD operations on FlightRouteDocument.
    /// </summary>
    public interface IFlightRouteRepository: IRepositoryBase<FlightRouteDocument>, IRepositoryEditable<FlightRouteDocument>, IRepositoryErasable
    {
        // This interface inherits methods for retrieving, creating, updating, and deleting flight route documents.
        // IRepositoryBase<FlightRouteDocument> provides methods to get all documents and to get a document by its ID.
        // IRepositoryEditable<FlightRouteDocument> provides methods to create and update documents.
        // IRepositoryErasable provides a method to delete a document by its ID.
    }
}
