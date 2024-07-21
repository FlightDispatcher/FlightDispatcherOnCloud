using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Models
{
    /// <summary>
    /// Represents a model for a country.
    /// </summary>
    public class CountryModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the country.
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the code of the country (ISO country code).
        /// </summary>
        public string Code { get; set; }
    }
}
