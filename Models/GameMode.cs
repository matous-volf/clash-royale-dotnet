namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Battle Game mode.
    /// </summary>
    public class GameMode
    {
        /// <summary>
        /// The Game mode's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The Game monde's ID.
        /// </summary>
        public int ID;

        internal GameMode(dynamic json)
        {
            Name = json.name;
            ID = json.id;
        }

        /// <summary>
        /// Initializes a new instance of the GameMode class.
        /// </summary>
        public GameMode() { }
    }
}