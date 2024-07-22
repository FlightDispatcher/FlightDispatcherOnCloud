using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Components.Store.Airlines
{
    public record LoadAirlinesAction();
    public record LoadAirlinesSuccessfulAction();
    public record LoadAirlinesFailedAction();
    public record SaveAirlineAction();
    public record SaveAirlineSuccessfulAction();
    public record SaveAirlineFailedAction();
}
