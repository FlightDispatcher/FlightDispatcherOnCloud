using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Test.Helpers
{
    public class FlightRouteConverterTest
    {
        [Fact]
        public void ConvertDocumentToModel()
        {
            // Arrange
            var document = new FlightRouteDocument
            {
                Id = ObjectId.GenerateNewId(),
                AirLine = new FlightRouteAirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Airline One", IATA = "AL1" },
                DepartureAirport = new FlightRouteAirportDocument { Id = ObjectId.GenerateNewId(), Name = "Departure Airport", IATA = "DEP" },
                ArrivalAirport = new FlightRouteAirportDocument { Id = ObjectId.GenerateNewId(), Name = "Arrival Airport", IATA = "ARR" },
                DepartureTime = "10:00",
                ArrivalTime = "13:00"
            };

            // Act
            var model = document.ToModel();

            // Assert
            Assert.Equal(document.Id.ToString(), model.Id);
            Assert.Equal(document.AirLine.Id.ToString(), model.AirLine.Id);
            Assert.Equal(document.AirLine.Name, model.AirLine.Name);
            Assert.Equal(document.AirLine.IATA, model.AirLine.IATA);
            Assert.Equal(document.DepartureAirport.Id.ToString(), model.DepartureAirport.Id);
            Assert.Equal(document.DepartureAirport.Name, model.DepartureAirport.Name);
            Assert.Equal(document.DepartureAirport.IATA, model.DepartureAirport.IATA);
            Assert.Equal(document.ArrivalAirport.Id.ToString(), model.ArrivalAirport.Id);
            Assert.Equal(document.ArrivalAirport.Name, model.ArrivalAirport.Name);
            Assert.Equal(document.ArrivalAirport.IATA, model.ArrivalAirport.IATA);
            Assert.Equal(document.DepartureTime, model.DepartureTime);
            Assert.Equal(document.ArrivalTime, model.ArrivalTime);
        }

        [Fact]
        public void ConvertModelToDocument()
        {
            // Arrange
            var model = new FlightRouteModel
            {
                Id = "615f7e3a5e2b4e001f0b8e5d",
                AirLine = new FlightRouteAirlineModel { Id = "615f7e3a5e2b4e001f0b8e5e", Name = "Airline Two", IATA = "AL2" },
                DepartureAirport = new FlightRouteAirportModel { Id = "615f7e3a5e2b4e001f0b8e5f", Name = "Departure Airport", IATA = "DEP" },
                ArrivalAirport = new FlightRouteAirportModel { Id = "615f7e3a5e2b4e001f0b8e60", Name = "Arrival Airport", IATA = "ARR" },
                DepartureTime = "13:00",
                ArrivalTime = "18:00"
            };

            // Act
            var document = model.ToDocument();

            // Assert
            Assert.Equal(ObjectId.Parse(model.Id), document.Id);
            Assert.Equal(ObjectId.Parse(model.AirLine.Id), document.AirLine.Id);
            Assert.Equal(model.AirLine.Name, document.AirLine.Name);
            Assert.Equal(model.AirLine.IATA, document.AirLine.IATA);
            Assert.Equal(ObjectId.Parse(model.DepartureAirport.Id), document.DepartureAirport.Id);
            Assert.Equal(model.DepartureAirport.Name, document.DepartureAirport.Name);
            Assert.Equal(model.DepartureAirport.IATA, document.DepartureAirport.IATA);
            Assert.Equal(ObjectId.Parse(model.ArrivalAirport.Id), document.ArrivalAirport.Id);
            Assert.Equal(model.ArrivalAirport.Name, document.ArrivalAirport.Name);
            Assert.Equal(model.ArrivalAirport.IATA, document.ArrivalAirport.IATA);
            Assert.Equal(model.DepartureTime, document.DepartureTime);
            Assert.Equal(model.ArrivalTime, document.ArrivalTime);
        }
    }
}
