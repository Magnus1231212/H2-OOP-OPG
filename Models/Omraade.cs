namespace H2_OOP_OPG
{
    /// <summary>
    /// Represents an area associated with a consultant.
    /// </summary>
    public class Omraade
    {
        /// <summary>
        /// Gets the unique identifier for the area.
        /// </summary>
        public int OmraadeID { get; private set; }

        /// <summary>
        /// Gets the name of the area.
        /// </summary>
        public string Navn { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the consultant associated with the area.
        /// </summary>
        public int KonsulentID { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Omraade"/> class.
        /// </summary>
        /// <param name="omraadeID">The unique identifier for the area.</param>
        /// <param name="navn">The name of the area.</param>
        /// <param name="konsulentID">The unique identifier for the consultant.</param>
        public Omraade(int omraadeID, string navn, int konsulentID)
        {
            OmraadeID = omraadeID;
            Navn = navn;
            KonsulentID = konsulentID;
        }
    }
}