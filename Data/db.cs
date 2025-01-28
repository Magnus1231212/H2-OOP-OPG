using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace H2_OOP_OPG
{
    /// <summary>
    /// Provides methods for managing database connections and retrieving connection strings.
    /// </summary>
    class DB
    {
        /// <summary>
        /// Retrieves the database connection string from the configuration file.
        /// </summary>
        /// <returns>
        /// The connection string specified in the <c>appsettings.json</c> file.
        /// </returns>
        public static string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set the base path for the file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Load the configuration file
                .Build();

            return configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        /// <summary>
        /// Opens a connection to the MySQL database using the connection string.
        /// </summary>
        /// <returns>An open <see cref="MySqlConnection"/> instance.</returns>
        public static MySqlConnection openConnection()
        {
            var connection = new MySqlConnection(GetConnectionString());
            connection.Open();
            return connection;
        }
    }
}
