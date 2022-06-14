namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Card.
    /// </summary>
    public class Card
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

        internal Card(dynamic json)
        {
            Name = json.name;
            ID = json.id;
            IconURL = json.iconUrls is not null ? json.iconUrls.medium : null;
            MaxLevel = json.maxLevel;
        }

        /// <summary>
        /// Initializes a new instance of the Card class.
        /// </summary>
        public Card() { }
    }
}