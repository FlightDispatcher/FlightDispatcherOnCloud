using FlightDispatcher.API.Exceptions;
using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infostructure.Interfaces;
using MongoDB.Bson;

namespace FlightDispatcher.API.Services
{
    /// <summary>
    /// Service for handling operations related to flight routes.
    /// </summary>
    public class FlightRouteService: IFlightRouteService
    {
        private readonly IFlightRouteRepository _flightRouteRepository;

        public FlightRouteService(IFlightRouteRepository flightRouteRepository)
        {
            _flightRouteRepository = flightRouteRepository;
        }

        /// <summary>
        /// Creates a new flight route.
        /// </summary>
        /// <param name="model">The flight route model to be created.</param>
        /// <returns>The created <see cref="FlightRouteModel"/>.</returns>
        public async Task<FlightRouteModel> Create(FlightRouteModel model)
        {
            var createdDocument = await _flightRouteRepository.Create(model.ToDocument());
            return createdDocument.ToModel();
        }

        /// <summary>
        /// Deletes a flight route by its ID.
        /// </summary>
        /// <param name="id">The ID of the flight route to be deleted.</param>
        public async Task Delete(string id)
        {
            await _flightRouteRepository.Delete(ObjectId.Parse(id));
        }

        /// <summary>
        /// Retrieves all flight routes.
        /// </summary>
        /// <returns>A list of <see cref="FlightRouteModel"/>.</returns>
        public async Task<List<FlightRouteModel>> GetAll()
        {
            var documents = await _flightRouteRepository.GetAll();
            return documents.ToModelList();
        }

        /// <summary>
        /// Retrieves a flight route by its ID.
        /// </summary>
        /// <param name="id">The ID of the flight route.</param>
        /// <returns>A <see cref="FlightRouteModel"/>.</returns>
        public async Task<FlightRouteModel> GetById(string id)
        {
            var document = await _flightRouteRepository.GetById(ObjectId.Parse(id));
            if (document == null)
                throw new NotFoundException($"Flight route with ID {id} not found.");

            return document.ToModel();
        }

        /// <summary>
        /// Updates an existing flight route.
        /// </summary>
        /// <param name="model">The flight route model to be updated.</param>
        /// <returns>The updated <see cref="FlightRouteModel"/>.</returns>
        public async Task<FlightRouteModel> Update(FlightRouteModel model)
        {
            var updatedDocument = await _flightRouteRepository.Update(model.ToDocument());
            return updatedDocument.ToModel();
        }
    }
}
