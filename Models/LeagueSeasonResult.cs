namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale player's League Season result.
    /// </summary>
    public class LeagueSeasonResult
    {
        /// <summary>
        /// The player's resulting Trophies count.
        /// </summary>
        public int Trophies;
        /// <summary>
        /// The player's resulting highest Trophies count.
        /// </summary>
        public int HighestTrophies;
        /// <summary>
        /// The player's resulting rank.
        /// </summary>
        public int Rank;
        /// <summary>
        /// The Season's ID.
        /// </summary>
        public string ID;

        internal LeagueSeasonResult(dynamic json)
        {
            Trophies = json.trophies;
            HighestTrophies = json.bestTrophies is not null ? json.bestTrophies : json.trophies;
            Rank = json.rank is not null ? json.rank : 0;
            ID = json.id;
        }

        public LeagueSeasonResult() { }
    }
}