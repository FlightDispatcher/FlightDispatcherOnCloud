using FlightDispatcher.API.Exceptions;
using FlightDispatcher.API.Services;
using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infrastructure.Interfaces;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Api.Test.Services
{
    public class AirlineServiceTests
    {
        private readonly AirlineService _airlineService;
        private readonly Mock<IAirlineRepository> _mockAirlineRepository;

        public AirlineServiceTests()
        {
            _mockAirlineRepository = new Mock<IAirlineRepository>();
            _airlineService = new AirlineService(_mockAirlineRepository.Object);
        }

        [Fact]
        public async Task GetAllAirlines_ShouldReturnListOfAirlines()
        {
            // Arrange
            var airlineDocuments = new List<AirlineDocument>
            {
                new AirlineDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "Test Airline", IATA = "TST", ICAO = "TSTC" }
            };
            _mockAirlineRepository.Setup(repo => repo.GetAll()).ReturnsAsync(airlineDocuments);

            // Act
            var result = await _airlineService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Test Airline", result[0].Name);
        }

        [Fact]
        public async Task GetAirlineById_ShouldReturnAirline_WhenExists()
        {
            // Arrange
            var airlineDocument = new AirlineDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "Test Airline", IATA = "TST", ICAO = "TSTC" };
            _mockAirlineRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync(airlineDocument);

            // Act
            var result = await _airlineService.GetById("603d2e3e1f3e1b001f64d5c5");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Airline", result.Name);
        }

        [Fact]
        public async Task GetAirlineById_ShouldThrowNotFoundException_WhenNotExists()
        {
            // Arrange
            _mockAirlineRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((AirlineDocument)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _airlineService.GetById("603d2e3e1f3e1b001f64d5c5"));
        }

        [Fact]
        public async Task CreateAirline_ShouldReturnCreatedAirline()
        {
            // Arrange
            var airlineModel = new AirlineModel { Id = "603d2e3e1f3e1b001f64d5c5", Name = "New Airline", IATA = "NEW", ICAO = "NEWC" };
            var airlineDocument = new AirlineDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "New Airline", IATA = "NEW", ICAO = "NEWC" };
            _mockAirlineRepository.Setup(repo => repo.Create(It.IsAny<AirlineDocument>())).ReturnsAsync(airlineDocument);

            // Act
            var result = await _airlineService.Create(airlineModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New Airline", result.Name);
        }

        [Fact]
        public async Task UpdateAirline_ShouldReturnUpdatedAirline()
        {
            // Arrange
            var airlineModel = new AirlineModel { Id = "603d2e3e1f3e1b001f64d5c5", Name = "Updated Airline", IATA = "UPD", ICAO = "UPDC" };
            var airlineDocument = new AirlineDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "Updated Airline", IATA = "UPD", ICAO = "UPDC" };
            _mockAirlineRepository.Setup(repo => repo.Update(It.IsAny<AirlineDocument>())).ReturnsAsync(airlineDocument);

            // Act
            var result = await _airlineService.Update(airlineModel);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Airline", result.Name);
        }

        [Fact]
        public async Task DeleteAirline_ShouldCompleteSuccessfully()
        {
            // Arrange
            _mockAirlineRepository.Setup(repo => repo.Delete(It.IsAny<ObjectId>())).Returns(Task.CompletedTask);

            // Act
            await _airlineService.Delete("603d2e3e1f3e1b001f64d5c5");

            // Assert
            _mockAirlineRepository.Verify(repo => repo.Delete(It.IsAny<ObjectId>()), Times.Once);
        }

        [Fact]
        public async Task GetByIATACode_ShouldReturnAirline_WhenAirlineExists()
        {
            // Arrange
            var iata = "AA";
            var airlineDocument = new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "American Airlines", IATA = iata, ICAO = "AAL" };
            _mockAirlineRepository.Setup(repo => repo.GetByIATACode(iata)).ReturnsAsync(airlineDocument);

            // Act
            var result = await _airlineService.GetByIATACode(iata);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(iata, result.IATA);
        }

        [Fact]
        public async Task GetByIATACode_ShouldThrowNotFoundException_WhenAirlineDoesNotExist()
        {
            // Arrange
            var iata = "AA";
            _mockAirlineRepository.Setup(repo => repo.GetByIATACode(iata)).ReturnsAsync((AirlineDocument)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<AirlineCodeNotFoundException>(() => _airlineService.GetByIATACode(iata));
            Assert.Equal($"Airline with IATA code {iata} not found.", exception.Message);
        }
    }
}
