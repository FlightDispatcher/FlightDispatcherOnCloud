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
    public class AirlineRepositoryTest
    {
        private readonly IMongoDatabase _testDatabase;
        private readonly AirlineRepository _repository;

        public AirlineRepositoryTest()
        {
            var mongoClient = new MongoClient("mongodb+srv://fausto:VSpo9kh9ROvmmCEp@flightdispatcherdev.xckqibi.mongodb.net/?retryWrites=true&w=majority&appName=FlightDispatcherDEV"); // Replace with your MongoDB connection string
            _testDatabase = mongoClient.GetDatabase("FlightDispatcherDB"); // Create a test database
            _repository = new AirlineRepository(_testDatabase);
        }

        [Fact]
        public async Task GetAll_ReturnsAllDocuments()
        {
            // Arrange
            var document1 = new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Airline One", IATA = "IATA1", ICAO = "ICAO1" };
            var document2 = new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Airline Two", IATA = "IATA2", ICAO = "ICAO2" };
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
            var document = new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Airline Three", IATA = "IATA1", ICAO = "ICAO1" };
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
            var newDocument = new AirlineDocument { Name = "New Airline", IATA = "IATA1", ICAO = "ICAO1" };

            // Act
            newDocument = await _repository.Create(newDocument);
            var insertedDocument = await _repository.GetById(newDocument.Id);

            // Assert
            Assert.NotNull(insertedDocument);
            Assert.Equal("New Airline", insertedDocument.Name);
        }

        [Fact]
        public async Task Update_UpdatesExistingDocument()
        {
            // Arrange
            var existingDocument = new AirlineDocument { Name = "Old Airline" , IATA = "oldIATA", ICAO = "oldICAO"};
            existingDocument = await _repository.Create(existingDocument);

            // Act
            existingDocument.Name = "Updated Airline";
            existingDocument.IATA = "newIATA";
            existingDocument.ICAO = "newICAO";
            var updatedDocument = await _repository.Update(existingDocument);

            // Assert
            Assert.NotNull(updatedDocument);
            Assert.Equal("Updated Airline", updatedDocument.Name);
            Assert.Equal("newIATA", updatedDocument.IATA);
            Assert.Equal("newICAO", updatedDocument.ICAO);
        }

        [Fact]
        public async Task Delete_RemovesDocumentById()
        {
            // Arrange
            var documentToDelete = new AirlineDocument { Name = "Airline To Delete", IATA = "IATA", ICAO = "ICAO" };
            documentToDelete = await _repository.Create(documentToDelete);

            // Act
            await _repository.Delete(documentToDelete.Id);
            var deletedDocument = await _repository.GetById(documentToDelete.Id);

            // Assert
            Assert.Null(deletedDocument);
        }
    }
}
