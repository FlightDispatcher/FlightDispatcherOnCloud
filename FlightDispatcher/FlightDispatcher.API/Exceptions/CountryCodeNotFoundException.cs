namespace FlightDispatcher.API.Exceptions
{
    public class CountryCodeNotFoundException : Exception
    {
        public CountryCodeNotFoundException(string message) : base(message)
        {
            
        }
    }
}
