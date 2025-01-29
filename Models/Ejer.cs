using MySqlConnector;

namespace H2_OOP_OPG {

    /// <summary>
    /// Represents an owner with personal and contact information.
    /// </summary>
    public class Ejer {
        /// <summary>
        /// Gets the unique identifier for the owner.
        /// </summary>
        public int EjerID { get; private set; }

        /// <summary>
        /// Gets the name of the owner.
        /// </summary>
        public string Navn { get; private set; }

        /// <summary>
        /// Gets the email address of the owner.
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the phone number of the owner.
        /// </summary>
        public string Tlf { get; private set; }

        /// <summary>
        /// Gets the address of the owner.
        /// </summary>
        public string Adresse { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ejer"/> class.
        /// </summary>
        /// <param name="ejerID">The unique identifier for the owner.</param>
        /// <param name="navn">The name of the owner.</param>
        /// <param name="email">The email address of the owner.</param>
        /// <param name="tlf">The phone number of the owner.</param>
        /// <param name="adresse">The address of the owner.</param>
        public Ejer(int ejerID, string navn, string email, string tlf, string adresse) {
            EjerID = ejerID;
            Navn = navn;
            Email = email;
            Tlf = tlf;
            Adresse = adresse;
        }


        public static Ejer FindEjer(int id) {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Ejer WHERE EjerID = @id";
            command.Parameters.AddWithValue("@id", id);

            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Ejer ejer = Parsing.ParseEjer(reader);
            connection.Close();
            return ejer;
        }

        public static Ejer FindEjer(string email) {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Ejer WHERE Email = @email";
            command.Parameters.AddWithValue("@email", email);

            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Ejer ejer = Parsing.ParseEjer(reader);
            connection.Close();
            return ejer;
        }

        public bool Save() {
            MySqlConnection connection = DB.openConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Ejer (Navn, Email, Tlf, Adresse) VALUES (@navn, @email, @tlf, @adresse)";
            command.Parameters.AddWithValue("@navn", Navn);
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@tlf", Tlf);
            command.Parameters.AddWithValue("@adresse", Adresse);

            int rows = command.ExecuteNonQuery();
            connection.Close();
            return rows > 0;
        }
    }
}
