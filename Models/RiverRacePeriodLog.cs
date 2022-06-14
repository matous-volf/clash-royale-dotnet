namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale River race Period log.
    /// </summary>
    public class RiverRacePeriodLog
    {
        /// <summary>
        /// The Period log entries.
        /// </summary>
        public RiverRacePeriodLogEntry[] Entries;
        /// <summary>
        /// The Period's log Period index.
        /// </summary>
        public int PeriodIndex;

        internal RiverRacePeriodLog(dynamic json)
        {
            Entries = ClashRoyale.GetObjectsFromJson<RiverRacePeriodLogEntry>(json.items);
            PeriodIndex = json.periodIndex;
        }

        /// <summary>
        /// Initializes a new instance of the RiverRacePeriodLog class.
        /// </summary>
        public RiverRacePeriodLog() { }
    }
}