namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Clan participated in River race.
    /// </summary>
    public class RiverRaceClan
    {
        /// <summary>
        /// The Clan's Tag.
        /// </summary>
        public string Tag;
        /// <summary>
        /// The Clan's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The Clan's Badge's ID.
        /// </summary>
        public int BadgeID;
        /// <summary>
        /// The total sum of the Clan's members' trophies.
        /// </summary>
        public int ClanScore;
        /// <summary>
        /// The Clan's River race Fame.
        /// </summary>
        public int Fame;
        /// <summary>
        /// The Clan's River race Period points.
        /// </summary>
        public int PeriodPoints;
        /// <summary>
        /// The Clan's River race Repair points.
        /// </summary>
        public int RepairPoints;
        /// <summary>
        /// The time the Clan finished the River race.
        /// </summary>
        public DateTime? FinishTime;
        /// <summary>
        /// The Clan's members participated in the River race.
        /// </summary>
        public RiverRacePlayer[] Participants;

        internal RiverRaceClan(dynamic json)
        {
            Tag = json.tag;
            Name = json.name;
            BadgeID = json.badgeId;
            ClanScore = json.clanScore;
            Fame = json.fame;
            PeriodPoints = json.periodPoints;
            RepairPoints = json.repairPoints;
            FinishTime = ClashRoyale.GetDateTimeFromJson(json.finishTime);
            Participants = ClashRoyale.GetObjectsFromJson<RiverRacePlayer>(json.participants);
        }

        public RiverRaceClan() { }
    }
}