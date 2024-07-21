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
    /// Provides methods to convert between <see cref="AirlineDocument"/> and <see cref="AirlineModel"/>.
    /// </summary>
    public static class AirlineConverter
    {
        #region Document -> Model

        /// <summary>
        /// Converts an <see cref="AirlineDocument"/> to an <see cref="AirlineModel"/>.
        /// </summary>
        /// <param name="document">The <see cref="AirlineDocument"/> to convert.</param>
        /// <returns>The converted <see cref="AirlineModel"/>.</returns>
        public static AirlineModel ToModel(this AirlineDocument document)
        {
            return new AirlineModel
            {
                Id = document.Id.ToString(),
                Name = document.Name,
                IATA = document.IATA,
                ICAO = document.ICAO
            };
        }

        /// <summary>
        /// Converts a list of <see cref="AirlineDocument"/> to a list of <see cref="AirlineModel"/>.
        /// </summary>
        /// <param name="documents">The list of <see cref="AirlineDocument"/> to convert.</param>
        /// <returns>The list of converted <see cref="AirlineModel"/>.</returns>
        public static List<AirlineModel> ToModelList(this List<AirlineDocument> documents)
        {
            return documents.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> Document

        /// <summary>
        /// Converts an <see cref="AirlineModel"/> to an <see cref="AirlineDocument"/>.
        /// </summary>
        /// <param name="model">The <see cref="AirlineModel"/> to convert.</param>
        /// <returns>The converted <see cref="AirlineDocument"/>.</returns>
        public static AirlineDocument ToDocument(this AirlineModel model)
        {
            // Se model.Id is null or empty, use ObjectId.Empty, otherwise use ObjectId.Parse.
            ObjectId id = string.IsNullOrWhiteSpace(model.Id) ? ObjectId.Empty : ObjectId.Parse(model.Id);

            return new AirlineDocument
            {
                Id = id,
                Name = model.Name,
                IATA = model.IATA,
                ICAO = model.ICAO
            };
        }

        /// <summary>
        /// Converts a list of <see cref="AirlineModel"/> to a list of <see cref="AirlineDocument"/>.
        /// </summary>
        /// <param name="models">The list of <see cref="AirlineModel"/> to convert.</param>
        /// <returns>The list of converted <see cref="AirlineDocument"/>.</returns>
        public static List<AirlineDocument> ToDocumentList(this List<AirlineModel> models)
        {
            return models.Select(ToDocument).ToList();
        }
        #endregion
    }
}
