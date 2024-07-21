namespace FlightDispatcher.API.Exceptions
{
    public class AirportCodeNotFoundException : Exception
    {
        public AirportCodeNotFoundException(string message) : base(message)
        {
            
        }
    }
}
