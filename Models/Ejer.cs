namespace H2_OOP_OPG;

public class Ejer {
    public int EjerID { get; private set; }
    public string Navn { get; private set; }
    public string Email { get; private set; }
    public string Tlf { get; private set; }
    public string Adresse { get; private set; }

    public Ejer(int ejerID, string navn, string email, string tlf, string adresse) {
        EjerID = ejerID;
        Navn = navn;
        Email = email;
        Tlf = tlf;
        Adresse = adresse;
    }
}