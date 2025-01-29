namespace H2_OOP_OPG;
using MySqlConnector;

/// <summary>
/// Represents a seasonal category with specific attributes.
/// </summary>
public class Saesonkategori {
    /// <summary>
    /// Gets the unique identifier for the category.
    /// </summary>
    public int KategoriID { get; private set; }

    /// <summary>
    /// Gets the name of the category.
    /// </summary>
    public string Navn { get; private set; }

    /// <summary>
    /// Gets the weeks associated with the category.
    /// </summary>
    public string Uger { get; private set; }

    /// <summary>
    /// Gets the season associated with the category.
    /// </summary>
    public SaesonkategoriEnum Saeson { get; private set; }

    /// <summary>
    /// Gets the price percentage associated with the category.
    /// </summary>
    public double PrisProcent { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Saesonkategori"/> class.
    /// </summary>
    /// <param name="kategoriID">The unique identifier for the category.</param>
    /// <param name="navn">The name of the category.</param>
    /// <param name="uger">The weeks associated with the category.</param>
    /// <param name="saeson">The season associated with the category.</param>
    /// <param name="prisProcent">The price percentage associated with the category.</param>
    public Saesonkategori(int kategoriID, string navn, string uger, SaesonkategoriEnum saeson, double prisProcent) {
        KategoriID = kategoriID;
        Navn = navn;
        Uger = uger;
        Saeson = saeson;
        PrisProcent = prisProcent;
    }

    public static Saesonkategori FindSaesonkategori(int id) {
        MySqlConnection connection = DB.openConnection();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Saesonkategori WHERE KategoriID = @id";
        command.Parameters.AddWithValue("@id", id);

        MySqlDataReader reader = command.ExecuteReader();
        if (!reader.Read()) {
            return null;
        }
        Saesonkategori kategori = Parsing.ParseSaesonkategori(reader);
        return kategori;
    }
}
