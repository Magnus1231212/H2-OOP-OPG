namespace H2_OOP_OPG {
    /// <summary>
    /// Represents a customer with contact information.
    /// </summary>
    public class Kunde {
        /// <summary>
        /// Gets the unique identifier for the customer.
        /// </summary>
        public int KundeID { get; private set; }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        public string Navn { get; private set; }

        /// <summary>
        /// Gets the phone number of the customer.
        /// </summary>
        public string Telefon { get; private set; }

        /// <summary>
        /// Gets the email address of the customer.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Kunde"/> class.
        /// </summary>
        /// <param name="kundeID">The unique identifier for the customer.</param>
        /// <param name="navn">The name of the customer.</param>
        /// <param name="telefon">The phone number of the customer.</param>
        /// <param name="email">The email address of the customer.</param>
        public Kunde(int kundeID, string navn, string telefon, string email) {
            KundeID = kundeID;
            Navn = navn;
            Telefon = telefon;
            Email = email;
        }
    }
}