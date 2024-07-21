using System.ComponentModel.DataAnnotations;

namespace FlightDispatcher.API.DTOs
{
    public class AirlineDTO
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IATA code is required")]
        public string IATA { get; set; }

        public string ICAO { get; set; }
    }
}
