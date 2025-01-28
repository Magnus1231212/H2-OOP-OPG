namespace H2_OOP_OPG;

public class Konsulent {
    public int KonsulentID { get; private set; }
    public string Navn { get; private set; }
    public string KontaktInfo { get; private set; }


    public Konsulent(int konsulentID, string navn, string kontaktInfo) {
        KonsulentID = konsulentID;
        Navn = navn;
        KontaktInfo = kontaktInfo;
    }
}