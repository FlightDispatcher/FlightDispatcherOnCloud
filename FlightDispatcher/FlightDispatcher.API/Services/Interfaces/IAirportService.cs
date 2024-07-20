using FlightDispatcher.Domain.Models;

namespace FlightDispatcher.API.Services.Interfaces
{
    public interface IAirportService : IControllerServiceReadOnly<AirportModel>, IControllerServiceEditable<AirportModel>, IControllerServiceErasable
    {
    }
}
