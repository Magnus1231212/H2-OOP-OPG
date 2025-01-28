namespace H2_OOP_OPG {
    /// <summary>
    /// Represents a reservation for a property.
    /// </summary>
    public class Reservation {
        /// <summary>
        /// Gets the unique identifier for the reservation.
        /// </summary>
        public int ReservationID { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the house associated with the reservation.
        /// </summary>
        public int HusID { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the customer associated with the reservation.
        /// </summary>
        public int KundeID { get; private set; }

        /// <summary>
        /// Gets the starting week of the reservation.
        /// </summary>
        public int StartUge { get; private set; }

        /// <summary>
        /// Gets the number of weeks the reservation is valid for.
        /// </summary>
        public int AntalUger { get; private set; }

        /// <summary>
        /// Gets the total price of the reservation.
        /// </summary>
        public double TotalPris { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Reservation"/> class.
        /// </summary>
        /// <param name="reservationID">The unique identifier for the reservation.</param>
        /// <param name="husID">The unique identifier for the house.</param>
        /// <param name="kundeID">The unique identifier for the customer.</param>
        /// <param name="startUge">The starting week of the reservation.</param>
        /// <param name="antalUger">The number of weeks for the reservation.</param>
        /// <param name="totalPris">The total price of the reservation.</param>
        public Reservation(int reservationID, int husID, int kundeID, int startUge, int antalUger, double totalPris) {
            ReservationID = reservationID;
            HusID = husID;
            KundeID = kundeID;
            StartUge = startUge;
            AntalUger = antalUger;
            TotalPris = totalPris;
        }
    }
}