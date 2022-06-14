namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale player's League statistics.
    /// </summary>
    public class LeagueStatistics
    {
        /// <summary>
        /// The current season result.
        /// </summary>
        public LeagueSeasonResult CurrentSeason;
        /// <summary>
        /// The previous season result.
        /// </summary>
        public LeagueSeasonResult PreviousSeason;
        /// <summary>
        /// The best season result.
        /// </summary>
        public LeagueSeasonResult BestSeason;

        internal LeagueStatistics(dynamic json)
        {
            CurrentSeason = new LeagueSeasonResult(json.currentSeason);
            PreviousSeason = json.previousSeason is not null ? new LeagueSeasonResult(json.previousSeason) : null;
            BestSeason = json.bestSeason is not null ? new LeagueSeasonResult(json.bestSeason) : null;
        }

        /// <summary>
        /// Initializes a new instance of the LeagueStatistics class.
        /// </summary>
        public LeagueStatistics() { }
    }
}