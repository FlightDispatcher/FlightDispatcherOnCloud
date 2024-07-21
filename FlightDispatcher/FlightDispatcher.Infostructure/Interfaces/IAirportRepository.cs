using FlightDispatcher.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface for airport repository, providing methods to perform CRUD operations on AirportDocument.
    /// </summary>
    public interface IAirportRepository: IRepositoryBase<AirportDocument>, IRepositoryEditable<AirportDocument>, IRepositoryErasable
    {
        // This interface inherits methods for retrieving, creating, updating, and deleting airport documents.
        // IRepositoryBase<AirportDocument> provides methods to get all documents and to get a document by its ID.
        // IRepositoryEditable<AirportDocument> provides methods to create and update documents.
        // IRepositoryErasable provides a method to delete a document by its ID.

        /// <summary>
        /// Retrieves an airport document by its IATA code.
        /// </summary>
        /// <param name="code">The IATA code of the airport.</param>
        /// <returns>The airport document with the specified IATA code.</returns>
        Task<AirportDocument> GetByIATACode(string code);
    }
}
