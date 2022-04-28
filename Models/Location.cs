namespace ClashRoyaleAPI
{
    /// <summary>
    /// Represents a Clash Royale location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// The location's name.
        /// </summary>
        public string Name;
        /// <summary>
        /// The location's ID.
        /// </summary>
        public int ID;
        /// <summary>
        /// Whether the location is a country.
        /// </summary>
        public bool IsCountry;
        /// <summary>
        /// The location's country code.
        /// </summary>
        public string CountryCode;

        internal Location(dynamic json)
        {
            Name = json.name;
            ID = json.id;
            IsCountry = json.isCountry;
            CountryCode = json.countryCode;
        }

        public Location() { }
    }
}