namespace H2_OOP_OPG;

public class Sommerhus {
    public int HusID { get; private set; }
    public int EjerID { get; private set; }
    public string Lokation { get; private set; }
    public string Klassifikation { get; private set; }
    public int OmraadeID { get; private set; }
    public double StandardPris { get; private set; }

    public Sommerhus(int husID, int ejerID, string lokation, string klassifikation, int omraadeID, double standardPris) {
        HusID = husID;
        EjerID = ejerID;
        Lokation = lokation;
        Klassifikation = klassifikation;
        OmraadeID = omraadeID;
        StandardPris = standardPris;
    }
}