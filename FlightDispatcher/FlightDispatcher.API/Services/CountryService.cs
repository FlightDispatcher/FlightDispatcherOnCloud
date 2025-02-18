﻿using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infrastructure.Interfaces;
using FlightDispatcher.API.Helpers;
using FlightDispatcher.Domain.Helpers;
using MongoDB.Bson;
using FlightDispatcher.API.Exceptions;

namespace FlightDispatcher.API.Services
{
    /// <summary>
    /// Service for handling operations related to countries.
    /// </summary>
    public class CountryService : ICountryService    
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Retrieves all countries.
        /// </summary>
        /// <returns>A list of <see cref="CountryModel"/>.</returns>
        public async Task<List<CountryModel>> GetAll()
        {
            var documents = await _countryRepository.GetAll();
            return documents.ToModelList();
        }

        /// <summary>
        /// Retrieves a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country.</param>
        /// <returns>A <see cref="CountryModel"/>.</returns>
        public async Task<CountryModel> GetById(string id)
        {
            var document = await _countryRepository.GetById(ObjectId.Parse(id));
            if (document == null)
                throw new NotFoundException($"Country with ID {id} not found.");

            return document.ToModel();
        }

        /// <summary>
        /// Retrieves a country by its ISO code.
        /// </summary>
        /// <param name="code">The ISO code of the country.</param>
        /// <returns>A <see cref="CountryModel"/>.</returns>
        public async Task<CountryModel> GetByCode(string code)
        {
            var document = await _countryRepository.GetByCode(code);
            if (document == null)
                throw new NotFoundException($"Country with code {code} not found.");

            return document.ToModel();
        }
    }
}
