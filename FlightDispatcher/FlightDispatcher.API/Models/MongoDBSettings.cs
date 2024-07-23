namespace FlightDispatcher.API.Models
{
    /// <summary>
    /// Represents the settings required to connect to a MongoDB database.
    /// </summary>
    public class MongoDBSettings
    {
        /// <summary>
        /// Gets or sets the connection URI for the MongoDB server.
        /// This is typically a string in the format "mongodb://username:password@host:port".
        /// </summary>
        public string ConnectionURI { get; set; } = null!;

        /// <summary>
        /// Gets or sets the name of the database to connect to.
        /// This should be the name of an existing database on the MongoDB server.
        /// </summary>
        public string DatabaseName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the username for authenticating with the MongoDB server.
        /// This is required if the MongoDB server uses authentication.
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the password for authenticating with the MongoDB server.
        /// This is required if the MongoDB server uses authentication.
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
