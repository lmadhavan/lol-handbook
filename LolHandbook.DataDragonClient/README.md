# Data Dragon Client

[![NuGet badge](https://img.shields.io/nuget/v/LolHandbook.DataDragonClient)](https://www.nuget.org/packages/LolHandbook.DataDragonClient/)

.NET client library for Riot's [Data Dragon](https://developer.riotgames.com/docs/lol#data-dragon) API that provides access to information about champions and items in [League of Legends](https://www.leagueoflegends.com/). This library is a component of the [League Handbook](https://github.com/lmadhavan/lol-handbook) app but also available as a standalone [NuGet package](https://www.nuget.org/packages/LolHandbook.DataDragonClient/) that can be used in any .NET project.

**Disclaimer:** This library isn't endorsed by Riot Games and doesn't reflect the views or opinions of Riot Games or anyone officially involved in producing or managing League of Legends. League of Legends and Riot Games are trademarks or registered trademarks of Riot Games, Inc.

## Quickstart

```csharp
using LolHandbook.DataDragon;

IDataDragonClient client = new DataDragonClient("na");

// current patch version
string patchVersion = await client.GetPatchVersionAsync();

// champions
IDictionary<string, ChampionSummary> championSummaries = await client.GetChampionSummariesAsync();
ChampionSummary summary = championSummaries.Values.First(c => c.Name == "Annie");
ChampionDetail detail = await client.GetChampionDetailAsync(summary.Id);

// items
IDictionary<string, Item> items = await client.GetItemsAsync();

// summoner spells
IDictionary<string, SummonerSpell> summonerSpells = await client.GetSummonerSpellsAsync();
```

## Caching

Since game data does not change often (new patches are typically released once every two weeks), it is beneficial to cache this data locally. A caching implementation is provided that will cache all calls except `GetChampionDetailAsync`. There is no built-in expiration mechanism, but you can manually invalidate the cache if needed.

```csharp
var client = new CachingDataDragonClient("na");

// ... do stuff ...

// invalidate cache if you need to fetch new data
client.InvalidateCache();
```

## Advanced configuration

When creating the client, you can pass in a custom `RealmConfiguration` that specifies one or more of the parameters below (anything that is not specified will use the default):
* `Cdn` lets you override the default Data Dragon endpoint
* `PatchVersion` lets you fetch data for an older patch version
* `Language` lets you override the default language code for the realm

Example (specifying a patch version):
```csharp
var configuration = new RealmConfiguration("na") { PatchVersion = "12.1.1" };
var client = new DataDragonClient(configuration);
```
