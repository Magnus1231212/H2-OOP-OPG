namespace H2_OOP_OPG;

/// <summary>
/// Represents a user with an ID, username, and password.
/// </summary>
public class User {
    /// <summary>
    /// Gets the user ID.
    /// </summary>
    public int UserID { get; private set; }

    /// <summary>
    /// Gets the username.
    /// </summary>
    public string Brugernavn { get; private set; }

    /// <summary>
    /// Gets the password.
    /// </summary>
    public string Adgangskode { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="userID">The user ID.</param>
    /// <param name="brugernavn">The username.</param>
    /// <param name="adgangskode">The password.</param>
    public User(int userID, string brugernavn, string adgangskode) {
        UserID = userID;
        Brugernavn = brugernavn;
        Adgangskode = adgangskode;
    }
}