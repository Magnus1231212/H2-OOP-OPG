namespace H2_OOP_OPG;

public class Reservation {
    public int ReservationID { get; private set; }  
    public int HusID { get; private set; }
    public int KundeID { get; private set; }
    public int StartUge { get; private set; }
    public int AntalUger { get; private set; }
    public double TotalPris { get; private set; }

    public Reservation(int reservationID, int husID, int kundeID, int startUge, int antalUger, double totalPris) {
        ReservationID = reservationID;
        HusID = husID;
        KundeID = kundeID;
        StartUge = startUge;
        AntalUger = antalUger;
        TotalPris = totalPris;
    }
}