# League Handbook

League Handbook is a [League of Legends](https://www.leagueoflegends.com/) reference app for Windows. It uses Riot's [Data Dragon](https://developer.riotgames.com/docs/lol#data-dragon) API to fetch champion and item information. It is written in C# and built on the Universal Windows Platform.

The latest release of League Handbook can be [installed from the Microsoft Store](https://www.microsoft.com/store/apps/9nblggh4w464?cid=readme). You can also build the source code using Visual Studio 2019 or higher.

## Project structure
League Handbook follows a typical MVVM architecture:
* **DataDragonClient** is the *model* layer that encapsulates the Data Dragon API. It is a standalone library that can be used by any .NET application to access LoL game data. Additional documentation for the client can be found [here](LolHandbook.DataDragonClient/README.md).
* **LolHandbook** is the *view* layer: it is the entry point for the application and contains the user interface which is built using XAML.
* **LolHandbook.ViewModels** is the *view-model* layer: it is responsible for filtering and formatting the raw data for display.
* **LolHandbook.BackgroundTasks** contains a background task that checks for new game patches and notifies the user.
