namespace ClashRoyaleAPI
{
    /// <summary>
    /// The exception that is thrown when an invalid Clash Royale API key is provided. For additional information, see the <see href="https://github.com/matousvolf/clash-royale-dotnet#usage">usage documentation</see>.
    /// </summary>
    [Serializable]
    public class InvalidKeyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the InvalidKeyException class with the default error message.
        /// </summary>
        public InvalidKeyException() : base("The provided API key is not valid.") { HelpLink = "https://github.com/matousvolf/clash-royale-dotnet#usage"; }
        /// <summary>
        /// Initializes a new instance of the InvalidKeyException class with a specified error message.
        /// </summary>
        public InvalidKeyException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the InvalidKeyException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        public InvalidKeyException(string message, Exception innerException) : base(message, innerException) { }
    }
}