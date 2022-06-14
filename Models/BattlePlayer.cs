namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale player participated in a Battle.
    /// </summary>
    public class BattlePlayer
    {
        /// <summary>
        /// The player's Tag.
        /// </summary>
        public string Tag;
        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The player's Trophies count before the start of the Battle.
        /// </summary>
        public int StartingTrophies;
        /// <summary>
        /// The player's Trophies count after the end of the Battle.
        /// </summary>
        public int TrophyChange;
        /// <summary>
        /// The player's Crowns won from the Battle count.
        /// </summary>
        public int Crowns;
        /// <summary>
        /// The player's King Tower Hit points count.
        /// </summary>
        public int KingTowerHitPoints;
        /// <summary>
        /// The player's Princess Towers Hit points counts.
        /// </summary>
        public int[] PrincessTowersHitPoints;
        /// <summary>
        /// The player's Cards used in the Battle.
        /// </summary>
        public Card[] Cards;
        /// <summary>
        /// The player's Clan.
        /// </summary>
        public PlayerClan Clan;

        internal BattlePlayer(dynamic json)
        {
            Tag = json.tag;
            Name = json.name;
            StartingTrophies = json.startingTrophies is not null ? json.startingTrophies : 0;
            TrophyChange = json.trophyChange is not null ? json.trophyChange : 0;
            Crowns = json.crowns is not null ? json.crowns : 0;
            KingTowerHitPoints = json.kingTowerHitPoints is not null ? json.kingTowerHitPoints : 0;

            if (json.princessTowersHitPoints is not null)
            {
                PrincessTowersHitPoints = new int[json.princessTowersHitPoints.Count];

                for (int i = 0; i < json.princessTowersHitPoints.Count; i++)
                {
                    PrincessTowersHitPoints[i] = json.princessTowersHitPoints[i];
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the BattlePlayer class.
        /// </summary>
        public BattlePlayer() { }
    }
}