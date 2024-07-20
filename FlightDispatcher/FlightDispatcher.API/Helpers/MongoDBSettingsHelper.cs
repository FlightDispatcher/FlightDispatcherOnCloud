using FlightDispatcher.API.Models;

namespace FlightDispatcher.API.Helpers
{
    public static class MongoDBSettingsHelper
    {
        /*
         * This extension method compiles the connections string for MongoDB
         */
        public static string GetConnectionString(this MongoDBSettings settings)
        {
            return settings.ConnectionURI
                .Replace("<username>", settings.UserName)
                .Replace("<password>", settings.Password);
        }
    }
}
