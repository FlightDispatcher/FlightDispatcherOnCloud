using FlightDispatcher.API.Exceptions;
using FlightDispatcher.API.Services;
using FlightDispatcher.API.Services.Interfaces;
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
        private readonly Mock<IFlightRouteRepository> _flightRouteRepositoryMock;
        private readonly Mock<IAirlineService> _airlineServiceMock;
        private readonly Mock<IAirportService> _airportServiceMock;

        public FlightRouteServiceTests()
        {
            _flightRouteRepositoryMock = new Mock<IFlightRouteRepository>();
            _airlineServiceMock = new Mock<IAirlineService>();
            _airportServiceMock = new Mock<IAirportService>();

            _flightRouteService = new FlightRouteService(
                _flightRouteRepositoryMock.Object,
                _airlineServiceMock.Object,
                _airportServiceMock.Object
            );
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
            _flightRouteRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(flightRouteDocuments);

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
            _flightRouteRepositoryMock.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync(flightRouteDocument);

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
            _flightRouteRepositoryMock.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((FlightRouteDocument)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _flightRouteService.GetById("603d2e3e1f3e1b001f64d5c5"));
        }

        [Fact]
        public async Task DeleteFlightRoute_ShouldCompleteSuccessfully()
        {
            // Arrange
            _flightRouteRepositoryMock.Setup(repo => repo.Delete(It.IsAny<ObjectId>())).Returns(Task.CompletedTask);

            // Act
            await _flightRouteService.Delete("603d2e3e1f3e1b001f64d5c5");

            // Assert
            _flightRouteRepositoryMock.Verify(repo => repo.Delete(It.IsAny<ObjectId>()), Times.Once);
        }

        [Fact]
        public async Task Create_ShouldThrow_WhenAirlineIATAIsInvalid()
        {
            // Arrange
            var flightRoute = new FlightRouteModel
            {
                AirLine = new FlightRouteAirlineModel { IATA = "INVALID" },
                DepartureAirport = new FlightRouteAirportModel { IATA = "JFK" },
                ArrivalAirport = new FlightRouteAirportModel { IATA = "LAX" },
                FlightNumber = "123",
                DepartureTime = "2024-07-21T12:00:00Z",
                ArrivalTime = "2024-07-21T15:00:00Z"
            };

            _airlineServiceMock
                .Setup(s => s.GetByIATACode(It.IsAny<string>()))
                .ReturnsAsync((AirlineModel)null); // Simula una compagnia aerea non trovata

            // Act & Assert
            await Assert.ThrowsAsync<AirlineCodeNotFoundException>(() => _flightRouteService.Create(flightRoute));
        }

        [Fact]
        public async Task Create_ShouldSucceed_WhenValidDataIsProvided()
        {
            // Arrange
            var flightRoute = new FlightRouteModel
            {
                AirLine = new FlightRouteAirlineModel { Id = ObjectId.GenerateNewId().ToString(), Name = "Alitalia", IATA = "AZ" },
                DepartureAirport = new FlightRouteAirportModel { Id = ObjectId.GenerateNewId().ToString(), IATA = "JFK", Name = "New York" },
                ArrivalAirport = new FlightRouteAirportModel { Id = ObjectId.GenerateNewId().ToString(), IATA = "LAX", Name = "Los Angeles" },
                FlightNumber = "123",
                DepartureTime = "2024-07-21T12:00:00Z",
                ArrivalTime = "2024-07-21T15:00:00Z"
            };

            var createdDocument = new FlightRouteDocument
            {
                Id = ObjectId.GenerateNewId()
            };

            _airlineServiceMock
                .Setup(s => s.GetByIATACode("AZ"))
                .ReturnsAsync(new AirlineModel { Id = flightRoute.AirLine.Id, Name = "Alitalia", IATA = "AZ" });

            _airportServiceMock
                .Setup(s => s.GetByIATACode("JFK"))
                .ReturnsAsync(new AirportModel { Id = flightRoute.DepartureAirport.Id, IATA = "JFK", Name = "New York" });

            _airportServiceMock
                .Setup(s => s.GetByIATACode("LAX"))
                .ReturnsAsync(new AirportModel { Id = flightRoute.ArrivalAirport.Id, IATA = "LAX", Name = "Los Angeles" });

            _flightRouteRepositoryMock
                .Setup(r => r.Create(It.IsAny<FlightRouteDocument>()))
                .ReturnsAsync(createdDocument);

            // Act
            var result = await _flightRouteService.Create(flightRoute);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Update_ShouldThrow_WhenDataDiscrepancyExists()
        {
            // Arrange
            var flightRoute = new FlightRouteModel
            {
                Id = "route-id",
                AirLine = new FlightRouteAirlineModel { IATA = "VALID" },
                DepartureAirport = new FlightRouteAirportModel { IATA = "JFK" },
                ArrivalAirport = new FlightRouteAirportModel { IATA = "LAX" },
                FlightNumber = "123",
                DepartureTime = "2024-07-21T12:00:00Z",
                ArrivalTime = "2024-07-21T15:00:00Z"
            };

            _airlineServiceMock
                .Setup(s => s.GetByIATACode("VALID"))
                .ReturnsAsync(new AirlineModel { Id = "airline-id", IATA = "VALID" });

            _airportServiceMock
                .Setup(s => s.GetByIATACode("JFK"))
                .ReturnsAsync(new AirportModel { Id = "departure-id", IATA = "JFK" });

            _airportServiceMock
                .Setup(s => s.GetByIATACode("LAX"))
                .ReturnsAsync(new AirportModel { Id = "arrival-id", IATA = "LAX" });

            // Data discrepancy setup
            _airlineServiceMock
                .Setup(s => s.GetByIATACode("VALID"))
                .ReturnsAsync(new AirlineModel { Id = "different-id", IATA = "VALID" });

            // Act & Assert
            await Assert.ThrowsAsync<DataDiscrepancyException>(() => _flightRouteService.Update(flightRoute));
        }
    }
}
