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
        This Converter Class transform AirportModel object in AirportDocument object and viceversa
     */

    public static class AirportConverter
    {
        #region Document -> Model
        public static AirportModel ToModel(this AirportDocument document)
        {
            return new AirportModel
            {
                Id = document.Id.ToString(),
                Name = document.Name,
                IATA = document.IATA,
                ICAO = document.ICAO,
                Country = document.Country
            };
        }

        public static List<AirportModel> ToModelList(this List<AirportDocument> documents)
        {
            return documents.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> Document
        public static AirportDocument ToDocument(this AirportModel model)
        {
            return new AirportDocument
            {
                Id = ObjectId.Parse(model.Id),
                Name = model.Name,
                IATA = model.IATA,
                ICAO = model.ICAO,
                Country = model.Country
            };
        }

        public static List<AirportDocument> ToDocumentList(this List<AirportModel> models)
        {
            return models.Select(ToDocument).ToList();
        }
        #endregion
    }
}
