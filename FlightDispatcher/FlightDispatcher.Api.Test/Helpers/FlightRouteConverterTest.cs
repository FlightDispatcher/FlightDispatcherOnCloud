using FlightDispatcher.API.DTOs;
using FlightDispatcher.API.Helpers;
using FlightDispatcher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Api.Test.Helpers
{
    public class FlightRouteConverterTest
    {
        [Fact]
        public void ConvertDTOToModel()
        {
            // Arrange
            var dto = new FlightRouteDTO
            {
                Id = "1",
                AirLine = new FlightRouteAirlineDTO { Id = "AL1", Name = "Sample Airline", IATA = "SA" },
                DepartureAirport = new FlightRouteAirportDTO { Id = "DA1", Name = "Departure Airport", IATA = "DA" },
                ArrivalAirport = new FlightRouteAirportDTO { Id = "AA1", Name = "Arrival Airport", IATA = "AA" },
                FlightNumber = "1",
                DepartureTime = "10:00",
                ArrivalTime = "13:00"
            };

            // Act
            var model = dto.ToModel();

            // Assert
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.AirLine.Id, model.AirLine.Id);
            Assert.Equal(dto.AirLine.Name, model.AirLine.Name);
            Assert.Equal(dto.AirLine.IATA, model.AirLine.IATA);
            Assert.Equal(dto.DepartureAirport.Id, model.DepartureAirport.Id);
            Assert.Equal(dto.DepartureAirport.Name, model.DepartureAirport.Name);
            Assert.Equal(dto.DepartureAirport.IATA, model.DepartureAirport.IATA);
            Assert.Equal(dto.ArrivalAirport.Id, model.ArrivalAirport.Id);
            Assert.Equal(dto.ArrivalAirport.Name, model.ArrivalAirport.Name);
            Assert.Equal(dto.ArrivalAirport.IATA, model.ArrivalAirport.IATA);
            Assert.Equal(dto.FlightNumber, model.FlightNumber);
            Assert.Equal(dto.DepartureTime, model.DepartureTime);
            Assert.Equal(dto.ArrivalTime, model.ArrivalTime);
        }

        [Fact]
        public void ConvertDTOListToModelList()
        {
            // Arrange
            var dtos = new List<FlightRouteDTO>
        {
            new FlightRouteDTO {
                Id = "1",
                AirLine = new FlightRouteAirlineDTO { Id = "AL1", Name = "Airline1", IATA = "A1" },
                DepartureAirport = new FlightRouteAirportDTO { Id = "DA1", Name = "Departure1", IATA = "DA1" },
                ArrivalAirport = new FlightRouteAirportDTO { Id = "AA1", Name = "Arrival1", IATA = "AA1" },
                FlightNumber = "1",
                DepartureTime = "10:00",
                ArrivalTime = "13:00"
            },
            new FlightRouteDTO {
                Id = "2",
                AirLine = new FlightRouteAirlineDTO { Id = "AL2", Name = "Airline2", IATA = "A2" },
                DepartureAirport = new FlightRouteAirportDTO { Id = "DA2", Name = "Departure2", IATA = "DA2" },
                ArrivalAirport = new FlightRouteAirportDTO { Id = "AA2", Name = "Arrival2", IATA = "AA2" },
                FlightNumber = "2",
                DepartureTime = "13:00",
                ArrivalTime = "16:00"
            },
        };

            // Act
            var models = dtos.ToModelList();

            // Assert
            Assert.NotNull(models);
            for (int i = 0; i < dtos.Count; i++)
            {
                Assert.Equal(dtos[i].Id, models[i].Id);
                Assert.Equal(dtos[i].AirLine.Id, models[i].AirLine.Id);
                Assert.Equal(dtos[i].AirLine.Name, models[i].AirLine.Name);
                Assert.Equal(dtos[i].AirLine.IATA, models[i].AirLine.IATA);
                Assert.Equal(dtos[i].DepartureAirport.Id, models[i].DepartureAirport.Id);
                Assert.Equal(dtos[i].DepartureAirport.Name, models[i].DepartureAirport.Name);
                Assert.Equal(dtos[i].DepartureAirport.IATA, models[i].DepartureAirport.IATA);
                Assert.Equal(dtos[i].ArrivalAirport.Id, models[i].ArrivalAirport.Id);
                Assert.Equal(dtos[i].ArrivalAirport.Name, models[i].ArrivalAirport.Name);
                Assert.Equal(dtos[i].ArrivalAirport.IATA, models[i].ArrivalAirport.IATA);
                Assert.Equal(dtos[i].FlightNumber, models[i].FlightNumber);
                Assert.Equal(dtos[i].DepartureTime, models[i].DepartureTime);
                Assert.Equal(dtos[i].ArrivalTime, models[i].ArrivalTime);
            }
        }

        [Fact]
        public void ConvertModelToDTO()
        {
            // Arrange
            var model = new FlightRouteModel
            {
                Id = "1",
                AirLine = new FlightRouteAirlineModel { Id = "AL1", Name = "Sample Airline", IATA = "SA" },
                DepartureAirport = new FlightRouteAirportModel { Id = "DA1", Name = "Departure Airport", IATA = "DA" },
                ArrivalAirport = new FlightRouteAirportModel { Id = "AA1", Name = "Arrival Airport", IATA = "AA" },
                FlightNumber = "1",
                DepartureTime = "10:00",
                ArrivalTime = "13:00"
            };

            // Act
            var dto = model.ToDTO();

            // Assert
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.AirLine.Id, model.AirLine.Id);
            Assert.Equal(dto.AirLine.Name, model.AirLine.Name);
            Assert.Equal(dto.AirLine.IATA, model.AirLine.IATA);
            Assert.Equal(dto.DepartureAirport.Id, model.DepartureAirport.Id);
            Assert.Equal(dto.DepartureAirport.Name, model.DepartureAirport.Name);
            Assert.Equal(dto.DepartureAirport.IATA, model.DepartureAirport.IATA);
            Assert.Equal(dto.ArrivalAirport.Id, model.ArrivalAirport.Id);
            Assert.Equal(dto.ArrivalAirport.Name, model.ArrivalAirport.Name);
            Assert.Equal(dto.ArrivalAirport.IATA, model.ArrivalAirport.IATA);
            Assert.Equal(dto.FlightNumber, model.FlightNumber);
            Assert.Equal(dto.DepartureTime, model.DepartureTime);
            Assert.Equal(dto.ArrivalTime, model.ArrivalTime);
        }

        [Fact]
        public void ToDTOList_ConvertsModelListToDTOList()
        {
            // Arrange
            var models = new List<FlightRouteModel>
            {
                new FlightRouteModel
                {
                    Id = "1",
                    AirLine = new FlightRouteAirlineModel { Id = "AL1", Name = "Airline1", IATA = "A1" },
                    DepartureAirport = new FlightRouteAirportModel { Id = "DA1", Name = "Departure1", IATA = "DA1" },
                    ArrivalAirport = new FlightRouteAirportModel { Id = "AA1", Name = "Arrival1", IATA = "AA1" },
                    FlightNumber = "1",
                    DepartureTime = "10:00",
                    ArrivalTime = "13:00"
                },
                new FlightRouteModel {
                    Id = "2",
                    AirLine = new FlightRouteAirlineModel { Id = "AL2", Name = "Airline2", IATA = "A2" },
                    DepartureAirport = new FlightRouteAirportModel { Id = "DA2", Name = "Departure2", IATA = "DA2" },
                    ArrivalAirport = new FlightRouteAirportModel { Id = "AA2", Name = "Arrival2", IATA = "AA2" },
                    FlightNumber = "2",
                    DepartureTime = "13:00",
                    ArrivalTime = "16:00"
                }
            };

            // Act
            var dtos = models.ToDTOList();

            // Assert
            Assert.NotNull(models);
            for (int i = 0; i < models.Count; i++)
            {
                Assert.Equal(dtos[i].Id, models[i].Id);
                Assert.Equal(dtos[i].AirLine.Id, models[i].AirLine.Id);
                Assert.Equal(dtos[i].AirLine.Name, models[i].AirLine.Name);
                Assert.Equal(dtos[i].AirLine.IATA, models[i].AirLine.IATA);
                Assert.Equal(dtos[i].DepartureAirport.Id, models[i].DepartureAirport.Id);
                Assert.Equal(dtos[i].DepartureAirport.Name, models[i].DepartureAirport.Name);
                Assert.Equal(dtos[i].DepartureAirport.IATA, models[i].DepartureAirport.IATA);
                Assert.Equal(dtos[i].ArrivalAirport.Id, models[i].ArrivalAirport.Id);
                Assert.Equal(dtos[i].ArrivalAirport.Name, models[i].ArrivalAirport.Name);
                Assert.Equal(dtos[i].ArrivalAirport.IATA, models[i].ArrivalAirport.IATA);
                Assert.Equal(dtos[i].FlightNumber, models[i].FlightNumber);
                Assert.Equal(dtos[i].DepartureTime, models[i].DepartureTime);
                Assert.Equal(dtos[i].ArrivalTime, models[i].ArrivalTime);
            }
        }
    }
}
