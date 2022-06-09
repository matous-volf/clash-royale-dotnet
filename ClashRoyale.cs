using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;

namespace ClashRoyaleAPI
{
    /// <summary>
    /// Provides access to all the Clash Royale API methods and settings.
    /// </summary>
    public static class ClashRoyale
    {
        private static string key;
        /// <summary>
        /// Gets or sets the API key used for obtaining the Clash Royale information.
        /// </summary>
        public static string Key
        {
            get => key;
            set
            {
                key = value;
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", value);
            }
        }

        private const string baseURLStandard = "https://api.clashroyale.com/v1/";

        private const string playersBaseURLStandard = baseURLStandard + "players/%23";
        private const string clansBaseURLStandard = baseURLStandard + "clans/%23";
        private const string clansSearchBaseURLStandard = baseURLStandard + "clans?";
        private const string cardsBaseURLStandard = baseURLStandard + "cards";
        private const string challengesBaseURLStandard = baseURLStandard + "challenges";

        private const string baseURLProxy = "https://proxy.royaleapi.dev/v1/";

        private const string playersBaseURLProxy = baseURLProxy + "players/%23";
        private const string clansBaseURLProxy = baseURLProxy + "clans/%23";
        private const string clansSearchBaseURLProxy = baseURLProxy + "clans?";
        private const string cardsBaseURLProxy = baseURLProxy + "cards";
        private const string challengesBaseURLProxy = baseURLProxy + "challenges";

        private static string playersBaseURL = playersBaseURLStandard;
        private static string clansBaseURL = clansBaseURLStandard;
        private static string clansSearchBaseURL = clansSearchBaseURLStandard;
        private static string cardsBaseURL = cardsBaseURLStandard;
        private static string challengesBaseURL = challengesBaseURLStandard;

        private static bool useProxyServers = false;
        /// <summary>
        /// Gets or sets whether to use <see href="https://docs.royaleapi.com/#/proxy">RoyaleAPI proxy servers</see> when obtaining the Clash Royale information.
        /// </summary>
        public static bool UseProxyServers
        {
            get
            {
                return useProxyServers;
            }
            set
            {
                useProxyServers = value;

                if (useProxyServers)
                {
                    playersBaseURL = playersBaseURLProxy;
                    clansBaseURL = clansBaseURLProxy;
                    clansSearchBaseURL = clansSearchBaseURLProxy;
                    cardsBaseURL = cardsBaseURLProxy;
                    challengesBaseURL = challengesBaseURLProxy;
                }
                else
                {
                    playersBaseURL = playersBaseURLStandard;
                    clansBaseURL = clansBaseURLStandard;
                    clansSearchBaseURL = clansSearchBaseURLStandard;
                    cardsBaseURL = cardsBaseURLStandard;
                    challengesBaseURL = challengesBaseURLStandard;
                }
            }
        }

        private static readonly HttpClient httpClient = new();

        private static string GetData(string url)
        {
            HttpResponseMessage response = httpClient.Send(new HttpRequestMessage(HttpMethod.Get, url));
            StreamReader streamReader = new(response.Content.ReadAsStream());
            string data = streamReader.ReadToEnd();

            if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new InvalidKeyException();
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }

            return data;
        }

        internal static DateTime? GetDateTimeFromJson(dynamic json)
        {
            if (json is null)
            {
                return null;
            }
            return DateTime.ParseExact(json.ToString(), "yyyyMMddTHHmmss.FFFZ", CultureInfo.InvariantCulture);
        }

        internal static T? GetEnumFromJson<T>(dynamic json) where T : struct
        {
            if (json is null)
            {
                return null;
            }

            string name = json.ToString();

            if (name == string.Empty)
            {
                return default;
            }

            if (typeof(T) == typeof(PrizeRarity))
            {
                name = name.Replace("hero", "champion");
            }

            return (T)Enum.Parse(typeof(T), name, true);
        }

        internal static T[] GetObjectsFromJson<T>(dynamic json)
        {
            T[] objects = new T[json.Count];

            for (int i = 0; i < json.Count; i++)
            {

                objects[i] = (T)Activator.CreateInstance(typeof(T),
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                    null,
                    new object[] { json[i] },
                    null);
            }

            return objects;
        }

        /// <summary>
        /// Gets information about a Clash Royale player.
        /// </summary>
        /// <param name="tag">
        /// The player's Tag. Both forms, with or without a hash character ('#'), are allowed. Case-insensitive.
        /// </param>
        /// <returns>
        /// The player object, or null if a player with the Tag does not exist.
        /// </returns>
        public static Player GetPlayerByTag(string tag)
        {
            if (tag.StartsWith("#"))
            {
                tag = tag[1..];
            }

            tag = tag.ToUpper();

            string url;

            string playerData;
            string upcomingChestsData;
            string battleLogData;

            url = playersBaseURL + tag;
            playerData = GetData(url);

            url = playersBaseURL + tag + "/upcomingchests";
            upcomingChestsData = GetData(url);

            url = playersBaseURL + tag + "/battlelog";
            battleLogData = GetData(url);
            battleLogData = "{\"items\":" + battleLogData + "}";

            if (playerData is null)
            {
                return null;
            }
            dynamic playerObject = JObject.Parse(playerData);
            dynamic upcomingChestsObject = JObject.Parse(upcomingChestsData);
            dynamic battleLogObject = JObject.Parse(battleLogData);

            return new Player(playerObject, upcomingChestsObject.items, battleLogObject.items);
        }

        /// <summary>
        /// Gets information about a Clash Royale Clan.
        /// </summary>
        /// <param name="tag">
        /// The Clan's Tag. Both forms, with or without a hash character ('#'), are allowed. Case-insensitive.
        /// </param>
        /// <returns>
        /// The Clan object, or null if a Clan with the tag does not exist.
        /// </returns>
        public static Clan GetClanByTag(string tag)
        {
            if (tag.StartsWith("#"))
            {
                tag = tag[1..];
            }

            tag = tag.ToUpper();

            string url;

            url = clansBaseURL + tag;
            string clanData = GetData(url);

            url = clansBaseURL + tag + "/currentriverrace";
            string currentRiverRaceData = GetData(url);

            url = clansBaseURL + tag + "/riverracelog";
            string riverRaceLogData = GetData(url);

            if (clanData is null)
            {
                return null;
            }
            dynamic clanObject = JObject.Parse(clanData);
            dynamic currentRiverRaceObject = currentRiverRaceData is not null ? JObject.Parse(currentRiverRaceData) : null;
            dynamic riverRaceLogObject = JObject.Parse(riverRaceLogData);

            return new Clan(clanObject, currentRiverRaceObject, riverRaceLogObject.items);
        }

        /// <summary>
        /// Gets information about Clash Royale Clans searched by their properties.
        /// </summary>
        /// <param name="name">
        /// The Clan's name to search for. Must be at least 3 characters long.
        /// </param>
        /// <param name="locationID">
        /// The Clan's location ID to search for.
        /// </param>
        /// <param name="minMembers">
        /// The Clan's minimum members count to search for. Must be in the range from 0 to 50.
        /// </param>
        /// <param name="maxMembers">
        /// The Clan's maximum members count to search for. Must be in the range from 0 to 50.
        /// </param>
        /// <param name="minScore">
        /// The Clan's minimum total Trophies to search for. Must be non-negative.
        /// </param>
        /// <returns>
        /// An array of the Clan objects found, or null if no Clans with the properties exist.
        /// </returns>
        public static SearchResultClan[] GetClansBySearch(string name = null, int locationID = 0, int minMembers = 0, int maxMembers = 50, int minScore = 0)
        {
            string url = clansSearchBaseURL;

            if (name is not null)
            {
                url += "name=" + name + "&";
            }
            if (locationID != 0)
            {
                url += "locationId=" + locationID + "&";
            }
            if (minMembers != 0)
            {
                url += "minMembers=" + minMembers + "&";
            }
            if (maxMembers != 50)
            {
                url += "maxMembers=" + maxMembers + "&";
            }
            if (minScore != 0)
            {
                url += "minScore=" + minScore + "&";
            }

            if (url == clansSearchBaseURL)
            {
                throw new ArgumentException("At least 1 Clan property must be specified.");
            }

            if (name.Length < 3)
            {
                throw new ArgumentOutOfRangeException(nameof(name), "The Clan's name must be at least 3 characters long.");
            }

            if (minMembers < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minMembers), "The Clan's minimum member count must be greater than or equal to 0.");
            }

            if (minMembers > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(minMembers), "The Clan's minimum member count must be lower than or equal to 50.");
            }

            if (maxMembers < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxMembers), "The Clan's maximum member count must be greater than or equal to 0.");
            }

            if (maxMembers > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(maxMembers), "The Clan's maximum member count must be lower than or equal to 50.");
            }

            if (minScore < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(minScore), "The Clan's minimum score must be greater than or equal to 0.");
            }

            string clansData = GetData(url);

            if (clansData is null)
            {
                return null;
            }
            dynamic clansObject = JObject.Parse(clansData);

            return ClashRoyale.GetObjectsFromJson<SearchResultClan>(clansObject.items);
        }

        /// <summary>
        /// Gets information about all the Clash Royale Cards.
        /// </summary>
        /// <returns>
        /// An array of the Card objects.
        /// </returns>
        public static Card[] GetAllCards()
        {
            string url = cardsBaseURL;
            string cardsData = GetData(url);

            dynamic cardsObject = JObject.Parse(cardsData);

            return ClashRoyale.GetObjectsFromJson<Card>(cardsObject.items);
        }

        /// <summary>
        /// Gets information about currently known challenges.
        /// </summary>
        /// <returns>
        /// An array of the challenge objects.
        /// </returns>
        public static ChallengeChain[] GetCurrentChallenges()
        {
            string url;

            string challengesData;

            url = challengesBaseURL;
            challengesData = GetData(url);

            if (challengesData is null)
            {
                return null;
            }

            challengesData = "{\"items\":" + challengesData + "}";
            dynamic challengesObject = JObject.Parse(challengesData);

            return ClashRoyale.GetObjectsFromJson<ChallengeChain>(challengesObject.items);
        }
    }
}