using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Helpers
{
    /// <summary>
    /// Provides methods to convert between <see cref="AirportDocument"/> and <see cref="AirportModel"/>.
    /// </summary>
    public static class AirportConverter
    {
        #region Document -> Model

        /// <summary>
        /// Converts an <see cref="AirportDocument"/> to an <see cref="AirportModel"/>.
        /// </summary>
        /// <param name="document">The <see cref="AirportDocument"/> to convert.</param>
        /// <returns>The converted <see cref="AirportModel"/>.</returns>
        public static AirportModel ToModel(this AirportDocument document)
        {
            return new AirportModel
            {
                Id = document.Id.ToString(),
                Name = document.Name,
                IATA = document.IATA,
                ICAO = document.ICAO,
                Location = document.Location,
                Country = document.Country
            };
        }

        /// <summary>
        /// Converts a list of <see cref="AirportDocument"/> to a list of <see cref="AirportModel"/>.
        /// </summary>
        /// <param name="documents">The list of <see cref="AirportDocument"/> to convert.</param>
        /// <returns>The list of converted <see cref="AirportModel"/>.</returns>
        public static List<AirportModel> ToModelList(this List<AirportDocument> documents)
        {
            return documents.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> Document

        /// <summary>
        /// Converts an <see cref="AirportModel"/> to an <see cref="AirportDocument"/>.
        /// </summary>
        /// <param name="model">The <see cref="AirportModel"/> to convert.</param>
        /// <returns>The converted <see cref="AirportDocument"/>.</returns>
        public static AirportDocument ToDocument(this AirportModel model)
        {
            // Se model.Id is null or empty, use ObjectId.Empty, otherwise use ObjectId.Parse.
            ObjectId id = string.IsNullOrWhiteSpace(model.Id) ? ObjectId.Empty : ObjectId.Parse(model.Id);

            return new AirportDocument
            {
                Id = id,
                Name = model.Name,
                IATA = model.IATA,
                ICAO = model.ICAO,
                Location = model.Location,
                Country = model.Country
            };
        }

        /// <summary>
        /// Converts a list of <see cref="AirportModel"/> to a list of <see cref="AirportDocument"/>.
        /// </summary>
        /// <param name="models">The list of <see cref="AirportModel"/> to convert.</param>
        /// <returns>The list of converted <see cref="AirportDocument"/>.</returns>
        public static List<AirportDocument> ToDocumentList(this List<AirportModel> models)
        {
            return models.Select(ToDocument).ToList();
        }
        #endregion
    }
}
