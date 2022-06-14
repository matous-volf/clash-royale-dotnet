namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale Challenge chain.
    /// </summary>
    public class ChallengeChain
    {
        /// <summary>
        /// The chain's type.
        /// </summary>
        public ChallengeChainType Type;
        /// <summary>
        /// The Challenges in the chain.
        /// </summary>
        public Challenge[] Challenges;
        /// <summary>
        /// The time the chain starts.
        /// </summary>
        public DateTime? StartTime;
        /// <summary>
        /// The time the chain ends.
        /// </summary>
        public DateTime? EndTime;

        internal ChallengeChain(dynamic json)
        {
            Type = ClashRoyale.GetEnumFromJson<ChallengeChainType>(json.type);
            Challenges = ClashRoyale.GetObjectsFromJson<Challenge>(json.challenges);
            StartTime = ClashRoyale.GetDateTimeFromJson(json.startTime);
            EndTime = ClashRoyale.GetDateTimeFromJson(json.endTime);
        }

        /// <summary>
        /// Initializes a new instance of the ChallengeChain class.
        /// </summary>
        public ChallengeChain() { }
    }
}