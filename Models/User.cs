namespace H2_OOP_OPG;

public class User {
    public int UserID { get; private set; }
    public string Brugernavn { get; private set; }
    public string Adgangskode { get; private set; }


    public User(int userID, string brugernavn, string adgangskode) {
        UserID = userID;
        Brugernavn = brugernavn;
        Adgangskode = adgangskode;
    }
}