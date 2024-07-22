using FlightDispatcher.FrontEnd.Domain.Models;
using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Components.Store.Airports
{
    [FeatureState]
    public record AirportsState()
    {
        public List<AirportModel> Airports { get; set; }

    }
}
