namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale player's Achievment.
    /// </summary>
    public class Achievement
    {
        /// <summary>
        /// The Achievment's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The Achievment's information.
        /// </summary>
        public string Info;
        /// <summary>
        /// The Achievment's value.
        /// </summary>
        public int Value;
        /// <summary>
        /// The Achievment's target.
        /// </summary>
        public int Target;
        /// <summary>
        /// The Achievment's Stars count.
        /// </summary>
        public int Stars;

        internal Achievement(dynamic json)
        {
            Name = json.name;
            Info = json.info;
            Value = json.value;
            Target = json.target;
            Stars = json.stars;
        }

        public Achievement() { }
    }
}