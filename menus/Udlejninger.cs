namespace H2_OOP_OPG {
    using Models;

    /// <summary>
    /// Handles operations related to bookings, including creating, editing, deleting, and viewing them.
    /// </summary>
    class Udlejninger {
        /// <summary>
        /// Displays the submenu for managing bookings.
        /// </summary>
        public static void SubMenu() {
            // Name of submenu
            string name = "Sommerhus Ejere";

            // Options to be displayed
            string[] options = {
                "Opret udlejning",
                "Rediger udlejning",
                "Slet udlejning",
                "Vis udlejning",
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
        /// Handles the creation of a new booking.
        /// </summary>
        public static void Create() {
            // Get the start week of the booking

            Console.WriteLine("Indtast første uge af reservationen");
            if (!int.TryParse(Console.ReadLine(), out int startWeek)) {
                Console.WriteLine("Uguvalid uge");
                return;
            }

            Console.WriteLine("Indtast antal uger af reservationen");
            if (!int.TryParse(Console.ReadLine(), out int weekCount)) {
                Console.WriteLine("Uguvalid tal");
                return;
            }

            Console.WriteLine("Indtast hus ID");
            // Get the ID of the house being booked
            if (!int.TryParse(Console.ReadLine(), out int houseID)) {
                Console.WriteLine("Uguvalid hus ID");
                return;
            }

            Console.WriteLine("Indtast kunde ID");
            if (!int.TryParse(Console.ReadLine(), out int customerID)) {
                Console.WriteLine("Uguvalid kunde ID");
                return;
            }

            Sommerhus sommerhus = Sommerhus.FindSommerhus(houseID);
            SommerhusSaesonPris pris = SommerhusSaesonPris.FindSommerhusSaesonPris(houseID);
            Saesonkategori saeson = Saesonkategori.FindSaesonkategori(pris.SaesonkategoriID);


            double pricePerWeek = pris.StandardPris * saeson.PrisProcent;
            double totalPrice = pricePerWeek * weekCount;

            if (!Reservation.IsValidTimeframe(startWeek, weekCount, houseID)) {
                Console.WriteLine("Invalid timeframe");
                return;
            }

            Console.WriteLine($"Total price: {totalPrice}. Confirm booking? (y/n)");
            string confirm = Console.ReadLine() ?? "";
            if (confirm != "y") {
                Console.WriteLine("Booking cancelled");
                return;
            }

            Reservation reservation = new Reservation(0, houseID, customerID, startWeek, weekCount, totalPrice);
            if (reservation.Save()) {
                Console.WriteLine("Reservation created");
            } else {
                Console.WriteLine("Failed to create reservation");
            }
        }

        /// <summary>
        /// Handles the editing of an existing booking.
        /// </summary>
        public static void Edit() {

        }

        /// <summary>
        /// Handles the deletion of an existing booking.
        /// </summary>
        public static void Delete() {

        }

        /// <summary>
        /// Displays information about a booking.
        /// </summary>
        public static void Show() {

        }
    }
}
