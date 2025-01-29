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
            }
            else {
                Console.WriteLine("Der skete en fejl.");
            }
        }

        public static void Edit() {
            Console.Write("Sommerhus ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Sommerhus sommerhus = Sommerhus.FindSommerhus(id);
            if (sommerhus == null) {
                Console.WriteLine("Sommerhus findes ikke.");
                return;
            }

            Console.Write("Ny lokation ({0}): ", sommerhus.Lokation);
            string location = Console.ReadLine() ?? sommerhus.Lokation;
            Console.Write("Ny klassifikation ({0}): ", sommerhus.Klassifikation);
            string classification = Console.ReadLine() ?? sommerhus.Klassifikation;
            Console.Write("Nyt Område ID ({0}): ", sommerhus.OmraadeID);
            if (!int.TryParse(Console.ReadLine(), out int areaID)) {
                areaID = sommerhus.OmraadeID;
            }
            Console.Write("Ny Standard Pris ({0}): ", sommerhus.StandardPris);
            if (!double.TryParse(Console.ReadLine(), out double standardPrice)) {
                standardPrice = sommerhus.StandardPris;
            }

            Sommerhus updatedSommerhus = new Sommerhus(id, sommerhus.EjerID, location, classification, areaID, standardPrice);
            if (updatedSommerhus.Save()) {
                Console.WriteLine("Sommerhus opdateret.");
            }
            else {
                Console.WriteLine("Der skete en fejl.");
            }
        }

        public static void Delete() {
            Console.Write("Sommerhus ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Sommerhus sommerhus = Sommerhus.FindSommerhus(id);
            if (sommerhus == null) {
                Console.WriteLine("Sommerhus findes ikke.");
                return;
            }

            Console.WriteLine("Er du sikker på at du vil slette dette sommerhus? (y/n)");
            string confirm = Console.ReadLine() ?? "";
            if (confirm.ToLower() != "y") {
                Console.WriteLine("Sletning annulleret.");
                return;
            }

            if (sommerhus.Delete()) {
                Console.WriteLine("Sommerhus slettet.");
            }
            else {
                Console.WriteLine("Der skete en fejl.");
            }
        }

        public static void Show() {
            Console.Write("Sommerhus ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Sommerhus sommerhus = Sommerhus.FindSommerhus(id);
            if (sommerhus == null) {
                Console.WriteLine("Sommerhus findes ikke.");
                return;
            }

            Console.WriteLine("ID: {0}", sommerhus.HusID);
            Console.WriteLine("Ejer ID: {0}", sommerhus.EjerID);
            Console.WriteLine("Lokation: {0}", sommerhus.Lokation);
            Console.WriteLine("Klassifikation: {0}", sommerhus.Klassifikation);
            Console.WriteLine("Område ID: {0}", sommerhus.OmraadeID);
            Console.WriteLine("Standard Pris: {0}", sommerhus.StandardPris);
        }
    }
}