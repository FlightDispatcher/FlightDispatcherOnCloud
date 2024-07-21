using FlightDispatcher.Domain.Documents;
using FlightDispatcher.Infrastructure.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Infrastructure.Test.SeedData
{
    public class CountrySeedData
    {
        private readonly IMongoDatabase _testDatabase;
        private readonly CountryRepository _repository;

        //public CountrySeedData()
        //{
        //    var mongoClient = new MongoClient("mongodb+srv://fausto:VSpo9kh9ROvmmCEp@flightdispatcherdev.xckqibi.mongodb.net/?retryWrites=true&w=majority&appName=FlightDispatcherDEV"); // Replace with your MongoDB connection string
        //    _testDatabase = mongoClient.GetDatabase("FlightDispatcherDB");
        //    _repository = new CountryRepository(_testDatabase);
        //}

        //[Fact]
        //public async Task SeedAirlinesData()
        //{
        //    // Arrange
        //    var countries = new List<CountryDocument>
        //{
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Albania", Code = "AL" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Andorra", Code = "AD" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Austria", Code = "AT" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Belarus", Code = "BY" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Belgium", Code = "BE" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Bosnia and Herzegovina", Code = "BA" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Bulgaria", Code = "BG" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Croatia", Code = "HR" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Cyprus", Code = "CY" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Czech Republic", Code = "CZ" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Denmark", Code = "DK" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Estonia", Code = "EE" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Finland", Code = "FI" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "France", Code = "FR" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Germany", Code = "DE" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Greece", Code = "GR" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Hungary", Code = "HU" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Iceland", Code = "IS" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Ireland", Code = "IE" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Italy", Code = "IT" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Kosovo", Code = "XK" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Latvia", Code = "LV" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Lithuania", Code = "LT" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Luxembourg", Code = "LU" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Malta", Code = "MT" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Moldova", Code = "MD" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Monaco", Code = "MC" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Montenegro", Code = "ME" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Netherlands", Code = "NL" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "North Macedonia", Code = "MK" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Norway", Code = "NO" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Poland", Code = "PL" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Portugal", Code = "PT" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Romania", Code = "RO" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Russia", Code = "RU" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "San Marino", Code = "SM" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Serbia", Code = "RS" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Slovakia", Code = "SK" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Slovenia", Code = "SI" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Spain", Code = "ES" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Sweden", Code = "SE" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Switzerland", Code = "CH" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Turkey", Code = "TR" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "Ukraine", Code = "UA" },
        //    new CountryDocument { Id = ObjectId.GenerateNewId(), Name = "United Kingdom", Code = "GB" }
        //};

        //    // Act
        //    foreach (CountryDocument country in countries)
        //    {
        //        await _repository.Create(country);
        //    }

        //    var result = await _repository.GetAll();

        //    // Assert
        //    Assert.NotNull(result);

        //}
    }
}
