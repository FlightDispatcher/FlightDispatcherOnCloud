﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.Domain.Models
{
    public class FlightRouteAirportModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IATA { get; set; }
    }
}
