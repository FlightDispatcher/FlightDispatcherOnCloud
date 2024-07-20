using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Infostructure.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Test.Repositories
{
    public class AirportRepositoryTest
    {
        private readonly IMongoDatabase _testDatabase;
        private readonly AirportRepository _repository;

        public AirportRepositoryTest()
        {
            var mongoClient = new MongoClient("mongodb+srv://fausto:VSpo9kh9ROvmmCEp@flightdispatcherdev.xckqibi.mongodb.net/?retryWrites=true&w=majority&appName=FlightDispatcherDEV"); // Replace with your MongoDB connection string
            _testDatabase = mongoClient.GetDatabase("FlightDispatcherDBTest");
            _repository = new AirportRepository(_testDatabase);
        }

        [Fact]
        public async Task GetAll_ReturnsAllDocuments()
        {
            // Arrange
            var document1 = new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Airport One", IATA = "IATA1", ICAO = "ICAO1", Country = "UK" };
            var document2 = new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Airport Two", IATA = "IATA2", ICAO = "ICAO2", Country = "UK" };
            await _repository.Create(document1);
            await _repository.Create(document2);

            // Act
            var result = await _repository.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Contains(result, doc => doc.Id == document1.Id);
            Assert.Contains(result, doc => doc.Id == document2.Id);
        }

        [Fact]
        public async Task GetById_ReturnsDocumentById()
        {
            // Arrange
            var document = new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Airport Three", IATA = "IATA1", ICAO = "ICAO1", Country = "Italy" };
            await _repository.Create(document);

            // Act
            var result = await _repository.GetById(document.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(document.Id, result.Id);
        }

        [Fact]
        public async Task Insert_AddsNewDocument()
        {
            // Arrange
            var newDocument = new AirportDocument { Name = "New Airport", IATA = "IATA1", ICAO = "ICAO1", Country = "UK" };

            // Act
            newDocument = await _repository.Create(newDocument);
            var insertedDocument = await _repository.GetById(newDocument.Id);

            // Assert
            Assert.NotNull(insertedDocument);
            Assert.Equal("New Airport", insertedDocument.Name);
        }

        [Fact]
        public async Task Update_UpdatesExistingDocument()
        {
            // Arrange
            var existingDocument = new AirportDocument { Name = "Old Airport", IATA = "oldIATA", ICAO = "oldICAO", Country = "UK" };
            existingDocument = await _repository.Create(existingDocument);

            // Act
            existingDocument.Name = "Updated Airport";
            existingDocument.IATA = "newIATA";
            existingDocument.ICAO = "newICAO";
            existingDocument.Country = "Spain";
            var updatedDocument = await _repository.Update(existingDocument);

            // Assert
            Assert.NotNull(updatedDocument);
            Assert.Equal("Updated Airport", updatedDocument.Name);
            Assert.Equal("newIATA", updatedDocument.IATA);
            Assert.Equal("newICAO", updatedDocument.ICAO);
            Assert.Equal("Spain", updatedDocument.Country);
        }

        [Fact]
        public async Task Delete_RemovesDocumentById()
        {
            // Arrange
            var documentToDelete = new AirportDocument { Name = "Airport To Delete", IATA = "IATA", ICAO = "ICAO", Country = "Italy" };
            documentToDelete = await _repository.Create(documentToDelete);

            // Act
            await _repository.Delete(documentToDelete.Id);
            var deletedDocument = await _repository.GetById(documentToDelete.Id);

            // Assert
            Assert.Null(deletedDocument);
        }
    }
}
