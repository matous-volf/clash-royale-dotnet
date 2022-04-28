namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale currently ongoing River race.
    /// </summary>
    public class CurrentRiverRace
    {
        /// <summary>
        /// The state of the River race.
        /// </summary>
        public string State;
        /// <summary>
        /// The River race's Period type.
        /// </summary>
        public string PeriodType;
        /// <summary>
        /// The River race's Period index.
        /// </summary>
        public int PeriodIndex;
        /// <summary>
        /// The River race's Period logs.
        /// </summary>
        public RiverRacePeriodLog[] PeriodLogs;
        /// <summary>
        /// The time the River race's collection ends.
        /// </summary>
        public DateTime? CollectionEndTime;
        /// <summary>
        /// The time the River race's War ends.
        /// </summary>
        public DateTime? WarEndTime;
        /// <summary>
        /// The River race's Section index.
        /// </summary>
        public int SectionIndex;
        /// <summary>
        /// The River race's Period index.
        /// </summary>
        public RiverRaceClan Clan;
        /// <summary>
        /// The Clans participated in the River race.
        /// </summary>
        public RiverRaceClan[] Clans;

        internal CurrentRiverRace(dynamic json)
        {
            State = json.state;
            PeriodType = json.periodType;
            PeriodIndex = json.periodIndex;
            PeriodLogs = json.periodLogs is not null ? ClashRoyale.GetObjectsFromJson<RiverRacePeriodLog>(json.periodLogs) : null;
            CollectionEndTime = ClashRoyale.GetDateTimeFromJson(json.collectionEndTime);
            WarEndTime = ClashRoyale.GetDateTimeFromJson(json.warEndTime);
            SectionIndex = json.sectionIndex;
            Clan = new RiverRaceClan(json.clan);
            Clans = ClashRoyale.GetObjectsFromJson<RiverRaceClan>(json.clans);
        }

        public CurrentRiverRace() { }
    }
}