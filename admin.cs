using System.Security.Cryptography;
using System.Text;
using MySqlConnector;

namespace H2_OOP_OPG {
    /// <summary>
    /// Provides administrative functionality including login, logout, and password hashing.
    /// </summary>
    class Admin {
        /// <summary>
        /// Handles the login process for the admin user.
        /// </summary>
        public static void Login() {
            Console.Clear();
            Console.WriteLine("Login");

            Console.Write("Username: ");
            string username = Console.ReadLine() ?? string.Empty;

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? string.Empty;

            using (var connection = DB.openConnection()) {
                var query = "SELECT * FROM User";
                using var command = new MySqlCommand(query, connection);
                using var reader = command.ExecuteReader();
                string _password = HashPassword(password);
                while (reader.Read()) {
                    if (reader.GetString("Brugernavn") == username && reader.GetString("Adgangskode") == _password) {
                        Program.LoggedIn = true;
                        Program.Username = username;
                        Console.WriteLine("Logged in as " + username);
                        Console.ReadKey();
                        return;
                    }
                }
            }
            Console.WriteLine("Invalid username or password");
            Console.ReadKey();
        }

        public static void CreateUser() {
            Console.Clear();
            Console.WriteLine("Create User");

            Console.Write("Username: ");
            string username = Console.ReadLine() ?? string.Empty;

            Console.Write("Password: ");
            string password = Console.ReadLine() ?? string.Empty;

            using (var connection = DB.openConnection()) {
                var query = "INSERT INTO User (Brugernavn, Adgangskode) VALUES (@username, @password)";
                using var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", HashPassword(password));
                command.ExecuteNonQuery();
            }
            Console.WriteLine("User created");
            Console.ReadKey();
        }

        /// <summary>
        /// Checks if the admin user is currently logged in.
        /// </summary>
        /// <returns><c>true</c> if the admin user is logged in; otherwise, <c>false</c>.</returns>
        public static bool IsLoggedin() {
            return Program.LoggedIn;
        }

        /// <summary>
        /// Logs out the currently logged-in admin user.
        /// </summary>
        public static void Logout() {
            Program.LoggedIn = false;
            Program.Username = string.Empty;
        }

        /// <summary>
        /// Hashes the provided password using the SHA256 hashing algorithm.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hashed password as a Base64-encoded string.</returns>
        public static string HashPassword(string password) {
            using (var sha256 = SHA256.Create()) {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
