using MongoDB.Bson;

namespace FlightDispatcher.API.Services.Interfaces
{
    public interface IControllerServiceReadOnly<TModel>
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetById(string id);
    }
}
