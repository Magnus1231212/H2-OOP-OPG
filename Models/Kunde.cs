namespace H2_OOP_OPG;

public class Kunde {
    public int KundeID { get; private set; }
    public string Navn { get; private set; }
    public string Telefon { get; private set; }
    public string Email { get; private set; }
    public Kunde(int kundeID, string navn, string telefon, string email) {
        KundeID = kundeID;
        Navn = navn;
        Telefon = telefon;
        Email = email;
    }
}