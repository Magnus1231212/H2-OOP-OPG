namespace H2_OOP_OPG;

/// <summary>
/// Represents the seasonal price for a summer house.
/// </summary>
public class SommerhusSaesonPris {
    /// <summary>
    /// Gets the standard price for the summer house.
    /// </summary>
    public double StandardPris { get; private set; }

    /// <summary>
    /// Gets the ID of the summer house.
    /// </summary>
    public int SommerhusID { get; private set; }

    /// <summary>
    /// Gets the ID of the season category.
    /// </summary>
    public int SaesonkategoriID { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SommerhusSaesonPris"/> class.
    /// </summary>
    /// <param name="standardpris">The standard price for the summer house.</param>
    /// <param name="sommerhusID">The ID of the summer house.</param>
    /// <param name="saesonkategoriID">The ID of the season category.</param>
    public SommerhusSaesonPris(double standardpris, int sommerhusID, int saesonkategoriID) {
        StandardPris = standardpris;
        SommerhusID = sommerhusID;
        SaesonkategoriID = saesonkategoriID;
    }
}