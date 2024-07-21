using FlightDispatcher.API.Exceptions;
using FlightDispatcher.API.Services;
using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infrastructure.Interfaces;
using MongoDB.Bson;
using Moq;
using FluentAssertions;
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
        private readonly Mock<IAirportRepository> _airportRepositoryMock;
        private readonly Mock<ICountryService> _countryServiceMock;

        public AirportServiceTests()
        {
            _airportRepositoryMock = new Mock<IAirportRepository>();
            _countryServiceMock = new Mock<ICountryService>();
            _airportService = new AirportService(
                _airportRepositoryMock.Object,
                _countryServiceMock.Object
            );
        }

        [Fact]
        public async Task Create_ShouldThrow_WhenCountryCodeIsInvalid()
        {
            // Arrange
            var airport = new AirportModel
            {
                IATA = "JFK",
                Country = "INVALID",
                Name = "John F. Kennedy International Airport"
            };

            _countryServiceMock
                .Setup(c => c.GetByCode("INVALID"))
                .ThrowsAsync(new NotFoundException("Country not found"));

            // Act & Assert
            await Assert.ThrowsAsync<CountryCodeNotFoundException>(() => _airportService.Create(airport));
        }

        [Fact]
        public async Task Create_ShouldThrow_WhenIATAAlreadyInUse()
        {
            // Arrange
            var airport = new AirportModel
            {
                IATA = "JFK",
                Country = "US",
                Name = "John F. Kennedy International Airport"
            };

            _countryServiceMock
                .Setup(c => c.GetByCode("US"))
                .ReturnsAsync(new CountryModel { Code = "US" });

            _airportRepositoryMock
                .Setup(r => r.GetByIATACode("JFK"))
                .ReturnsAsync(new AirportDocument { IATA = "JFK" }); // Simula un aeroporto già esistente

            // Act & Assert
            await Assert.ThrowsAsync<AirportCodeAlreadyInUseException>(() => _airportService.Create(airport));
        }

        [Fact]
        public async Task Create_ShouldSucceed_WhenValidDataIsProvided()
        {
            // Arrange
            var airport = new AirportModel
            {
                Name = "John F. Kennedy International Airport",
                IATA = "JFK",
                ICAO = "",
                Location = "New York",
                Country = "US"
            };

            var createdDocument = new AirportDocument
            {
                Id = ObjectId.GenerateNewId(),
                Name = "John F. Kennedy International Airport",
                IATA = "JFK",
                ICAO = "",
                Location = "New York",
                Country = "US"
            };

            _countryServiceMock
                .Setup(c => c.GetByCode("US"))
                .ReturnsAsync(new CountryModel { Code = "US" });

            _airportRepositoryMock
                .Setup(r => r.GetByIATACode("JFK"))
                .ReturnsAsync((AirportDocument)null); // Simula nessun aeroporto esistente

            _airportRepositoryMock
                .Setup(r => r.Create(It.IsAny<AirportDocument>()))
                .ReturnsAsync(createdDocument);

            // Act
            var result = await _airportService.Create(airport);

            // Assert
            result.Should().NotBeNull();
            result.IATA.Should().Be("JFK");
        }

        [Fact]
        public async Task Update_ShouldThrow_WhenCountryCodeIsInvalid()
        {
            // Arrange
            var airport = new AirportModel
            {
                Id = "airport-id",
                IATA = "JFK",
                Country = "INVALID",
                Name = "John F. Kennedy International Airport"
            };

            _countryServiceMock
                .Setup(c => c.GetByCode("INVALID"))
                .ThrowsAsync(new NotFoundException("Country not found"));

            // Act & Assert
            await Assert.ThrowsAsync<CountryCodeNotFoundException>(() => _airportService.Update(airport));
        }

        [Fact]
        public async Task Update_ShouldThrow_WhenIATAAlreadyInUseByAnotherAirport()
        {
            // Arrange
            var airport = new AirportModel
            {
                Id = "airport-id",
                IATA = "JFK",
                Country = "US",
                Name = "John F. Kennedy International Airport"
            };

            var existingAirport = new AirportDocument
            {
                Id = ObjectId.GenerateNewId(),
                IATA = "JFK"
            };

            _countryServiceMock
                .Setup(c => c.GetByCode("US"))
                .ReturnsAsync(new CountryModel { Code = "US" });

            _airportRepositoryMock
                .Setup(r => r.GetByIATACode("JFK"))
                .ReturnsAsync(existingAirport); // Simula un aeroporto esistente con lo stesso IATA

            // Act & Assert
            await Assert.ThrowsAsync<AirportCodeAlreadyInUseException>(() => _airportService.Update(airport));
        }

        [Fact]
        public async Task Delete_ShouldSucceed_WhenValidIdIsProvided()
        {
            // Arrange
            var id = ObjectId.GenerateNewId().ToString();

            // Act
            await _airportService.Delete(id);

            // Assert
            _airportRepositoryMock.Verify(r => r.Delete(ObjectId.Parse(id)), Times.Once);
        }

        [Fact]
        public async Task GetByIATACode_ShouldThrow_WhenAirportNotFound()
        {
            // Arrange
            var iataCode = "INVALID";

            _airportRepositoryMock
                .Setup(r => r.GetByIATACode(iataCode))
                .ReturnsAsync((AirportDocument)null);

            // Act & Assert
            await Assert.ThrowsAsync<AirportCodeNotFoundException>(() => _airportService.GetByIATACode(iataCode));
        }

        [Fact]
        public async Task GetByIATACode_ShouldReturnAirport_WhenFound()
        {
            // Arrange
            var iataCode = "JFK";
            var airportDocument = new AirportDocument
            {
                Id = ObjectId.GenerateNewId(),
                IATA = "JFK"
            };

            _airportRepositoryMock
                .Setup(r => r.GetByIATACode(iataCode))
                .ReturnsAsync(airportDocument);

            // Act
            var result = await _airportService.GetByIATACode(iataCode);

            // Assert
            result.Should().NotBeNull();
            result.IATA.Should().Be(iataCode);
        }
    }
}
