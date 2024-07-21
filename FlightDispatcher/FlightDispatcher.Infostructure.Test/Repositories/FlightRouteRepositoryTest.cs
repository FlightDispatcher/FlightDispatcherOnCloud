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
    public class FlightRouteRepositoryTest
    {
        private readonly IMongoDatabase _testDatabase;
        private readonly FlightRouteRepository _repository;

        public FlightRouteRepositoryTest()
        {
            var mongoClient = new MongoClient("mongodb+srv://fausto:VSpo9kh9ROvmmCEp@flightdispatcherdev.xckqibi.mongodb.net/?retryWrites=true&w=majority&appName=FlightDispatcherDEV"); // Replace with your MongoDB connection string
            _testDatabase = mongoClient.GetDatabase("FlightDispatcherDBTest");
            _repository = new FlightRouteRepository(_testDatabase);
        }


        [Fact]
        public async Task GetAll_ReturnsAllDocuments()
        {
            // Arrange
            var document1 = new FlightRouteDocument { 
                Id = ObjectId.GenerateNewId(),
                AirLine = new() 
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airline One",
                    IATA = "ONE"
                },
                ArrivalAirport = new() 
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airport One",
                    IATA = "O"
                },
                DepartureAirport = new() 
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airport Two",
                    IATA = "T"
                },
                FlightNumber = "1",
                DepartureTime = "13:00",
                ArrivalTime = "15:00"
            };
            var document2 = new FlightRouteDocument
            {
                Id = ObjectId.GenerateNewId(),
                AirLine = new() 
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airline TWO",
                    IATA = "TWO"
                },
                ArrivalAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airport Three",
                    IATA = "T"
                },
                DepartureAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airport Four",
                    IATA = "F"
                },
                FlightNumber = "2",
                DepartureTime = "18:00",
                ArrivalTime = "20:00"
            };
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
            var document = new FlightRouteDocument
            {
                Id = ObjectId.GenerateNewId(),
                AirLine = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airline Three",
                    IATA = "Three"
                },
                ArrivalAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airport 5",
                    IATA = "5"
                },
                DepartureAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Airport 6",
                    IATA = "6"
                },
                FlightNumber = "3",
                DepartureTime = "10:00",
                ArrivalTime = "17:00"
            };
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
            var newDocument = new FlightRouteDocument
            {
                Id = ObjectId.GenerateNewId(),
                AirLine = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Ryanair",
                    IATA = "FR"
                },
                ArrivalAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "London Stanstead",
                    IATA = "STN"
                },
                DepartureAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Napoli",
                    IATA = "NAP"
                },
                FlightNumber = "FR1832",
                DepartureTime = "20:50",
                ArrivalTime = "22:45"
            };

            // Act
            newDocument = await _repository.Create(newDocument);
            var insertedDocument = await _repository.GetById(newDocument.Id);

            // Assert
            Assert.NotNull(insertedDocument);
            Assert.Equal("Ryanair", insertedDocument.AirLine.Name);
            Assert.Equal("London Stanstead", insertedDocument.ArrivalAirport.Name);
            Assert.Equal("Napoli", insertedDocument.DepartureAirport.Name);
        }

        [Fact]
        public async Task Update_UpdatesExistingDocument()
        {
            // Arrange
            var existingDocument = new FlightRouteDocument
            {
                Id = ObjectId.GenerateNewId(),
                AirLine = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Ryanair",
                    IATA = "FR"
                },
                ArrivalAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "London Stanstead",
                    IATA = "STN"
                },
                DepartureAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Napoli",
                    IATA = "NAP"
                },
                FlightNumber = "FR1832",
                DepartureTime = "20:50",
                ArrivalTime = "22:45"
            };
            existingDocument = await _repository.Create(existingDocument);

            // Act
            existingDocument.DepartureTime = "21:00";
            existingDocument.ArrivalTime = "23:30";
            var updatedDocument = await _repository.Update(existingDocument);

            // Assert
            Assert.NotNull(updatedDocument);
            Assert.Equal("21:00", updatedDocument.DepartureTime);
            Assert.Equal("23:30", updatedDocument.ArrivalTime);
        }

        [Fact]
        public async Task Delete_RemovesDocumentById()
        {
            // Arrange
            var documentToDelete = new FlightRouteDocument
            {
                Id = ObjectId.GenerateNewId(),
                AirLine = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Ryanair",
                    IATA = "FR"
                },
                ArrivalAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "London Stanstead",
                    IATA = "STN"
                },
                DepartureAirport = new()
                {
                    Id = ObjectId.GenerateNewId(),
                    Name = "Roma Ciampino",
                    IATA = "CIA"
                },
                FlightNumber = "FR1832",
                DepartureTime = "06:30",
                ArrivalTime = "08:20"
            };

            documentToDelete = await _repository.Create(documentToDelete);

            // Act
            await _repository.Delete(documentToDelete.Id);
            var deletedDocument = await _repository.GetById(documentToDelete.Id);

            // Assert
            Assert.Null(deletedDocument);
        }
    }
}
