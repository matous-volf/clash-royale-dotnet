namespace ClashRoyaleAPI
{
    /// <summary>
    /// The exception that is thrown when an invalid Clash Royale API key is provided. For additional information, see the <see href="https://github.com/matousvolf/clash-royale-dotnet#usage">usage documentation</see>.
    /// </summary>
    [Serializable]
    public class InvalidKeyException : Exception
    {
        public InvalidKeyException() : base("The provided API key is not valid.") { HelpLink = "https://github.com/matousvolf/clash-royale-dotnet#usage"; }
        public InvalidKeyException(string message) : base(message) { }
        public InvalidKeyException(string message, Exception inner) : base(message, inner) { }
        protected InvalidKeyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}