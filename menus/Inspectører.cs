namespace H2_OOP_OPG {
    /// <summary>
    /// Handles operations related to summer house owners, including creating, editing, deleting, and viewing them.
    /// </summary>
    class Inspectører {
        /// <summary>
        /// Displays the submenu for managing summer house owners.
        /// </summary>
        public static void SubMenu() {
            // Name of submenu
            string name = "Inspectører";

            // Options to be displayed
            string[] options = {
                "Opret Inspectør",
                "Rediger Inspectør",
                "Slet Inspectør",
                "Vis Inspectør",
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
            Console.WriteLine("Navn: ");
            string name = Console.ReadLine() ?? "";

            Console.WriteLine("Kontaktinfo: ");
            string contactInfo = Console.ReadLine() ?? "";

            if (name == "" || contactInfo == "") {
                Console.WriteLine("Alle felter skal udfyldes.");
                return;
            }

            if (Inspektoer.FindInspektoer(name) != null) {
                Console.WriteLine("Inspectør findes allerede.");
                return;
            }

            Inspektoer inspector = new Inspektoer(0, name, contactInfo);
            if (inspector.Save()) {
                Console.WriteLine("Inspectør oprettet.");
            }
            else {
                Console.WriteLine("Der skete en fejl under oprettelsen.");
            }
        }

        /// <summary>
        /// Handles the editing of an existing summer house owner.
        /// </summary>
        public static void Edit() {
            Console.WriteLine("ID på Inspektør: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Inspektoer inspector = Inspektoer.FindInspektoer(id);

            if (inspector == null) {
                Console.WriteLine("Ingen Inspektør med det ID.");
                return;
            }

            Console.WriteLine("Nyt navn: ");
            string name = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(name)) {
                name = inspector.Navn;
            }

            Console.WriteLine("Ny kontaktinfo: ");
            string contactInfo = Console.ReadLine() ?? "";
            if (string.IsNullOrEmpty(contactInfo)) {
                contactInfo = inspector.KontaktInfo;
            }

            if (Inspektoer.UpdateInspektoer(id, name, contactInfo)) {
                Console.WriteLine("Inspektør opdateret.");
            }
            else {
                Console.WriteLine("Der skete en fejl under opdateringen.");
            }
        }

        /// <summary>
        /// Handles the deletion of an existing summer house owner.
        /// </summary>
        public static void Delete() {
            Console.WriteLine("ID på Inspektør: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Inspektoer inspector = Inspektoer.FindInspektoer(id);

            if (inspector == null) {
                Console.WriteLine("Ingen Inspektør med det ID.");
                return;
            }

            Console.WriteLine($"Er du sikker på at du vil slette {inspector.Navn}? (y/n)");
            string confirm = Console.ReadLine() ?? "";
            if (confirm != "y") {
                Console.WriteLine("Sletning annulleret.");
                return;
            }

            if (Inspektoer.DeleteInspektoer(id)) {
                Console.WriteLine("Inspektør slettet.");
            }
            else {
                Console.WriteLine("Der skete en fejl under sletningen.");
            }
        }

        /// <summary>
        /// Displays information about a summer house owner.
        /// </summary>
        public static void Show() {
            Console.WriteLine("ID på Inspektør: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Inspektoer inspector = Inspektoer.FindInspektoer(id);

            if (inspector == null) {
                Console.WriteLine("Ingen Inspektør med det ID.");
                return;
            }

            Console.Clear();

            Console.WriteLine($"ID: {inspector.InspektoerID}");
            Console.WriteLine($"Navn: {inspector.Navn}");
            Console.WriteLine($"Kontaktinfo: {inspector.KontaktInfo}");
        }
    }
}
