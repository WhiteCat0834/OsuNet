# OsuNet

OsuNet is a library for the [Osu!API v1](https://github.com/ppy/osu-api/wiki)  
Documentation for this library: [link](https://github.com/WhiteCat0834/OsuNet/wiki)

> [!NOTE]
> The original repository belongs to Blackcat76iT


## Installation

```
PM> Install-Package OsuNet
```


## Usage Example

Before you can start using the library, you must obtain a [token](https://osu.ppy.sh/p/api/). You can also log in to your Osu account in advance.

**Example:**
```cs
using System;
using System.Linq;
using System.Net.Http;
using OsuNet;
using OsuNet.Models;
using OsuNet.Models.Options;

public class Program {
    private static readonly OsuApi api = new OsuApi("YOUR_TOKEN", new HttpClient());

    static async Task Main(string[] args) {
        Console.Write("Enter BeatmapId: ");
        string input = Console.ReadLine();

        if (!ulong.TryParse(input, out ulong beatmapId)) {
            Console.WriteLine("Error: Invalid BeatmapId. Please enter a valid positive integer.");
            return;
        }

        Beatmap beatmap = (await api.GetBeatmapsAsync(new GetBeatmapsOptions() {
            BeatmapId = beatmapId
        })).FirstOrDefault();

        if (beatmap is null) {
            Console.WriteLine("Beatmap not found.");
            return;
        }

        Console.WriteLine(beatmap.Title);
        Console.WriteLine(beatmap.GetThumbnail()); // Returns a link to the thumbnail of the beatmap.
    }
}
```


## License

[MIT license](LICENSE)


## Additionally

[![Dotnet Build](https://github.com/WhiteCat0834/OsuNet/actions/workflows/dotnet.yml/badge.svg)](https://github.com/WhiteCat0834/OsuNet/actions/workflows/dotnet.yml)
[![nuget](https://img.shields.io/nuget/vpre/OsuNet?style=plastic&cacheSeconds=86400)](https://www.nuget.org/packages/OsuNet)