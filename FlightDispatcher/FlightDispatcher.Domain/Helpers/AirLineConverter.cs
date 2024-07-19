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
        This Converter Class transform AirlineModel object in AirLineDocument object and viceversa
     */

    public static class AirlineConverter
    {
        #region Document -> Model
        public static AirlineModel ToModel(AirlineDocument document)
        {
            return new AirlineModel
            {
                Id = document.Id.ToString(),
                Name = document.Name,
                IATA = document.IATA,
                ICAO = document.ICAO
            };
        }

        public static List<AirlineModel> ToModelList(List<AirlineDocument> documents)
        {
            return documents.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> Document
        public static AirlineDocument ToDocument(AirlineModel model)
        {
            return new AirlineDocument
            {
                Id = ObjectId.Parse(model.Id),
                Name = model.Name,
                IATA = model.IATA,
                ICAO = model.ICAO
            };
        }

        public static List<AirlineDocument> ToDocumentList(List<AirlineModel> models)
        {
            return models.Select(ToDocument).ToList();
        }
        #endregion
    }
}
