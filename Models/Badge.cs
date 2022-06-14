namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale player's Badge.
    /// </summary>
    public class Badge
    {
        /// <summary>
        /// The Badge's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The Badge's current Level.
        /// </summary>
        public int Level;
        /// <summary>
        /// The Badge's max Level.
        /// </summary>
        public int MaxLevel;
        /// <summary>
        /// The Badge's progress.
        /// </summary>
        public int Progress;
        /// <summary>
        /// The Badge's target.
        /// </summary>
        public int Target;
        /// <summary>
        /// The Badge's icon's URL.
        /// </summary>
        public string IconURL;

        internal Badge(dynamic json)
        {
            Name = json.name;
            Level = json.level is not null ? json.level : 0;
            MaxLevel = json.maxLevel is not null ? json.maxLevel : 0;
            Progress = json.progress;
            Target = json.target is not null ? json.target : 0;
            IconURL = json.iconUrls.large;
        }

        /// <summary>
        /// Initializes a new instance of the Badge class.
        /// </summary>
        public Badge() { }
    }
}