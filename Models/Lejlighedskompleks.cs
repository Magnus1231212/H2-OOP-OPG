namespace H2_OOP_OPG {
    /// <summary>
    /// Represents an apartment complex and its associated details.
    /// </summary>
    public class Lejlighedskompleks {
        /// <summary>
        /// Gets the unique identifier for the apartment complex.
        /// </summary>
        public int KompleksID { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the inspector associated with the apartment complex.
        /// </summary>
        public int InspektoerID { get; private set; }

        /// <summary>
        /// Gets the type of the apartment complex.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the unique identifier for the summer house associated with the apartment complex.
        /// </summary>
        public int SommerhusID { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Lejlighedskompleks"/> class.
        /// </summary>
        /// <param name="kompleksID">The unique identifier for the apartment complex.</param>
        /// <param name="inspektoerID">The unique identifier for the inspector.</param>
        /// <param name="type">The type of the apartment complex.</param>
        /// <param name="sommerhusID">The unique identifier for the summer house.</param>
        public Lejlighedskompleks(int kompleksID, int inspektoerID, string type, int sommerhusID) {
            KompleksID = kompleksID;
            InspektoerID = inspektoerID;
            Type = type;
            SommerhusID = sommerhusID;
        }
    }
}