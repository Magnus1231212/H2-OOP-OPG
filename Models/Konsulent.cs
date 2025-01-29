using MySqlConnector;

namespace H2_OOP_OPG {
    /// <summary>
    /// Represents a consultant with contact information.
    /// </summary>
    public class Konsulent {
        /// <summary>
        /// Gets the unique identifier for the consultant.
        /// </summary>
        public int KonsulentID { get; private set; }

        /// <summary>
        /// Gets the name of the consultant.
        /// </summary>
        public string Navn { get; private set; }

        /// <summary>
        /// Gets the contact information for the consultant.
        /// </summary>
        public string KontaktInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Konsulent"/> class.
        /// </summary>
        /// <param name="konsulentID">The unique identifier for the consultant.</param>
        /// <param name="navn">The name of the consultant.</param>
        /// <param name="kontaktInfo">The contact information for the consultant.</param>
        public Konsulent(int konsulentID, string navn, string kontaktInfo) {
            KonsulentID = konsulentID;
            Navn = navn;
            KontaktInfo = kontaktInfo;
        }

        public static Konsulent FindKonsulent(int id) {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Konsulent WHERE KonsulentID = @id";
            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Konsulent konsulent = Parsing.ParseKonsulent(reader);
            connection.Close();
            return konsulent;
        }
    }
}