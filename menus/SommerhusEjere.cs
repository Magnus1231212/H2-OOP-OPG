namespace H2_OOP_OPG;

class SommerhusEjere {
    public static void SubMenu() {
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
                () => Create(),
                () => Edit(),
                () => Delete(),
                () => Show(),
            };

        // Build submenu
        Menu.buildSub(name, options, cases);
    }

    public static void Create() {
        Console.WriteLine("Opret Sommerhus Ejer");
    }

    public static void Edit() {
        Console.WriteLine("Rediger Sommerhus Ejer");
    }

    public static void Delete() {
        Console.WriteLine("Slet Sommerhus Ejer");
    }

    public static void Show() {
        Console.WriteLine("Vis Sommerhus Ejer");
    }
}