using FlightDispatcher.Domain.Models;

namespace FlightDispatcher.API.Services.Interfaces
{
    public interface IAirlineService: IControllerServiceReadOnly<AirlineModel>, IControllerServiceEditable<AirlineModel>, IControllerServiceErasable
    {

    }
}
