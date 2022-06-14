namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale River race standing.
    /// </summary>
    public class RiverRaceStanding
    {
        /// <summary>
        /// The Clan with the standing.
        /// </summary>
        public RiverRaceClan Clan;
        /// <summary>
        /// The standing rank.
        /// </summary>
        public int Rank;
        /// <summary>
        /// The Trophy change after the standing.
        /// </summary>
        public int TrophyChange;

        internal RiverRaceStanding(dynamic json)
        {
            Clan = new RiverRaceClan(json.clan);
            Rank = json.rank;
            TrophyChange = json.trophyChange;
        }

        /// <summary>
        /// Initializes a new instance of the RiverRaceStanding class.
        /// </summary>
        public RiverRaceStanding() { }
    }
}