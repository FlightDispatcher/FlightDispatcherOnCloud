using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infostructure.Interfaces;
using MongoDB.Bson;

namespace FlightDispatcher.API.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository _airlineRepository;

        public AirlineService(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }

        public async Task<AirlineModel> Create(AirlineModel model)
        {
            var result = await _airlineRepository.Create(model.ToDocument());

            return result.ToModel();
        }

        public async Task Delete(string id)
        {
            await _airlineRepository.Delete(ObjectId.Parse(id));
        }

        public async Task<List<AirlineModel>> GetAll()
        {
            var result = await _airlineRepository.GetAll();

            return result.ToModelList();
        }

        public async Task<AirlineModel> GetById(string id)
        {
            var result = await _airlineRepository.GetById(ObjectId.Parse(id));

            return result.ToModel();
        }

        public async Task<AirlineModel> Update(AirlineModel model)
        {
            var result = await _airlineRepository.Update(model.ToDocument());

            return result.ToModel();
        }
    }
}
