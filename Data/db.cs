using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace H2_OOP_OPG;

class DB {
    public static string GetConnectionString() {
        var configuration = new ConfigurationBuilder()
            .SetBasePath("./") // Set the base path for the file
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        return configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
    }

    public static MySqlConnection openConnection() {
        var connection = new MySqlConnection(GetConnectionString());
        connection.Open();
        return connection;
    }
}
