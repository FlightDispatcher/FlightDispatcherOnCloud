namespace FlightDispatcher.API.Exceptions
{
    public class AirlineCodeAlreadyInUseException: Exception
    {
        public AirlineCodeAlreadyInUseException(string message) : base(message)
        {
            
        }
    }
}
