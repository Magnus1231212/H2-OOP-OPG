namespace H2_OOP_OPG {
    /// <summary>
    /// Handles operations related to summer houses, including creating, editing, deleting, and viewing them.
    /// </summary>
    class SaesonKategorier {
        /// <summary>
        /// Displays the submenu for managing summer houses.
        /// </summary>
        public static void SubMenu() {
            // Name of submenu
            string name = "Sæson Kategorier";

            // Options to be displayed
            string[] options = {
                "Opret Sæson Kategori",
                "Rediger Sæson Kategori",
                "Slet Sæson Kategori",
                "Vis Sæson Kategori",
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

        /// <summary>
        /// Handles the creation of a new summer house.
        /// </summary>
        public static void Create() {
            Console.WriteLine("Opret Sæson Kategori");
        }

        /// <summary>
        /// Handles the editing of an existing summer house.
        /// </summary>
        public static void Edit() {
            Console.WriteLine("Rediger Sæson Kategori");
        }

        /// <summary>
        /// Handles the deletion of an existing summer house.
        /// </summary>
        public static void Delete() {
            Console.WriteLine("Slet Sæson Kategori");
        }

        /// <summary>
        /// Displays information about a summer house.
        /// </summary>
        public static void Show() {
            Console.WriteLine("Vis Sæson Kategori");
        }
    }
}