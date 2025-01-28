using System.Security.Cryptography;
using System.Text;

namespace H2_OOP_OPG;

class Admin {
    public static void Login() {
        Console.Clear();
        Console.WriteLine("Login");

        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();

        if (username == "admin" && password == "admin") {
            Program.LoggedIn = true;
            Program.Username = username;
            Console.WriteLine("Logged in as " + username);
            Console.ReadKey();
        }
        else {
            Console.WriteLine("Invalid username or password");
            Console.ReadKey();
        }
    }

    public static bool IsLoggedin() {
        return Program.LoggedIn;
    }

    public static void Logout() {
        Program.LoggedIn = false;
        Program.Username = "";
    }

    public static string HashPassword(string password) {
        using (var sha256 = SHA256.Create()) {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}