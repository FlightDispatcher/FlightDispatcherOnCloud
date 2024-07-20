namespace FlightDispatcher.API.DTOs
{
    public class AirportDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IATA { get; set; }
        public string ICAO { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
    }
}
