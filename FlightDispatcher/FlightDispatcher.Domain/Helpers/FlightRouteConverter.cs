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
    /// Provides methods to convert between <see cref="FlightRouteDocument"/> and <see cref="FlightRouteModel"/>.
    /// </summary>
    public static class FlightRouteConverter
    {
        #region Document -> Model
        /// <summary>
        /// Converts a <see cref="FlightRouteDocument"/> to a <see cref="FlightRouteModel"/>.
        /// </summary>
        /// <param name="document">The <see cref="FlightRouteDocument"/> to convert.</param>
        /// <returns>The converted <see cref="FlightRouteModel"/>.</returns>
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

        /// <summary>
        /// Converts a list of <see cref="FlightRouteDocument"/> to a list of <see cref="FlightRouteModel"/>.
        /// </summary>
        /// <param name="documents">The list of <see cref="FlightRouteDocument"/> to convert.</param>
        /// <returns>The list of converted <see cref="FlightRouteModel"/>.</returns>
        public static List<FlightRouteModel> ToModelList(this List<FlightRouteDocument> documents)
        {
            return documents.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> Document
        /// <summary>
        /// Converts a <see cref="FlightRouteModel"/> to a <see cref="FlightRouteDocument"/>.
        /// </summary>
        /// <param name="model">The <see cref="FlightRouteModel"/> to convert.</param>
        /// <returns>The converted <see cref="FlightRouteDocument"/>.</returns>
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

        /// <summary>
        /// Converts a list of <see cref="FlightRouteModel"/> to a list of <see cref="FlightRouteDocument"/>.
        /// </summary>
        /// <param name="models">The list of <see cref="FlightRouteModel"/> to convert.</param>
        /// <returns>The list of converted <see cref="FlightRouteDocument"/>.</returns>
        public static List<FlightRouteDocument> ToDocumentList(this List<FlightRouteModel> models)
        {
            return models.Select(ToDocument).ToList();
        }
        #endregion
    }
}
