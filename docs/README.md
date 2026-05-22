# Instructions for Building Documentation

The documentation for the OsuNet library uses [DocFX][docfx-main].
Instructions for installing this tool can be found [here][docfx-installing].

> [!IMPORTANT]
> You must use DocFX version **2.78.5** for everything to work correctly.

1. Navigate to the root of the repository.
2. Build the docs using `docfx docs/docfx.json`. Add the `--serve`
 parameter to preview the site locally.

Please note that if you intend to target a specific version, ensure
that you have the correct version checked out.


## Additionally

Many thanks to the [Discord.NET][Discord.NET] project for the usage example


[docfx-main]: https://dotnet.github.io/docfx/
[docfx-installing]: https://dotnet.github.io/docfx/index.html
[Discord.NET]: https://github.com/discord-net/Discord.Net