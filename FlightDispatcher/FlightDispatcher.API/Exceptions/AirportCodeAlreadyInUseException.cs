namespace FlightDispatcher.API.Exceptions
{
    public class AirportCodeAlreadyInUseException: Exception
    {
        public AirportCodeAlreadyInUseException(string message) : base(message)
        {
            
        }
    }
}
