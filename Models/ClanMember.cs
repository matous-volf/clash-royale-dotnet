namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Clan member.
    /// </summary>
    public class ClanMember
    {
        /// <summary>
        /// The member's Tag.
        /// </summary>
        public string Tag;
        /// <summary>
        /// The member's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The member's Level.
        /// </summary>
        public int Level;
        /// <summary>
        /// The member's Trophies count.
        /// </summary>
        public int Trophies;
        /// <summary>
        /// The member's Arena.
        /// </summary>
        public Arena Arena;
        /// <summary>
        /// The member's rank in the Clan.
        /// </summary>
        public int ClanRank;
        /// <summary>
        /// The member's previous rank in the Clan.
        /// </summary>
        public int PreviousClanRank;
        /// <summary>
        /// The member's Clan Role.
        /// </summary>
        public MemberRole Role;
        /// <summary>
        /// The last time the member was online.
        /// </summary>
        public DateTime? LastSeen;
        /// <summary>
        /// The member's given Donations count.
        /// </summary>
        public int Donations;
        /// <summary>
        /// The member's received Donations count.
        /// </summary>
        public int DonationsReceived;

        internal ClanMember(dynamic json)
        {
            Tag = json.tag;
            Name = json.name;
            Level = json.expLevel;
            Trophies = json.trophies;
            Arena = new Arena(json.arena);
            ClanRank = json.clanRank;
            PreviousClanRank = json.previousClanRank;
            Role = ClashRoyale.GetEnumFromJson<MemberRole>(json.role);
            LastSeen = ClashRoyale.GetDateTimeFromJson(json.lastSeen);
            Donations = json.donations;
            DonationsReceived = json.donationsReceived;
        }

        /// <summary>
        /// Initializes a new instance of the ClanMember class.
        /// </summary>
        public ClanMember() { }
    }
}