namespace H2_OOP_OPG;

using H2_OOP_OPG.Models;
using MySqlConnector;

public class Parsing {
    // Parse SQL data to their respective classes

    public static Ejer ParseEjer(MySqlDataReader reader) {
        return new Ejer(
            reader.GetInt32("EjerID"),
            reader.GetString("Navn"),
            reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),
            reader.IsDBNull(reader.GetOrdinal("Tlf")) ? null : reader.GetString("Tlf"),
            reader.IsDBNull(reader.GetOrdinal("Adresse")) ? null : reader.GetString("Adresse")
        );
    }

    public static Sommerhus ParseSommerhus(MySqlDataReader reader) {
        return new Sommerhus(
            reader.GetInt32("HusID"),
            reader.GetInt32("EjerID"),
            reader.GetString("Lokation"),
            reader.GetString("Klassifikation"),
            reader.GetInt32("OmraadeID"),
            reader.GetDouble("StandardPris")
        );
    }

    public static Reservation ParseReservation(MySqlDataReader reader) {
        return new Reservation(
            reader.GetInt32("ReservationID"),
            reader.GetInt32("HusID"),
            reader.GetInt32("KundeID"),
            reader.GetInt32("StartUge"),
            reader.GetInt32("AntalUger"),
            reader.GetDouble("TotalPris")
        );
    }

    public static Kunde ParseKunde(MySqlDataReader reader) {
        return new Kunde(
            reader.GetInt32("KundeID"),
            reader.GetString("Navn"),
            reader.IsDBNull(reader.GetOrdinal("Telefon")) ? null : reader.GetString("Telefon"),
            reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email")
        );
    }

    public static Omraade ParseOmraade(MySqlDataReader reader) {
        return new Omraade(
            reader.GetInt32("OmraadeID"),
            reader.GetString("Navn"),
            reader.GetInt32("KonsulentID")
        );
    }

    public static Konsulent ParseKonsulent(MySqlDataReader reader) {
        return new Konsulent(
            reader.GetInt32("KonsulentID"),
            reader.GetString("Navn"),
            reader.GetString("KontaktInfo")
        );
    }

    public static Inspektoer ParseInspektoer(MySqlDataReader reader) {
        return new Inspektoer(
            reader.GetInt32("InspektoerID"),
            reader.GetString("Navn"),
            reader.GetString("KontaktInfo")
        );
    }

    public static Saesonkategori ParseSaesonkategori(MySqlDataReader reader) {
        return new Saesonkategori(
            reader.GetInt32("KategoriID"),
            reader.GetString("Navn"),
            reader.GetString("Uger"),
            Enum.Parse<SaesonkategoriEnum>(reader.GetString("Saeson")),
            reader.GetDouble("PrisProcent")
        );
    }

    public static Lejlighedskompleks ParseLejlighedskompleks(MySqlDataReader reader) {
        return new Lejlighedskompleks(
            reader.GetInt32("KompleksID"),
            reader.GetInt32("InspektoerID"),
            reader.GetString("Type"),
            reader.GetInt32("SommerhusID")
        );
    }

    public static SommerhusSaesonPris ParseSommerhusSaesonPris(MySqlDataReader reader) {
        return new SommerhusSaesonPris(
            reader.GetDouble("StandardPris"),
            reader.GetInt32("SommerhusID"),
            reader.GetInt32("SaesonkategoriID")
        );
    }

    public static User ParseUser(MySqlDataReader reader) {
        return new User(
            reader.GetInt32("UserID"),
            reader.GetString("Brugernavn"),
            reader.GetString("Adgangskode")
        );
    }

}
