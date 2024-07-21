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
        private readonly IAirlineService _airlineService;
        private readonly IAirportService _airportService;
        public FlightRouteService(IFlightRouteRepository flightRouteRepository, IAirlineService airlineService, IAirportService airportService)
        {
            _flightRouteRepository = flightRouteRepository;
            _airlineService = airlineService;
            _airportService = airportService;
        }

        /// <summary>
        /// Creates a new flight route.
        /// </summary>
        /// <param name="model">The flight route model to be created.</param>
        /// <returns>The created <see cref="FlightRouteModel"/>.</returns>
        public async Task<FlightRouteModel> Create(FlightRouteModel model)
        {
            await ValidateFlightRouteModel(model);

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
            await ValidateFlightRouteModel(model);

            var updatedDocument = await _flightRouteRepository.Update(model.ToDocument());
            return updatedDocument.ToModel();
        }

        private async Task ValidateFlightRouteModel(FlightRouteModel model)
        {
            // Check if the airline IATA code is valid
            var airline = await _airlineService.GetByIATACode(model.AirLine.IATA);
            if (airline == null)
            {
                throw new AirlineCodeNotFoundException($"Invalid airline IATA code: {model.AirLine.IATA}");
            } 
            else
            {
                if (model.AirLine.Id != airline.Id || model.AirLine.Name != airline.Name)
                {
                    throw new DataDiscrepancyException($"Data discrepancy for airline with IATA code: {model.AirLine.IATA}");
                }
            }

            // Check if the departure airport IATA code is valid
            var departureAirport = await _airportService.GetByIATACode(model.DepartureAirport.IATA);
            if (departureAirport == null)
            {
                throw new AirportCodeNotFoundException($"Invalid departure airport IATA code: {model.DepartureAirport.IATA}");
            }
            else
            {
                if (model.DepartureAirport.Id != departureAirport.Id || model.DepartureAirport.Name != departureAirport.Name)
                {
                    throw new DataDiscrepancyException($"Data discrepancy for Departure Airport with IATA code: {model.DepartureAirport.IATA}");
                }
            }
                

            // Check if the arrival airport IATA code is valid
            var arrivalAirport = await _airportService.GetByIATACode(model.ArrivalAirport.IATA);
            if (arrivalAirport == null)
            {
                throw new AirportCodeNotFoundException($"Invalid arrival airport IATA code: {model.ArrivalAirport.IATA}");
            }
            else
            {
                if (model.ArrivalAirport.Id != arrivalAirport.Id || model.ArrivalAirport.Name != arrivalAirport.Name)
                {
                    throw new DataDiscrepancyException($"Data discrepancy for Arrival Airport with IATA code: {model.ArrivalAirport.IATA}");
                }
            }
                
        }
    }
}
