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
            var mongoClient = new MongoClient("mongodb://localhost:27017"); // Replace with your MongoDB connection string
            _testDatabase = mongoClient.GetDatabase("TestDatabase"); // Create a test database
            _repository = new AirlineRepository(_testDatabase);
        }

        [Fact]
        public async Task GetAll_ReturnsAllDocuments()
        {
            // Arrange
            var document1 = new AirLineDocument { Id = ObjectId.GenerateNewId(), Name = "Airline One", IATA = "IATA1", ICAO = "ICAO1" };
            var document2 = new AirLineDocument { Id = ObjectId.GenerateNewId(), Name = "Airline Two", IATA = "IATA2", ICAO = "ICAO2" };
            await _repository.Create(document1);
            await _repository.Create(document2);

            // Act
            var result = await _repository.GetAll();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, doc => doc.Name == "Airline One");
            Assert.Contains(result, doc => doc.Name == "Airline Two");
        }

        [Fact]
        public async Task GetById_ReturnsDocumentById()
        {
            // Arrange
            var document = new AirLineDocument { Id = ObjectId.GenerateNewId(), Name = "Airline Three", IATA = "IATA1", ICAO = "ICAO1" };
            await _repository.Create(document);

            // Act
            var result = await _repository.GetById(document.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Airline Three", result.Name);
        }

        [Fact]
        public async Task Insert_AddsNewDocument()
        {
            // Arrange
            var newDocument = new AirLineDocument { Name = "New Airline", IATA = "IATA1", ICAO = "ICAO1" };

            // Act
            await _repository.Create(newDocument);
            var insertedDocument = _testDatabase.GetCollection<AirLineDocument>("AirLine").Find(doc => doc.Name == "New Airline").FirstOrDefault();

            // Assert
            Assert.NotNull(insertedDocument);
            Assert.Equal("New Airline", insertedDocument.Name);
        }

        [Fact]
        public async Task Update_UpdatesExistingDocument()
        {
            // Arrange
            var existingDocument = new AirLineDocument { Id = ObjectId.GenerateNewId(), Name = "Old Airline" };
            _testDatabase.GetCollection<AirLineDocument>("AirLine").InsertOne(existingDocument);

            // Act
            existingDocument.Name = "Updated Airline";
            var updatedDocument = await _repository.Update(existingDocument);

            // Assert
            Assert.NotNull(updatedDocument);
            Assert.Equal("Updated Airline", updatedDocument.Name);
        }

        [Fact]
        public async Task Delete_RemovesDocumentById()
        {
            // Arrange
            var documentToDelete = new AirLineDocument { Id = ObjectId.GenerateNewId(), Name = "Airline Four" };
            _testDatabase.GetCollection<AirLineDocument>("AirLine").InsertOne(documentToDelete);

            // Act
            await _repository.Delete(documentToDelete.Id);
            var deletedDocument = _testDatabase.GetCollection<AirLineDocument>("AirLine").Find(doc => doc.Id == documentToDelete.Id).FirstOrDefault();

            // Assert
            Assert.Null(deletedDocument);
        }
    }
}
