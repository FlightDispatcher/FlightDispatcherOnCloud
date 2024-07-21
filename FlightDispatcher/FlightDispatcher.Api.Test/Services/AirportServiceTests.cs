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
    public class AirportServiceTests
    {
        private readonly AirportService _airportService;
        private readonly Mock<IAirportRepository> _mockAirportRepository;

        public AirportServiceTests()
        {
            _mockAirportRepository = new Mock<IAirportRepository>();
            _airportService = new AirportService(_mockAirportRepository.Object);
        }

        [Fact]
        public async Task GetAllAirports_ShouldReturnListOfAirports()
        {
            // Arrange
            var airportDocuments = new List<AirportDocument>
            {
                new AirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "Test Airport", IATA = "TST", ICAO = "TSTC", Location = "Test City", Country = "Test Country" }
            };
            _mockAirportRepository.Setup(repo => repo.GetAll()).ReturnsAsync(airportDocuments);

            // Act
            var result = await _airportService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Test Airport", result[0].Name);
        }

        [Fact]
        public async Task GetAirportById_ShouldReturnAirport_WhenExists()
        {
            // Arrange
            var airportDocument = new AirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "Test Airport", IATA = "TST", ICAO = "TSTC", Location = "Test City", Country = "Test Country" };
            _mockAirportRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync(airportDocument);

            // Act
            var result = await _airportService.GetById("603d2e3e1f3e1b001f64d5c5");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Airport", result.Name);
        }

        [Fact]
        public async Task GetAirportById_ShouldThrowNotFoundException_WhenNotExists()
        {
            // Arrange
            _mockAirportRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((AirportDocument)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _airportService.GetById("603d2e3e1f3e1b001f64d5c5"));
        }

        [Fact]
        public async Task CreateAirport_ShouldReturnCreatedAirport()
        {
            // Arrange
            var airportModel = new AirportModel { Id = "603d2e3e1f3e1b001f64d5c5", Name = "New Airport", IATA = "NEW", ICAO = "NEWC", Location = "New City", Country = "New Country" };
            var airportDocument = new AirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "New Airport", IATA = "NEW", ICAO = "NEWC", Location = "New City", Country = "New Country" };
            _mockAirportRepository.Setup(repo => repo.Create(It.IsAny<AirportDocument>())).ReturnsAsync(airportDocument);

            // Act
            var result = await _airportService.Create(airportModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Airport", result.Name);
        }

        [Fact]
        public async Task UpdateAirport_ShouldReturnUpdatedAirport()
        {
            // Arrange
            var airportModel = new AirportModel { Id = "603d2e3e1f3e1b001f64d5c5", Name = "Updated Airport", IATA = "UPD", ICAO = "UPDC", Location = "Updated City", Country = "Updated Country" };
            var airportDocument = new AirportDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "Updated Airport", IATA = "UPD", ICAO = "UPDC", Location = "Updated City", Country = "Updated Country" };
            _mockAirportRepository.Setup(repo => repo.Update(It.IsAny<AirportDocument>())).ReturnsAsync(airportDocument);

            // Act
            var result = await _airportService.Update(airportModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Airport", result.Name);
        }

        [Fact]
        public async Task DeleteAirport_ShouldCompleteSuccessfully()
        {
            // Arrange
            _mockAirportRepository.Setup(repo => repo.Delete(It.IsAny<ObjectId>())).Returns(Task.CompletedTask);

            // Act
            await _airportService.Delete("603d2e3e1f3e1b001f64d5c5");

            // Assert
            _mockAirportRepository.Verify(repo => repo.Delete(It.IsAny<ObjectId>()), Times.Once);
        }
    }
}
