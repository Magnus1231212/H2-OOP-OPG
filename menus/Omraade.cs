namespace H2_OOP_OPG {
    /// <summary>
    /// Handles operations related to areas, including creating, editing, deleting, and viewing them.
    /// </summary>
    class Omraader {
        /// <summary>
        /// Displays the submenu for managing areas.
        /// </summary>
        public static void SubMenu() {
            // Name of submenu
            string name = "Områder";

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
        /// Handles the creation of a new area.
        /// </summary>
        public static void Create() {
            Console.Write("Navn på Område: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Konsulent ID: ");
            if (!int.TryParse(Console.ReadLine(), out int konsulentID)) {
                Console.WriteLine("Ugyldigt Konsulent ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name)) {
                Console.WriteLine("Områdenavn må ikke være tomt.");
                return;
            }

            Omraade omraade = new Omraade(0, name, konsulentID);
            if (omraade.Save()) {
                Console.WriteLine("Område oprettet.");
            } else {
                Console.WriteLine("Der skete en fejl.");
            }
        }

        /// <summary>
        /// Handles the editing of an existing area.
        /// </summary>
        public static void Edit() {
            Console.Write("Område ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Omraade omraade = Omraade.FindOmraade(id);
            if (omraade == null) {
                Console.WriteLine("Område ikke fundet.");
                return;
            }

            Console.Write($"Navn ({omraade.Navn}): ");
            string name = Console.ReadLine() ?? "";
            Console.Write($"Konsulent ID ({omraade.KonsulentID}): ");
            if (!int.TryParse(Console.ReadLine(), out int konsulentID)) {
                Console.WriteLine("Ugyldigt Konsulent ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(name)) {
                Console.WriteLine("Områdenavn må ikke være tomt.");
                return;
            }

            Omraade updatedOmraade = new Omraade(id, name, konsulentID);
            if (updatedOmraade.Save()) {
                Console.WriteLine("Område opdateret.");
            } else {
                Console.WriteLine("Der skete en fejl.");
            }
        }

        /// <summary>
        /// Handles the deletion of an existing area.
        /// </summary>
        public static void Delete() {
            Console.Write("Område ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Omraade omraade = Omraade.FindOmraade(id);
            if (omraade == null) {
                Console.WriteLine("Område ikke fundet.");
                return;
            }

            Console.Write($"Er du sikker på, at du vil slette {omraade.Navn}? (y/n): ");
            string confirm = Console.ReadLine() ?? "";
            if (confirm.ToLower() != "y") {
                Console.WriteLine("Sletning annulleret.");
                return;
            }

            if (omraade.Delete()) {
                Console.WriteLine("Område slettet.");
            } else {
                Console.WriteLine("Der skete en fejl.");
            }
        }

        /// <summary>
        /// Displays information about an area.
        /// </summary>
        public static void Show() {
            Console.Write("Område ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) {
                Console.WriteLine("Ugyldigt ID.");
                return;
            }

            Omraade omraade = Omraade.FindOmraade(id);
            if (omraade == null) {
                Console.WriteLine("Område ikke fundet.");
                return;
            }

            Console.WriteLine($"ID: {omraade.OmraadeID}");
            Console.WriteLine($"Navn: {omraade.Navn}");
            Console.WriteLine($"Konsulent ID: {omraade.KonsulentID}");
        }
    }
}
