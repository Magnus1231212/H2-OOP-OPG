namespace H2_OOP_OPG {
    using Models;
    using MySqlConnector;

    /// <summary>
    /// Represents a summer house with various properties such as ID, location, classification, and standard price.
    /// </summary>
    public class Sommerhus {
        public int HusID { get; private set; }
        public int EjerID { get; private set; }
        public string Lokation { get; private set; }
        public string Klassifikation { get; private set; }
        public int OmraadeID { get; private set; }
        public double StandardPris { get; private set; }

        public Sommerhus(int husID, int ejerID, string lokation, string klassifikation, int omraadeID, double standardPris) {
            HusID = husID;
            EjerID = ejerID;
            Lokation = lokation;
            Klassifikation = klassifikation;
            OmraadeID = omraadeID;
            StandardPris = standardPris;
        }

        public static Sommerhus FindSommerhus(int id) {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Sommerhus WHERE HusID = @id";
            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read()) {
                connection.Close();
                return null;
            }
            
            Sommerhus sommerhus = Parsing.ParseSommerhus(reader);
            connection.Close();
            return sommerhus;
        }

        public bool Save() {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Sommerhus (EjerID, Lokation, Klassifikation, OmraadeID, StandardPris) VALUES (@ejerID, @lokation, @klassifikation, @omraadeID, @standardPris)";
            command.Parameters.AddWithValue("@ejerID", EjerID);
            command.Parameters.AddWithValue("@lokation", Lokation);
            command.Parameters.AddWithValue("@klassifikation", Klassifikation);
            command.Parameters.AddWithValue("@omraadeID", OmraadeID);
            command.Parameters.AddWithValue("@standardPris", StandardPris);

            int rows = command.ExecuteNonQuery();
            
            if (rows > 0) {
                command.CommandText = "SELECT LAST_INSERT_ID()";
                HusID = Convert.ToInt32(command.ExecuteScalar());
            }
            
            connection.Close();
            return rows > 0;
        }

        public bool Delete() {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Sommerhus WHERE HusID = @id";
            command.Parameters.AddWithValue("@id", HusID);

            int rows = command.ExecuteNonQuery();
            connection.Close();
            return rows > 0;
        }
    }
}