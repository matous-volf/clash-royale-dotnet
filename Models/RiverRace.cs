namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale River race.
    /// </summary>
    public class RiverRace
    {
        /// <summary>
        /// The River race standings.
        /// </summary>
        public RiverRaceStanding[] Standings;
        /// <summary>
        /// The ID of the Season the River race happened in.
        /// </summary>
        public int SeasonID;
        /// <summary>
        /// The date the River race was created.
        /// </summary>
        public string CreatedDate;
        /// <summary>
        /// The River race's section index.
        /// </summary>
        public int SectionIndex;

        internal RiverRace(dynamic json)
        {
            Standings = ClashRoyale.GetObjectsFromJson<RiverRaceStanding>(json.standings);
            SeasonID = json.seasonId;
            CreatedDate = json.createdDate;
            SectionIndex = json.sectionIndex;
        }

        /// <summary>
        /// Initializes a new instance of the RiverRace class.
        /// </summary>

        public RiverRace() { }
    }
}