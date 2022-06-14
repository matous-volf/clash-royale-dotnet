namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Challenge prize.
    /// </summary>
    public class Prize
    {
        /// <summary>
        /// The prize's type.
        /// </summary>
        public PrizeType? Type;
        /// <summary>
        /// The prize's amount.
        /// </summary>
        public int Amount;
        /// <summary>
        /// The prize's Chest.
        /// </summary>
        public string Chest;
        /// <summary>
        /// The prize's resource.
        /// </summary>
        public PrizeResource? Resource;
        /// <summary>
        /// The prize's consumable's name.
        /// </summary>
        public string ConsumableName;
        /// <summary>
        /// The prize's Rarity.
        /// </summary>
        public PrizeRarity? Rarity;
        /// <summary>
        /// The prize's Card.
        /// </summary>
        public Card Card;
        /// <summary>
        /// The prize's wins count.
        /// </summary>
        public int Wins;

        internal Prize(dynamic json)
        {
            Type = ClashRoyale.GetEnumFromJson<PrizeType>(json.type);
            Amount = json.amount ?? 0;
            Chest = json.chest ?? null;
            Resource = ClashRoyale.GetEnumFromJson<PrizeResource>(json.resource);
            ConsumableName = json.consumableName ?? null;
            Rarity = ClashRoyale.GetEnumFromJson<PrizeRarity>(json.rarity);
            Card = json.card is not null ? new Card(json.card) : null;
            Wins = json.wins ?? 0;
        }

        /// <summary>
        /// Initializes a new instance of the Prize class.
        /// </summary>
        public Prize() { }
    }
}