namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale player.
    /// </summary>
    public class Player
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
        /// The player's Level.
        /// </summary>
        public int Level;
        /// <summary>
        /// The player's Experience points count.
        /// </summary>
        public int ExperiencePoints;
        /// <summary>
        /// The player's Star points count.
        /// </summary>
        public int StarPoints;
        /// <summary>
        /// The player's Arena.
        /// </summary>
        public Arena Arena;
        /// <summary>
        /// The player's Trophies count.
        /// </summary>
        public int Trophies;
        /// <summary>
        /// The player's Highest Trophies count.
        /// </summary>
        public int HighestTrophies;
        /// <summary>
        /// The player's League statistics.
        /// </summary>
        public LeagueStatistics LeagueStatistics;
        /// <summary>
        /// The player's Badges.
        /// </summary>
        public Badge[] Badges;
        /// <summary>
        /// The player's Achievments.
        /// </summary>
        public Achievement[] Achievements;
        /// <summary>
        /// The player's wins count.
        /// </summary>
        public int Wins;
        /// <summary>
        /// The player's three Crown wins count.
        /// </summary>
        public int ThreeCrownWins;
        /// <summary>
        /// The player's losses count.
        /// </summary>
        public int Losses;
        /// <summary>
        /// The player's battles count.
        /// </summary>
        public int BattleCount;
        /// <summary>
        /// The player's Tournament Battles count.
        /// </summary>
        public int TournamentBattleCount;
        /// <summary>
        /// The player's Tournament won Cards count.
        /// </summary>
        public int TournamentCardsWon;
        /// <summary>
        /// The player's max Challenge wins count.
        /// </summary>
        public int ChallengeMaxWins;
        /// <summary>
        /// The player's Challenge won Cards count.
        /// </summary>
        public int ChallengeCardsWon;
        /// <summary>
        /// The player's Cards.
        /// </summary>
        public PlayerCard[] Cards;
        /// <summary>
        /// The player's current favourite Card.
        /// </summary>
        public Card CurrentFavouriteCard;
        /// <summary>
        /// The player's upcoming Chests.
        /// </summary>
        public Chest[] UpcomingChests;
        /// <summary>
        /// The player's Battle log.
        /// </summary>
        public Battle[] BattleLog;

        /// <summary>
        /// The player's Clan.
        /// </summary>
        public PlayerClan Clan;
        /// <summary>
        /// The player's Clan role.
        /// </summary>
        public MemberRole? Role;
        /// <summary>
        /// The player's given Donations count.
        /// </summary>
        public int Donations;
        /// <summary>
        /// The player's received Donations count.
        /// </summary>
        public int DonationsReceived;
        /// <summary>
        /// The player's total Donations count.
        /// </summary>
        public int TotalDonations;
        /// <summary>
        /// The player's War Day wins count.
        /// </summary>
        public int WarDayWins;
        /// <summary>
        /// The player's collected Clan Cards count.
        /// </summary>
        public int ClanCardsCollected;

        internal Player(dynamic playerJson, dynamic upcomingChestsJson, dynamic battleLogJson)
        {
            Tag = playerJson.tag;
            Name = playerJson.name;
            Level = playerJson.expLevel;
            ExperiencePoints = playerJson.expPoints;
            StarPoints = playerJson.starPoints is not null ? playerJson.starPoints : 0;
            Arena = new Arena(playerJson.arena);
            Trophies = playerJson.trophies;
            HighestTrophies = playerJson.bestTrophies;
            LeagueStatistics = playerJson.leagueStatistics is not null ? new LeagueStatistics(playerJson.leagueStatistics) : null;
            Badges = ClashRoyale.GetObjectsFromJson<Badge>(playerJson.badges);
            Achievements = ClashRoyale.GetObjectsFromJson<Achievement>(playerJson.achievements);
            Wins = playerJson.wins;
            ThreeCrownWins = playerJson.threeCrownWins;
            Losses = playerJson.losses;
            BattleCount = playerJson.battleCount;
            TournamentBattleCount = playerJson.tournamentBattleCount;
            TournamentCardsWon = playerJson.tournamentCardsWon;
            ChallengeMaxWins = playerJson.challengeMaxWins;
            ChallengeCardsWon = playerJson.challengeCardsWon;
            Cards = ClashRoyale.GetObjectsFromJson<PlayerCard>(playerJson.cards);
            CurrentFavouriteCard = new Card(playerJson.currentFavouriteCard);
            UpcomingChests = ClashRoyale.GetObjectsFromJson<Chest>(upcomingChestsJson);
            BattleLog = ClashRoyale.GetObjectsFromJson<Battle>(battleLogJson);

            Clan = playerJson.clan is not null ? new PlayerClan(playerJson.clan) : null;
            Role = ClashRoyale.GetEnumFromJson<MemberRole>(playerJson.role);
            Donations = playerJson.donations;
            DonationsReceived = playerJson.donationsReceived;
            TotalDonations = playerJson.totalDonations;
            WarDayWins = playerJson.warDayWins;
            ClanCardsCollected = playerJson.clanCardsCollected;
        }

        public Player() { }
    }
}