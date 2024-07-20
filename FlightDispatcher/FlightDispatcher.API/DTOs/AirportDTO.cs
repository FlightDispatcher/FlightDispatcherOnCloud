using System.ComponentModel.DataAnnotations;

namespace FlightDispatcher.API.DTOs
{
    public class AirportDTO
    {
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "IATA code is required")]
        public string IATA { get; set; }

        public string ICAO { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
    }
}
