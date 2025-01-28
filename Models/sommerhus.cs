namespace H2_OOP_OPG.Models;

/// <summary>
/// Represents a summer house with various properties such as ID, location, classification, and standard price.
/// </summary>
public class Sommerhus {
    /// <summary>
    /// Gets the unique identifier for the house.
    /// </summary>
    public int HusID { get; private set; }

    /// <summary>
    /// Gets the unique identifier for the owner.
    /// </summary>
    public int EjerID { get; private set; }

    /// <summary>
    /// Gets the location of the summer house.
    /// </summary>
    public string Lokation { get; private set; }

    /// <summary>
    /// Gets the classification of the summer house.
    /// </summary>
    public string Klassifikation { get; private set; }

    /// <summary>
    /// Gets the unique identifier for the area.
    /// </summary>
    public int OmraadeID { get; private set; }

    /// <summary>
    /// Gets the standard price of the summer house.
    /// </summary>
    public double StandardPris { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sommerhus"/> class with specified properties.
    /// </summary>
    /// <param name="husID">The unique identifier for the house.</param>
    /// <param name="ejerID">The unique identifier for the owner.</param>
    /// <param name="lokation">The location of the summer house.</param>
    /// <param name="klassifikation">The classification of the summer house.</param>
    /// <param name="omraadeID">The unique identifier for the area.</param>
    /// <param name="standardPris">The standard price of the summer house.</param>
    public Sommerhus(int husID, int ejerID, string lokation, string klassifikation, int omraadeID, double standardPris) {
        HusID = husID;
        EjerID = ejerID;
        Lokation = lokation;
        Klassifikation = klassifikation;
        OmraadeID = omraadeID;
        StandardPris = standardPris;
    }
}