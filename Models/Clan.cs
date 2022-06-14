namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Clan.
    /// </summary>
    public class Clan
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
        /// The Clan's description.
        /// </summary>
        public string Description;
        /// <summary>
        /// The Clan's Badge's ID.
        /// </summary>
        public string BadgeID;
        /// <summary>
        /// The Clan's location.
        /// </summary>
        public Location Location;
        /// <summary>
        /// The Clan's type.
        /// </summary>
        public string Type;
        /// <summary>
        /// The Clan's required trophies count.
        /// </summary>
        public int RequiredTrophies;
        /// <summary>
        /// The total sum of the Clan's members' trophies.
        /// </summary>
        public int ClanScore;
        /// <summary>
        /// The Clan's Clan War Trophies count.
        /// </summary>
        public int ClanWarTrophies;
        /// <summary>
        /// The Clan's weekly Donations count.
        /// </summary>
        public int DonationsPerWeek;
        /// <summary>
        /// The Clan's members.
        /// </summary>
        public ClanMember[] Members;
        /// <summary>
        /// The Clan's members count.
        /// </summary>
        public int MemberCount;
        /// <summary>
        /// The Clan's current River race.
        /// </summary>
        public CurrentRiverRace CurrentRiverRace;
        /// <summary>
        /// The Clan's River race log.
        /// </summary>
        public RiverRace[] RiverRaceLog;

        internal Clan(dynamic clanJson, dynamic currentRiverRaceJson, dynamic riverRaceLogJson)
        {
            Tag = clanJson.tag;
            Name = clanJson.name;
            Description = clanJson.description;
            BadgeID = clanJson.badgeId;
            Location = new Location(clanJson.location);
            Type = clanJson.type;
            RequiredTrophies = clanJson.requiredTrophies;
            ClanScore = clanJson.clanScore;
            ClanWarTrophies = clanJson.clanWarTrophies;
            DonationsPerWeek = clanJson.donationsPerWeek;
            Members = ClashRoyale.GetObjectsFromJson<ClanMember>(clanJson.memberList);
            MemberCount = clanJson.members;
            CurrentRiverRace = currentRiverRaceJson is not null ? new CurrentRiverRace(currentRiverRaceJson) : null;
            RiverRaceLog = ClashRoyale.GetObjectsFromJson<RiverRace>(riverRaceLogJson);
        }

        /// <summary>
        /// Initializes a new instance of the Clan class.
        /// </summary>
        public Clan() { }
    }
}