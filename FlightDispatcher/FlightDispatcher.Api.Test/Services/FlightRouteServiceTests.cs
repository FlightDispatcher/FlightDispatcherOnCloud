using FlightDispatcher.API.Exceptions;
using FlightDispatcher.API.Services;
using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infostructure.Interfaces;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Api.Test.Services
{
    public class FlightRouteServiceTests
    {
        private readonly FlightRouteService _flightRouteService;
        private readonly Mock<IFlightRouteRepository> _mockFlightRouteRepository;

        public FlightRouteServiceTests()
        {
            _mockFlightRouteRepository = new Mock<IFlightRouteRepository>();
            _flightRouteService = new FlightRouteService(_mockFlightRouteRepository.Object);
        }

        [Fact]
        public async Task GetAllFlightRoutes_ShouldReturnListOfFlightRoutes()
        {
            // Arrange
            var flightRouteDocuments = new List<FlightRouteDocument>
            {
                new FlightRouteDocument
                {
                    Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"),
                    AirLine = new FlightRouteAirlineDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c6"), Name = "Test Airline", IATA = "TST" },
                    DepartureAirport = new FlightRouteAirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c7"), Name = "Test Airport", IATA = "TST" },
                    ArrivalAirport = new FlightRouteAirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c8"), Name = "Destination Airport", IATA = "DST" },
                    FlightNumber = "1",
                    DepartureTime = "10:00",
                    ArrivalTime = "12:00"
                }
            };
            _mockFlightRouteRepository.Setup(repo => repo.GetAll()).ReturnsAsync(flightRouteDocuments);

            // Act
            var result = await _flightRouteService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Test Airline", result[0].AirLine.Name);
        }

        [Fact]
        public async Task GetFlightRouteById_ShouldReturnFlightRoute_WhenExists()
        {
            // Arrange
            var flightRouteDocument = new FlightRouteDocument
            {
                Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"),
                AirLine = new FlightRouteAirlineDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c6"), Name = "Test Airline", IATA = "TST" },
                DepartureAirport = new FlightRouteAirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c7"), Name = "Test Airport", IATA = "TST" },
                ArrivalAirport = new FlightRouteAirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c8"), Name = "Destination Airport", IATA = "DST" },
                FlightNumber = "1",
                DepartureTime = "10:00",
                ArrivalTime = "12:00"
            };
            _mockFlightRouteRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync(flightRouteDocument);

            // Act
            var result = await _flightRouteService.GetById("603d2e3e1f3e1b001f64d5c5");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Airline", result.AirLine.Name);
        }

        [Fact]
        public async Task GetFlightRouteById_ShouldThrowNotFoundException_WhenNotExists()
        {
            // Arrange
            _mockFlightRouteRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((FlightRouteDocument)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _flightRouteService.GetById("603d2e3e1f3e1b001f64d5c5"));
        }

        [Fact]
        public async Task CreateFlightRoute_ShouldReturnCreatedFlightRoute()
        {
            // Arrange
            var flightRouteModel = new FlightRouteModel
            {
                Id = "603d2e3e1f3e1b001f64d5c5",
                AirLine = new FlightRouteAirlineModel { Id = "603d2e3e1f3e1b001f64d5c6", Name = "New Airline", IATA = "NEW" },
                DepartureAirport = new FlightRouteAirportModel { Id = "603d2e3e1f3e1b001f64d5c7", Name = "New Airport", IATA = "NEW" },
                ArrivalAirport = new FlightRouteAirportModel { Id = "603d2e3e1f3e1b001f64d5c8", Name = "New Destination", IATA = "NEW" },
                FlightNumber = "1",
                DepartureTime = "14:00",
                ArrivalTime = "16:00"
            };
            var flightRouteDocument = new FlightRouteDocument
            {
                Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"),
                AirLine = new FlightRouteAirlineDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c6"), Name = "New Airline", IATA = "NEW" },
                DepartureAirport = new FlightRouteAirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c7"), Name = "New Airport", IATA = "NEW" },
                ArrivalAirport = new FlightRouteAirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c8"), Name = "New Destination", IATA = "NEW" },
                FlightNumber = "1",
                DepartureTime = "14:00",
                ArrivalTime = "16:00"
            };
            _mockFlightRouteRepository.Setup(repo => repo.Create(It.IsAny<FlightRouteDocument>())).ReturnsAsync(flightRouteDocument);

            // Act
            var result = await _flightRouteService.Create(flightRouteModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Airline", result.AirLine.Name);
        }

        [Fact]
        public async Task UpdateFlightRoute_ShouldReturnUpdatedFlightRoute()
        {
            // Arrange
            var flightRouteModel = new FlightRouteModel
            {
                Id = "603d2e3e1f3e1b001f64d5c5",
                AirLine = new FlightRouteAirlineModel { Id = "603d2e3e1f3e1b001f64d5c6", Name = "Updated Airline", IATA = "UPD" },
                DepartureAirport = new FlightRouteAirportModel { Id = "603d2e3e1f3e1b001f64d5c7", Name = "Updated Airport", IATA = "UPD" },
                ArrivalAirport = new FlightRouteAirportModel { Id = "603d2e3e1f3e1b001f64d5c8", Name = "Updated Destination", IATA = "UPD" },
                DepartureTime = "15:00",
                ArrivalTime = "17:00"
            };
            var flightRouteDocument = new FlightRouteDocument
            {
                Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"),
                AirLine = new FlightRouteAirlineDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c6"), Name = "Updated Airline", IATA = "UPD" },
                DepartureAirport = new FlightRouteAirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c7"), Name = "Updated Airport", IATA = "UPD" },
                ArrivalAirport = new FlightRouteAirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c8"), Name = "Updated Destination", IATA = "UPD" },
                DepartureTime = "15:00",
                ArrivalTime = "17:00"
            };
            _mockFlightRouteRepository.Setup(repo => repo.Update(It.IsAny<FlightRouteDocument>())).ReturnsAsync(flightRouteDocument);

            // Act
            var result = await _flightRouteService.Update(flightRouteModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Airline", result.AirLine.Name);
        }

        [Fact]
        public async Task DeleteFlightRoute_ShouldCompleteSuccessfully()
        {
            // Arrange
            _mockFlightRouteRepository.Setup(repo => repo.Delete(It.IsAny<ObjectId>())).Returns(Task.CompletedTask);

            // Act
            await _flightRouteService.Delete("603d2e3e1f3e1b001f64d5c5");

            // Assert
            _mockFlightRouteRepository.Verify(repo => repo.Delete(It.IsAny<ObjectId>()), Times.Once);
        }
    }
}
