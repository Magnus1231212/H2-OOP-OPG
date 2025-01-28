namespace H2_OOP_OPG;

public class Omraade {
    public int OmraadeID { get; private set; }  
    public string Navn { get; private set; }
    public int KonsulentID { get; private set; }

    public Omraade(int omraadeID, string navn, int konsulentID) {
        OmraadeID = omraadeID;
        Navn = navn;
        KonsulentID = konsulentID;
    }
}