using MySqlConnector;

namespace H2_OOP_OPG;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello, World!");
        using (var connection = DB.openConnection()) {
            var query = "SELECT * FROM User";
            using var command = new MySqlCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read()) {
                Console.WriteLine(reader.GetString("Brugernavn"));
            }
        }
    }
}
