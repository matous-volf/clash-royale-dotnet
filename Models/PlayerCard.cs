namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Card in a player's collection.
    /// </summary>
    public class PlayerCard
    {
        /// <summary>
        /// The Card's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The Card's ID.
        /// </summary>
        public int ID;
        /// <summary>
        /// The Card's icon's URL.
        /// </summary>
        public string IconURL;
        /// <summary>
        /// The Card's max Level.
        /// </summary>
        public int MaxLevel;
        /// <summary>
        /// The Card's current Level.
        /// </summary>
        public int Level;
        /// <summary>
        /// The Card's current Star Level.
        /// </summary>
        public int StarLevel;
        /// <summary>
        /// The amount of this Card the player has.
        /// </summary>
        public int Count;

        internal PlayerCard(dynamic json)
        {
            Name = json.name;
            ID = json.id;
            IconURL = json.iconUrls.medium;
            MaxLevel = json.maxLevel;
            Level = json.level;
            StarLevel = json.starLevel is not null ? json.starLevel : 0;
            Count = json.count;
        }

        public PlayerCard() { }
    }
}