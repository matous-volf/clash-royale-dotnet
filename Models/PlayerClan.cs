namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale player's Clan.
    /// </summary>
    public class PlayerClan
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

        internal PlayerClan(dynamic json)
        {
            Tag = json.tag;
            Name = json.name;
            BadgeID = json.badgeId;
        }

        public PlayerClan() { }
    }
}