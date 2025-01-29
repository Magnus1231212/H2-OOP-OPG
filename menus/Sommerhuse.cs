namespace H2_OOP_OPG {
    using Models;
    /// <summary>
    /// Handles operations related to summer houses, including creating, editing, deleting, and viewing them.
    /// </summary>
    class Sommerhuse {
        /// <summary>
        /// Displays the submenu for managing summer houses.
        /// </summary>
        public static void SubMenu() {
            // Name of submenu
            string name = "Sommerhuse";

            // Options to be displayed
            string[] options = {
                "Opret Sommerhus",
                "Rediger Sommerhus",
                "Slet Sommerhus",
                "Vis Sommerhus",
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
            Console.Write("Ejer Email: ");
            string email = Console.ReadLine() ?? "";
            
            Ejer owner = Ejer.FindEjer(email);
            if (owner == null) {
                Console.WriteLine("Ejer ikke fundet.");
                return;
            }
            
            Console.Write("Lokation: ");
            string location = Console.ReadLine() ?? "";
            Console.Write("Klassifikation: ");
            string classification = Console.ReadLine() ?? "";
            Console.Write("Område ID: ");
            if (!int.TryParse(Console.ReadLine(), out int areaID)) {
                Console.WriteLine("Ugyldigt Område ID.");
                return;
            }
            Console.Write("Standard Pris: ");
            if (!double.TryParse(Console.ReadLine(), out double standardPrice)) {
                Console.WriteLine("Ugyldig pris.");
                return;
            }

            Sommerhus sommerhus = new Sommerhus(0, owner.EjerID, location, classification, areaID, standardPrice);
            if (sommerhus.Save()) {
                Console.WriteLine("Sommerhus oprettet.");
            } else {
                Console.WriteLine("Der skete en fejl.");
            }
        }

        /// <summary>
        /// Handles the editing of an existing summer house.
        /// </summary>
        public static void Edit() {
            Console.WriteLine("Rediger Sommerhus");
        }

        /// <summary>
        /// Handles the deletion of an existing summer house.
        /// </summary>
        public static void Delete() {
            Console.WriteLine("Slet Sommerhus");
        }

        /// <summary>
        /// Displays information about a summer house.
        /// </summary>
        public static void Show() {
            Console.WriteLine("Vis Sommerhus");
        }
    }
}