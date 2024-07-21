using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Domain.DTOs
{
    public class AirlineDTO
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IATA code is required")]
        public string IATA { get; set; }

        public string ICAO { get; set; }
    }
}
