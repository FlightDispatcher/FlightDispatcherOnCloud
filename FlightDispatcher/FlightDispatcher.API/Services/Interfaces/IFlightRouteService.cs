using FlightDispatcher.Domain.Models;

namespace FlightDispatcher.API.Services.Interfaces
{
    public interface IFlightRouteService: IControllerServiceReadOnly<FlightRouteModel>, IControllerServiceEditable<FlightRouteModel>, IControllerServiceErasable
    {

    }
}
