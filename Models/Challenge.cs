namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Challenge.
    /// </summary>
    public class Challenge
    {
        /// <summary>
        /// The Challenge's ID.
        /// </summary>
        public int ID;
        /// <summary>
        /// The Challenge's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The Challenge's description.
        /// </summary>
        public string Description;
        /// <summary>
        /// The Challenge's win mode.
        /// </summary>
        public string WinMode;
        /// <summary>
        /// Whether the Challenge is casual.
        /// </summary>
        public bool IsCasual;
        /// <summary>
        /// The Challenge's maximum losses count.
        /// </summary>
        public int MaxLosses;
        /// <summary>
        /// The Challenge's Game mode.
        /// </summary>
        public GameMode GameMode;
        /// <summary>
        /// The Challenge's prizes.
        /// </summary>
        public Prize[] Prizes;
        /// <summary>
        /// The Challenge's icon's URL.
        /// </summary>
        public string IconURL;

        internal Challenge(dynamic json)
        {
            ID = json.id;
            Name = json.name;
            Description = json.description;
            WinMode = json.winMode;
            IsCasual = json.casual;
            MaxLosses = json.maxLosses;
            GameMode = new GameMode(json.gameMode);
            Prizes = ClashRoyale.GetObjectsFromJson<Prize>(json.prizes);
            IconURL = json.iconUrl;
        }

        public Challenge() { }
    }
}