namespace FlightDispatcher.API.Exceptions
{
    public class AirlineCodeNotFoundException : Exception
    {
        public AirlineCodeNotFoundException(string message) : base(message)
        {
            
        }
    }
}
