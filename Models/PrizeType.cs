namespace ClashRoyaleAPI
{
    /// <summary>
    /// Specifies the Clash Royale Challenge prize types.
    /// </summary>
    public enum PrizeType {
        /// <summary>
        /// Specifies none prize.
        /// </summary>
        None,
        /// <summary>
        /// Specifies the Card stack prize.
        /// </summary>
        CardStack,
        /// <summary>
        /// Specifies the random Card stack prize.
        /// </summary>
        CardStackRandom,
        /// <summary>
        /// Specifies the Chest prize.
        /// </summary>
        Chest,
        /// <summary>
        /// Specifies the Resource prize.
        /// </summary>
        Resource,
        /// <summary>
        /// Specifies the Trade token resource.
        /// </summary>
        TradeToken,
        /// <summary>
        /// Specifies the Consumable resource.
        /// </summary>
        Consumable
    };
}