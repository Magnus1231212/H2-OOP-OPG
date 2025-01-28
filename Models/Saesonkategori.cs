namespace H2_OOP_OPG;

public class Saesonkategori {
    public int KategoriID { get; private set; }
    public string Navn { get; private set; }
    public string Uger { get; private set; }
    public SaesonkategoriEnum Saeson { get; private set; }
    public double PrisProcent { get; private set; }

    public Saesonkategori(int kategoriID, string navn, string uger, SaesonkategoriEnum saeson, double prisProcent) {
        KategoriID = kategoriID;
        Navn = navn;
        Uger = uger;
        Saeson = saeson;
        PrisProcent = prisProcent;
    }
}