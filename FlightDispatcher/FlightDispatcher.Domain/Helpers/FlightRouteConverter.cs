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
        This Converter Class transform FlightRouteModel object in FlightRouteDocument object and viceversa
     */

    public static class FlightRouteConverter
    {
        #region Document -> Model
        public static FlightRouteModel ToModel(this FlightRouteDocument document)
        {
            return new FlightRouteModel
            {
                Id = document.Id.ToString(),
                AirLine =
                {
                    Id = document.AirLine.Id.ToString(),
                    Name = document.AirLine.Name,
                    IATA = document.AirLine.IATA
                },
                DepartureAirport =
                {
                    Id = document.DepartureAirport.Id.ToString(),
                    Name = document.DepartureAirport.Name,
                    IATA = document.DepartureAirport.IATA
                },
                ArrivalAirport =
                {
                    Id = document.ArrivalAirport.Id.ToString(),
                    Name = document.ArrivalAirport.Name,
                    IATA = document.ArrivalAirport.IATA
                },
                DepartureTime = document.DepartureTime,
                ArrivalTime = document.ArrivalTime
            };
        }

        public static List<FlightRouteModel> ToModelList(this List<FlightRouteDocument> documents)
        {
            return documents.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> Document
        public static FlightRouteDocument ToDocument(this FlightRouteModel model)
        {
            return new FlightRouteDocument
            {
                Id = ObjectId.Parse(model.Id),
                AirLine =
                {
                    Id = ObjectId.Parse(model.AirLine.Id),
                    Name = model.AirLine.Name,
                    IATA = model.AirLine.IATA
                },
                DepartureAirport =
                {
                    Id = ObjectId.Parse(model.DepartureAirport.Id),
                    Name = model.DepartureAirport.Name,
                    IATA = model.DepartureAirport.IATA
                },
                ArrivalAirport =
                {
                    Id = ObjectId.Parse(model.ArrivalAirport.Id),
                    Name = model.ArrivalAirport.Name,
                    IATA = model.ArrivalAirport.IATA
                },
                DepartureTime = model.DepartureTime,
                ArrivalTime = model.ArrivalTime
            };
        }

        public static List<FlightRouteDocument> ToDocumentList(this List<FlightRouteModel> models)
        {
            return models.Select(ToDocument).ToList();
        }
        #endregion
    }
}
