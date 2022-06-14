namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Chest in a player's cycle.
    /// </summary>
    public class Chest
    {
        /// <summary>
        /// The Chest's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The Chest's index in the player's cycle.
        /// </summary>
        public int Index;

        internal Chest(dynamic json)
        {
            Name = json.name;
            Index = json.index;
        }

        /// <summary>
        /// Initializes a new instance of the Chest class.
        /// </summary>
        public Chest() { }
    }
}