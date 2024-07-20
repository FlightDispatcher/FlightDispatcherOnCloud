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
    public class AirportConverterTest
    {
        [Fact]
        public void ConvertDocumentToModel()
        {
            // Arrange
            var document = new AirportDocument
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Airport One",
                IATA = "AP1",
                ICAO = "ICA1",
                Location = "Loc1",
                Country = "Country One"
            };

            // Act
            var model = document.ToModel();

            // Assert
            Assert.Equal(document.Id.ToString(), model.Id);
            Assert.Equal(document.Name, model.Name);
            Assert.Equal(document.IATA, model.IATA);
            Assert.Equal(document.ICAO, model.ICAO);
            Assert.Equal(document.Location, model.Location);
            Assert.Equal(document.Country, model.Country);
        }

        [Fact]
        public void ConvertModelToDocument()
        {
            // Arrange
            var model = new AirportModel
            {
                Id = "615f7e3a5e2b4e001f0b8e5d",
                Name = "Airport Two",
                IATA = "AP2",
                ICAO = "ICA2",
                Location = "Loc2",
                Country = "Country Two"
            };

            // Act
            var document = model.ToDocument();

            // Assert
            Assert.Equal(ObjectId.Parse(model.Id), document.Id);
            Assert.Equal(model.Name, document.Name);
            Assert.Equal(model.IATA, document.IATA);
            Assert.Equal(model.ICAO, document.ICAO);
            Assert.Equal(model.Location, document.Location);
            Assert.Equal(model.Country, document.Country);
        }
    }
}
