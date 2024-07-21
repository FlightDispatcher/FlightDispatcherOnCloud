using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infrastructure.Interfaces;
using FlightDispatcher.API.Helpers;
using FlightDispatcher.Domain.Helpers;
using MongoDB.Bson;
using FlightDispatcher.API.Exceptions;

namespace FlightDispatcher.API.Services
{
    /// <summary>
    /// Service for handling operations related to airports.
    /// </summary>
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airportRepository;
        private readonly ICountryService _countryService;

        public AirportService(IAirportRepository airportRepository, ICountryService countryService)
        {
            _airportRepository = airportRepository;
            _countryService = countryService;
        }

        /// <summary>
        /// Creates a new airport.
        /// </summary>
        /// <param name="model">The airport model to be created.</param>
        /// <returns>The created <see cref="AirportModel"/>.</returns>
        public async Task<AirportModel> Create(AirportModel model)
        {
            // Check if the country code is valid
            try
            {
                var country = await _countryService.GetByCode(model.Country);
            }
            catch (NotFoundException)
            {

                throw new CountryCodeNotFoundException($"Invalid country code: {model.Country}");
            }

            // Check if the IATA code is already in use
            var existingAirport = await _airportRepository.GetByIATACode(model.IATA);
            if (existingAirport != null)
                throw new AirportCodeAlreadyInUseException($"An airport with IATA code {model.IATA} already exists.");

            var createdDocument = await _airportRepository.Create(model.ToDocument());
            return createdDocument.ToModel();
        }

        /// <summary>
        /// Deletes an airport by its ID.
        /// </summary>
        /// <param name="id">The ID of the airport to be deleted.</param>
        public async Task Delete(string id)
        {
            await _airportRepository.Delete(ObjectId.Parse(id));
        }

        /// <summary>
        /// Retrieves all airports.
        /// </summary>
        /// <returns>A list of <see cref="AirportModel"/>.</returns>
        public async Task<List<AirportModel>> GetAll()
        {
            var documents = await _airportRepository.GetAll();
            return documents.ToModelList();
        }

        /// <summary>
        /// Retrieves an airport by its ID.
        /// </summary>
        /// <param name="id">The ID of the airport.</param>
        /// <returns>An <see cref="AirportModel"/>.</returns>
        public async Task<AirportModel> GetById(string id)
        {
            var document = await _airportRepository.GetById(ObjectId.Parse(id));
            if (document == null)
                throw new NotFoundException($"Airport with ID {id} not found.");

            return document.ToModel();
        }

        /// <summary>
        /// Updates an existing airport.
        /// </summary>
        /// <param name="model">The airport model to be updated.</param>
        /// <returns>The updated <see cref="AirportModel"/>.</returns>
        public async Task<AirportModel> Update(AirportModel model)
        {
            // Check if the country code is valid
            try
            {
                var country = await _countryService.GetByCode(model.Country);
            }
            catch (NotFoundException)
            {

                throw new CountryCodeNotFoundException($"Invalid country code: {model.Country}");
            }

            // Check if the IATA code is already in use by another airport
            var existingAirport = await _airportRepository.GetByIATACode(model.IATA);
            if (existingAirport != null && existingAirport.Id.ToString() != model.Id)
                throw new AirportCodeAlreadyInUseException($"An airport with IATA code {model.IATA} already exists.");

            var updatedDocument = await _airportRepository.Update(model.ToDocument());
            return updatedDocument.ToModel();
        }

        /// <summary>
        /// Retrieves an airport by its IATA code.
        /// </summary>
        /// <param name="code">The IATA code of the airport.</param>
        /// <returns>A <see cref="AirportModel"/>.</returns>
        public async Task<AirportModel> GetByIATACode(string code)
        {
            var document = await _airportRepository.GetByIATACode(code);
            if (document == null)
                throw new AirportCodeNotFoundException($"Airport with IATA code {code} not found.");

            return document.ToModel();
        }
    }
}
