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
    public class AirlineConverterTest
    {
        [Fact]
        public void ConvertDTOToModel()
        {
            // Arrange
            var dto = new AirlineDTO
            {
                Id = "1",
                Name = "Sample Airline",
                IATA = "SA",
                ICAO = "SAM"
            };

            // Act
            var model = dto.ToModel();

            // Assert
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Name, model.Name);
            Assert.Equal(dto.IATA, model.IATA);
            Assert.Equal(dto.ICAO, model.ICAO);
        }

        [Fact]
        public void ConvertDTOListToModelList()
        {
            // Arrange
            var dtos = new List<AirlineDTO>
        {
            new AirlineDTO { Id = "1", Name = "Airline1", IATA = "A1", ICAO = "ICAO1" },
            new AirlineDTO { Id = "2", Name = "Airline2", IATA = "A2", ICAO = "ICAO2" }
        };

            // Act
            var models = dtos.ToModelList();

            // Assert
            Assert.Equal(dtos.Count, models.Count);
            for (int i = 0; i < dtos.Count; i++)
            {
                Assert.Equal(dtos[i].Id, models[i].Id);
                Assert.Equal(dtos[i].Name, models[i].Name);
                Assert.Equal(dtos[i].IATA, models[i].IATA);
                Assert.Equal(dtos[i].ICAO, models[i].ICAO);
            }
        }

        [Fact]
        public void ConvertModelToDTO()
        {
            // Arrange
            var model = new AirlineModel
            {
                Id = "1",
                Name = "Sample Airline",
                IATA = "SA",
                ICAO = "SAM"
            };

            // Act
            var dto = model.ToDTO();

            // Assert
            Assert.Equal(model.Id, dto.Id);
            Assert.Equal(model.Name, dto.Name);
            Assert.Equal(model.IATA, dto.IATA);
            Assert.Equal(model.ICAO, dto.ICAO);
        }

        [Fact]
        public void ToDTOList_ConvertsModelListToDTOList()
        {
            // Arrange
            var models = new List<AirlineModel>
        {
            new AirlineModel { Id = "1", Name = "Airline1", IATA = "A1", ICAO = "ICAO1" },
            new AirlineModel { Id = "2", Name = "Airline2", IATA = "A2", ICAO = "ICAO2" }
        };

            // Act
            var dtos = models.ToDTOList();

            // Assert
            Assert.Equal(models.Count, dtos.Count);
            for (int i = 0; i < models.Count; i++)
            {
                Assert.Equal(models[i].Id, dtos[i].Id);
                Assert.Equal(models[i].Name, dtos[i].Name);
                Assert.Equal(models[i].IATA, dtos[i].IATA);
                Assert.Equal(models[i].ICAO, dtos[i].ICAO);
            }
        }
    }
}
