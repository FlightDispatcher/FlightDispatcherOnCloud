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
                AirLine = new()
                {
                    Id = document.AirLine.Id.ToString(),
                    Name = document.AirLine.Name,
                    IATA = document.AirLine.IATA
                },
                DepartureAirport = new()
                {
                    Id = document.DepartureAirport.Id.ToString(),
                    Name = document.DepartureAirport.Name,
                    IATA = document.DepartureAirport.IATA
                },
                ArrivalAirport = new()
                {
                    Id = document.ArrivalAirport.Id.ToString(),
                    Name = document.ArrivalAirport.Name,
                    IATA = document.ArrivalAirport.IATA
                },
                FlightNumber = document.FlightNumber,
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
            // Se model.Id is null or empty, use ObjectId.Empty, otherwise use ObjectId.Parse.
            ObjectId id = string.IsNullOrWhiteSpace(model.Id) ? ObjectId.Empty : ObjectId.Parse(model.Id);
            ObjectId airlineId = string.IsNullOrWhiteSpace(model.AirLine.Id) ? ObjectId.Empty : ObjectId.Parse(model.AirLine.Id);
            ObjectId departureId = string.IsNullOrWhiteSpace(model.DepartureAirport.Id) ? ObjectId.Empty : ObjectId.Parse(model.DepartureAirport.Id);
            ObjectId arrivalId = string.IsNullOrWhiteSpace(model.ArrivalAirport.Id) ? ObjectId.Empty : ObjectId.Parse(model.ArrivalAirport.Id);

            return new FlightRouteDocument
            {
                Id = id,
                AirLine = new()
                {
                    Id = airlineId,
                    Name = model.AirLine.Name,
                    IATA = model.AirLine.IATA
                },
                DepartureAirport = new()
                {
                    Id = departureId,
                    Name = model.DepartureAirport.Name,
                    IATA = model.DepartureAirport.IATA
                },
                ArrivalAirport = new()
                {
                    Id = arrivalId,
                    Name = model.ArrivalAirport.Name,
                    IATA = model.ArrivalAirport.IATA
                },
                FlightNumber = model.FlightNumber,
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
