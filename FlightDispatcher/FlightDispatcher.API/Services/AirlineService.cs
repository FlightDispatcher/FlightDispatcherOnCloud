using FlightDispatcher.API.Exceptions;
using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infostructure.Interfaces;
using MongoDB.Bson;

namespace FlightDispatcher.API.Services
{
    /// <summary>
    /// Service for handling operations related to airlines.
    /// </summary>
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository _airlineRepository;

        public AirlineService(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        /// <summary>
        /// Creates a new airline.
        /// </summary>
        /// <param name="model">The airline model to be created.</param>
        /// <returns>The created <see cref="AirlineModel"/>.</returns>
        public async Task<AirlineModel> Create(AirlineModel model)
        {
            // Check if the IATA code is already in use
            var existingAirline = await _airlineRepository.GetByIATACode(model.IATA);
            if (existingAirline != null)
                throw new AirlineCodeAlreadyInUseException($"An airline with IATA code {model.IATA} already exists.");

            var createdDocument = await _airlineRepository.Create(model.ToDocument());
            return createdDocument.ToModel();
        }

        /// <summary>
        /// Deletes an airline by its ID.
        /// </summary>
        /// <param name="id">The ID of the airline to be deleted.</param>
        public async Task Delete(string id)
        {
            await _airlineRepository.Delete(ObjectId.Parse(id));
        }

        /// <summary>
        /// Retrieves all airlines.
        /// </summary>
        /// <returns>A list of <see cref="AirlineModel"/>.</returns>
        public async Task<List<AirlineModel>> GetAll()
        {
            var documents = await _airlineRepository.GetAll();
            return documents.ToModelList();
        }

        /// <summary>
        /// Retrieves an airline by its ID.
        /// </summary>
        /// <param name="id">The ID of the airline.</param>
        /// <returns>An <see cref="AirlineModel"/>.</returns>
        public async Task<AirlineModel> GetById(string id)
        {
            var document = await _airlineRepository.GetById(ObjectId.Parse(id));
            if (document == null)
                throw new NotFoundException($"Airline with ID {id} not found.");

            return document.ToModel();
        }

        /// <summary>
        /// Updates an existing airline.
        /// </summary>
        /// <param name="model">The airline model to be updated.</param>
        /// <returns>The updated <see cref="AirlineModel"/>.</returns>
        public async Task<AirlineModel> Update(AirlineModel model)
        {
            // Check if the IATA code is already in use by another airline
            var existingAirline = await _airlineRepository.GetByIATACode(model.IATA);
            if (existingAirline != null && existingAirline.Id.ToString() != model.Id)
                throw new AirlineCodeAlreadyInUseException($"An airline with IATA code {model.IATA} already exists.");

            var updatedDocument = await _airlineRepository.Update(model.ToDocument());
            return updatedDocument.ToModel();
        }

        /// <summary>
        /// Retrieves an airline by its IATA code.
        /// </summary>
        /// <param name="code">The IATA code of the airline.</param>
        /// <returns>A <see cref="AirlineModel"/>.</returns>
        public async Task<AirlineModel> GetByIATACode(string code)
        {
            var document = await _airlineRepository.GetByIATACode(code);
            if (document == null)
                throw new AirlineCodeNotFoundException($"Airline with IATA code {code} not found.");

            return document.ToModel();
        }
    }
}
