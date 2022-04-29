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

In order to use the API, you need to obtain an [API key](https://developer.clashroyale.com/#/getting-started) and pass it to the `ClashRoyale` class using the `Key` property:
```
ClashRoyale.Key = "<your_key>";
```

Optionally, you can choose to use [RoyaleAPI proxy servers](https://docs.royaleapi.com/#/proxy) using the `UseProxyServers` property:
```
ClashRoyale.UseProxyServers = true;
```

### Player information
To get information about a player, use the `GetPlayerByTag` method:
```cs
Player player = ClashRoyale.GetPlayerByTag(tag:"#2PRQQVR88");
```
*Although in the official API it is divided into different requests, this information also contains the player's Battle log and upcoming Chests.*

### Clan information

#### By Tag
To get information about a particular Clan, use the `GetClanByTag` method:
```cs
Clan clan = ClashRoyale.GetClanByTag(tag: "#L2QCY2VC");
```

#### By properties
To get information about Clans searched by their properties, use the `GetClansBySearch` method:
```cs
Clan[] clans = ClashRoyale.GetClansBySearch(name: "HMaK", locationID: 57000070, minMembers: 35, maxMembers: 45, minScore: 30000);
```

*Although in the official API it is divided into different requests, this information also contains the Clan's current and previous River races.*

### Card information
To get information about all Cards, use the `GetAllCards` method:
```cs
Card[] cards = ClashRoyale.GetAllCards();
```

### Challenges information
To get information about currently known Challenges, use the `GetCurrentChallenges` method:
```cs
ChallengeChain[] challengeChains = ClashRoyale.GetCurrentChallenges();
```

## API coverage
The [latest realease](https://github.com/matousvolf/clash-royale-dotnet/releases/tag/v1.0.1) covers these parts of the official API:
- players
- Clans
- Cards
- Challenges

These parts are not covered yet:
- Tournaments
- locations

## Contact
If you encounter any bug or imperfection, please let me know by submitting an [issue](https://github.com/matousvolf/clash-royale-dotnet/issues).

With questions or anything else, send me an email to [matousvolfu@gmail.com](mailto:matousvolfu@gmail.com).

---

This material is unofficial and is not endorsed by Supercell. For more information see [Supercell's fan content policy](https://www.supercell.com/fan-content-policy).
