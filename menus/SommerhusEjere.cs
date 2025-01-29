namespace H2_OOP_OPG {
    using Models;
    /// <summary>
    /// Handles operations related to summer house owners, including creating, editing, deleting, and viewing them.
    /// </summary>
    class SommerhusEjere {
        /// <summary>
        /// Displays the submenu for managing summer house owners.
        /// </summary>
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

        /// <summary>
        /// Handles the creation of a new summer house owner.
        /// </summary>
        public static void Create() {
            // Ask for name, email, phone number, and address
            Console.Write("Navn: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            Console.Write("Telefon: ");
            string phone = Console.ReadLine() ?? "";
            Console.Write("Adresse: ");
            string address = Console.ReadLine() ?? "";

            if (name == "" || email == "" || phone == "" || address == "") {
                Console.WriteLine("Alle felter skal udfyldes.");
                return;
            }

            if (Ejer.FindEjer(email) != null) {
                Console.WriteLine("Ejer findes allerede.");
                return;
            }

            // Create a new owner
            Ejer owner = new Ejer(0, name, email, phone, address);
            if (owner.Save()) {
                Console.WriteLine("Ejer oprettet.");
            } else {
                Console.WriteLine("Der skete en fejl.");
            }

        }

        /// <summary>
        /// Handles the editing of an existing summer house owner.
        /// </summary>
        public static void Edit() {
            Console.WriteLine("Ejer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Ejer owner = Ejer.FindEjer(id);
            if (owner == null) {
                Console.WriteLine("Ejer findes ikke.");
                return;
            }

            Console.WriteLine($"Navn ({owner.Navn}): ");
            string name = Console.ReadLine() ?? "";
            Console.WriteLine($"Email ({owner.Email}): ");
            string email = Console.ReadLine() ?? "";
            Console.WriteLine($"Telefon ({owner.Tlf}): ");
            string phone = Console.ReadLine() ?? "";
            Console.WriteLine($"Adresse ({owner.Adresse}): ");
            string address = Console.ReadLine() ?? "";

            if (name == "" || email == "" || phone == "" || address == "") {
                Console.WriteLine("Alle felter skal udfyldes.");
                return;
            }

            Ejer newOwner = new Ejer(id, name, email, phone, address);
            if (newOwner.Save()) {
                Console.WriteLine("Ejer opdateret.");
            } else {
                Console.WriteLine("Der skete en fejl.");
            }


        }

        /// <summary>
        /// Handles the deletion of an existing summer house owner.
        /// </summary>
        public static void Delete() {
            Console.WriteLine("Ejer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Ejer owner = Ejer.FindEjer(id);
            if (owner == null) {
                Console.WriteLine("Ejer findes ikke.");
                return;
            }

            Console.WriteLine($"Er du sikker på at du vil slette {owner.Navn}? (y/n)");
            string confirm = Console.ReadLine() ?? "";
            if (confirm != "y") {
                Console.WriteLine("Sletning annulleret.");
                return;
            }

            if (owner.Delete()) {
                Console.WriteLine("Ejer slettet.");
            } else {
                Console.WriteLine("Der skete en fejl.");
            }
        }

        /// <summary>
        /// Displays information about a summer house owner.
        /// </summary>
        public static void Show() {
            Console.WriteLine("Ejer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Ejer owner = Ejer.FindEjer(id);
            if (owner == null) {
                Console.WriteLine("Ejer findes ikke.");
                return;
            }

            Console.WriteLine($"ID: {owner.EjerID}");
            Console.WriteLine($"Navn: {owner.Navn}");
            Console.WriteLine($"Email: {owner.Email}");
            Console.WriteLine($"Telefon: {owner.Tlf}");
            Console.WriteLine($"Adresse: {owner.Adresse}");
        }
    }
}
