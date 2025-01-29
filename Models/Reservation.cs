namespace H2_OOP_OPG;
using MySqlConnector;

/// <summary>
/// Represents a reservation for a property.
/// </summary>
public class Reservation
{
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
    public Reservation(int reservationID, int husID, int kundeID, int startUge, int antalUger, double totalPris)
    {
        ReservationID = reservationID;
        HusID = husID;
        KundeID = kundeID;
        StartUge = startUge;
        AntalUger = antalUger;
        TotalPris = totalPris;
    }

    public static Reservation FindReservation(int id)
    {
        MySqlConnection connection = DB.openConnection();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Reservation WHERE ReservationID = @id";
        command.Parameters.AddWithValue("@id", id);

        MySqlDataReader reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }
        Reservation reservation = Parsing.ParseReservation(reader);
        return reservation;
    }

    public bool Save() {
        MySqlConnection connection = DB.openConnection();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Reservation (HusID, KundeID, StartUge, AntalUger, TotalPris) VALUES (@husID, @kundeID, @startUge, @antalUger, @totalPris) ON DUPLICATE KEY UPDATE HusID = VALUES(HusID), KundeID = VALUES(KundeID), StartUge = VALUES(StartUge), AntalUger = VALUES(AntalUger), TotalPris = VALUES(TotalPris)";
        command.Parameters.AddWithValue("@husID", this.HusID);
        command.Parameters.AddWithValue("@kundeID", this.KundeID);
        command.Parameters.AddWithValue("@startUge", this.StartUge);
        command.Parameters.AddWithValue("@antalUger", this.AntalUger);
        command.Parameters.AddWithValue("@totalPris", this.TotalPris);

        int rows = command.ExecuteNonQuery();
        return rows >= 1;
    }

    public bool Delete()
    {
        MySqlConnection connection = DB.openConnection();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Reservation WHERE ReservationID = @id";
        command.Parameters.AddWithValue("@id", ReservationID);

        int rows = command.ExecuteNonQuery();
        return rows >= 1;
    }

    public static bool IsValidTimeframe(int husID, int startUge, int antalUger)
    {
        MySqlConnection connection = DB.openConnection();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Reservation WHERE HusID = @husID AND StartUge <= @startUge AND StartUge + AntalUger >= @startUge";
        command.Parameters.AddWithValue("@husID", husID);
        command.Parameters.AddWithValue("@startUge", startUge);

        MySqlDataReader reader = command.ExecuteReader();
        return !reader.Read();
    }

    public static Reservation[] FindReservations(int husID)
    {
        MySqlConnection connection = DB.openConnection();
        MySqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Reservation WHERE HusID = @husID";
        command.Parameters.AddWithValue("@husID", husID);

        MySqlDataReader reader = command.ExecuteReader();
        List<Reservation> reservations = new List<Reservation>();

        while (reader.Read())
        {
            Reservation reservation = Parsing.ParseReservation(reader);
            reservations.Add(reservation);
        }

        return reservations.ToArray();
    }
}
