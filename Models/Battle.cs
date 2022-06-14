namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Battle.
    /// </summary>
    public class Battle
    {
        /// <summary>
        /// The Battle's type.
        /// </summary>
        public BattleType Type;
        /// <summary>
        /// The Battle's Game mode.
        /// </summary>
        public GameMode GameMode;
        /// <summary>
        /// The Battle's Deck selection.
        /// </summary>
        public BattleDeckSelection DeckSelection;
        /// <summary>
        /// The Arena the Battle was played in.
        /// </summary>
        public Arena Arena;
        /// <summary>
        /// The time the Battle was played.
        /// </summary>
        public DateTime? Time;
        /// <summary>
        /// The Battle's team players.
        /// </summary>
        public BattlePlayer[] Team;
        /// <summary>
        /// The Battle's opponent players.
        /// </summary>
        public BattlePlayer[] Opponent;
        /// <summary>
        /// Whether the Battle is a hosted Match.
        /// </summary>
        public bool IsHostedMatch;
        /// <summary>
        /// Whether the Battle is from a Ladder Tournament.
        /// </summary>
        public bool IsLadderTournament;
        /// <summary>
        /// The Battle's Tournament Tag.
        /// </summary>
        public string TournamentTag;
        /// <summary>
        /// The title of the Battle's Challenge.
        /// </summary>
        public string ChallengeTitle;
        /// <summary>
        /// The ID of the Battle's Challenge.
        /// </summary>
        public int ChallengeID;
        /// <summary>
        /// The player's Challenge win count before the Battle.
        /// </summary>
        public int ChallengeWinCountBefore;
        /// <summary>
        /// The Boat Battle's side.
        /// </summary>
        public string BoatBattleSide;
        /// <summary>
        /// Whether the Battle was a victorious Boat Battle.
        /// </summary>
        public bool BoatBattleWon;
        /// <summary>
        /// The Boat Battle's previous destroyed Towers count.
        /// </summary>
        public int BoatBattlePreviousTowersDestroyed;
        /// <summary>
        /// The Boat Battle's new destroyed Towers count.
        /// </summary>
        public int BoatBattleNewTowersDestroyed;
        /// <summary>
        /// The Boat Battle's remaining Towers count.
        /// </summary>
        public int BoatBattleRemainingTowers;

        internal Battle(dynamic json)
        {
            Type = ClashRoyale.GetEnumFromJson<BattleType>(json.type);
            GameMode = new GameMode(json.gameMode);
            DeckSelection = ClashRoyale.GetEnumFromJson<BattleDeckSelection>(json.deckSelection);
            Arena = new Arena(json.arena);
            Time = ClashRoyale.GetDateTimeFromJson(json.battleTime);
            Team = ClashRoyale.GetObjectsFromJson<BattlePlayer>(json.team);
            Opponent = ClashRoyale.GetObjectsFromJson<BattlePlayer>(json.opponent);
            IsHostedMatch = json.isHostedMatch;
            IsLadderTournament = json.isLadderTournament;
            TournamentTag = json.tournamentTag;
            ChallengeTitle = json.challengeTitle;
            ChallengeID = json.challengeID is not null ? json.challengeId : 0;
            ChallengeWinCountBefore = json.challengeWinCountBefore is not null ? json.challengeWinCountBefore : 0;
            BoatBattleSide = json.boatBattleSide;
            BoatBattleWon = json.boatBattleWon is not null ? json.boatBattleWon : false;
            BoatBattlePreviousTowersDestroyed = json.prevTowersDestroyed is not null ? json.prevTowersDestroyed : 0;
            BoatBattleNewTowersDestroyed = json.newTowersDestroyed is not null ? json.newTowersDestroyed : 0;
            BoatBattleRemainingTowers = json.remainingTowers is not null ? json.remainingTowers : 0;
        }

        /// <summary>
        /// Initializes a new instance of the Battle class.
        /// </summary>
        public Battle() { }
    }
}