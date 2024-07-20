using MongoDB.Bson;

namespace FlightDispatcher.API.Services.Interfaces
{
    public interface IControllerServiceErasable
    {
        Task Delete(string id);
    }
}
