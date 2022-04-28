namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Arena.
    /// </summary>
    public class Arena
    {
        /// <summary>
        /// The Arena's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The Arena's ID.
        /// </summary>
        public int ID;

        internal Arena(dynamic json)
        {
            Name = json.name;
            ID = json.id;
        }

        public Arena() { }
    }
}