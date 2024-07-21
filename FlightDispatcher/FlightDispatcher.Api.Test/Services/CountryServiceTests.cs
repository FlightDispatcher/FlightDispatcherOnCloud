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
    public class CountryServiceTests
    {
        private readonly CountryService _countryService;
        private readonly Mock<ICountryRepository> _mockCountryRepository;

        public CountryServiceTests()
        {
            _mockCountryRepository = new Mock<ICountryRepository>();
            _countryService = new CountryService(_mockCountryRepository.Object);
        }

        [Fact]
        public async Task GetAllCountries_ShouldReturnListOfCountries()
        {
            // Arrange
            var countryDocuments = new List<CountryDocument>
            {
                new CountryDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "Test Country", Code = "TC" }
            };
            _mockCountryRepository.Setup(repo => repo.GetAll()).ReturnsAsync(countryDocuments);

            // Act
            var result = await _countryService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Test Country", result[0].Name);
        }

        [Fact]
        public async Task GetCountryById_ShouldReturnCountry_WhenExists()
        {
            // Arrange
            var countryDocument = new CountryDocument { Id = new ObjectId("603d2e3e1f3e1b001f64d5c5"), Name = "Test Country", Code = "TC" };
            _mockCountryRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync(countryDocument);

            // Act
            var result = await _countryService.GetById("603d2e3e1f3e1b001f64d5c5");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Country", result.Name);
        }

        [Fact]
        public async Task GetCountryById_ShouldThrowNotFoundException_WhenNotExists()
        {
            // Arrange
            _mockCountryRepository.Setup(repo => repo.GetById(It.IsAny<ObjectId>())).ReturnsAsync((CountryDocument)null);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _countryService.GetById("603d2e3e1f3e1b001f64d5c5"));
        }
    }
}
