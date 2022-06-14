namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale River race Period log entry
    /// </summary>
    public class RiverRacePeriodLogEntry
    {
        /// <summary>
        /// The entry's Clan's Tag.
        /// </summary>
        public string ClanTag;
        /// <summary>
        /// The entry's Clan's earned points count.
        /// </summary>
        public int PointsEarned;
        /// <summary>
        /// The entry's Clan's earned progress.
        /// </summary>
        public int ProgressEarned;
        /// <summary>
        /// The entry's Clan's progress earned from defenses.
        /// </summary>
        public int ProgressEarnedFromDefenses;
        /// <summary>
        /// The entry's Clan's progress at the start of the day.
        /// </summary>
        public int ProgressStartOfDay;
        /// <summary>
        /// The entry's Clan's progress at the end of the day.
        /// </summary>
        public int ProgressEndOfDay;
        /// <summary>
        /// The entry's Clan's remaining defenses count.
        /// </summary>
        public int NumberOfDefensesRemaining;
        /// <summary>
        /// The entry's Clan's rank at the end of the day.
        /// </summary>
        public int EndOfDayRank;

        internal RiverRacePeriodLogEntry(dynamic json)
        {
            ClanTag = json.clan.tag;
            PointsEarned = json.pointsEarned;
            ProgressEarned = json.progressEarned;
            ProgressEarnedFromDefenses = json.progressEarnedFromDefenses;
            ProgressStartOfDay = json.progressStartOfDay;
            ProgressEndOfDay = json.progressEndOfDay;
            NumberOfDefensesRemaining = json.numOfDefensesRemaining;
            EndOfDayRank = json.endOfDayRank;
        }

        /// <summary>
        /// Initializes a new instance of the RiverRacePeriodLogEntry class.
        /// </summary>
        public RiverRacePeriodLogEntry() { }
    }
}