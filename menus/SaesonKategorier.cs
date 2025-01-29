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
                "Rediger Sæson Kategori",
                "Vis Sæson Kategori",
            };

            // Array of actions to be called
            Action[] cases = {
                () => Edit(),
                () => Show(),
            };

            // Build submenu
            Menu.buildSub(name, options, cases);
        }

        /// <summary>
        /// Handles the editing of an existing summer house.
        /// </summary>
        public static void Edit() {
            Console.WriteLine("ID på Sæson Kategori: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Saesonkategori kategori = Saesonkategori.FindSaesonkategori(id);
            if (kategori == null) {
                Console.WriteLine("Sæson Kategori ikke fundet.");
                return;
            }

            Console.WriteLine("Nyt Navn: ");
            string navn = Console.ReadLine();
            if (string.IsNullOrEmpty(navn)) {
                navn = kategori.Navn;
            }

            Console.WriteLine("Ny Start Uger: ");
            int startUge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ny Slut Uger: ");
            int slutUge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nyt Sæson: ");
            string saesonInput = Console.ReadLine();
            if (!Enum.TryParse(saesonInput, out SaesonkategoriEnum saeson)) {
                Console.WriteLine("Ugyldig Sæson værdi.");
                return;
            }

            Console.WriteLine("Nyt Pris Procent: ");
            double prisProcent = Convert.ToDouble(Console.ReadLine());

            List<int> uger = new List<int>();
            for (int i = startUge; i <= slutUge; i++) {
                uger.Add(i);
            }

            string ugerArray = $"[{string.Join(",", uger)}]";

            if (Saesonkategori.UpdateSaesonkategori(id, navn, ugerArray, saeson, prisProcent)) {
                Console.WriteLine("Saeson kategori opdateret.");
            }
            else {
                Console.WriteLine("Der skete en fejl under opdateringen.");
            }
        }

        /// <summary>
        /// Displays information about a summer house.
        /// </summary>
        public static void Show() {
            Console.WriteLine("Indsæt ID på Sæson Kategori: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Saesonkategori kategori = Saesonkategori.FindSaesonkategori(id);
            if (kategori == null) {
                Console.WriteLine("Sæson Kategori ikke fundet.");
                return;
            }

            Console.WriteLine($"ID: {kategori.KategoriID}");
            Console.WriteLine($"Navn: {kategori.Navn}");
            Console.WriteLine($"Uger: {kategori.Uger}");
            Console.WriteLine($"Sæson: {kategori.Saeson}");
            Console.WriteLine($"Pris Procent: {kategori.PrisProcent}");
        }
    }
}