namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale River race player.
    /// </summary>
    public class RiverRacePlayer
    {
        /// <summary>
        /// The player's Tag.
        /// </summary>
        public string Tag;
        /// <summary>
        /// The player's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The player's Fame count.
        /// </summary>
        public int Fame;
        /// <summary>
        /// The player's Repair Point count.
        /// </summary>
        public int RepairPoints;
        /// <summary>
        /// The player's Boat Attacks count.
        /// </summary>
        public int BoatAttacks;
        /// <summary>
        /// The player's River race Decks used today count.
        /// </summary>
        public int DecksUsedToday;
        /// <summary>
        /// The player's total River race Decks used count.
        /// </summary>
        public int DecksUsed;

        internal RiverRacePlayer(dynamic json)
        {
            Tag = json.tag;
            Name = json.name;
            Fame = json.fame;
            RepairPoints = json.repairPoints;
            BoatAttacks = json.boatAttacks;
            DecksUsed = json.decksUsed;
            DecksUsedToday = json.decksUsedToday;
        }

        public RiverRacePlayer() { }
    }
}