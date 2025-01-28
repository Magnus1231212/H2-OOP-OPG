namespace H2_OOP_OPG;

public class Lejlighedskompleks {
    public int KompleksID { get; private set; }
    public int InspektoerID { get; private set; }
    public string Type { get; private set; }
    public int SommerhusID { get; private set; }

    public Lejlighedskompleks(int kompleksID, int inspektoerID, string type, int sommerhusID) {
        KompleksID = kompleksID;
        InspektoerID = inspektoerID;
        Type = type;
        SommerhusID = sommerhusID;
    }
}