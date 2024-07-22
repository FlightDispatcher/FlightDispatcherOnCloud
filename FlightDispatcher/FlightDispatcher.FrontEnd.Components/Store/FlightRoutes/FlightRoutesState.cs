using FlightDispatcher.FrontEnd.Domain.Models;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Components.Store.FlightRoutes
{
    [FeatureState]
    public record FlightRoutesState()
    {
        public List<FlightRouteModel> FlightRoutes { get; set; }

    }
}
