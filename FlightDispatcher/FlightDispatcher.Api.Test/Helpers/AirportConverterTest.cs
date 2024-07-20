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
    public class AirportConverterTest
    {
        [Fact]
        public void ConvertDTOToModel()
        {
            // Arrange
            var dto = new AirportDTO
            {
                Id = "1",
                Name = "Sample Airport",
                IATA = "SA",
                ICAO = "SAM",
                Location = "Sample Location",
                Country = "Sample Country"
            };

            // Act
            var model = dto.ToModel();

            // Assert
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Name, model.Name);
            Assert.Equal(dto.IATA, model.IATA);
            Assert.Equal(dto.ICAO, model.ICAO);
            Assert.Equal(dto.Location, model.Location);
            Assert.Equal(dto.Country, model.Country);
        }

        [Fact]
        public void ConvertDTOListToModelList()
        {
            // Arrange
            var dtos = new List<AirportDTO>
        {
            new AirportDTO { Id = "1", Name = "Airport1", IATA = "A1", ICAO = "ICAO1", Location = "Loc1", Country = "Country1" },
            new AirportDTO { Id = "2", Name = "Airport2", IATA = "A2", ICAO = "ICAO2", Location = "Loc2", Country = "Country2" }
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
                Assert.Equal(dtos[i].Location, models[i].Location);
                Assert.Equal(dtos[i].Country, models[i].Country);
            }
        }

        [Fact]
        public void ConvertModelToDTO()
        {
            // Arrange
            var model = new AirportModel
            {
                Id = "1",
                Name = "Sample Airport",
                IATA = "SA",
                ICAO = "SAM",
                Location = "Sample Location",
                Country = "Sample Country"
            };

            // Act
            var dto = model.ToDTO();

            // Assert
            Assert.Equal(model.Id, dto.Id);
            Assert.Equal(model.Name, dto.Name);
            Assert.Equal(model.IATA, dto.IATA);
            Assert.Equal(model.ICAO, dto.ICAO);
            Assert.Equal(model.Location, dto.Location);
            Assert.Equal(model.Country, dto.Country);
        }

        [Fact]
        public void ConvertModelListToDTOList()
        {
            // Arrange
            var models = new List<AirportModel>
        {
            new AirportModel { Id = "1", Name = "Airport1", IATA = "A1", ICAO = "ICAO1", Location = "Loc1", Country = "Country1" },
            new AirportModel { Id = "2", Name = "Airport2", IATA = "A2", ICAO = "ICAO2", Location = "Loc2", Country = "Country2" }
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
                Assert.Equal(models[i].Location, dtos[i].Location);
                Assert.Equal(models[i].Country, dtos[i].Country);
            }
        }
    }
}
