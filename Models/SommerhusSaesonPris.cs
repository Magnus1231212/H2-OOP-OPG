namespace H2_OOP_OPG;

public class SommerhusSaesonPris {
    public double StandardPris { get; private set; }
    public int SommerhusID { get; private set; }
    public int SaesonkategoriID { get; private set; }

    public SommerhusSaesonPris(double standardpris, int sommerhusID, int saesonkategoriID) {
        StandardPris = standardpris;
        SommerhusID = sommerhusID;
        SaesonkategoriID = saesonkategoriID;
    }
}