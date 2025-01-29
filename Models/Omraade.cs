namespace H2_OOP_OPG {
    using MySqlConnector;

    /// <summary>
    /// Represents an area associated with a consultant.
    /// </summary>
    public class Omraade {
        /// <summary>
        /// Gets the unique identifier for the area.
        /// </summary>
        public int OmraadeID { get; private set; }

        /// <summary>
        /// Gets the name of the area.
        /// </summary>
        public string Navn { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the consultant associated with the area.
        /// </summary>
        public int KonsulentID { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omraade"/> class.
        /// </summary>
        public Omraade(int omraadeID, string navn, int konsulentID) {
            OmraadeID = omraadeID;
            Navn = navn;
            KonsulentID = konsulentID;
        }

        public static Omraade FindOmraade(int id) {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Omraade WHERE OmraadeID = @id";
            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read()) {
                connection.Close();
                return null;
            }

            Omraade omraade = new Omraade(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            connection.Close();
            return omraade;
        }

        public bool Save() {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Omraade (OmraadeID, Navn, KonsulentID)
                VALUES (@omraadeID, @navn, @konsulentID)
                ON DUPLICATE KEY UPDATE
                    Navn = VALUES(Navn),
                    KonsulentID = VALUES(KonsulentID)";
            command.Parameters.AddWithValue("@omraadeID", OmraadeID);
            command.Parameters.AddWithValue("@navn", Navn);
            command.Parameters.AddWithValue("@konsulentID", KonsulentID);

            int rows = command.ExecuteNonQuery();
            connection.Close();
            return rows > 0;
        }

        public bool Delete() {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Omraade WHERE OmraadeID = @id";
            command.Parameters.AddWithValue("@id", OmraadeID);

            int rows = command.ExecuteNonQuery();
            connection.Close();
            return rows > 0;
        }
    }
}
