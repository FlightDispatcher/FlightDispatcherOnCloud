using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Components.Store.FlightRoutes
{
    public record LoadFlightRoutesAction();
    public record LoadFlightRoutesSuccessfulAction();
    public record LoadFlightRoutesFailedAction();
    public record SaveFlightRouteAction();
    public record SaveFlightRouteSuccessfulAction();
    public record SaveFlightRouteFailedAction();
}
