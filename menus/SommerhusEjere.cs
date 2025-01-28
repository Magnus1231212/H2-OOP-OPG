namespace H2_OOP_OPG
{
    /// <summary>
    /// Handles operations related to summer house owners, including creating, editing, deleting, and viewing them.
    /// </summary>
    class SommerhusEjere
    {
        /// <summary>
        /// Displays the submenu for managing summer house owners.
        /// </summary>
        public static void SubMenu()
        {
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

        /// <summary>
        /// Handles the creation of a new summer house owner.
        /// </summary>
        public static void Create()
        {
            Console.WriteLine("Opret Sommerhus Ejer");
        }

        /// <summary>
        /// Handles the editing of an existing summer house owner.
        /// </summary>
        public static void Edit()
        {
            Console.WriteLine("Rediger Sommerhus Ejer");
        }

        /// <summary>
        /// Handles the deletion of an existing summer house owner.
        /// </summary>
        public static void Delete()
        {
            Console.WriteLine("Slet Sommerhus Ejer");
        }

        /// <summary>
        /// Displays information about a summer house owner.
        /// </summary>
        public static void Show()
        {
            Console.WriteLine("Vis Sommerhus Ejer");
        }
    }
}