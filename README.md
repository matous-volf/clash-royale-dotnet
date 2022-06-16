# Clash Royale .NET
An unofficial .NET wrapper for Supercell's [Clash Royale API](https://developer.clashroyale.com/).

## Installation
1. Install the [NuGet package](https://www.nuget.org/packages/ClashRoyaleDotNet).
2. Add the `ClashRoyaleAPI` namespace wherever you want to use it:

   ```cs
   using ClashRoyaleAPI;
   ```

## Usage
After [installing](#installation), you'll be able to reference the classes and methods.

In order to use the API, you need to create an instance of the `ClashRoyale` class. In the constructor, pass an [API key](https://developer.clashroyale.com/#/getting-started):
```cs
ClashRoyale clashRoyale = new(key:"<your_key>");
```

Optionally, you can choose to use [RoyaleAPI proxy servers](https://docs.royaleapi.com/#/proxy) with the second parameter:
```cs
ClashRoyale clashRoyale = new(key:"<your_key>", useProxyServers:true);
```

Both of these can be changed later by setting the `Key` and `UseProxyServers` properties.

### Player information
To get information about a player, use the `GetPlayerByTag` method:
```cs
Player player = clashRoyale.GetPlayerByTag(tag:"#2PRQQVR88");
```
*Although in the official API it is divided into different requests, this information also contains the player's Battle log and upcoming Chests.*

### Clan information

#### By Tag
To get information about a particular Clan, use the `GetClanByTag` method:
```cs
Clan clan = clashRoyale.GetClanByTag(tag: "#L2QCY2VC");
```
*Although in the official API it is divided into different requests, this information also contains the Clan's current and previous River races.*

#### By properties
To get information about Clans searched by their properties, use the `GetClansBySearch` method:
```cs
SearchResultClan[] clans = clashRoyale.GetClansBySearch(name: "HMaK", locationID: 57000070, minMembers: 35, maxMembers: 45, minScore: 30000);
```

### Card information
To get information about all Cards, use the `GetAllCards` method:
```cs
Card[] cards = clashRoyale.GetAllCards();
```

### Challenges information
To get information about currently known Challenges, use the `GetCurrentChallenges` method:
```cs
ChallengeChain[] challengeChains = clashRoyale.GetCurrentChallenges();
```

## API coverage
The [latest release](https://github.com/matousvolf/clash-royale-dotnet/releases/latest) covers these parts of the official API:
- players
- Clans
- Cards
- Challenges

These parts are not covered yet:
- Tournaments
- locations

## Known issues
Below are currently known problems this package has:
- Players' upcoming Chests don't include Royal Wild Chest. It seems Supercell only grants this information to [RoyaleAPI](https://royaleapi.com/).
- Challenges returned from the `GetCurrentChallenges` method have invalid end times. This is caused by a bug in the official API.

Due to the implementation in this package, both of these issues are going to be resolved the moment they get fixed in the official API.

## Contact
If you encounter any bug or imperfection, please let me know by submitting an [issue](https://github.com/matousvolf/clash-royale-dotnet/issues).

With questions or anything else, send me an email to [matousvolfu@gmail.com](mailto:matousvolfu@gmail.com).

---

This material is unofficial and is not endorsed by Supercell. For more information see [Supercell's fan content policy](https://www.supercell.com/fan-content-policy).
