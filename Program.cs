using MySqlConnector;

namespace H2_OOP_OPG;

class Program {
    public static bool Exit = false;

    static void Main(string[] args) {
        // Initialize the menu
        Menu.Initialize("Sommerhus Udlejning", true, 7, 7);

        // Main menu
        do {
            // Name of the project
            string Title = "Home";

            // Array of options to be displayed
            string[] options = {
                    "Login",
                };

            // Array of actions to be called
            Action[] cases = {
                    () => {},
                    () => {},
                };

            // Build main menu
            Menu.buildMain(options, cases, Title);

        } while (!Exit);
    }

    public static void MainMenu() {
        // Name of submenu
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
                () => SommerhusEjere(),
            };

        // Build submenu
        Menu.buildSub(name, options, cases);
    }

    public static void SommerhusEjere() {
        // Name of submenu
        string name = "Sommerhus Ejere";

        // Options to be displayed
        string[] options = {
                "Opret Sommerhus Ejer",
                "Rediger Sommerhus Ejer",
                "Slet Sommerhus Ejer",
                "Vis Sommerhus Ejer",
            };

        // Array of actions to be called
        Action[] cases = {
                () => {},
            };

        // Build submenu
        Menu.buildSub(name, options, cases);
    }
}
