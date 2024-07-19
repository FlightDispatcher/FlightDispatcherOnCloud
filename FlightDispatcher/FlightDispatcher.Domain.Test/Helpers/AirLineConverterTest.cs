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
    public class AirlineConverterTest
    {
        [Fact]
        public void ConvertDocumentToModel()
        {
            // Arrange
            var document = new AirlineDocument
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Airline One",
                IATA = "AL1",
                ICAO = "ICA1"
            };

            // Act
            var model = AirlineConverter.ToModel(document);

            // Assert
            Assert.Equal(document.Id.ToString(), model.Id);
            Assert.Equal(document.Name, model.Name);
            Assert.Equal(document.IATA, model.IATA);
            Assert.Equal(document.ICAO, model.ICAO);
        }

        [Fact]
        public void ConvertModelToDocument()
        {
            // Arrange
            var model = new AirlineModel
            {
                Id = "615f7e3a5e2b4e001f0b8e5d",
                Name = "Airline Two",
                IATA = "AL2",
                ICAO = "ICA2"
            };

            // Act
            var document = AirlineConverter.ToDocument(model);

            // Assert
            Assert.Equal(ObjectId.Parse(model.Id), document.Id);
            Assert.Equal(model.Name, document.Name);
            Assert.Equal(model.IATA, document.IATA);
            Assert.Equal(model.ICAO, document.ICAO);
        }
    }
}
