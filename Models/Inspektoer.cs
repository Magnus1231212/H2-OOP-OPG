namespace H2_OOP_OPG
{
    /// <summary>
    /// Represents an inspector with contact information.
    /// </summary>
    public class Inspektoer
    {
        /// <summary>
        /// Gets the unique identifier for the inspector.
        /// </summary>
        public int InspektoerID { get; private set; }

        /// <summary>
        /// Gets the name of the inspector.
        /// </summary>
        public string Navn { get; private set; }

        /// <summary>
        /// Gets the contact information for the inspector.
        /// </summary>
        public string KontaktInfo { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Inspektoer"/> class.
        /// </summary>
        /// <param name="inspektoerID">The unique identifier for the inspector.</param>
        /// <param name="navn">The name of the inspector.</param>
        /// <param name="kontaktInfo">The contact information for the inspector.</param>
        public Inspektoer(int inspektoerID, string navn, string kontaktInfo)
        {
            InspektoerID = inspektoerID;
            Navn = navn;
            KontaktInfo = kontaktInfo;
        }
    }
}