namespace H2_OOP_OPG;

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

    // Parse classes to SQL data
    public static MySqlParameter[] ParseEjer(Ejer ejer) {
        return new MySqlParameter[] {
            new("EjerID", ejer.EjerID),
            new("Navn", ejer.Navn),
            new("Email", ejer.Email),
            new("Tlf", ejer.Tlf),
            new("Adresse", ejer.Adresse)
        };
    }

    public static MySqlParameter[] ParseSommerhus(Sommerhus sommerhus) {
        return new MySqlParameter[] {
            new("HusID", sommerhus.HusID),
            new("EjerID", sommerhus.EjerID),
            new("Lokation", sommerhus.Lokation),
            new("Klassifikation", sommerhus.Klassifikation),
            new("OmraadeID", sommerhus.OmraadeID),
            new("StandardPris", sommerhus.StandardPris)
        };
    }

    public static MySqlParameter[] ParseReservation(Reservation reservation) {
        return new MySqlParameter[] {
            new("ReservationID", reservation.ReservationID),
            new("HusID", reservation.HusID),
            new("KundeID", reservation.KundeID),
            new("StartUge", reservation.StartUge),
            new("AntalUger", reservation.AntalUger),
            new("TotalPris", reservation.TotalPris)
        };
    }

    public static MySqlParameter[] ParseKunde(Kunde kunde) {
        return new MySqlParameter[] {
            new("KundeID", kunde.KundeID),
            new("Navn", kunde.Navn),
            new("Telefon", kunde.Telefon),
            new("Email", kunde.Email)
        };
    }

    public static MySqlParameter[] ParseOmraade(Omraade omraade) {
        return new MySqlParameter[] {
            new("OmraadeID", omraade.OmraadeID),
            new("Navn", omraade.Navn),
            new("KonsulentID", omraade.KonsulentID)
        };
    }

    public static MySqlParameter[] ParseKonsulent(Konsulent konsulent) {
        return new MySqlParameter[] {
            new("KonsulentID", konsulent.KonsulentID),
            new("Navn", konsulent.Navn),
            new("KontaktInfo", konsulent.KontaktInfo)
        };
    }


    public static MySqlParameter[] ParseInspektoer(Inspektoer inspektoer) {
        return new MySqlParameter[] {
            new("InspektoerID", inspektoer.InspektoerID),
            new("Navn", inspektoer.Navn),
            new("KontaktInfo", inspektoer.KontaktInfo)
        };
    }

    public static MySqlParameter[] ParseSaesonkategori(Saesonkategori saesonkategori) {
        return new MySqlParameter[] {
            new("KategoriID", saesonkategori.KategoriID),
            new("Navn", saesonkategori.Navn),
            new("Uger", saesonkategori.Uger),
            new("Saeson", saesonkategori.Saeson),
            new("PrisProcent", saesonkategori.PrisProcent)
        };
    }

    public static MySqlParameter[] ParseLejlighedskompleks(Lejlighedskompleks lejlighedskompleks) {
        return new MySqlParameter[] {
            new("KompleksID", lejlighedskompleks.KompleksID),
            new("InspektoerID", lejlighedskompleks.InspektoerID),
            new("Type", lejlighedskompleks.Type),
            new("SommerhusID", lejlighedskompleks.SommerhusID)
        };
    }

    public static MySqlParameter[] ParseSommerhusSaesonPris(SommerhusSaesonPris sommerhusSaesonPris) {
        return new MySqlParameter[] {
            new("StandardPris", sommerhusSaesonPris.StandardPris),
            new("SommerhusID", sommerhusSaesonPris.SommerhusID),
            new("SaesonkategoriID", sommerhusSaesonPris.SaesonkategoriID)
        };
    }

    public static MySqlParameter[] ParseUser(User user) {
        return new MySqlParameter[] {
            new("UserID", user.UserID),
            new("Brugernavn", user.Brugernavn),
            new("Adgangskode", user.Adgangskode)
        };
    }

}
