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
    /// Provides methods to convert between <see cref="CountryDocument"/> and <see cref="CountryModel"/>.
    /// </summary>
    public static class CountryConverter
    {
        #region Document -> Model
        /// <summary>
        /// Converts a <see cref="CountryDocument"/> to a <see cref="CountryModel"/>.
        /// </summary>
        /// <param name="document">The <see cref="CountryDocument"/> to convert.</param>
        /// <returns>The converted <see cref="CountryModel"/>.</returns>
        public static CountryModel ToModel(this CountryDocument document)
        {
            return new CountryModel
            {
                Id = document.Id.ToString(),
                Name = document.Name,
                Code = document.Code
            };
        }

        /// <summary>
        /// Converts a list of <see cref="CountryDocument"/> to a list of <see cref="CountryModel"/>.
        /// </summary>
        /// <param name="documents">The list of <see cref="CountryDocument"/> to convert.</param>
        /// <returns>The list of converted <see cref="CountryModel"/>.</returns>
        public static List<CountryModel> ToModelList(this List<CountryDocument> documents)
        {
            return documents.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> Document
        /// <summary>
        /// Converts a <see cref="CountryModel"/> to a <see cref="CountryDocument"/>.
        /// </summary>
        /// <param name="model">The <see cref="CountryModel"/> to convert.</param>
        /// <returns>The converted <see cref="CountryDocument"/>.</returns>
        public static CountryDocument ToDocument(this CountryModel model)
        {
            // Se model.Id is null or empty, use ObjectId.Empty, otherwise use ObjectId.Parse.
            ObjectId id = string.IsNullOrWhiteSpace(model.Id) ? ObjectId.Empty : ObjectId.Parse(model.Id);

            return new CountryDocument
            {
                Id = id,
                Name = model.Name,
                Code = model.Code
            };
        }

        /// <summary>
        /// Converts a list of <see cref="CountryModel"/> to a list of <see cref="CountryDocument"/>.
        /// </summary>
        /// <param name="models">The list of <see cref="CountryModel"/> to convert.</param>
        /// <returns>The list of converted <see cref="CountryDocument"/>.</returns>
        public static List<CountryDocument> ToDocumentList(this List<CountryModel> models)
        {
            return models.Select(ToDocument).ToList();
        }
        #endregion
    }
}
