using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Test.Helpers
{
    public class CountryConverterTest
    {
        [Fact]
        public void ConvertDocumentToModel()
        {
            // Arrange
            var document = new CountryDocument
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Country One",
                Code = "AA",
            };

            // Act
            var model = document.ToModel();

            // Assert
            Assert.Equal(document.Id.ToString(), model.Id);
            Assert.Equal(document.Name, model.Name);
            Assert.Equal(document.Code, model.Code);
        }

        [Fact]
        public void ConvertModelToDocument()
        {
            // Arrange
            var model = new CountryModel
            {
                Id = "615f7e3a5e2b4e001f0b8e5d",
                Name = "Country Two",
                Code = "AB"
            };

            // Act
            var document = model.ToDocument();

            // Assert
            Assert.Equal(ObjectId.Parse(model.Id), document.Id);
            Assert.Equal(model.Name, document.Name);
            Assert.Equal(model.Code, document.Code);
        }
    }
}
