namespace H2_OOP_OPG;

public class Inspektoer {
    public int InspektoerID { get; private set; }
    public string Navn { get; private set; }
    public string KontaktInfo { get; private set; }


    public Inspektoer(int inspektoerID, string navn, string kontaktInfo) {
        InspektoerID = inspektoerID;
        Navn = navn;
        KontaktInfo = kontaktInfo;
    }
}