using MySqlConnector;

namespace H2_OOP_OPG;

class Program {
    public static bool Exit = false;
    public static bool LoggedIn = false;
    public static string Username = "";

    static void Main(string[] args) {
        // Initialize the menu
        Menu.Initialize("Sommerhus Udlejning", true, 7, 7);

        // Login menu
        do {
            Console.Clear();
            Console.WriteLine("Welcome to the Sommerhus Udlejning system\n");

            // Name of the project
            string Title = "Home";

            // Array of options to be displayed
            string[] options = {
                    "Login",
                };

            // Array of actions to be called
            Action[] cases = {
                    () => Admin.Login(),
                };

            // Build main menu
            Menu.buildMain(options, cases, Title);

        } while (!LoggedIn);
        MainMenu();
    }

    public static void MainMenu() {
        // Main menu
        do {
            Console.Clear();
            Console.WriteLine($"Hey {Username}, Welcome to the Sommerhus Udlejning system\n");

            // Name of menu
            string name = "Main Menu";

            // Options to be displayed
            string[] options = {
                "Sommerhus Ejere",
                "Sommerhuse",
                "Udlejninger",
                "Områder",
                "Sæson Kategorier",
                "Inspectører",
            };

            // Array of actions to be called
            Action[] cases = {
                () => SommerhusEjere.SubMenu(),
                () => Sommerhuse.SubMenu(),
                () => Udlejninger.SubMenu(),
                () => Omraader.SubMenu(),
                () => SaesonKategorier.SubMenu(),
                () => Inspectører.SubMenu(),
            };

            // Build submenu
            Menu.buildMain(options, cases, name);

        } while (!Exit);
    }
}
