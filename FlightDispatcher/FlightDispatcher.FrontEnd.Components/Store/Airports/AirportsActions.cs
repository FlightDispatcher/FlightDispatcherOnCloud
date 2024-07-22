using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Components.Store.Airports
{
    public record LoadAirportsAction();
    public record LoadAirportsSuccessfulAction();
    public record LoadAirportsFailedAction();
    public record SaveAirportAction();
    public record SaveAirportSuccessfulAction();
    public record SaveAirportFailedAction();
}
