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
    public class AirportSeedData
    {
        private readonly IMongoDatabase _testDatabase;
        private readonly AirportRepository _repository;

        public AirportSeedData()
        {
            var mongoClient = new MongoClient("mongodb+srv://fausto:VSpo9kh9ROvmmCEp@flightdispatcherdev.xckqibi.mongodb.net/?retryWrites=true&w=majority&appName=FlightDispatcherDEV"); // Replace with your MongoDB connection string
            _testDatabase = mongoClient.GetDatabase("FlightDispatcherDB");
            _repository = new AirportRepository(_testDatabase);
        }

        [Fact]
        public async Task SeedAirportsData()
        {
            // Arrange
            var ukAirports = new List<AirportDocument>
            {
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Birmingham Airport", IATA = "BHX", ICAO = "", Location = "Birmingham", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Bournemouth Airport", IATA = "BOH", ICAO = "", Location = "Bournemouth", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Bristol Airport", IATA = "BRS", ICAO = "", Location = "Bristol", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Cardiff Airport", IATA = "CWL", ICAO = "", Location = "Cardiff", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "East Midlands Airport", IATA = "EMA", ICAO = "", Location = "Nottingham", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Exeter Airport", IATA = "EXT", ICAO = "", Location = "Exeter", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Humberside Airport", IATA = "HUY", ICAO = "", Location = "Hull", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Leeds Bradford Airport", IATA = "LBA", ICAO = "", Location = "Leeds/Bradford", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Liverpool John Lennon Airport", IATA = "LPL", ICAO = "", Location = "Liverpool", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "London City Airport", IATA = "LCY", ICAO = "", Location = "London", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Gatwick Airport", IATA = "LGW", ICAO = "", Location = "London", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Heathrow Airport", IATA = "LHR", ICAO = "", Location = "London", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Luton Airport", IATA = "LTN", ICAO = "", Location = "London", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "London Southend Airport", IATA = "SEN", ICAO = "", Location = "London", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "London Stansted Airport", IATA = "STN", ICAO = "", Location = "London", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Manchester Airport", IATA = "MAN", ICAO = "", Location = "Manchester", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Newcastle International Airport", IATA = "NCL", ICAO = "", Location = "Newcastle upon Tyne", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Newquay Airport", IATA = "NQY", ICAO = "", Location = "Newquay", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Norwich Airport", IATA = "NWI", ICAO = "", Location = "Norwich", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Southampton Airport", IATA = "SOU", ICAO = "", Location = "Southampton", Country = "GB" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Teesside International Airport", IATA = "MME", ICAO = "", Location = "Middlesbrough", Country = "GB" }
            };

            var italianAirports = new List<AirportDocument>
            {
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Fertilia Airport", IATA = "AHO", ICAO = "", Location = "Alghero", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Ancona Airport", IATA = "AOI", ICAO = "", Location = "Ancona", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Palese Airport", IATA = "BRI", ICAO = "", Location = "Bari", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Orio al Serio Airport", IATA = "BGY", ICAO = "", Location = "Bergamo", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Bologna Airport", IATA = "BLQ", ICAO = "", Location = "Bologna", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Brescia Airport", IATA = "VBS", ICAO = "", Location = "Brescia", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Brindisi Airport", IATA = "BDS", ICAO = "", Location = "Brindisi", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Cagliari Airport", IATA = "CAG", ICAO = "", Location = "Cagliari", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Fontanarossa Airport", IATA = "CTA", ICAO = "", Location = "Catania", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Cuneo Levaldigi Airport", IATA = "CUF", ICAO = "", Location = "Cuneo", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Peretola Airport", IATA = "FLR", ICAO = "", Location = "Florence", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Cristoforo Colombo Airport", IATA = "GOA", ICAO = "", Location = "Genoa", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Lamezia Terme Airport", IATA = "SUF", ICAO = "", Location = "Lamezia", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Linate Airport", IATA = "LIN", ICAO = "", Location = "Milan", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Malpensa Airport", IATA = "MXP", ICAO = "", Location = "Milan", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Naples International Airport", IATA = "NAP", ICAO = "", Location = "Naples", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Costa Smeralda Airport", IATA = "OLB", ICAO = "", Location = "Olbia", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Palermo Airport", IATA = "PMO", ICAO = "", Location = "Palermo", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Giuseppe Verdi Airport", IATA = "PMF", ICAO = "", Location = "Parma", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "San Egidio Airport", IATA = "PEG", ICAO = "", Location = "Perugia", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Abruzzo Airport", IATA = "PSR", ICAO = "", Location = "Pescara", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Galileo Galilei Airport", IATA = "PSA", ICAO = "", Location = "Pisa", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Federico Fellini Airport", IATA = "RMI", ICAO = "", Location = "Rimini", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Leonardo da Vinci–Fiumicino Airport", IATA = "FCO", ICAO = "", Location = "Rome", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Ciampino Airport", IATA = "CIA", ICAO = "", Location = "Rome", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Vincenzo Florio Airport", IATA = "TPS", ICAO = "", Location = "Trapani", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Friuli Venezia Giulia Airport", IATA = "TRS", ICAO = "", Location = "Trieste", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Caselle Airport", IATA = "TRN", ICAO = "", Location = "Turin", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Venice Marco Polo Airport", IATA = "VCE", ICAO = "", Location = "Venice", Country = "IT" },
                new AirportDocument { Id = ObjectId.GenerateNewId(), Name = "Verona Villafranca Airport", IATA = "VRN", ICAO = "", Location = "Verona", Country = "IT" }
            };

            // Act
            foreach (AirportDocument airport in ukAirports)
            {
                await _repository.Create(airport);
            }

            foreach (AirportDocument airport in italianAirports)
            {
                await _repository.Create(airport);
            }

            var result = await _repository.GetAll();

            // Assert
            Assert.NotNull(result);
            
        }
    }
}
