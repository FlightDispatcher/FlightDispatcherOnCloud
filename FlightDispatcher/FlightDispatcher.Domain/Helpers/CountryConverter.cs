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
    /* 
        This Converter Class transform CountryModel object in CountryDocument object and viceversa
     */

    public static class CountryConverter
    {
        #region Document -> Model
        public static CountryModel ToModel(this CountryDocument document)
        {
            return new CountryModel
            {
                Id = document.Id.ToString(),
                Name = document.Name,
                Code = document.Code
            };
        }

        public static List<CountryModel> ToModelList(this List<CountryDocument> documents)
        {
            return documents.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> Document
        public static CountryDocument ToDocument(this CountryModel model)
        {
            return new CountryDocument
            {
                Id = ObjectId.Parse(model.Id),
                Name = model.Name,
                Code = model.Code
            };
        }

        public static List<CountryDocument> ToDocumentList(this List<CountryModel> models)
        {
            return models.Select(ToDocument).ToList();
        }
        #endregion
    }
}
