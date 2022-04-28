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

        public GameMode() { }
    }
}