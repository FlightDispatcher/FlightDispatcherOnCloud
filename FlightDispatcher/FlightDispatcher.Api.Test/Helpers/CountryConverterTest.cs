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
    public class CountryConverterTest
    {
        [Fact]
        public void ConvertDTOToModel()
        {
            // Arrange
            var dto = new CountryDTO
            {
                Id = "1",
                Name = "Sample Country",
                Code = "SA"
            };

            // Act
            var model = dto.ToModel();

            // Assert
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Name, model.Name);
            Assert.Equal(dto.Code, model.Code);
        }

        [Fact]
        public void ConvertDTOListToModelList()
        {
            // Arrange
            var dtos = new List<CountryDTO>
        {
            new CountryDTO { Id = "1", Name = "Country1", Code = "A1" },
            new CountryDTO { Id = "2", Name = "Country2", Code = "A2" }
        };

            // Act
            var models = dtos.ToModelList();

            // Assert
            Assert.Equal(dtos.Count, models.Count);
            for (int i = 0; i < dtos.Count; i++)
            {
                Assert.Equal(dtos[i].Id, models[i].Id);
                Assert.Equal(dtos[i].Name, models[i].Name);
                Assert.Equal(dtos[i].Code, models[i].Code);
            }
        }

        [Fact]
        public void ConvertModelToDTO()
        {
            // Arrange
            var model = new CountryModel
            {
                Id = "1",
                Name = "Sample Country",
                Code = "SA"
            };

            // Act
            var dto = model.ToDTO();

            // Assert
            Assert.Equal(model.Id, dto.Id);
            Assert.Equal(model.Name, dto.Name);
            Assert.Equal(model.Code, dto.Code);
        }

        [Fact]
        public void ToDTOList_ConvertsModelListToDTOList()
        {
            // Arrange
            var models = new List<CountryModel>
        {
            new CountryModel { Id = "1", Name = "Country1", Code = "A1" },
            new CountryModel { Id = "2", Name = "Country2", Code = "A2" }
        };

            // Act
            var dtos = models.ToDTOList();

            // Assert
            Assert.Equal(models.Count, dtos.Count);
            for (int i = 0; i < models.Count; i++)
            {
                Assert.Equal(models[i].Id, dtos[i].Id);
                Assert.Equal(models[i].Name, dtos[i].Name);
                Assert.Equal(models[i].Code, dtos[i].Code);
            }
        }
    }
}
