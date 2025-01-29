namespace H2_OOP_OPG {

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
            SommerhusSaesonPris[] priser = SommerhusSaesonPris.FindSommerhusSaesonPris(houseID);

            if (sommerhus == null || priser.Length == 0) {
                Console.WriteLine("Hus eller pris ikke fundet");
                return;
            }

            Saesonkategori[] saesoner = new Saesonkategori[priser.Length];
            for (int i = 0; i < priser.Length; i++) {
                saesoner[i] = Saesonkategori.FindSaesonkategori(priser[i].SaesonkategoriID);
            }

            int[] weeks = new int[weekCount];
            for (int i = 0; i < weekCount; i++) {
                weeks[i] = startWeek + i;
            }
            double totalPrice = 0;


            foreach (Saesonkategori saeson in saesoner) {
                // Parse season.Uger from "[int,int,int]" to int[]
                string[] weekStrings = saeson.Uger.Trim('[', ']').Split(',');
                int[] seasonWeeks = Array.ConvertAll(weekStrings, int.Parse);

                double pricePerWeek = priser[0].StandardPris * saeson.PrisProcent;
                for (int i = 0; i < weekCount; i++) {
                    if (seasonWeeks.Contains(weeks[i])) {
                        totalPrice += pricePerWeek;
                        weeks = weeks.Where(w => w != weeks[i]).ToArray();
                        weekCount--;
                    }
                }
            }

            // Handle the weeks that are not part of a season
            totalPrice += weeks.Length * priser[0].StandardPris;

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
            Console.WriteLine("Indtast reservations ID for at redigere");
            if (!int.TryParse(Console.ReadLine(), out int reservationID)) {
                Console.WriteLine("Uguvalid reservations ID");
                return;
            }

            Reservation reservation = Reservation.FindReservation(reservationID);
            if (reservation == null) {
                Console.WriteLine("Reservation ikke fundet");
                return;
            }

            Console.WriteLine("Indtast ny start uge af reservationen");
            if (!int.TryParse(Console.ReadLine(), out int newStartWeek)) {
                Console.WriteLine("Uguvalid uge");
                return;
            }

            Console.WriteLine("Indtast nyt antal uger af reservationen");
            if (!int.TryParse(Console.ReadLine(), out int newWeekCount)) {
                Console.WriteLine("Uguvalid tal");
                return;
            }

            if (!Reservation.IsValidTimeframe(reservation.HusID, newStartWeek, newWeekCount)) {
                Console.WriteLine("Invalid timeframe");
                return;
            }

            SommerhusSaesonPris[] priser = SommerhusSaesonPris.FindSommerhusSaesonPris(reservation.HusID);

            if (priser.Length == 0) {
                Console.WriteLine("Pris ikke fundet");
                return;
            }

            Saesonkategori[] saesoner = new Saesonkategori[priser.Length];
            for (int i = 0; i < priser.Length; i++) {
                saesoner[i] = Saesonkategori.FindSaesonkategori(priser[i].SaesonkategoriID);
            }

            int[] weeks = new int[newWeekCount];
            for (int i = 0; i < newWeekCount; i++) {
                weeks[i] = newStartWeek + i;
            }
            double newTotalPrice = 0;

            foreach (Saesonkategori saeson in saesoner) {
                string[] weekStrings = saeson.Uger.Trim('[', ']').Split(',');
                int[] seasonWeeks = Array.ConvertAll(weekStrings, int.Parse);

                double pricePerWeek = priser[0].StandardPris * saeson.PrisProcent;
                for (int i = 0; i < newWeekCount; i++) {
                    if (seasonWeeks.Contains(weeks[i])) {
                        newTotalPrice += pricePerWeek;
                        weeks = weeks.Where(w => w != weeks[i]).ToArray();
                        newWeekCount--;
                    }
                }
            }

            newTotalPrice += weeks.Length * priser[0].StandardPris;

            Reservation newReservation = new Reservation(reservationID, reservation.HusID, reservation.KundeID, newStartWeek, newWeekCount, newTotalPrice);

            if (newReservation.Save()) {
                Console.WriteLine("Reservation opdateret");
            } else {
                Console.WriteLine("Kunne ikke opdatere reservation");
            }
        }

        /// <summary>
        /// Handles the deletion of an existing booking.
        /// </summary>
        public static void Delete() {
            Console.WriteLine("Indtast reservations ID for at slette");
            if (!int.TryParse(Console.ReadLine(), out int reservationID)) {
                Console.WriteLine("Uguvalid reservations ID");
                return;
            }

            Reservation reservation = Reservation.FindReservation(reservationID);
            if (reservation == null) {
                Console.WriteLine("Reservation ikke fundet");
                return;
            }

            Console.WriteLine($"Er du sikker på at du vil slette reservation {reservationID}? (y/n)");
            string confirm = Console.ReadLine() ?? "";
            if (confirm != "y") {
                Console.WriteLine("Sletning afbrudt");
                return;
            }

            if (reservation.Delete()) {
                Console.WriteLine("Reservation slettet");
            } else {
                Console.WriteLine("Kunne ikke slette reservation");
            }
        }

        /// <summary>
        /// Displays information about a booking.
        /// </summary>
        public static void Show() {

        }
    }
}
