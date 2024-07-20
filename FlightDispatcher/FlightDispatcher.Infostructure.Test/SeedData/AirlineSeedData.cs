using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Infostructure.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infostructure.Test.SeedData
{
    public class AirlineSeedData
    {
        private readonly IMongoDatabase _testDatabase;
        private readonly AirlineRepository _repository;

        public AirlineSeedData()
        {
            var mongoClient = new MongoClient("mongodb+srv://fausto:VSpo9kh9ROvmmCEp@flightdispatcherdev.xckqibi.mongodb.net/?retryWrites=true&w=majority&appName=FlightDispatcherDEV"); // Replace with your MongoDB connection string
            _testDatabase = mongoClient.GetDatabase("FlightDispatcherDB");
            _repository = new AirlineRepository(_testDatabase);
        }

        [Fact]
        public async Task SeedAirlinesData()
        {
            // Arrange
            var airlines = new List<AirlineDocument>
            {
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Ryanair", IATA = "FR", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Lufthansa", IATA = "LH", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Air France", IATA = "AF", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "EasyJet", IATA = "U2", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "British Airways", IATA = "BA", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "KLM Royal Dutch Airlines", IATA = "KL", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Turkish Airlines", IATA = "TK", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Aeroflot", IATA = "SU", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Swiss International Air Lines", IATA = "LX", ICAO = "" },
                new AirlineDocument { Id = ObjectId.GenerateNewId(), Name = "Vueling Airlines", IATA = "VY", ICAO = "" }
            };

            // Act
            foreach (AirlineDocument airline in airlines)
            {
                await _repository.Create(airline);
            }

            var result = await _repository.GetAll();

            // Assert
            Assert.NotNull(result);

        }
    }
}
