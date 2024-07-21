using FlightDispatcher.Domain.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Interfaces
{
    /// <summary>
    /// Interface for country repository, providing methods to perform read operations on CountryDocument.
    /// </summary>
    public interface ICountryRepository: IRepositoryBase<CountryDocument>
    {
        // This interface inherits methods for retrieving country documents.
        // IRepositoryBase<CountryDocument> provides methods to get all documents and to get a document by its ID.

        /// <summary>
        /// Retrieves a country document by its ISO code.
        /// </summary>
        /// <param name="code">The ISO code of the country.</param>
        /// <returns>The country document with the specified code, or null if not found.</returns>
        Task<CountryDocument> GetByCode(string code);
    }
}
