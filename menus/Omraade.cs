namespace H2_OOP_OPG {
    /// <summary>
    /// Handles operations related to summer houses, including creating, editing, deleting, and viewing them.
    /// </summary>
    class Omraade {
        /// <summary>
        /// Displays the submenu for managing summer houses.
        /// </summary>
        public static void SubMenu() {
            // Name of submenu
            string name = "Område";

            // Options to be displayed
            string[] options = {
                "Opret Område",
                "Rediger Område",
                "Slet Område",
                "Vis Område",
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
            Console.WriteLine("Opret Område");
        }

        /// <summary>
        /// Handles the editing of an existing summer house.
        /// </summary>
        public static void Edit() {
            Console.WriteLine("Rediger Område");
        }

        /// <summary>
        /// Handles the deletion of an existing summer house.
        /// </summary>
        public static void Delete() {
            Console.WriteLine("Slet Område");
        }

        /// <summary>
        /// Displays information about a summer house.
        /// </summary>
        public static void Show() {
            Console.WriteLine("Vis Område");
        }
    }
}