namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Clan from a search result.
    /// </summary>
    public class SearchResultClan
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
        /// The Clan's members count.
        /// </summary>
        public int MemberCount;

        internal SearchResultClan(dynamic searchResultClanJson)
        {
            Tag = searchResultClanJson.tag;
            Name = searchResultClanJson.name;
            BadgeID = searchResultClanJson.badgeId;
            Location = new Location(searchResultClanJson.location);
            Type = searchResultClanJson.type;
            RequiredTrophies = searchResultClanJson.requiredTrophies;
            ClanScore = searchResultClanJson.clanScore;
            ClanWarTrophies = searchResultClanJson.clanWarTrophies;
            DonationsPerWeek = searchResultClanJson.donationsPerWeek;
            MemberCount = searchResultClanJson.members;
        }

        public SearchResultClan() { }
    }
}